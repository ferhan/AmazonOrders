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
 * Promotion Id List
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
    public class PromotionIdList : AbstractMwsObject
    {

        private List<string> _promotionId;

        /// <summary>
        /// Gets and sets the PromotionId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "PromotionId")]
        public List<string> PromotionId
        {
            get
            {
                if(this._promotionId == null)
                {
                    this._promotionId = new List<string>();
                }
                return this._promotionId;
            }
            set { this._promotionId = value; }
        }

        /// <summary>
        /// Sets the PromotionId property.
        /// </summary>
        /// <param name="promotionId">PromotionId property.</param>
        /// <returns>this instance.</returns>
        public PromotionIdList WithPromotionId(string[] promotionId)
        {
            this._promotionId.AddRange(promotionId);
            return this;
        }

        /// <summary>
        /// Checks if PromotionId property is set.
        /// </summary>
        /// <returns>true if PromotionId property is set.</returns>
        public bool IsSetPromotionId()
        {
            return this.PromotionId.Count > 0;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _promotionId = reader.ReadList<string>("PromotionId");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.WriteList("PromotionId", _promotionId);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2011-01-01", "PromotionIdList", this);
        }

        public PromotionIdList() : base()
        {
        }
    }
}
