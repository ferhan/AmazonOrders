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
 * Message List
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
    public class MessageList : AbstractMwsObject
    {

        private List<Message> _message;

        /// <summary>
        /// Gets and sets the Message property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Message")]
        public List<Message> Message
        {
            get
            {
                if(this._message == null)
                {
                    this._message = new List<Message>();
                }
                return this._message;
            }
            set { this._message = value; }
        }

        /// <summary>
        /// Sets the Message property.
        /// </summary>
        /// <param name="message">Message property.</param>
        /// <returns>this instance.</returns>
        public MessageList WithMessage(Message[] message)
        {
            this._message.AddRange(message);
            return this;
        }

        /// <summary>
        /// Checks if Message property is set.
        /// </summary>
        /// <returns>true if Message property is set.</returns>
        public bool IsSetMessage()
        {
            return this.Message.Count > 0;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _message = reader.ReadList<Message>("Message");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.WriteList("Message", _message);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2011-01-01", "MessageList", this);
        }

        public MessageList() : base()
        {
        }
    }
}
