using System.Text.Json.Serialization;
using GLPIDotNet_API.Dashboard.Common;
using GLPIDotNet_API.Dashboard.Common.LinkCommon;
using Newtonsoft.Json;

namespace GLPIDotNet_API.Dashboard.Assets
{
    public abstract class WorkStation<TW> : Dashboard<TW> where TW : Dashboard<TW>
        {
        [JsonProperty("contact")]
        public string Contact { get; set; }

        [JsonProperty("contact_num")]
        public string ContactNum { get; set; }

        [JsonProperty("serial")]
        public string Serial { get; set; }

        [JsonProperty("otherserial")]
        public string OtherSerial { get; set; }

        [JsonProperty("states_id")]
        public long? IdStates { get; set; }

        [JsonProperty("is_dynamic")]
        public bool? IsDynamic { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public State State { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public Network Network {get;set;}
    }
}
