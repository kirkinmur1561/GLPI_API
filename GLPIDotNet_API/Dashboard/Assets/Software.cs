using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Assets
{
    public class Software : Dashboard<Software>, IEquatable<Software>
    {
        [JsonProperty("is_update")]
        public bool? IsUpdate { get; set; }

        [JsonProperty("softwares_id")]
        public long? IdSoftwares { get; set; }

        [JsonProperty("is_helpdesk_visible")]
        public bool? IsHelpdeskVisible { get; set; }

        [JsonProperty("softwarecategories_id")]
        public long? IdSoftwareCategories { get; set; }

        [JsonProperty("is_valid")]
        public bool? IsValid { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as Software);
        }

        public bool Equals(Software other)
        {
            return other != null &&
                   Id == other.Id &&
                   IdEntities == other.IdEntities &&
                   IsRecursive == other.IsRecursive &&
                   Name == other.Name &&
                   Comment == other.Comment &&
                   IdLocations == other.IdLocations &&
                   IdUsersTech == other.IdUsersTech &&
                   IdGroupsTech == other.IdGroupsTech &&
                   IdManufacturers == other.IdManufacturers &&
                   IsDeleted == other.IsDeleted &&
                   IsTemplate == other.IsTemplate &&
                   TemplateName == other.TemplateName &&
                   DateMod == other.DateMod &&
                   IdUsers == other.IdUsers &&
                   IdGroups == other.IdGroups &&
                   TicketTco == other.TicketTco &&
                   DateCreation == other.DateCreation &&
                   IsUpdate == other.IsUpdate &&
                   IdSoftwares == other.IdSoftwares &&
                   IsHelpdeskVisible == other.IsHelpdeskVisible &&
                   IdSoftwareCategories == other.IdSoftwareCategories &&
                   IsValid == other.IsValid;
        }

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
            hash.Add(IdGroups);
            hash.Add(TicketTco);
            hash.Add(DateCreation);
            hash.Add(IsUpdate);
            hash.Add(IdSoftwares);
            hash.Add(IsHelpdeskVisible);
            hash.Add(IdSoftwareCategories);
            hash.Add(IsValid);
            return hash.ToHashCode();
        }

        public static bool operator ==(Software left, Software right)
        {
            return EqualityComparer<Software>.Default.Equals(left, right);
        }

        public static bool operator !=(Software left, Software right)
        {
            return !(left == right);
        }
    }
}
