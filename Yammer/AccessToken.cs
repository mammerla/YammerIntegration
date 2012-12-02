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
    public class AccessToken : YammerObject
    {
        /// <summary>
        /// The time that the access token was authorized at.
        /// </summary>
        [DataMember(Name = "authorized_at")]
        public DateTime AuthorizedAt { get; set; }

        /// <summary>
        /// Time when the access token was created.
        /// </summary>
        [DataMember(Name = "created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Time when the access token expires.
        /// </summary>
        [DataMember(Name = "expires_at")]
        public DateTime? ExpiresAt { get; set; }

        [DataMember(Name = "modify_messages")]
        public bool ModifyMessages { get; set; }

        [DataMember(Name = "modify_subscriptions")]
        public bool ModifySubscriptions { get; set; }

        [DataMember(Name = "network_id")]
        public int NetworkId { get; set; }

        [DataMember(Name = "network_name")]
        public string NetworkName { get; set; }

        [DataMember(Name = "network_permalink")]
        public string NetworkPermalink { get; set; }

        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "user_id")]
        public long UserId { get; set; }

        [DataMember(Name = "view_groups")]
        public bool ViewGroups { get; set; }

        [DataMember(Name = "view_members")]
        public bool ViewMembers { get; set; }

        [DataMember(Name = "view_messages")]
        public bool ViewMessages { get; set; }

        [DataMember(Name = "view_subscriptions")]
        public bool ViewSubscriptions { get; set; }

        [DataMember(Name = "view_tags")]
        public bool ViewTags { get; set; }
    }
}