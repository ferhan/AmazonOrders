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
 * Payment Execution Detail Item List
 * API Version: 2011-01-01
 * Library Version: 2013-11-01
 * Generated: Fri Nov 08 21:29:21 GMT 2013
 */


using System;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;
using MWSClientCsRuntime;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceWebServiceOrders.Model
{
    [XmlTypeAttribute(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01")]
    [XmlRootAttribute(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01", IsNullable = false)]
    public class PaymentExecutionDetailItemList : AbstractMwsObject
    {
        [Key]
        public int id { get; set; } 
        
        private List<PaymentExecutionDetailItem> _paymentExecutionDetailItem;

        /// <summary>
        /// Gets and sets the PaymentExecutionDetailItem property.
        /// </summary>
        [XmlElementAttribute(ElementName = "PaymentExecutionDetailItem")]
        public List<PaymentExecutionDetailItem> PaymentExecutionDetailItem
        {
            get
            {
                if(this._paymentExecutionDetailItem == null)
                {
                    this._paymentExecutionDetailItem = new List<PaymentExecutionDetailItem>();
                }
                return this._paymentExecutionDetailItem;
            }
            set { this._paymentExecutionDetailItem = value; }
        }

        /// <summary>
        /// Sets the PaymentExecutionDetailItem property.
        /// </summary>
        /// <param name="paymentExecutionDetailItem">PaymentExecutionDetailItem property.</param>
        /// <returns>this instance.</returns>
        public PaymentExecutionDetailItemList WithPaymentExecutionDetailItem(PaymentExecutionDetailItem[] paymentExecutionDetailItem)
        {
            this._paymentExecutionDetailItem.AddRange(paymentExecutionDetailItem);
            return this;
        }

        /// <summary>
        /// Checks if PaymentExecutionDetailItem property is set.
        /// </summary>
        /// <returns>true if PaymentExecutionDetailItem property is set.</returns>
        public bool IsSetPaymentExecutionDetailItem()
        {
            return this.PaymentExecutionDetailItem.Count > 0;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _paymentExecutionDetailItem = reader.ReadList<PaymentExecutionDetailItem>("PaymentExecutionDetailItem");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.WriteList("PaymentExecutionDetailItem", _paymentExecutionDetailItem);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2011-01-01", "PaymentExecutionDetailItemList", this);
        }

        public PaymentExecutionDetailItemList() : base()
        {
        }
    }
}
