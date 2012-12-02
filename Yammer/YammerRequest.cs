/*
Copyright (c) Microsoft Corporation
All rights reserved.
Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the 
License at http://www.apache.org/licenses/LICENSE-2.0 
    
THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING 
WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace mammerla.YammerIntegration.Yammer
{
    public class YammerRequest
    {
        private String yammerUrlBase = "https://www.yammer.com/";
        private String yammerApiToken = "api";
        private String yammerVersionToken = "v1";
        private YammerEndPoint endPoint;
        private YammerBaseContext context;
        private HttpWebRequest hwr;

        public String Method { get; set; }
        public String ContentType { get; set; }

        public String YammerUrlBase
        {
            get
            {
                return this.yammerUrlBase;
            }

            set
            {
                this.yammerUrlBase = value;
            }
        }

        public YammerEndPoint EndPoint
        {
            get
            {
                return endPoint;
            }

            set
            {
                this.endPoint = value;
            }
        }

        /// <summary>
        /// Returns a segment for an endpoint given its identifier.
        /// </summary>
        public String EndPointUrlSegment
        {
            get
            {
                switch (this.endPoint)
                {
                    case YammerEndPoint.MessagesFollowing:
                        return "messages/following";

                    case YammerEndPoint.Activity:
                        return "activity";

                    case YammerEndPoint.Messages:
                        return "messages";

                    case YammerEndPoint.MessagesMyFeed:
                        return "messages/my_feed";

                    case YammerEndPoint.MessagesAlgo:
                        return "messages/algo";

                    case YammerEndPoint.MessagesSent:
                        return "messages/sent";

                    case YammerEndPoint.MessagesReceived:
                        return "messages/received";

                    case YammerEndPoint.MessagesPrivate:
                        return "messages/private";

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public YammerRequest(YammerBaseContext context)
        {
            this.context = context;
        }

        public String BuildUrl()
        {
            String url = yammerUrlBase + yammerApiToken + "/" + yammerVersionToken + "/";

            url += this.EndPointUrlSegment+ ".json";

            return url;
        }

        public void BeginInit()
        {
            this.Initialize(null);
        }

        public void Initialize(String parameters)
        {
            String url = BuildUrl();

            if (parameters != null)
            {
                url += "?" + parameters;
            }

            this.hwr = WebRequest.CreateHttp(url);

            this.context.InitializeWebRequest(this.hwr);

            if (this.Method != null)
            {
                this.hwr.Method = this.Method;
            }

            if (this.ContentType != null)
            {
                this.hwr.ContentType = this.ContentType;
            }

        }

        public Stream GetRequestStream()
        {
            return this.hwr.GetRequestStream();
        }

        public Stream GetResponseStream()
        {
            HttpWebResponse wr = this.hwr.GetResponse() as HttpWebResponse;

            return wr.GetResponseStream();
        }
    }
}