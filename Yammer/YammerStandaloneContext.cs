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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mammerla.YammerIntegration.Yammer
{
    /// <summary>
    /// Yammer context that can be used generically -- e.g., from command line applications -- to authenticate against Yammer.
    /// Currently, all this context will do is retrieve a token for a user from a database if it exists, so it assumes that the user has already signed
    /// in and retrieved a Yammer OAuth token in some other way -- e.g., ran a web page with a YammerControl on it.
    /// </summary>
    public class YammerStandaloneContext : YammerBaseContext
    {
        private String clientId;
        private String clientSecret;
        private AuthenticationResponse authenticationResponse;

        public override AuthenticationResponse AuthenticationResponse
        {
            get
            {
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
                return this.clientId;
            }
        }

        public String ClientSecret
        {
            get
            {
                return this.clientSecret;
            }
        }

        public String UserId { get; set; }

        public String AuthToken { get; set; }


        public void EnsureAuthenticated()
        {
            if (this.LoadAuthenticationResponseToken(this.UserId))
            {
                this.AuthToken = this.AuthenticationResponse.AccessToken.Token;
                return;
            }
        }
    }
}
