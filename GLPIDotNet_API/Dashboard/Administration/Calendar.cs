using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;
namespace GLPIDotNet_API.Dashboard.Administration
{
    /// <summary>
    /// /*унаследованы все поля*/
    /// </summary>
    public class Calendar:Dashboard<Calendar>
    {
        [JsonProperty("cache_duration")]
        public int[] CacheDuration { get; set; }
    }
}
