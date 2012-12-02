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
using mammerla.YammerIntegration.Yammer;

namespace mammerla.YammerIntegration.WebForms
{
    /// <summary>
    /// Simple control that displays a list of messages coming from Yammer.
    /// </summary>
    [ToolboxData("<{0}:MessageList runat=server></{0}:MessageList>")]
    public class MessageList: YammerControl, INamingContainer
    {

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
      }

        protected override void CreateChildControls()
        {
            MessageSet msgs = this.YammerContext.GetMessages(YammerEndPoint.MessagesAlgo);

            ListBox lb = new ListBox();
        
            foreach (Message m in msgs.Messages)
            {
                ListItem li = new ListItem();
                li.Text = m.Body.Rich;
                lb.Items.Add(li);
            }

            this.Controls.Add(lb);
        }
    }
}
