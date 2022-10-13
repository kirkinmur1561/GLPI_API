using GLPIDotNet_API.Dashboard.Common;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Administration
{
    public class AuthLDAP : Dashboard<AuthLDAP>, IEquatable<AuthLDAP>
    {
        public AuthLDAP()
        {

        }
        public string host { get; set; }
        public string basedn { get; set; }
        public string rootdn { get; set; }
        public int port { get; set; }
        public string condition { get; set; }
        public string login_field { get; set; }
        public string sync_field { get; set; }
        public int use_tls { get; set; }
        public string group_field { get; set; }
        public string group_condition { get; set; }
        public int group_search_type { get; set; }
        public string group_member_field { get; set; }
        public string email1_field { get; set; }
        public string realname_field { get; set; }
        public string firstname_field { get; set; }
        public string phone_field { get; set; }
        public string phone2_field { get; set; }
        public string mobile_field { get; set; }
        public string comment_field { get; set; }
        public int use_dn { get; set; }
        public int time_offset { get; set; }
        public int deref_option { get; set; }
        public string title_field { get; set; }
        public string category_field { get; set; }
        public object language_field { get; set; }
        public string entity_field { get; set; }
        public string entity_condition { get; set; }
        public bool? is_active { get; set; }
        public string registration_number_field { get; set; }
        public string email2_field { get; set; }
        public string email3_field { get; set; }
        public string email4_field { get; set; }
        public string location_field { get; set; }
        public string responsible_field { get; set; }
        public long? pagesize { get; set; }
        public long? ldap_maxlimit { get; set; }
        public long? can_support_pagesize { get; set; }
        public object picture_field { get; set; }
        public object inventory_domain { get; set; }
        public object tls_certfile { get; set; }
        public object tls_keyfile { get; set; }
        public int use_bind { get; set; }
        public int timeout { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as AuthLDAP);
        }

        public bool Equals(AuthLDAP other) =>
            other != null &&
            Id == other.Id &&
            IdEntities == other.IdEntities &&
            IsRecursive == other.IsRecursive &&
            Name == other.Name &&
            Comment == other.Comment &&
            IdLocations == other.IdLocations &&
            IdUsersTech == other.IdUsersTech &&
            IdGroupsTech == other.IdGroupsTech &&
            IdManufacturers == other.IdManufacturers &&
            IsDeleted == other.IsDeleted &&
            IsTemplate == other.IsTemplate &&
            TemplateName == other.TemplateName &&
            DateMod == other.DateMod &&
            IdUsers == other.IdUsers &&
            IdGroups == other.IdGroups &&
            TicketTco == other.TicketTco &&
            DateCreation == other.DateCreation &&
            host == other.host &&
            basedn == other.basedn &&
            rootdn == other.rootdn &&
            port == other.port &&
            condition == other.condition &&
            login_field == other.login_field &&
            sync_field == other.sync_field &&
            use_tls == other.use_tls &&
            group_field == other.group_field &&
            group_condition == other.group_condition &&
            group_search_type == other.group_search_type &&
            group_member_field == other.group_member_field &&
            email1_field == other.email1_field &&
            realname_field == other.realname_field &&
            firstname_field == other.firstname_field &&
            phone_field == other.phone_field &&
            phone2_field == other.phone2_field &&
            mobile_field == other.mobile_field &&
            comment_field == other.comment_field &&
            use_dn == other.use_dn &&
            time_offset == other.time_offset &&
            deref_option == other.deref_option &&
            title_field == other.title_field &&
            category_field == other.category_field &&
            EqualityComparer<object>.Default.Equals(language_field, other.language_field) &&
            entity_field == other.entity_field &&
            entity_condition == other.entity_condition &&
            is_active == other.is_active &&
            registration_number_field == other.registration_number_field &&
            email2_field == other.email2_field &&
            email3_field == other.email3_field &&
            email4_field == other.email4_field &&
            location_field == other.location_field &&
            responsible_field == other.responsible_field &&
            pagesize == other.pagesize &&
            ldap_maxlimit == other.ldap_maxlimit &&
            can_support_pagesize == other.can_support_pagesize &&
            EqualityComparer<object>.Default.Equals(picture_field, other.picture_field) &&
            EqualityComparer<object>.Default.Equals(inventory_domain, other.inventory_domain) &&
            EqualityComparer<object>.Default.Equals(tls_certfile, other.tls_certfile) &&
            EqualityComparer<object>.Default.Equals(tls_keyfile, other.tls_keyfile) &&
            use_bind == other.use_bind &&
            timeout == other.timeout;
        

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(IdEntities);
            hash.Add(IsRecursive);
            hash.Add(Name);
            hash.Add(Comment);
            hash.Add(IdLocations);
            hash.Add(IdUsersTech);
            hash.Add(IdGroupsTech);
            hash.Add(IdManufacturers);
            hash.Add(IsDeleted);
            hash.Add(IsTemplate);
            hash.Add(TemplateName);
            hash.Add(DateMod);
            hash.Add(IdUsers);
            hash.Add(IdGroups);
            hash.Add(TicketTco);
            hash.Add(DateCreation);
            hash.Add(host);
            hash.Add(basedn);
            hash.Add(rootdn);
            hash.Add(port);
            hash.Add(condition);
            hash.Add(login_field);
            hash.Add(sync_field);
            hash.Add(use_tls);
            hash.Add(group_field);
            hash.Add(group_condition);
            hash.Add(group_search_type);
            hash.Add(group_member_field);
            hash.Add(email1_field);
            hash.Add(realname_field);
            hash.Add(firstname_field);
            hash.Add(phone_field);
            hash.Add(phone2_field);
            hash.Add(mobile_field);
            hash.Add(comment_field);
            hash.Add(use_dn);
            hash.Add(time_offset);
            hash.Add(deref_option);
            hash.Add(title_field);
            hash.Add(category_field);
            hash.Add(language_field);
            hash.Add(entity_field);
            hash.Add(entity_condition);
            hash.Add(is_active);
            hash.Add(registration_number_field);
            hash.Add(email2_field);
            hash.Add(email3_field);
            hash.Add(email4_field);
            hash.Add(location_field);
            hash.Add(responsible_field);
            hash.Add(pagesize);
            hash.Add(ldap_maxlimit);
            hash.Add(can_support_pagesize);
            hash.Add(picture_field);
            hash.Add(inventory_domain);
            hash.Add(tls_certfile);
            hash.Add(tls_keyfile);
            hash.Add(use_bind);
            hash.Add(timeout);
            return hash.ToHashCode();
        }

        public static bool operator ==(AuthLDAP left, AuthLDAP right)
        {
            return EqualityComparer<AuthLDAP>.Default.Equals(left, right);
        }

        public static bool operator !=(AuthLDAP left, AuthLDAP right)
        {
            return !(left == right);
        }
    }
}
