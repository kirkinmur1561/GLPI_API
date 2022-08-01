using System.Collections.Generic;
using Newtonsoft.Json;
namespace GLPIDotNet_API.Dashboard.Search
{
    public class ResponseSearch
    {
        [JsonProperty("totalcount")]
        public long TotalCount { get; set; }
        [JsonProperty("count")]
        public long Count { get; set; }
        [JsonProperty("sort")]
        public List<string> Sort { get; set; }
        [JsonProperty("order")]
        public List<string> Order { get; set; }

        [JsonProperty("content-range")]
        public string ContentRange { get; set; }
        [JsonProperty("data")]
        public List<Dictionary<int, object>> Data { get; set; }
    }
}
