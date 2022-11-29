using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Assets
{
    public class CartridgeItem : Dashboard<CartridgeItem>, IEquatable<CartridgeItem>
    {
        [JsonProperty("cartridgeitems_id")]
        public long? IdCartridge { get; set; }

        [JsonProperty("printers_id")]
        public long? IdPrinter { get; set; }

        [JsonProperty("date_in")]
        public DateTime? DateIn { get; set; }

        [JsonProperty("date_use")]
        public DateTime? DateUse { get; set; }

        [JsonProperty("date_out")]
        public DateTime? DateOut { get; set; }

        [JsonProperty("pages")]
        public long? Pages { get; set; }

        public bool Equals(CartridgeItem other) =>
            GetHashCode() == other.GetHashCode();

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(IdEntity);
            hash.Add(IsRecursive);
            hash.Add(Name);
            hash.Add(Comment);
            hash.Add(IdLocation);
            hash.Add(IdUsersTech);
            hash.Add(IdGroupsTech);
            hash.Add(IdManufacturer);
            hash.Add(IsDeleted);
            hash.Add(IsTemplate);
            hash.Add(TemplateName);
            hash.Add(DateMod);
            hash.Add(IdUser);
            hash.Add(IdGroup);
            hash.Add(TicketTco);
            hash.Add(DateCreation);
            hash.Add(IdCartridge);
            hash.Add(IdPrinter);
            hash.Add(DateIn);
            hash.Add(DateUse);
            hash.Add(DateOut);
            hash.Add(Pages);
            return hash.ToHashCode();
        }

        public static bool operator ==(CartridgeItem left, CartridgeItem right) =>
            EqualityComparer<CartridgeItem>.Default.Equals(left, right);


        public static bool operator !=(CartridgeItem left, CartridgeItem right) =>
            !(left == right);
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CartridgeItem)obj);
        }

    }
}
