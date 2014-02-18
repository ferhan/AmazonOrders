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
 * Order List
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
    public class OrderList : AbstractMwsObject
    {

        private List<Order> _order;

        /// <summary>
        /// Gets and sets the Order property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Order")]
        public List<Order> Order
        {
            get
            {
                if(this._order == null)
                {
                    this._order = new List<Order>();
                }
                return this._order;
            }
            set { this._order = value; }
        }

        /// <summary>
        /// Sets the Order property.
        /// </summary>
        /// <param name="order">Order property.</param>
        /// <returns>this instance.</returns>
        public OrderList WithOrder(Order[] order)
        {
            this._order.AddRange(order);
            return this;
        }

        /// <summary>
        /// Checks if Order property is set.
        /// </summary>
        /// <returns>true if Order property is set.</returns>
        public bool IsSetOrder()
        {
            return this.Order.Count > 0;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _order = reader.ReadList<Order>("Order");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.WriteList("Order", _order);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2011-01-01", "OrderList", this);
        }

        public OrderList() : base()
        {
        }
    }
}
