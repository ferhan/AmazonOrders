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
 * Response Metadata
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
    public class ResponseMetadata : AbstractMwsObject
    {

        private string _requestId;

        /// <summary>
        /// Gets and sets the RequestId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "RequestId")]
        public string RequestId
        {
            get { return this._requestId; }
            set { this._requestId = value; }
        }

        /// <summary>
        /// Sets the RequestId property.
        /// </summary>
        /// <param name="requestId">RequestId property.</param>
        /// <returns>this instance.</returns>
        public ResponseMetadata WithRequestId(string requestId)
        {
            this._requestId = requestId;
            return this;
        }

        /// <summary>
        /// Checks if RequestId property is set.
        /// </summary>
        /// <returns>true if RequestId property is set.</returns>
        public bool IsSetRequestId()
        {
            return this._requestId != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _requestId = reader.Read<string>("RequestId");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("RequestId", _requestId);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2011-01-01", "ResponseMetadata", this);
        }

        public ResponseMetadata() : base()
        {
        }
    }
}
