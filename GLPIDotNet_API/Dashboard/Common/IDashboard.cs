using GLPIDotNet_API.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Base.GLPI;
using GLPIDotNet_API.Base.Request;
using GLPIDotNet_API.Dashboard.Administration;
using GLPIDotNet_API.Dashboard.Administration.User;
using GLPIDotNet_API.Dashboard.Assets.LinkComputer;
using GLPIDotNet_API.Exception;

namespace GLPIDotNet_API.Dashboard.Common
{
    public interface IDashboard:IEquatable<IDashboard>
    {        
        [JsonProperty("id")]
        long? Id { get; set; }

        [JsonProperty("entities_id")]
        long? IdEntity { get; set; }

        [JsonProperty("is_recursive")]
        bool? IsRecursive { get; set; }

        [JsonProperty("name")]
        string Name { get; set; }

        [JsonProperty("comment")]
        string Comment { get; set; }

        [JsonProperty("locations_id")]
        long? IdLocation { get; set; }

        [JsonProperty("users_id_tech")]
        long? IdUsersTech { get; set; }

        [JsonProperty("groups_id_tech")]
        long? IdGroupsTech { get; set; }

        [JsonProperty("manufacturers_id")]
        long? IdManufacturer { get; set; }

        [JsonProperty("is_deleted")]
        bool? IsDeleted { get; set; }

        [JsonProperty("is_template")]
        bool? IsTemplate { get; set; }

        [JsonProperty("template_name")]
        string TemplateName { get; set; }

        [JsonProperty("date_mod")]
        DateTime? DateMod { get; set; }

        [JsonProperty("users_id")]
        long? IdUser { get; set; }

        [JsonProperty("groups_id")]
        long? IdGroup { get; set; }

        [JsonProperty("ticket_tco")]
        double? TicketTco { get; set; }

        [JsonProperty("date_creation")]
        DateTime? DateCreation { get; set; }

        [JsonProperty("links")]
        List<Link> Links { get; set; }
        
        [JsonIgnore]
        User User { get; set; }
        
        [JsonIgnore]
        Group Group { get; set; }
        
        [JsonIgnore]
        Manufacturer Manufacturer { get; set; }
        
        [JsonIgnore]
        Location Location { get; set; }
        
        [JsonIgnore]
        Entity Entity { get; set; }        
        
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        Dictionary<string,object> ChangeProperty { get; }

        
    }
}
