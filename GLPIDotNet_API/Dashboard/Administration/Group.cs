using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;

namespace GLPIDotNet_API.Dashboard.Administration
{
    public class Group:Dashboard<Group>
    {
        
        [JsonProperty("ldap_field")]
        public object LDAPField { get; set; }
        
        [JsonProperty("ldap_value")]
        public object LDAPValue { get; set; }
        
        [JsonProperty("ldap_group_dn")]
        public object LDAPGroupDN { get; set; }       
        
        [JsonProperty("completename")]
        public string CompleteName { get; set; }
        
        [JsonProperty("level")]
        public int? Level { get; set; }
        
        [JsonProperty("ancestors_cache")]
        public object CacheAncestors { get; set; }
        
        [JsonProperty("sons_cache")]
        public object CacheSons { get; set; }
        
        [JsonProperty("is_requester")]
        public bool? IsRequester { get; set; }
        
        [JsonProperty("is_watcher")]
        public bool? IsWatcher { get; set; }
        
        [JsonProperty("is_assign")]
        public bool? IsAssign { get; set; }
        
        [JsonProperty("is_task")]
        public bool? IsTask { get; set; }
        
        [JsonProperty("is_notify")]
        public bool? IsNotify { get; set; }
        
        [JsonProperty("is_itemgroup")]
        public bool? IsItemGroup { get; set; }
        
        [JsonProperty("is_usergroup")]
        public bool? IsUserGroup { get; set; }
        
        [JsonProperty("is_manager")]
        public bool? IsManager { get; set; }
    }
}
