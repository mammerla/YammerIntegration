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
    public class User : YammerObject
    {
        /// <summary>
        /// Specifies a datetime when the user was created.
        /// </summary>
        [DataMember(Name="activated_at")]
        public DateTime? ActivatedAt { get; set; }

        /// <summary>
        /// Indicates whether the user is an administrator in the system.
        /// </summary>
        [DataMember(Name="admin")]
        public bool Admin { get; set; }

        /// <summary>
        /// Specifies the birth date of the user.
        /// </summary>
        [DataMember(Name="birth_date")]
        public string BirthDate { get; set; }

        /// <summary>
        /// Indicates whehter the user can create announcements.
        /// </summary>
        [DataMember(Name="can_broadcast")]
        public bool CanBroadcast { get; set; }

        /// <summary>
        /// Contains more details on how to reach the user.
        /// </summary>
        [DataMember(Name="contact")]
        public Contact Contact { get; set; }

        /// <summary>
        /// Indicates the self-reported department of the user.
        /// </summary>
        [DataMember(Name="department")]
        public string Department { get; set; }

        /// <summary>
        /// Indicates a set of expertise fields for the user.
        /// </summary>
        [DataMember(Name="expertise")]
        public string Expertise { get; set; }

        /// <summary>
        /// A set of external URLs listed for the user.
        /// </summary>
        [DataMember(Name="external_urls")]
        public List<string> ExternalUrls { get; set; }

        /// <summary>
        /// The first name of the user.
        /// </summary>
        [DataMember(Name="first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The full name of the user.
        /// </summary>
        [DataMember(Name="full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// A unique identifier for the user.
        /// </summary>
        [DataMember(Name="guid")]
        public string Guid { get; set; }

        /// <summary>
        /// An optional hire date for the user.
        /// </summary>
        [DataMember(Name="hire_date")]
        public DateTime? HireDate { get; set; }

        /// <summary>
        /// A long integer that specifies the ID of the user.
        /// </summary>
        [DataMember(Name="id")]
        public long Id { get; set; }

        /// <summary>
        /// A self-reported collection of interests from the user.
        /// </summary>
        [DataMember(Name="interests")]
        public string Interests { get; set; }

        /// <summary>
        /// The job title as entered by the user.
        /// </summary>
        [DataMember(Name="job_title")]
        public string JobTitle { get; set; }

        /// <summary>
        /// Names of the users' children.
        /// </summary>
        [DataMember(Name="kids_names")]
        public string KidsNames { get; set; }

        /// <summary>
        /// Last name of the user.
        /// </summary>
        [DataMember(Name="last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Reported general location of the user.
        /// </summary>
        [DataMember(Name="location")]
        public string Location { get; set; }

        /// <summary>
        /// URL to a picture of the user.
        /// </summary>
        [DataMember(Name="mugshot_url")]
        public string MugshotUrl { get; set; }

        /// <summary>
        /// Template for building arbitrarily sized pictures of a user.
        /// </summary>
        [DataMember(Name="mugshot_url_template")]
        public string MugshotUrlTemplate { get; set; }

        /// <summary>
        /// Name of a user.
        /// </summary>
        [DataMember(Name="name")]
        public string name { get; set; }

        /// <summary>
        /// A set of domains associated with the user.
        /// </summary>
        [DataMember(Name="network_domains")]
        public List<string> NetworkDomains { get; set; }

        /// <summary>
        /// An employment history for the user.
        /// </summary>
        [DataMember(Name="previous_companies")]
        public List<Employment> PreviousCompanies { get; set; }

        /// <summary>
        /// A set of schools representing the educational history of a user.
        /// </summary>
        [DataMember(Name="schools")]
        public List<School> Schools { get; set; }

        /// <summary>
        /// Additional settings specified for a user.
        /// </summary>
        [DataMember(Name="settings")]
        public Dictionary<string, string> Settings { get; set; }

        /// <summary>
        /// Indicates whether the "Ask for Picture" prompt is enabled.
        /// </summary>
        [DataMember(Name="show_ask_for_photo")]
        public bool ShowAskForPhoto { get; set; }

        /// <summary>
        /// Name of a users' significant other.
        /// </summary>
        [DataMember(Name="significant_other")]
        public string SignificantOther { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name="state")]
        public string State { get; set; }

        /// <summary>
        /// Various stats on the user.
        /// </summary>
        [DataMember(Name="stats")]
        public Stats Stats { get; set; }

        /// <summary>
        /// Specifies a summary of the user.
        /// </summary>
        [DataMember(Name="summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Preferred timezone of the user.
        /// </summary>
        [DataMember(Name="timezone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Type of the user.
        /// </summary>
        [DataMember(Name="type")]
        public string Type { get; set; }

        /// <summary>
        /// Url of the User.
        /// </summary>
        [DataMember(Name="url")]
        public string Url { get; set; }

        /// <summary>
        /// Indicates whether the user is a verified (fully trusted) administator.
        /// </summary>
        [DataMember(Name="verified_admin")]
        public bool VerifiedAdmin { get; set; }

        /// <summary>
        /// Indicates a friendly page where you can see more infromation about a user.
        /// </summary>
        [DataMember(Name="web_url")]
        public string WebUrl { get; set; }
    }
}