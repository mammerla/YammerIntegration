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
    public class Network : YammerObject
    {
        /// <summary>
        /// Specifies whether the network is an external network ('community');
        /// </summary>
        [DataMember(Name="community")]
        public bool Community { get; set; }
 
        /// <summary>
        /// The date time a network was created at.
        /// </summary>
        [DataMember(Name="created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// The defined background color for the header of a network.
        /// </summary>
        [DataMember(Name="header_background_color")]
        public string HeaderBackgroundColor { get; set; }

        /// <summary>
        /// Defined text color for the header of a network.
        /// </summary>
        [DataMember(Name="header_text_color")]
        public string HeaderTextColor { get; set; }

        /// <summary>
        /// Long integer identifier of the network.
        /// </summary>
        [DataMember(Name="id")]
        public long Id { get; set; }

        /// <summary>
        /// Specifies whether the network has chat features enabled.
        /// </summary>
        [DataMember(Name="is_chat_enabled")]
        public bool IsChatEnabled { get; set; }

        /// <summary>
        /// Specifies whether the network has the ability to create groups.
        /// </summary>
        [DataMember(Name="is_group_enabled")]
        public bool IsGroupEnabled { get; set; }

        /// <summary>
        /// Indicates whether organization charts are enabled in the network.
        /// </summary>
        [DataMember(Name="is_org_chart_enabled")]
        public bool IsOrgChartEnabled { get; set; }

        /// <summary>
        /// A friendly name for the network.
        /// </summary>
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Indicates the background color of navigation elements in the site.
        /// </summary>
        [DataMember(Name="navigation_background_color")]
        public string NavigationBackgroundColor { get; set; }

        /// <summary>
        /// Indicates the color of text for navigation elements on the site.
        /// </summary>
        [DataMember(Name="navigation_text_color")]
        public string NavigationTextColor { get; set; }

        /// <summary>
        /// Indicates whether the network is paid or part of a free offering.
        /// </summary>
        [DataMember(Name="paid")]
        public bool Paid { get; set; }

        /// <summary>
        /// Specifies a permanent link to use to refer to the network.
        /// </summary>
        [DataMember(Name="permalink")]
        public string Permalink { get; set; }

        /// <summary>
        /// A set of additional profile fields that are specified for the network.
        /// </summary>
        [DataMember(Name="profile_fields_config")]
        public ProfileFields ProfileFields { get; set; }

        /// <summary>
        /// Indicates whether an upgrade banner 
        /// </summary>
        [DataMember(Name="show_upgrade_banner")]
        public bool ShowUpgradeBanner { get; set; }

        [DataMember(Name="type")]
        public string Type { get; set; }

        [DataMember(Name="web_url")]
        public string WebUrl { get; set; }
    }
}