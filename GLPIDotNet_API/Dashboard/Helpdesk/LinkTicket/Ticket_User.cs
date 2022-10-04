using System.Collections.Generic;
using GLPIDotNet_API.Base;
using Newtonsoft.Json;
namespace GLPIDotNet_API.Dashboard.Helpdesk.LinkTicket
{
    public class TicketUser:CommonLinkTicket
    {        
        [JsonProperty("type")]
        public long IdType { get; set; }
        [JsonProperty("use_notification")]
        public long IdUseNotification{ get; set; }
        [JsonProperty("alternative_email")]
        public string Email { get; set; }

    }
}
