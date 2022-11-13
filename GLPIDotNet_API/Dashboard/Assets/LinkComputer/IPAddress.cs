using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;

namespace GLPIDotNet_API.Dashboard.Assets.LinkComputer
{
    public class IPAddress:Dashboard<IPAddress>
    {
        public enum EipVersion
        {
            IpV4 = 4,
            IpV6 = 6
        }
        
        [JsonProperty("items_id")]
        public long? IdItem {get; set;}
        
        [JsonProperty("itemtype")]
        public string TypeItem {get; set;}
        
        /// <summary>
        /// Версия IP
        /// </summary>
        [JsonProperty("version")]
        public EipVersion Version {get; set;}
        
        [JsonProperty("name")]
        public string Address {get; set;}
        
        [JsonProperty("binary_0")]
        public long? Binary0 {get; set;}
        
        [JsonProperty("binary_1")]
        public long? Binary1 {get; set;}
        
        [JsonProperty("binary_2")]
        public long? Binary2 {get; set;}
        
        [JsonProperty("binary_3")]
        public long? Binary3 {get; set;}        
       
        [JsonProperty("mainitems_id")]
        public long? IdMainItem {get; set;}
        
        [JsonProperty("mainitemtype")]
        public string TypeMainItem {get; set;}       
    }
}