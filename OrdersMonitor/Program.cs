using MarketplaceWebServiceOrders;
using MarketplaceWebServiceOrders.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;

namespace OrdersMonitor {

    /// <summary>
    /// Runnable sample code to demonstrate usage of the C# client.
    ///
    /// To use, import the client source as a console application,
    /// and mark this class as the startup object. Then, replace
    /// parameters below with sensible values and run.
    /// </summary>
    public class OrdersMonitorApp {

        public static DateTime DateTimeBegin = new DateTime(2000, 1, 1);
        public static string AccessKey;
        public static string SecretKey;
        public static string SellerId;
        public static MarketplaceIdList MarketplaceId = new MarketplaceIdList
        {
            Id = new List<string>(new[] { "ATVPDKIKX0DER" })
        };
        public static void Main(string[] args)
        {

            // The client application name
            const string appName = "OrderHistoryApp";

            // The client application version
            const string appVersion = "1.0";

            // The endpoint for region service and version (see developer guide)
            // ex: https://mws.amazonservices.com
            const string serviceUrl = "https://mws.amazonservices.com/Orders/2011-01-01";

            // Create a configuration object
            MarketplaceWebServiceOrdersConfig config = new MarketplaceWebServiceOrdersConfig { ServiceURL = serviceUrl };

            // Set other client connection configurations here if needed
            // Create the client itself
            MarketplaceWebServiceOrders.MarketplaceWebServiceOrders client = new MarketplaceWebServiceOrdersClient(AccessKey, SecretKey, appName, appVersion, config);

            OrdersMonitorApp ordersMonitorApp = new OrdersMonitorApp(client);

            try 
            {

                // response = sample.InvokeGetOrder();
                // response = sample.InvokeGetServiceStatus();
                // response = sample.InvokeListOrderItems();
                // response = sample.InvokeListOrderItemsByNextToken();

                DateTime createdAfterDefault = new DateTime(2010, 1, 1);
                DateTime createdBeforeDefault = DateTime.Now.AddMinutes(-5);

                using (var db = new OrderContext())
                {
                    // is this the first time ?
                    var query = from o in db.Orders orderby o.PurchaseDate descending select o;

                    if (query.Any())
                    {
                        Console.WriteLine("Results exist in database: " + query.Count());

                        // although we are using a nullable type, there is no way that we will get a record that has a 
                        // null PurchaseDate. So we are safe here.
                        DateTime? tempDate = query.First().PurchaseDate;
                        DateTime lastPurchase = DateTimeBegin;  // silly assignment so we cover the else case.
                        if (tempDate != null) {
                            lastPurchase = (DateTime)tempDate;
                        }

                        Console.WriteLine("Last order date is : " + lastPurchase);
                        
                        GetOrdersForTimeWindow(ordersMonitorApp, lastPurchase, createdBeforeDefault);
                    }
                    else
                    {
                        Console.WriteLine("No results exist. Fresh Database.");
                        
                        // get orders for the time window and save to the database
                        GetOrdersForTimeWindow(ordersMonitorApp, createdAfterDefault, createdBeforeDefault);
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void GetOrdersForTimeWindow(
            OrdersMonitorApp theApp, 
            DateTime createdAfter, 
            DateTime createdBefore
            )
        {
            try
            {
                IMWSResponse response;
                ListOrdersResponse listOrdersResponse = null;
                ListOrdersByNextTokenResponse listOrdersByNextTokenResponse = null;
                string nextTokenFromRequest = null;
                OrderList ordersFromRequest;

                do
                {
                    // if this is not the first request, get the rest of the request.
                    if (nextTokenFromRequest != null)
                    {
                        Console.WriteLine("Get the next of the data");
                        response = theApp.InvokeListOrdersByNextToken(nextTokenFromRequest);

                        listOrdersByNextTokenResponse = (ListOrdersByNextTokenResponse)response;

                        nextTokenFromRequest = listOrdersByNextTokenResponse.ListOrdersByNextTokenResult.NextToken;
                        ordersFromRequest = listOrdersByNextTokenResponse.ListOrdersByNextTokenResult.Orders;

                    }
                    else
                    {
                        // we are making a request for the first time.
                        response = theApp.InvokeListOrders(createdAfter, createdBefore);

                        listOrdersResponse = (ListOrdersResponse)response;

                        nextTokenFromRequest = listOrdersResponse.ListOrdersResult.NextToken;
                        ordersFromRequest = listOrdersResponse.ListOrdersResult.Orders;
                    }

                    ResponseHeaderMetadata rhmd = response.ResponseHeaderMetadata;

                    // We recommend logging the request id and timestamp of every call.
                    Console.WriteLine("RequestId: " + rhmd.RequestId + "Timestamp: " + rhmd.Timestamp);

                    using (var db = new OrderContext())
                    {

                        foreach (Order order in ordersFromRequest.Order)
                        {
                            Console.WriteLine(order.AmazonOrderId + " " + order.PurchaseDate);
                            // is this order already in the database ?
                            var queryDuplicateCheck = from o in db.Orders
                                                      where o.AmazonOrderId == order.AmazonOrderId
                                                      select o;

                            if (!queryDuplicateCheck.Any() && order.ShippingAddress != null)
                            {
                                db.Orders.Add(order);
                            }
                        }

                        db.SaveChanges();
                    }

                    Thread.Sleep(30000);

                } while (nextTokenFromRequest != null);
            }
            catch (MarketplaceWebServiceOrdersException ex)
            {
                // Exception properties are important for diagnostics.
                ResponseHeaderMetadata rhmd = ex.ResponseHeaderMetadata;
                Console.WriteLine("Service Exception:");
                if (rhmd != null)
                {
                    Console.WriteLine("RequestId: " + rhmd.RequestId);
                    Console.WriteLine("Timestamp: " + rhmd.Timestamp);
                }
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("StatusCode: " + ex.StatusCode);
                Console.WriteLine("ErrorCode: " + ex.ErrorCode);
                Console.WriteLine("ErrorType: " + ex.ErrorType);
            }

        }

        private readonly MarketplaceWebServiceOrders.MarketplaceWebServiceOrders _client;

        public OrdersMonitorApp(MarketplaceWebServiceOrders.MarketplaceWebServiceOrders client)
        {
            _client = client;
        }

        public GetOrderResponse InvokeGetOrder()
        {
            // Create a request.
            GetOrderRequest request = new GetOrderRequest();
            request.SellerId = SellerId;
            OrderIdList amazonOrderId = new OrderIdList();
            request.AmazonOrderId = amazonOrderId;
            return _client.GetOrder(request);
        }

        public GetServiceStatusResponse InvokeGetServiceStatus()
        {
            // Create a request.
            GetServiceStatusRequest request = new GetServiceStatusRequest();
            request.SellerId = SellerId;
            return _client.GetServiceStatus(request);
        }

        public ListOrderItemsResponse InvokeListOrderItems()
        {
            // Create a request.
            ListOrderItemsRequest request = new ListOrderItemsRequest();
            request.SellerId = SellerId;
            const string amazonOrderId = "example";
            request.AmazonOrderId = amazonOrderId;
            return _client.ListOrderItems(request);
        }

        public ListOrderItemsByNextTokenResponse InvokeListOrderItemsByNextToken()
        {
            // Create a request.
            ListOrderItemsByNextTokenRequest request = new ListOrderItemsByNextTokenRequest();
            request.SellerId = SellerId;
            const string nextToken = "example";
            request.NextToken = nextToken;
            return _client.ListOrderItemsByNextToken(request);
        }

        public ListOrdersResponse InvokeListOrders(DateTime createdAfter, DateTime createdBefore)
        {
            // Create a request.
            ListOrdersRequest request = new ListOrdersRequest();
            request.SellerId = SellerId;
            request.CreatedAfter = createdAfter;
            request.CreatedBefore = createdBefore;
            //DateTime lastUpdatedAfter = new DateTime();
            //request.LastUpdatedAfter = lastUpdatedAfter;
            //DateTime lastUpdatedBefore = new DateTime();
            //request.LastUpdatedBefore = lastUpdatedBefore;
            OrderStatusList orderStatus = new OrderStatusList();
            request.OrderStatus = orderStatus;

            request.MarketplaceId = MarketplaceId;
            FulfillmentChannelList fulfillmentChannel = new FulfillmentChannelList();
            request.FulfillmentChannel = fulfillmentChannel;
            PaymentMethodList paymentMethod = new PaymentMethodList();
            request.PaymentMethod = paymentMethod;
            //string buyerEmail = "example";
            //request.BuyerEmail = buyerEmail;
            //string sellerOrderId = "example";
            //request.SellerOrderId = sellerOrderId;
            const decimal maxResultsPerPage = 100;
            request.MaxResultsPerPage = maxResultsPerPage;
            TFMShipmentStatusList tfmShipmentStatus = new TFMShipmentStatusList();
            request.TFMShipmentStatus = tfmShipmentStatus;

            return _client.ListOrders(request);
        }

        public ListOrdersByNextTokenResponse InvokeListOrdersByNextToken(string nextToken)
        {
            // Create a request.
            ListOrdersByNextTokenRequest request = new ListOrdersByNextTokenRequest();
            request.SellerId = SellerId;
            request.NextToken = nextToken;
            return _client.ListOrdersByNextToken(request);
        }
    }
}
