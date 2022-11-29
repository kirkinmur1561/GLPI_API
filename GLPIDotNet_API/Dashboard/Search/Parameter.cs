using GLPIDotNet_API.Dashboard.Assets;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GLPIDotNet_API.Dashboard.Search
{
    public class Parameter
    {
        public enum EOrder
        {
            ASC,
            DESC
        };

        public long? id
        {
            get => p_id;
            set
            {
                p_id = value;
                if (p_id != null)
                {
                    GetType()
                        .GetProperties()
                        .Where(w => !new string[] { "p_id", "id" }.Contains(w.Name))
                        .ToList()
                        .ForEach(a => a.SetValue(this, null));
                }
            }
        }
        protected internal long? p_id;

        public bool? expand_dropdowns { get => p_expand_dropdowns; set => Updater(value); }
        protected internal bool? p_expand_dropdowns;

        public bool? get_hateoas { get => p_get_hateoas; set => Updater(value); }
        protected internal bool? p_get_hateoas;

        public bool? get_sha1 { get => p_get_sha1; set => Updater(value); }
        protected internal bool? p_get_sha1;

        public bool? with_devices { get => p_with_devices; set => Updater(value); }
        protected internal bool? p_with_devices;

        public bool? with_disks { get => p_with_disks; set => Updater(value); }
        protected internal bool? p_with_disks;

        public bool? with_softwares { get => p_with_softwares; set => Updater(value); }
        protected internal bool? p_with_softwares;

        public bool? with_connections { get => p_with_connections; set => Updater(value); }
        protected internal bool? p_with_connections;

        public bool? with_networkports { get => p_with_networkports; set => Updater(value); }
        protected internal bool? p_with_networkports;

        public bool? with_infocoms { get => p_with_infocoms; set => Updater(value); }
        protected internal bool? p_with_infocoms;

        public bool? with_contracts { get => p_with_contracts; set => Updater(value); }
        protected internal bool? p_with_contracts;

        public bool? with_documents { get => p_with_documents; set => Updater(value); }
        protected internal bool? p_with_documents;

        public bool? with_tickets { get => p_with_tickets; set => Updater(value); }
        protected internal bool? p_with_tickets;

        public bool? with_problems { get => p_with_problems; set => Updater(value); }
        protected internal bool? p_with_problems;

        public bool? with_changes { get => p_with_changes; set => Updater(value); }
        protected internal bool? p_with_changes;

        public bool? with_notes { get => p_with_notes; set => Updater(value); }
        protected internal bool? p_with_notes;

        public bool? with_logs { get => p_with_logs; set => Updater(value); }
        protected internal bool? p_with_logs;

        public bool? add_keys_names { get => p_add_keys_names; set => Updater(value); }
        protected internal bool? p_add_keys_names;

        public bool? only_id { get => p_only_id; set => Updater(value); }
        protected internal bool? p_only_id;

        public Range range { get => p_range; set => Updater(value); }
        protected internal Range p_range;

        public int? sort { get => p_sort; set => Updater(value); }
        protected internal int? p_sort;

        public EOrder? order { get => p_order; set => Updater(value); }
        protected internal EOrder? p_order;

        public string searchText { get => p_searchText; set => Updater(value); }
        protected internal string p_searchText;

        public bool? is_deleted { get => p_is_deleted; set => Updater(value); }
        protected internal bool? p_is_deleted;
        //add_keys_names
        //raw

        protected internal void Updater(object val,[CallerMemberName] string name = "")
        {
            GetType()
                .GetField($"p_{name}", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(this, val);
            if (val != null) id = null;
            
        }

        public override string ToString() =>
            id != null ?
                $"/{id}" : 
                $"{string.Join("&", GetType().GetProperties().Where(w => w.GetValue(this) != null).Select(s => $"{s.Name}={s.GetValue(this)?.ToString()?.ToLower()}"))}";
        

    }
}
