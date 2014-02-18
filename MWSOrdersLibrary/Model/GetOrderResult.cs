/*******************************************************************************
 * Copyright 2009-2013 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Get Order Result
 * API Version: 2011-01-01
 * Library Version: 2013-11-01
 * Generated: Fri Nov 08 21:29:21 GMT 2013
 */


using System;
using System.Xml;
using System.Xml.Serialization;
using MWSClientCsRuntime;

namespace MarketplaceWebServiceOrders.Model
{
    [XmlTypeAttribute(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01")]
    [XmlRootAttribute(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01", IsNullable = false)]
    public class GetOrderResult : AbstractMwsObject
    {

        private OrderList _orders;

        /// <summary>
        /// Gets and sets the Orders property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Orders")]
        public OrderList Orders
        {
            get { return this._orders; }
            set { this._orders = value; }
        }

        /// <summary>
        /// Sets the Orders property.
        /// </summary>
        /// <param name="orders">Orders property.</param>
        /// <returns>this instance.</returns>
        public GetOrderResult WithOrders(OrderList orders)
        {
            this._orders = orders;
            return this;
        }

        /// <summary>
        /// Checks if Orders property is set.
        /// </summary>
        /// <returns>true if Orders property is set.</returns>
        public bool IsSetOrders()
        {
            return this._orders != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _orders = reader.Read<OrderList>("Orders");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("Orders", _orders);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2011-01-01", "GetOrderResult", this);
        }

        public GetOrderResult() : base()
        {
        }
    }
}
