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
    public enum SenderType
    {
        /// <summary>
        /// Indicates that the creator of a message is a standard user.
        /// </summary>
        [EnumMember(Value = "user")]
        User,

        /// <summary>
        /// Indicates that the message was created to help a user and community within Yammer, e.g., "Welcome to the network, John Doe"
        /// </summary>
        [EnumMember(Value = "guide")]
        Guide,

        /// <summary>
        /// Programmatically created messages, such as those created by an RSS or Twitter import.
        /// </summary>
        [EnumMember(Value = "bot")]
        Bot,

        /// <summary>
        /// Messages created via the chart feature.
        /// </summary>
        [EnumMember(Value = "chat")]
        Chat,

        /// <summary>
        /// Indicates that the message was created to server as an announcement.
        /// </summary>
        [EnumMember(Value = "announcement")]
        Announcement,

        /// <summary>
        /// System message created on behalf of a user, e.g., "John Doe created a group Foo".
        /// </summary>
        [EnumMember(Value = "system")]
        System
    }
}