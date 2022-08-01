using System.Collections.Generic;
using GLPIDotNet_API.Base;
using Newtonsoft.Json;
namespace GLPIDotNet_API.Dashboard.Helpdesk.LinkTicket
{
    public class TicketUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("tickets_id")]
        public long IdTicket { get; set; }
        [JsonProperty("users_id")]
        public long IdUser { get; set; }
        [JsonProperty("type")]
        public long IdType { get; set; }
        [JsonProperty("use_notification")]
        public long IdUseNotification{ get; set; }
        [JsonProperty("alternative_email")]
        public string Email { get; set; }
        [JsonProperty("links")]
        public List<Link> Links { get; set; }

    }
}
