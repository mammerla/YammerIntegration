/*
Copyright (c) Microsoft Corporation
All rights reserved.
Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the 
License at http://www.apache.org/licenses/LICENSE-2.0 
    
THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING 
WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.
*/


using mammerla.ServerIntegration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mammerla.YammerIntegration.Yammer
{
    public abstract class YammerBaseContext
    {
        private const string YammerOAuthUrl = "https://www.yammer.com/dialog/oauth?client_id={0}&redirect_uri={1}";
        private const string YammerOAuthValidatorUrl = " https://www.yammer.com/oauth2/access_token.json?client_id={0}&client_secret={1}&code={2}";
        private DataContractJsonSerializerSettings settings;
        private EntityTokenManager tokenManager;
        private bool persistTokensInDatabase = true;

        public bool PersistTokensInDatabase
        {
            get
            {
                return this.persistTokensInDatabase;
            }

            set
            {
                this.persistTokensInDatabase = value;
            }
        }

        public abstract AuthenticationResponse AuthenticationResponse { get; set;  }

        public String AuthenticationResponseAsString
        {
            get
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AuthenticationResponse), this.Settings);

                MemoryStream ms = new MemoryStream();

                serializer.WriteObject(ms, this.AuthenticationResponse);

                return UTF8Encoding.UTF8.GetString(ms.GetBuffer());
  
            }

            set
            {
                String content = value.Replace("\\/", "/");

                content = content.Replace("\0", "");

                using (MemoryStream ms = new MemoryStream(UTF8Encoding.UTF8.GetBytes(content)))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AuthenticationResponse), this.Settings);

                    this.AuthenticationResponse = serializer.ReadObject(ms) as AuthenticationResponse;

                    this.InitializeAuthenticationResponse(this.AuthenticationResponse);
                }
            }
        }

        internal DataContractJsonSerializerSettings Settings
        {
            get
            {
                if (this.settings != null)
                {
                    return this.settings;
                }

                this.settings = new DataContractJsonSerializerSettings();
                settings.DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat("yyyy/MM/dd HH:mm:ss \"+0000\"");

                return this.settings;
            }
        }

        public EntityTokenManager TokenManager
        {
            get
            {
                if (this.tokenManager == null)
                {
                    this.tokenManager = new EntityTokenManager();
                }

                return this.tokenManager;
            }
        }

        public void SaveAuthenticationResponseToken(String userId)
        {
            this.TokenManager.StoreNewToken(TokenType.AccessToken, TokenStoreType.Yammer, userId, this.AuthenticationResponse.AccessToken.Token, this.AuthenticationResponseAsString);
        }

        public bool LoadAuthenticationResponseToken(String userId)
        {
            String accessToken = null;
            String contextContent = null;

            if (this.TokenManager.GetAccessTokenAndContent(TokenStoreType.Yammer, userId, out accessToken, out contextContent))
            {
                this.AuthenticationResponseAsString = contextContent;
                
                return true;
            }

            return false;
        }

        public MessageSet GetMessages(YammerEndPoint endPoint)
        {
            return this.GetMessages(endPoint, MessageThreading.ThreadStarterOnly, null, null, null);
        }

        public MessageSet GetMessages(YammerEndPoint endPoint, MessageThreading threading, int? limit, int? olderThan, int? newerThan)
        {
            MessageSet msgs = null;

            YammerRequest yr = this.CreateRequest();

            yr.EndPoint = endPoint;
            yr.BeginInit();

            using (Stream s = yr.GetResponseStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MessageSet), this.Settings);

                msgs = serializer.ReadObject(s) as MessageSet;

                if (msgs != null)
                {
                    msgs.YammerContext = this;

                    foreach (Message m in msgs.Messages)
                    {
                        m.YammerContext = this;
                    }
                }
            }

            return msgs;
        }

        public void PostMessage(String messageContent)
        {
            YammerRequest yr = this.CreateRequest();

            yr.EndPoint = YammerEndPoint.Messages;

            String contentString = @"
{
  ""body"": """ + messageContent + @"""                
}
";
            yr.Method = "POST";
            yr.ContentType = "application/json";
            yr.BeginInit();

            Stream content = yr.GetRequestStream();

            using (StreamWriter sw = new StreamWriter(content))
            {
                sw.Write(contentString);
            }

            Stream responseStream = yr.GetResponseStream();
          
            StreamReader sr = new StreamReader(responseStream);
            
            String body = sr.ReadToEnd();
        }

        public void PostActivity(Activity activity)
        {
            YammerRequest yr = this.CreateRequest();

            yr.EndPoint = YammerEndPoint.Activity;

            ActivityUpdate au = new ActivityUpdate();
            au.Activity = activity;

            yr.Method = "POST";
            yr.ContentType = "application/json";
            yr.BeginInit();

            Stream content = yr.GetRequestStream();

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ActivityUpdate), this.Settings);

            serializer.WriteObject(content, au);

     

            Stream responseStream = yr.GetResponseStream();

            StreamReader sr = new StreamReader(responseStream);

            String body = sr.ReadToEnd();
        }

        public YammerRequest CreateRequest()
        {
            YammerRequest yr = new YammerRequest(this);

            return yr;
        }

        protected void InitializeAuthenticationResponse(AuthenticationResponse response)
        {
            response.AccessToken.YammerContext = this;
            response.Network.YammerContext = this;
            response.User.YammerContext = this;
        }

        public void InitializeWebRequest(HttpWebRequest webRequest)
        {
            if (this.AuthenticationResponse == null)
            {
                throw new InvalidOperationException("Not authorized");
            }

            webRequest.Headers.Add("Authorization", "Bearer " + this.AuthenticationResponse.AccessToken.Token);
        }
    }
}
