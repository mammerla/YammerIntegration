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
using System.Runtime.Serialization;
using System.Web;

namespace mammerla.YammerIntegration.Yammer
{
    [DataContract]
    public class Activity
    {
        [DataMember(Name="actor")]
        public Actor Actor { get; set; }

        [DataMember(Name="action")]
        public String Action { get; set; }

        [DataMember(Name = "private")]
        public bool Private { get; set; }

        [DataMember(Name = "message")]
        public String Message { get; set; }

        [DataMember(Name = "object")]
        public OpenGraphObject Object { get; set; }

        [DataMember(Name = "users")]
        public IList<Actor> Users { get; set; }

        public Activity()
        {
            this.Actor = new Actor();
            this.Users = new List<Actor>();
            this.Object = new OpenGraphObject();
        }
    }
}