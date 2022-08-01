using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Assets
{
    public class ConsumableItem : Dashboard<ConsumableItem>, IEquatable<ConsumableItem>
    {
        [JsonProperty("consumableitems_id")]
        public long? IdConsumable { get; set; }

        [JsonProperty("date_in")]
        public DateTime? DateIn { get; set; }

        [JsonProperty("date_out")]
        public DateTime? DateOut { get; set; }

        [JsonProperty("itemtype")]
        public DateTime? ItemType { get; set; }

        [JsonProperty("items_id")]
        public long? IdItems { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as ConsumableItem);
        }

        public bool Equals(ConsumableItem other)
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
                   IdConsumable == other.IdConsumable &&
                   DateIn == other.DateIn &&
                   DateOut == other.DateOut &&
                   ItemType == other.ItemType &&
                   IdItems == other.IdItems;
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
            hash.Add(IdConsumable);
            hash.Add(DateIn);
            hash.Add(DateOut);
            hash.Add(ItemType);
            hash.Add(IdItems);
            return hash.ToHashCode();
        }

        public static bool operator ==(ConsumableItem left, ConsumableItem right)
        {
            return EqualityComparer<ConsumableItem>.Default.Equals(left, right);
        }

        public static bool operator !=(ConsumableItem left, ConsumableItem right)
        {
            return !(left == right);
        }
    }
}
