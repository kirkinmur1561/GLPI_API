using System;
using System.Collections.Generic;
using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;
namespace GLPIDotNet_API.Dashboard.Administration
{
    public class ITILCategory : Dashboard<ITILCategory>, IEquatable<ITILCategory>
    {
        public ITILCategory()
        {

        }

        [JsonProperty("itilcategories_id")]
        public string IdItilCategory { get; set; }

        [JsonProperty("knowbaseitemcategories_")]
        public long? IdKnowBaseItemCategory { get; set; }

        [JsonProperty("level")]
        public int? Level { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("ancestors_cache")]
        public string AncestorsCache { get; set; }

        [JsonProperty("sons_cache")]
        public string SonsCache { get; set; }

        [JsonProperty("is_helpdeskvisible")]
        public bool? IsHelpDeskVisible { get; set; }

        [JsonProperty("tickettemplates_id_incident")]
        public string IdTicketTemplatesIncident { get; set; }

        [JsonProperty("tickettemplates_id_demand")]
        public string IdTicketTemplatesDemand { get; set; }

        [JsonProperty("changetemplates_id")]
        public string IdChangeTemplates { get; set; }

        [JsonProperty("problemtemplates_id")]
        public string IdProblemTemplates { get; set; }

        [JsonProperty("is_incident")]
        public bool? IsIncident { get; set; }

        [JsonProperty("is_request")]
        public bool? IsRequest { get; set; }

        [JsonProperty("is_problem")]
        public bool? IsProblem { get; set; }

        [JsonProperty("is_change")]
        public bool? IsChange { get; set; }

        public bool Equals(ITILCategory other) =>
            GetHashCode() == other.GetHashCode();


        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(IdEntities);
            hash.Add(IsRecursive);
            hash.Add(Name);
            hash.Add(Comment);
            hash.Add(IdLocations);
            hash.Add(IdUsersTech);
            hash.Add(IdGroupsTech);
            hash.Add(IdManufacturers);
            hash.Add(IsDeleted);
            hash.Add(IsTemplate);
            hash.Add(TemplateName);
            hash.Add(DateMod);
            hash.Add(IdUsers);
            hash.Add(TicketTco);
            hash.Add(DateCreation);
            hash.Add(IdItilCategory);
            hash.Add(IdKnowBaseItemCategory);
            hash.Add(Level);
            hash.Add(Code);
            hash.Add(AncestorsCache);
            hash.Add(SonsCache);
            hash.Add(IsHelpDeskVisible);
            hash.Add(IdTicketTemplatesIncident);
            hash.Add(IdTicketTemplatesDemand);
            hash.Add(IdChangeTemplates);
            hash.Add(IdProblemTemplates);
            hash.Add(IsIncident);
            hash.Add(IsRequest);
            hash.Add(IsProblem);
            hash.Add(IsChange);
            return hash.ToHashCode();
        }

        public static bool operator ==(ITILCategory left, ITILCategory right)
        {
            return EqualityComparer<ITILCategory>.Default.Equals(left, right);
        }

        public static bool operator !=(ITILCategory left, ITILCategory right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ITILCategory);
        }
    }
}
