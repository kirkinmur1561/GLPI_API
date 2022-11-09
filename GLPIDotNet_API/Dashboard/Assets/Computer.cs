using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using GLPIDotNet_API.Dashboard.Administration;
using GLPIDotNet_API.Dashboard.Assets.LinkComputer;
using GLPIDotNet_API.Dashboard.Helpdesk.LinkTicket;

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
        
        [JsonIgnore]
        public Entity Entity { get; set; }
        
        [JsonIgnore]
        public List<ItemTicket> Item_Ticket {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemProject> Item_Project {get;set;} = new();
        
        [JsonIgnore]
        public List<NetworkPort> NetworkPort {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceMotherboard> Item_DeviceMotherboard {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceFirmware> Item_DeviceFirmware {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceProcessor> Item_DeviceProcessor {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceMemory> Item_DeviceMemory {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceHardDrive> Item_DeviceHardDrive {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceNetworkCard> Item_DeviceNetworkCard {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceDrive> Item_DeviceDrive {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceBattery> Item_DeviceBattery {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceGraphicCard> Item_DeviceGraphicCard {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceSoundCard> Item_DeviceSoundCard {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceControl> Item_DeviceControl {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDevicePCI> Item_DevicePci {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceCase> Item_DeviceCase {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDevicePowerSupply> Item_DevicePowerSupply {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceGeneric> Item_DeviceGeneric {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceSimcard> Item_DeviceSimcard {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceSensor> Item_DeviceSensor {get;set;} = new();
        
        [JsonIgnore]
        public List<ItemDeviceCamera> Item_DeviceCamera {get;set;} = new();


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
