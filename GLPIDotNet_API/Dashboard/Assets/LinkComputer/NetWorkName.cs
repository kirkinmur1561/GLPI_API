using System.Collections.Generic;
using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;

namespace GLPIDotNet_API.Dashboard.Assets.LinkComputer
{
    public class NetWorkName:Dashboard<NetWorkName>
    {
        [JsonIgnore]
        public IpAddress IpAddress { get; set; }
    }
}