using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Assets
{

    public class Phone : WorkStation<Phone>, IEquatable<Phone>
    {
        [JsonProperty("phonetypes_id")]
        public long? IdPhoneTypes { get; set; }

        [JsonProperty("phonemodels_id")]
        public long? IdPhoneModel { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("phonepowersupplies_id")]
        public long? IdPhonePowerSupplies { get; set; }

        [JsonProperty("number_line")]
        public long? NumberLine { get; set; }

        [JsonProperty("have_headset")]
        public bool? HaveHeadset { get; set; }

        [JsonProperty("have_hp")]
        public bool? HaveHP { get; set; }

        [JsonProperty("manufacturers_id")]
        public long? IdManufacture { get; set; }

        [JsonProperty("is_global")]
        public bool? IsGlobal { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as Phone);
        }

        public bool Equals(Phone other)
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
                   IdPhoneTypes == other.IdPhoneTypes &&
                   IdPhoneModel == other.IdPhoneModel &&
                   Brand == other.Brand &&
                   IdPhonePowerSupplies == other.IdPhonePowerSupplies &&
                   NumberLine == other.NumberLine &&
                   HaveHeadset == other.HaveHeadset &&
                   HaveHP == other.HaveHP &&
                   IdManufacture == other.IdManufacture &&
                   IsGlobal == other.IsGlobal;
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
            hash.Add(IdPhoneTypes);
            hash.Add(IdPhoneModel);
            hash.Add(Brand);
            hash.Add(IdPhonePowerSupplies);
            hash.Add(NumberLine);
            hash.Add(HaveHeadset);
            hash.Add(HaveHP);
            hash.Add(IdManufacture);
            hash.Add(IsGlobal);
            return hash.ToHashCode();
        }

        public static bool operator ==(Phone left, Phone right)
        {
            return EqualityComparer<Phone>.Default.Equals(left, right);
        }

        public static bool operator !=(Phone left, Phone right)
        {
            return !(left == right);
        }
    }
}
