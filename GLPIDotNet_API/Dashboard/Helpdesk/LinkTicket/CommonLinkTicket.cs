using System.Collections.Generic;
using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;

namespace GLPIDotNet_API.Dashboard.Helpdesk.LinkTicket
{
    public abstract class CommonLinkTicket
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("tickets_id")]
        public long IdTicket { get; set; }
        [JsonProperty("users_id")]
        public long IdUser { get; set; }
        [JsonProperty("links")]
        public List<Link> Links { get; set; }
    }
}