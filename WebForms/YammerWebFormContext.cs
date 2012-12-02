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
using mammerla.YammerIntegration.Yammer;
using System.Configuration;

namespace mammerla.YammerIntegration.WebForms
{
    /// <summary>
    /// Leverages ASP.NET context to manage the process of logging into Yammer.
    /// </summary>
    public class YammerWebFormContext : YammerBaseContext
    {
        private const string YammerOAuthUrl = "https://www.yammer.com/dialog/oauth?client_id={0}&redirect_uri={1}";
        private const string YammerOAuthValidatorUrl = " https://www.yammer.com/oauth2/access_token.json?client_id={0}&client_secret={1}&code={2}";

        private AuthenticationResponse authenticationResponse;
        private DataContractJsonSerializerSettings settings;
        private HttpContext context;
        private bool forceRefreshToken = false;

        public bool ForceRefreshToken
        {
            get
            {
                return this.forceRefreshToken;
            }

            set
            {
                this.forceRefreshToken = value;
            }
        }

        public User User
        {
            get
            {
                if (this.AuthenticationResponse == null)
                {
                    return null;
                }

                return this.AuthenticationResponse.User;
            }
        }

        public Network Network
        {
            get
            {
                if (this.AuthenticationResponse == null)
                {
                    return null;
                }

                return this.AuthenticationResponse.Network;
            }

        }

        public override AuthenticationResponse AuthenticationResponse
        {
            get
            {
                // if we haven't gotten OAuth response content, then we can't provide anything here.
                if (this.authenticationResponse != null)
                {
                    return this.authenticationResponse;
                }

                // Have we received OAuth response content?  If so, hydrate an authentication response object.
                if (this.AuthenticationResponseSessionStorage != null)
                {
                    this.AuthenticationResponseAsString = this.AuthenticationResponseSessionStorage;
                }

                return this.authenticationResponse;
            }

            set
            {
                this.authenticationResponse = value;
            }
        }

        public String ClientId
        {
            get
            {
                return ConfigurationManager.AppSettings["YammerClientId"];
            }

        }

        public String ClientSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["YammerClientSecret"];
            }
                
        }

        public HttpContext Context
        {
            get
            {
                return this.context;
            }
            set
            {
                this.context = value;
            }
        }

        
        public String AuthenticationResponseSessionStorage
        {
            get
            {
                return this.Context.Session["YamOAuthAuthResponse"] as String;
            }
            set
            {
                this.Context.Session["YamOAuthAuthResponse"] = value;
            }
        }

        public String AccessCode
        {
            get
            {
                return this.Context.Session["YamOAuthAccessCode"] as String;
            }
            set
            {
                this.Context.Session["YamOAuthAccessCode"] = value;
            }
        }

        public String AuthToken
        {
            get
            {
                return this.Context.Session["YamOAuthToken"] as String;
            }
            set
            {
                this.Context.Session["YamOAuthToken"] = value;
            }
        }

        public bool AuthTokenIsError
        {
            get;
            set;
        }

        public void EnsureAuthenticated()
        {
            // is the authentication toek empty or in an error state?
            if (String.IsNullOrEmpty(this.AuthToken) || this.AuthTokenIsError)
            {
                String code = this.Context.Request["code"];

                if (code == null)
                {
                    String url = this.Context.Request.Url.ToString();

                    int lastCode = url.LastIndexOf("?code=");
                    if (lastCode > 0)
                    {
                        code = url.Substring(lastCode + 6);
                    }
                }
                // have we received an initial authenticate code from Yammer?  If so, validate it and use it.
                if (code != null)
                {
                    this.AccessCode = code as String;

                    // prepare to call Yammer to get a valid authentication token given our code & secret.
                    String url = String.Format(YammerOAuthValidatorUrl, this.ClientId, this.ClientSecret, this.AccessCode);

                    HttpWebRequest hwr = WebRequest.CreateHttp(url);

                    WebResponse wr = hwr.GetResponse();
 
                    using (Stream s = wr.GetResponseStream())
                    {
                        // deserialize the result.
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AuthenticationResponse), this.Settings);
 
                        this.authenticationResponse = serializer.ReadObject(s) as AuthenticationResponse;

                        this.InitializeAuthenticationResponse(this.authenticationResponse);

                        // if we have a valid result, so keep going.
                        if (this.authenticationResponse != null)
                        {
                            this.AuthTokenIsError = false;

                            // let's persist this in session state.
                            this.AuthenticationResponseSessionStorage = this.AuthenticationResponseAsString;
                            this.AuthToken = this.AuthenticationResponse.AccessToken.Token;

                            if (this.Context.User != null && this.PersistTokensInDatabase)
                            {
                                this.SaveAuthenticationResponseToken(this.Context.User.Identity.Name);
                            }
                        }
                    }
                }
                else
                {
                    // we don't seem to have an active token
                    if (this.Context.User != null && !this.AuthTokenIsError)
                    {
                        // can we load a token from the database for this user?
                        if (!this.ForceRefreshToken && this.LoadAuthenticationResponseToken(this.Context.User.Identity.Name) && this.PersistTokensInDatabase)
                        {
                            this.AuthenticationResponseSessionStorage = this.AuthenticationResponseAsString;
                            this.AuthToken = this.AuthenticationResponse.AccessToken.Token;

                            // great, we loaded a token, let's return.
                            return;
                        }
                    }

                    // no token available to us, so start the redirection process over to Yammer to kick off the OAuth flow.
                    String url = String.Format(YammerOAuthUrl, this.ClientId, this.Context.Request.Url);

                    this.Context.Response.Redirect(url);
                }
            }
        }
    }
}
