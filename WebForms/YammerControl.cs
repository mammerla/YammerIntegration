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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mammerla.YammerIntegration.WebForms
{
    /// <summary>
    /// Base class control for any ASP.NET control that works with Yammer.  Manages a YammerWebFormContext object which has logic for
    /// authenticating against Yammer.
    /// </summary>
    public class YammerControl : Control
    {
        private YammerWebFormContext yammerContext;
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

        protected YammerWebFormContext YammerContext
        {
            get
            {
                return this.yammerContext;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.yammerContext = new YammerWebFormContext();

            this.yammerContext.Context = this.Context;
            this.yammerContext.PersistTokensInDatabase = this.PersistTokensInDatabase;
            this.yammerContext.EnsureAuthenticated();
        }
    }
}
