#nullable enable
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Base;
using GLPIDotNet_API.Dashboard.Administration;
using GLPIDotNet_API.Dashboard.Assets.LinkComputer;
using GLPIDotNet_API.Dashboard.Helpdesk.LinkTicket;
using IPAddress = GLPIDotNet_API.Dashboard.Assets.LinkComputer.IPAddress;

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
        public Network Network { get; set; }        
        
        [JsonIgnore]
        public List<ItemTicket> Item_Ticket {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_Project> Item_Project {get;set;} = new();
        
        [JsonIgnore]
        public List<NetworkPort> NetworkPort {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceMotherboard> Item_DeviceMotherboard {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceFirmware> Item_DeviceFirmware {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceProcessor> Item_DeviceProcessor {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceMemory> Item_DeviceMemory {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceHardDrive> Item_DeviceHardDrive {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceNetworkCard> Item_DeviceNetworkCard {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceDrive> Item_DeviceDrive {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceBattery> Item_DeviceBattery {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceGraphicCard> Item_DeviceGraphicCard {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceSoundCard> Item_DeviceSoundCard {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceControl> Item_DeviceControl {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DevicePci> Item_DevicePci {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceCase> Item_DeviceCase {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DevicePowerSupply> Item_DevicePowerSupply {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceGeneric> Item_DeviceGeneric {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceSimcard> Item_DeviceSimcard {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceSensor> Item_DeviceSensor {get;set;} = new();
        
        [JsonIgnore]
        public List<Item_DeviceCamera> Item_DeviceCamera {get;set;} = new();

        [JsonIgnore] 
        public List<Contract_Item> Contract_Item { get; set; } = new();        
        
        [JsonIgnore]
        public AutoUpdateSystem AutoUpdateSystem {get;set;}
        
        [JsonIgnore]
        public ComputerModel ComputerModel {get;set;}
        
        [JsonIgnore]
        public ComputerType ComputerType {get;set;}
        
        [JsonIgnore]
        public Manufacturer Manufacturer {get;set;}
        
        [JsonIgnore]
        public User User {get;set;}        
        
        [JsonIgnore]
        public ReservationItem ReservationItem {get;set;}        
        
        [JsonIgnore]
        public Infocom Infocom {get;set;}
        
        [JsonIgnore]
        public Group Group {get;set;}
        
        [JsonIgnore]
        public Location Location {get;set;}

        [JsonIgnore] 
        public List<NetworkName> NetworkNames { get; set; } = new();        

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Computer) obj);
        }

        public static bool operator ==(Computer left, Computer right) =>
            EqualityComparer<Computer>.Default.Equals(left, right);

        public static bool operator !=(Computer left, Computer right) =>
            !(left == right);

       
        public override async Task LoadFromLinkAsync(Glpi glpi, IEnumerable<PropertyInfo> properties = null, bool? isIgnoreProperties = null,
            CancellationToken cancel = default)
        {
            await base.LoadFromLinkAsync(glpi, properties, isIgnoreProperties, cancel);
            
            if (NetworkPort.Any())
            {
                for (var indexPort = 0; indexPort < NetworkPort.Count; indexPort++)
                {
                    var networkPort = NetworkPort[indexPort];
                    List<NetworkName>? newNames =
                        JsonConvert.DeserializeObject<List<NetworkName>>(
                            await GetJsonFromUri(glpi,
                                new Uri($"{glpi.Client.BaseAddress}NetworkPort/{networkPort.Id}/NetworkName"), cancel));

                    if (newNames == null) continue;
                    for (var indexName = 0; indexName < newNames.Count; indexName++)
                    {
                        var networkName = newNames[indexName];
                        networkName.IpAddress =
                            JsonConvert.DeserializeObject<IEnumerable<IPAddress>>(
                                await GetJsonFromUri(glpi,
                                    new Uri($"{glpi.Client.BaseAddress}NetworkName/{networkName.Id}/IPAddress"),
                                    cancel));
                        networkPort.ListNetworkNames.Add(networkName);
                    }
                }
            } 
        }


        public bool Equals(Computer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return IdAutoUpdateSystems == other.IdAutoUpdateSystems && IdNetworks == other.IdNetworks &&
                   IdComputerModels == other.IdComputerModels && IdComputerTypes == other.IdComputerTypes &&
                   UUId == other.UUId && Equals(Entity, other.Entity) && Equals(Item_Ticket, other.Item_Ticket) &&
                   Equals(Item_Project, other.Item_Project) && Equals(NetworkPort, other.NetworkPort) &&
                   Equals(Item_DeviceMotherboard, other.Item_DeviceMotherboard) &&
                   Equals(Item_DeviceFirmware, other.Item_DeviceFirmware) &&
                   Equals(Item_DeviceProcessor, other.Item_DeviceProcessor) &&
                   Equals(Item_DeviceMemory, other.Item_DeviceMemory) &&
                   Equals(Item_DeviceHardDrive, other.Item_DeviceHardDrive) &&
                   Equals(Item_DeviceNetworkCard, other.Item_DeviceNetworkCard) &&
                   Equals(Item_DeviceDrive, other.Item_DeviceDrive) &&
                   Equals(Item_DeviceBattery, other.Item_DeviceBattery) &&
                   Equals(Item_DeviceGraphicCard, other.Item_DeviceGraphicCard) &&
                   Equals(Item_DeviceSoundCard, other.Item_DeviceSoundCard) &&
                   Equals(Item_DeviceControl, other.Item_DeviceControl) &&
                   Equals(Item_DevicePci, other.Item_DevicePci) && Equals(Item_DeviceCase, other.Item_DeviceCase) &&
                   Equals(Item_DevicePowerSupply, other.Item_DevicePowerSupply) &&
                   Equals(Item_DeviceGeneric, other.Item_DeviceGeneric) &&
                   Equals(Item_DeviceSimcard, other.Item_DeviceSimcard) &&
                   Equals(Item_DeviceSensor, other.Item_DeviceSensor) &&
                   Equals(Item_DeviceCamera, other.Item_DeviceCamera) && Equals(Contract_Item, other.Contract_Item) &&
                   Equals(AutoUpdateSystem, other.AutoUpdateSystem) && Equals(ComputerModel, other.ComputerModel) &&
                   Equals(ComputerType, other.ComputerType) && Equals(Manufacturer, other.Manufacturer) &&
                   Equals(User, other.User) && Equals(ReservationItem, other.ReservationItem) &&
                   Equals(Infocom, other.Infocom) && Equals(Group, other.Group) && Equals(Location, other.Location);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = IdAutoUpdateSystems.GetHashCode();
                hashCode = (hashCode * 397) ^ IdNetworks.GetHashCode();
                hashCode = (hashCode * 397) ^ IdComputerModels.GetHashCode();
                hashCode = (hashCode * 397) ^ IdComputerTypes.GetHashCode();
                hashCode = (hashCode * 397) ^ (UUId != null ? UUId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Entity != null ? Entity.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_Ticket != null ? Item_Ticket.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_Project != null ? Item_Project.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (NetworkPort != null ? NetworkPort.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceMotherboard != null ? Item_DeviceMotherboard.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceFirmware != null ? Item_DeviceFirmware.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceProcessor != null ? Item_DeviceProcessor.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceMemory != null ? Item_DeviceMemory.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceHardDrive != null ? Item_DeviceHardDrive.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceNetworkCard != null ? Item_DeviceNetworkCard.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceDrive != null ? Item_DeviceDrive.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceBattery != null ? Item_DeviceBattery.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceGraphicCard != null ? Item_DeviceGraphicCard.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceSoundCard != null ? Item_DeviceSoundCard.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceControl != null ? Item_DeviceControl.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DevicePci != null ? Item_DevicePci.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceCase != null ? Item_DeviceCase.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DevicePowerSupply != null ? Item_DevicePowerSupply.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceGeneric != null ? Item_DeviceGeneric.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceSimcard != null ? Item_DeviceSimcard.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceSensor != null ? Item_DeviceSensor.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item_DeviceCamera != null ? Item_DeviceCamera.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Contract_Item != null ? Contract_Item.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AutoUpdateSystem != null ? AutoUpdateSystem.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ComputerModel != null ? ComputerModel.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ComputerType != null ? ComputerType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Manufacturer != null ? Manufacturer.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (User != null ? User.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ReservationItem != null ? ReservationItem.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Infocom != null ? Infocom.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Group != null ? Group.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Location != null ? Location.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
