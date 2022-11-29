using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Assets
{
    public class Monitor : WorkStation<Monitor>, IEquatable<Monitor>
    {
        [JsonProperty("size")]
        public double? Size { get; set; }

        [JsonProperty("have_micro")]
        public bool? HaveMicro { get; set; }

        [JsonProperty("have_speaker")]
        public bool? HaveSpeaker { get; set; }

        [JsonProperty("have_subd")]
        public bool? HaveSubD { get; set; }

        [JsonProperty("have_bnc")]
        public bool? HaveBNC { get; set; }

        [JsonProperty("have_dvi")]
        public bool? HaveDVI { get; set; }

        [JsonProperty("have_pivot")]
        public bool? HavePivot { get; set; }

        [JsonProperty("have_hdmi")]
        public bool? HaveHDMI { get; set; }

        [JsonProperty("have_displayport")]
        public bool? HaveDisplayPort { get; set; }

        [JsonProperty("monitortypes_id")]
        public long? IdMonitorTypes { get; set; }

        [JsonProperty("monitormodels_id")]
        public long? IdMonitorModels { get; set; }

        [JsonProperty("is_global")]
        public bool? IsGlobal { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as Monitor);
        }

        public bool Equals(Monitor other)
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
                   Size == other.Size &&
                   HaveMicro == other.HaveMicro &&
                   HaveSpeaker == other.HaveSpeaker &&
                   HaveSubD == other.HaveSubD &&
                   HaveBNC == other.HaveBNC &&
                   HaveDVI == other.HaveDVI &&
                   HavePivot == other.HavePivot &&
                   HaveHDMI == other.HaveHDMI &&
                   HaveDisplayPort == other.HaveDisplayPort &&
                   IdMonitorTypes == other.IdMonitorTypes &&
                   IdMonitorModels == other.IdMonitorModels &&
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
            hash.Add(Size);
            hash.Add(HaveMicro);
            hash.Add(HaveSpeaker);
            hash.Add(HaveSubD);
            hash.Add(HaveBNC);
            hash.Add(HaveDVI);
            hash.Add(HavePivot);
            hash.Add(HaveHDMI);
            hash.Add(HaveDisplayPort);
            hash.Add(IdMonitorTypes);
            hash.Add(IdMonitorModels);
            hash.Add(IsGlobal);
            return hash.ToHashCode();
        }

        public static bool operator ==(Monitor left, Monitor right)
        {
            return EqualityComparer<Monitor>.Default.Equals(left, right);
        }

        public static bool operator !=(Monitor left, Monitor right)
        {
            return !(left == right);
        }
    }
}
