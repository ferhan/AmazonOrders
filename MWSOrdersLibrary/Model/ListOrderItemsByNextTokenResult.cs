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
 * List Order Items By Next Token Result
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
    public class ListOrderItemsByNextTokenResult : AbstractMwsObject
    {

        private string _nextToken;
        private string _amazonOrderId;
        private OrderItemList _orderItems;

        /// <summary>
        /// Gets and sets the NextToken property.
        /// </summary>
        [XmlElementAttribute(ElementName = "NextToken")]
        public string NextToken
        {
            get { return this._nextToken; }
            set { this._nextToken = value; }
        }

        /// <summary>
        /// Sets the NextToken property.
        /// </summary>
        /// <param name="nextToken">NextToken property.</param>
        /// <returns>this instance.</returns>
        public ListOrderItemsByNextTokenResult WithNextToken(string nextToken)
        {
            this._nextToken = nextToken;
            return this;
        }

        /// <summary>
        /// Checks if NextToken property is set.
        /// </summary>
        /// <returns>true if NextToken property is set.</returns>
        public bool IsSetNextToken()
        {
            return this._nextToken != null;
        }

        /// <summary>
        /// Gets and sets the AmazonOrderId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AmazonOrderId")]
        public string AmazonOrderId
        {
            get { return this._amazonOrderId; }
            set { this._amazonOrderId = value; }
        }

        /// <summary>
        /// Sets the AmazonOrderId property.
        /// </summary>
        /// <param name="amazonOrderId">AmazonOrderId property.</param>
        /// <returns>this instance.</returns>
        public ListOrderItemsByNextTokenResult WithAmazonOrderId(string amazonOrderId)
        {
            this._amazonOrderId = amazonOrderId;
            return this;
        }

        /// <summary>
        /// Checks if AmazonOrderId property is set.
        /// </summary>
        /// <returns>true if AmazonOrderId property is set.</returns>
        public bool IsSetAmazonOrderId()
        {
            return this._amazonOrderId != null;
        }

        /// <summary>
        /// Gets and sets the OrderItems property.
        /// </summary>
        [XmlElementAttribute(ElementName = "OrderItems")]
        public OrderItemList OrderItems
        {
            get { return this._orderItems; }
            set { this._orderItems = value; }
        }

        /// <summary>
        /// Sets the OrderItems property.
        /// </summary>
        /// <param name="orderItems">OrderItems property.</param>
        /// <returns>this instance.</returns>
        public ListOrderItemsByNextTokenResult WithOrderItems(OrderItemList orderItems)
        {
            this._orderItems = orderItems;
            return this;
        }

        /// <summary>
        /// Checks if OrderItems property is set.
        /// </summary>
        /// <returns>true if OrderItems property is set.</returns>
        public bool IsSetOrderItems()
        {
            return this._orderItems != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _nextToken = reader.Read<string>("NextToken");
            _amazonOrderId = reader.Read<string>("AmazonOrderId");
            _orderItems = reader.Read<OrderItemList>("OrderItems");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("NextToken", _nextToken);
            writer.Write("AmazonOrderId", _amazonOrderId);
            writer.Write("OrderItems", _orderItems);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2011-01-01", "ListOrderItemsByNextTokenResult", this);
        }

        public ListOrderItemsByNextTokenResult() : base()
        {
        }
    }
}
