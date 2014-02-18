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
 * Order Id List
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
    public class OrderIdList : AbstractMwsObject
    {

        private List<string> _id;

        /// <summary>
        /// Gets and sets the Id property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Id")]
        public List<string> Id
        {
            get
            {
                if(this._id == null)
                {
                    this._id = new List<string>();
                }
                return this._id;
            }
            set { this._id = value; }
        }

        /// <summary>
        /// Sets the Id property.
        /// </summary>
        /// <param name="id">Id property.</param>
        /// <returns>this instance.</returns>
        public OrderIdList WithId(string[] id)
        {
            this._id.AddRange(id);
            return this;
        }

        /// <summary>
        /// Checks if Id property is set.
        /// </summary>
        /// <returns>true if Id property is set.</returns>
        public bool IsSetId()
        {
            return this.Id.Count > 0;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _id = reader.ReadList<string>("Id");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.WriteList("Id", _id);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2011-01-01", "OrderIdList", this);
        }

        public OrderIdList() : base()
        {
        }
    }
}
