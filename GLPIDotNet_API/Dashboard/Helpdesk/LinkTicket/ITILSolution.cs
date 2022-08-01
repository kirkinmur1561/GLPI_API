using GLPIDotNet_API.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Helpdesk.LinkTicket
{
    public class ITILSolution
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("itemtype")]
        public string ItemType { get; set; }
        [JsonProperty("items_id")]
        public long IdItems { get; set; }
        [JsonProperty("solutiontypes_id")]
        public long IdSolutionType { get; set; }
        [JsonProperty("solutiontype_name")]
        public string NameSolutionType { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("date_creation")]
        public DateTime? DateCreation { get; set; }
        [JsonProperty("date_mod")]
        public DateTime? DateMod { get; set; }
        [JsonProperty("date_approval")]
        public DateTime? DateApproval { get; set; }
        [JsonProperty("users_id")]
        public long IdUser { get; set; }
        [JsonProperty("user_name")]
        public string NameUser { get; set; }
        [JsonProperty("users_id_editor")]
        public long IdUserEditor { get; set; }
        [JsonProperty("users_id_approval")]
        public long IdUserApproval { get; set; }
        [JsonProperty("user_name_approval")]
        public string NameUserApproval { get; set; }
        [JsonProperty("status")]
        public int? Status { get; set; }
        [JsonProperty("itilfollowups_id")]
        public long? IdItilFollowUp { get; set; }
        [JsonProperty("links")]
        public List<Link> Links { get; set; }
    }
}
