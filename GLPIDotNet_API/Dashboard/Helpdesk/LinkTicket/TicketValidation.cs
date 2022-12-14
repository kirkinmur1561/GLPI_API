using System;
using System.Collections.Generic;
using GLPIDotNet_API.Base;
using Newtonsoft.Json;
namespace GLPIDotNet_API.Dashboard.Helpdesk.LinkTicket
{
    public class TicketValidation:CommonLinkTicket
    {       
        [JsonProperty("entities_id")]
        public long IdEntity { get; set; }       
        [JsonProperty("users_id_validate")]
        public long IdUserValidate{ get; set; }
        [JsonProperty("comment_submission")]
        public string CommentSubmission { get; set; }
        [JsonProperty("comment_validation")]
        public string CommentValidation { get; set; }
        [JsonProperty("status")]
        public int? Status { get; set; }
        [JsonProperty("submission_date")]
        public DateTime? DateSubmission { get; set; } 
        [JsonProperty("validation_date")]
        public DateTime? DateValidation { get; set; }
        [JsonProperty("timeline_position")]
        public int? TimelinePosition { get; set; }        
    }
}
