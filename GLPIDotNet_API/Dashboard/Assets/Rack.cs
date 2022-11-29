using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Assets
{
    public class Rack : WorkStation<Rack>, IEquatable<Rack>
    {
        [JsonProperty("rackmodels_id")]
        public long? IdRackModel { get; set; }

        [JsonProperty("racktypes_id")]
        public long? IdRackType { get; set; }

        [JsonProperty("width")]
        public double? Width { get; set; }

        [JsonProperty("height")]
        public double? Height { get; set; }

        [JsonProperty("depth")]
        public double? Depth { get; set; }

        [JsonProperty("number_units")]
        public long? NumberUnit { get; set; }

        [JsonProperty("dcrooms_id")]
        public long? IdDCRoom { get; set; }

        [JsonProperty("room_orientation")]
        public long? RoomOrientation { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("bgcolor")]
        public string BGColor { get; set; }

        [JsonProperty("max_power")]
        public double? MaxPower { get; set; }

        [JsonProperty("mesured_power")]
        public long? MesuredPower { get; set; }

        [JsonProperty("max_weight")]
        public double? MaxWeight { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as Rack);
        }

        public bool Equals(Rack other)
        {
            return other != null &&
                   Id == other.Id &&
                   IdEntity == other.IdEntity &&
                   IsRecursive == other.IsRecursive &&
                   Name == other.Name &&
                   Comment == other.Comment &&
                   IdLocation == other.IdLocation &&
                   IdUsersTech == other.IdUsersTech &&
                   IdGroupsTech == other.IdGroupsTech &&
                   IdManufacturer == other.IdManufacturer &&
                   IsDeleted == other.IsDeleted &&
                   IsTemplate == other.IsTemplate &&
                   TemplateName == other.TemplateName &&
                   DateMod == other.DateMod &&
                   IdUser == other.IdUser &&
                   IdGroup == other.IdGroup &&
                   TicketTco == other.TicketTco &&
                   DateCreation == other.DateCreation &&

                   Contact == other.Contact &&
                   ContactNum == other.ContactNum &&
                   Serial == other.Serial &&
                   OtherSerial == other.OtherSerial &&
                   IdStates == other.IdStates &&
                   IsDynamic == other.IsDynamic &&
                   IdRackModel == other.IdRackModel &&
                   IdRackType == other.IdRackType &&
                   Width == other.Width &&
                   Height == other.Height &&
                   Depth == other.Depth &&
                   NumberUnit == other.NumberUnit &&
                   IdDCRoom == other.IdDCRoom &&
                   RoomOrientation == other.RoomOrientation &&
                   Position == other.Position &&
                   BGColor == other.BGColor &&
                   MaxPower == other.MaxPower &&
                   MesuredPower == other.MesuredPower &&
                   MaxWeight == other.MaxWeight;
        }

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

            hash.Add(Contact);
            hash.Add(ContactNum);
            hash.Add(Serial);
            hash.Add(OtherSerial);
            hash.Add(IdStates);
            hash.Add(IsDynamic);
            hash.Add(IdRackModel);
            hash.Add(IdRackType);
            hash.Add(Width);
            hash.Add(Height);
            hash.Add(Depth);
            hash.Add(NumberUnit);
            hash.Add(IdDCRoom);
            hash.Add(RoomOrientation);
            hash.Add(Position);
            hash.Add(BGColor);
            hash.Add(MaxPower);
            hash.Add(MesuredPower);
            hash.Add(MaxWeight);
            return hash.ToHashCode();
        }

        public static bool operator ==(Rack left, Rack right)
        {
            return EqualityComparer<Rack>.Default.Equals(left, right);
        }

        public static bool operator !=(Rack left, Rack right)
        {
            return !(left == right);
        }
    }
}
