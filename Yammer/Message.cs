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
    public class Message : YammerObject
    {
        [DataMember(Name = "attachments")]
        public String Attachments { get; set; }

        /// <summary>
        /// Contents of the message in various formats.
        /// </summary>
        [DataMember(Name = "body")]
        public MessageBody Body { get; set; }

        /// <summary>
        /// An integer identifier placeholder for message orders, as used by chat clients.
        /// </summary>
        [DataMember(Name = "chat_client_sequence")]
        public long? ChatClientSequence { get; set; }

        /// <summary>
        /// Indicates the type of client that may have created this message.
        /// </summary>
        [DataMember(Name = "client_type")]
        public String ClientType { get; set; }

        /// <summary>
        /// Indicates the URL of a client appication that may have created this message.
        /// </summary>
        [DataMember(Name = "client_url")]
        public String ClientUrl { get; set; }

        /// <summary>
        /// Indicates a time when the message was created.
        /// </summary>
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Whether the message is a direct message from one user to another.
        /// </summary>
        [DataMember(Name = "direct_message")]
        public bool DirectMessage { get; set; }

        /// <summary>
        /// Unique identifier of the message within Yammer.
        /// </summary>
        [DataMember(Name = "id")]
        public long Id { get; set; }

        /// <summary>
        /// Indicates a collection of users that have liked a particular message.
        /// </summary>
        [DataMember(Name = "liked_by")]
        public UserList LikedBy { get; set; }

        /// <summary>
        /// Type of the message.
        /// </summary>
        [DataMember(Name = "message_type")]
        public String MessageType { get; set; }

        /// <summary>
        /// Indicates which network this message is within.
        /// </summary>
        [DataMember(Name = "network_id")]
        public long NetworkId { get; set; }

        /// <summary>
        /// Indicates the privacy status of the message.
        /// </summary>
        [DataMember(Name = "privacy")]
        public String Privacy { get; set; }

        [DataMember(Name = "replied_to_id")]
        public long? RepliedToId { get; set; }

        [DataMember(Name = "sender_id")]
        public long SenderId { get; set; }

        /// <summary>
        /// Type of sender that created this message.
        /// </summary>
        public SenderType SenderType { get; set; }

        [DataMember(Name = "sender_type")]
        public String SenderTypeString
        {
            get
            {
                return this.SenderType.ToString().ToLower();
            }

            set
            {
                switch (value.ToLower())
                {
                    case "user":
                        this.SenderType = Yammer.SenderType.User;
                        break;
                        
                    case "announcement":
                        this.SenderType = Yammer.SenderType.Announcement;
                        break;

                    case "bot":
                        this.SenderType = Yammer.SenderType.Bot;
                        break;

                    case "chat":
                        this.SenderType = Yammer.SenderType.Chat;
                        break;

                    case "guide":
                        this.SenderType = Yammer.SenderType.Guide;
                        break;
                }
            }
        }

        /// <summary>
        /// Indicates whether the message is a system message.
        /// </summary>
        [DataMember(Name = "system_message")]
        public bool SystemMessage { get; set; }

        /// <summary>
        /// Indicates the identifier of the thread that this message is a part of.
        /// </summary>
        [DataMember(Name = "thread_id")]
        public long ThreadId { get; set; }

        /// <summary>
        /// Indicates the API Url that you can access the message from.
        /// </summary>
        [DataMember(Name = "url")]
        public String Url { get; set; }

        /// <summary>
        /// Indicates the user-facing page that hosts this message.
        /// </summary>
        [DataMember(Name = "web_url")]
        public String WebUrl { get; set; }
    }
}