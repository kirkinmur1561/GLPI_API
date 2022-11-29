using System.Collections.Generic;
using GLPIDotNet_API.Dashboard.Administration;
using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;

namespace GLPIDotNet_API.Dashboard.Assets.LinkComputer
{
    public class NetworkPort:Dashboard<NetworkPort>
    {        
        [JsonProperty("items_id")]
        public long? IdItem {get; set;}
        
        [JsonProperty("itemtype")]
        public string TypeItem {get; set;}            
        
        /// <summary>
        /// Port number
        /// </summary>
        [JsonProperty("logical_number")]
        public long? LogicalNum {get; set;}        
        
        [JsonProperty("instantiation_type")]
        public string TypeInstantiation {get; set;}
        
        [JsonProperty("mac")]
        public string MAC_Address {get; set;}                
        
        [JsonProperty("is_dynamic")]
        public bool? IsDynamic {get; set;}         
        
        [JsonProperty("ifmtu")]
        public long? ifMtu {get; set;}
        
        [JsonProperty("ifspeed")]
        public long? ifSpeed {get; set;}
        
        [JsonProperty("ifinternalstatus")]
        public long? ifInternalStatus {get; set;}
        
        [JsonProperty("ifconnectionstatus")]
        public long? ifConnectionStatus {get; set;}
        
        [JsonProperty("iflastchange")]
        public long? ifLastChange {get; set;}
        
        [JsonProperty("ifinbytes")]
        public long? ifInBytes {get; set;}
        
        [JsonProperty("ifinerrors")]
        public long? ifInErrors {get; set;}
        
        [JsonProperty("ifoutbytes")]
        public long? ifOutBytes {get; set;}
        
        [JsonProperty("ifouterrors")]
        public long? ifOutErrors {get; set;}
        
        [JsonProperty("ifstatus")]
        public long? ifStatus {get; set;}
        
        [JsonProperty("ifdescr")]
        public long? ifDescr {get; set;}
        
        [JsonProperty("ifalias")]
        public long? ifAlias {get; set;}
        
        [JsonProperty("portduplex")]
        public object PortDuplex {get; set;}
        
        [JsonProperty("trunk")]
        public long? Trunk {get; set;}
        
        [JsonProperty("lastup")]
        public object LastUp {get; set;}        
        
        [JsonIgnore]
        public Computer Computer { get; set; }       

        [JsonIgnore]
        public List<NetworkName> ListNetworkNames { get; set; } = new();
    }
}