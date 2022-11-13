using System.Collections.Generic;
using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;

namespace GLPIDotNet_API.Dashboard.Assets.LinkComputer
{
    public class NetworkName:Dashboard<NetworkName>
    {
        [JsonIgnore]
        public IEnumerable<IPAddress> IpAddress { get; set; }
    }
}