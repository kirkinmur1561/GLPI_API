using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Assets
{

    public class Computer : WorkStation<Computer>, IEquatable<Computer>
    {
        [JsonProperty("autoupdatesystems_id")]
        public long? IdAutoUpdateSystems { get; set; }

        [JsonProperty("networks_id")]
        public long? IdNetworks { get; set; }

        [JsonProperty("computermodels_id")]
        public long? IdComputerModels { get; set; }

        [JsonProperty("computertypes_id")]
        public long? IdComputerTypes { get; set; }

        [JsonProperty("uuid")]
        public string UUId { get; set; }


        public override bool Equals(object obj) =>
            Equals(obj as Computer);

        public bool Equals(Computer other)
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
                   Contact == other.Contact &&
                   ContactNum == other.ContactNum &&
                   Serial == other.Serial &&
                   OtherSerial == other.OtherSerial &&
                   IdStates == other.IdStates &&
                   IsDynamic == other.IsDynamic &&
                   IdAutoUpdateSystems == other.IdAutoUpdateSystems &&
                   IdNetworks == other.IdNetworks &&
                   IdComputerModels == other.IdComputerModels &&
                   IdComputerTypes == other.IdComputerTypes &&
                   UUId == other.UUId;
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
            hash.Add(Contact);
            hash.Add(ContactNum);
            hash.Add(Serial);
            hash.Add(OtherSerial);
            hash.Add(IdStates);
            hash.Add(IsDynamic);
            hash.Add(IdAutoUpdateSystems);
            hash.Add(IdNetworks);
            hash.Add(IdComputerModels);
            hash.Add(IdComputerTypes);
            hash.Add(UUId);
            return hash.ToHashCode();
        }

        public static bool operator ==(Computer left, Computer right) =>
            EqualityComparer<Computer>.Default.Equals(left, right);


        public static bool operator !=(Computer left, Computer right) =>
            !(left == right);

    }
}
