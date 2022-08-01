using System;
using System.Collections.Generic;
using GLPIDotNet_API.Base;
using Newtonsoft.Json;
namespace GLPIDotNet_API.Dashboard.Helpdesk.LinkTicket
{
    public class ITILFollowup
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("itemtype")]
        public string ItemType { get; set; }
        [JsonProperty("items_id")]
        public long IdItems { get; set; }
        [JsonProperty("date")]
        public DateTime? Date { get; set; }
        [JsonProperty("users_id")]
        public long IdUser { get; set; }
        [JsonProperty("users_id_editor")]
        public long IdUserEditor { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }
        [JsonProperty("requesttypes_id")]
        public long IdRequestType { get; set; }
        [JsonProperty("date_mod")]
        public DateTime? DateMod { get; set; }
        [JsonProperty("date_creation")]
        public DateTime? DateCreation { get; set; }
        [JsonProperty("timeline_position")]
        public int TimeLinePosition { get; set; }
        [JsonProperty("sourceitems_id")]
        public long IdSourceItem { get; set; }
        [JsonProperty("sourceof_items_id")]
        public long IdSourceOfItem { get; set; }
        [JsonProperty("links")]
        public List<Link> Links { get; set; }
    }
}
