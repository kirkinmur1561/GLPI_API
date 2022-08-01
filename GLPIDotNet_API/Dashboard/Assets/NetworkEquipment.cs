using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Assets
{

    public class NetworkEquipment : WorkStation<NetworkEquipment>, IEquatable<NetworkEquipment>
    {
        [JsonProperty("ram")]
        public long? RAM { get; set; }

        [JsonProperty("networks_id")]
        public long? IdNetworks { get; set; }

        [JsonProperty("networkequipmenttypes_id")]
        public long? IdNetworkEquipmentTypes { get; set; }

        [JsonProperty("networkequipmentmodels_id")]
        public long? IdNetworkEquipmentModels { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as NetworkEquipment);
        }

        public bool Equals(NetworkEquipment other)
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
                   RAM == other.RAM &&
                   IdNetworks == other.IdNetworks &&
                   IdNetworkEquipmentTypes == other.IdNetworkEquipmentTypes &&
                   IdNetworkEquipmentModels == other.IdNetworkEquipmentModels;
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
            hash.Add(RAM);
            hash.Add(IdNetworks);
            hash.Add(IdNetworkEquipmentTypes);
            hash.Add(IdNetworkEquipmentModels);
            return hash.ToHashCode();
        }

        public static bool operator ==(NetworkEquipment left, NetworkEquipment right)
        {
            return EqualityComparer<NetworkEquipment>.Default.Equals(left, right);
        }

        public static bool operator !=(NetworkEquipment left, NetworkEquipment right)
        {
            return !(left == right);
        }
    }
}
