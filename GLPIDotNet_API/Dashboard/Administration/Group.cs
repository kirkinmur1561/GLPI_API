using GLPIDotNet_API.Dashboard.Common;

namespace GLPIDotNet_API.Dashboard.Administration
{
    public class Group:Dashboard<Group>
    {
        public object ldap_field { get; set; }
        public object ldap_value { get; set; }
        public object ldap_group_dn { get; set; }
        public long? groups_id { get; set; }
        public string completename { get; set; }
        public int? level { get; set; }
        public object ancestors_cache { get; set; }
        public object sons_cache { get; set; }
        public bool? is_requester { get; set; }
        public bool? is_watcher { get; set; }
        public bool? is_assign { get; set; }
        public bool? is_task { get; set; }
        public bool? is_notify { get; set; }
        public bool? is_itemgroup { get; set; }
        public bool? is_usergroup { get; set; }
        public bool? is_manager { get; set; }


    }
}
