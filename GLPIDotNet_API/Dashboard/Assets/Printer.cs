using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Assets
{

    public class Printer : WorkStation<Printer>, IEquatable<Printer>
    {
        [JsonProperty("have_serial")]
        public bool? HaveSerial { get; set; }

        [JsonProperty("have_parallel")]
        public bool? HaveParallelPort { get; set; }

        [JsonProperty("have_usb")]
        public bool? HaveUSB { get; set; }

        [JsonProperty("have_wifi")]
        public bool? HaveWiFi { get; set; }

        [JsonProperty("have_ethernet")]
        public bool? HaveRJ45 { get; set; }

        [JsonProperty("memory_size")]
        public double? MemorySize { get; set; }

        [JsonProperty("networks_id")]
        public long? IdNetworks { get; set; }

        [JsonProperty("printertypes_id")]
        public long? IdPrinterTypes { get; set; }

        [JsonProperty("printermodels_id")]
        public long? IdPrinterModels { get; set; }

        [JsonProperty("init_pages_counter")]
        public long? InitPagesCounter { get; set; }

        [JsonProperty("last_pages_counter")]
        public long? LastPagesCounter { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as Printer);
        }

        public bool Equals(Printer other)
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
                   HaveSerial == other.HaveSerial &&
                   HaveParallelPort == other.HaveParallelPort &&
                   HaveUSB == other.HaveUSB &&
                   HaveWiFi == other.HaveWiFi &&
                   HaveRJ45 == other.HaveRJ45 &&
                   MemorySize == other.MemorySize &&
                   IdNetworks == other.IdNetworks &&
                   IdPrinterTypes == other.IdPrinterTypes &&
                   IdPrinterModels == other.IdPrinterModels &&
                   InitPagesCounter == other.InitPagesCounter &&
                   LastPagesCounter == other.LastPagesCounter;
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
            hash.Add(HaveSerial);
            hash.Add(HaveParallelPort);
            hash.Add(HaveUSB);
            hash.Add(HaveWiFi);
            hash.Add(HaveRJ45);
            hash.Add(MemorySize);
            hash.Add(IdNetworks);
            hash.Add(IdPrinterTypes);
            hash.Add(IdPrinterModels);
            hash.Add(InitPagesCounter);
            hash.Add(LastPagesCounter);
            return hash.ToHashCode();
        }

        public static bool operator ==(Printer left, Printer right)
        {
            return EqualityComparer<Printer>.Default.Equals(left, right);
        }

        public static bool operator !=(Printer left, Printer right)
        {
            return !(left == right);
        }
    }
}
