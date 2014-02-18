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
 * Order Item List
 * API Version: 2011-01-01
 * Library Version: 2013-11-01
 * Generated: Fri Nov 08 21:29:21 GMT 2013
 */


using System;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;
using MWSClientCsRuntime;

namespace MarketplaceWebServiceOrders.Model
{
    [XmlTypeAttribute(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01")]
    [XmlRootAttribute(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01", IsNullable = false)]
    public class OrderItemList : AbstractMwsObject
    {

        private List<OrderItem> _orderItem;

        /// <summary>
        /// Gets and sets the OrderItem property.
        /// </summary>
        [XmlElementAttribute(ElementName = "OrderItem")]
        public List<OrderItem> OrderItem
        {
            get
            {
                if(this._orderItem == null)
                {
                    this._orderItem = new List<OrderItem>();
                }
                return this._orderItem;
            }
            set { this._orderItem = value; }
        }

        /// <summary>
        /// Sets the OrderItem property.
        /// </summary>
        /// <param name="orderItem">OrderItem property.</param>
        /// <returns>this instance.</returns>
        public OrderItemList WithOrderItem(OrderItem[] orderItem)
        {
            this._orderItem.AddRange(orderItem);
            return this;
        }

        /// <summary>
        /// Checks if OrderItem property is set.
        /// </summary>
        /// <returns>true if OrderItem property is set.</returns>
        public bool IsSetOrderItem()
        {
            return this.OrderItem.Count > 0;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _orderItem = reader.ReadList<OrderItem>("OrderItem");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.WriteList("OrderItem", _orderItem);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2011-01-01", "OrderItemList", this);
        }

        public OrderItemList() : base()
        {
        }
    }
}
