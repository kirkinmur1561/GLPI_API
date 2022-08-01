using GLPIDotNet_API.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Common
{
    public interface IDashboard
    {
        [JsonProperty("id")]
        long? Id { get; set; }

        [JsonProperty("entities_id")]
        long? IdEntities { get; set; }

        [JsonProperty("is_recursive")]
        bool? IsRecursive { get; set; }

        [JsonProperty("name")]
        string Name { get; set; }

        [JsonProperty("comment")]
        string Comment { get; set; }

        [JsonProperty("locations_id")]
        long? IdLocations { get; set; }

        [JsonProperty("users_id_tech")]
        long? IdUsersTech { get; set; }

        [JsonProperty("groups_id_tech")]
        long? IdGroupsTech { get; set; }

        [JsonProperty("manufacturers_id")]
        long? IdManufacturers { get; set; }

        [JsonProperty("is_deleted")]
        bool? IsDeleted { get; set; }

        [JsonProperty("is_template")]
        bool? IsTemplate { get; set; }

        [JsonProperty("template_name")]
        string TemplateName { get; set; }

        [JsonProperty("date_mod")]
        DateTime? DateMod { get; set; }

        [JsonProperty("users_id")]
        long? IdUsers { get; set; }

        [JsonProperty("groups_id")]
        long? IdGroups { get; set; }

        [JsonProperty("ticket_tco")]
        double? TicketTco { get; set; }

        [JsonProperty("date_creation")]
        DateTime? DateCreation { get; set; }

        [JsonProperty("links")]
        List<Link> Links { get; set; }
       
    }
}
