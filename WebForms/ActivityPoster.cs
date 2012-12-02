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
    /// A simple test control that lets you post a Yammer Activity for an object.
    /// NOTE: in order for you to see the activities you must post it using an e-mail address that is either your account in Yammer or someone you follow in Yammer
    /// Also, there must be at least a few activities (around 10) in order for the activity ticker to show up.
    /// </summary>
    [ToolboxData("<{0}:ActivityPoster runat=server></{0}:ActivityPoster>")]
    public class ActivityPoster : YammerControl, INamingContainer
    {
        private TextBox objectUrl;
        private TextBox objectTitle;
        private TextBox objectType;
        private TextBox objectImage;

        private TextBox actorName;
        private TextBox actorEmail;

        private TextBox message;
        private TextBox action;

        private Button postButton;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
      }

        protected override void CreateChildControls()
        {

            Table t = new Table();

            TableRow tr = new TableRow();
            t.Rows.Add(tr);

            TableCell td = new TableCell();
            tr.Cells.Add(td);

            Label l = new Label();
            l.Text = "Object URL:";
            td.Controls.Add(l);

            td = new TableCell();
            tr.Cells.Add(td);

            this.objectUrl = new TextBox();
            td.Controls.Add(this.objectUrl);

            tr = new TableRow();
            t.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);

            l = new Label();
            l.Text = "Object Type:";
            td.Controls.Add(l);

            td = new TableCell();
            tr.Cells.Add(td);

            this.objectType = new TextBox();
            td.Controls.Add(this.objectType);

            tr = new TableRow();
            t.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);

            l = new Label();
            l.Text = "Object Image:";
            td.Controls.Add(l);

            td = new TableCell();
            tr.Cells.Add(td);

            this.objectImage = new TextBox();
            td.Controls.Add(this.objectImage);

            tr = new TableRow();
            t.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);

            l = new Label();
            l.Text = "Object Title:";
           
            td.Controls.Add(l);

            td = new TableCell();
            tr.Cells.Add(td);

            this.objectTitle = new TextBox();
            td.Controls.Add(this.objectTitle);
            
            tr = new TableRow();
            t.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);


            l = new Label();
            l.Text = "Actor Name:";
            td.Controls.Add(l);

            td = new TableCell();
            tr.Cells.Add(td);


            this.actorName = new TextBox();
            td.Controls.Add(this.actorName);

            tr = new TableRow();
            t.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);

            l = new Label();
            l.Text = "Actor Email:";
            td.Controls.Add(l);

            td = new TableCell();
            tr.Cells.Add(td);

            this.actorEmail = new TextBox();
            td.Controls.Add(this.actorEmail);

            tr = new TableRow();
            t.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);

            l = new Label();
            l.Text = "Action:";
            td.Controls.Add(l);

            td = new TableCell();
            tr.Cells.Add(td);

            this.action = new TextBox();
            td.Controls.Add(this.action);

            tr = new TableRow();
            t.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);

            l = new Label();
            l.Text = "Message:";
            td.Controls.Add(l);

            td = new TableCell();
            tr.Cells.Add(td);


            this.message = new TextBox();
            td.Controls.Add(this.message);

            this.Controls.Add(t);

            this.postButton = new Button();
            this.postButton.ID = "testButton";
            this.postButton.UseSubmitBehavior = false;
            this.postButton.Text = "Post";
            this.postButton.Click += createPost_Click;
            this.Controls.Add(this.postButton);

            base.CreateChildControls();
        }

        private void createPost_Click(object sender, EventArgs e)
        {
            Activity a = new Activity();
            a.Actor.EMail = this.actorEmail.Text;
            a.Actor.Name = this.actorName.Text;
            a.Object.Url = this.objectUrl.Text;
            a.Object.Type = this.objectType.Text;
            a.Object.Image = this.objectImage.Text;
            a.Object.Title = this.objectTitle.Text;
            a.Action = this.action.Text;
            a.Message = this.message.Text;

            a.Users.Add(a.Actor);

            this.YammerContext.PostActivity(a);
        }
    }
}
