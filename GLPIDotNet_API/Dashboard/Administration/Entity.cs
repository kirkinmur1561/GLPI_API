using GLPIDotNet_API.Dashboard.Common;

namespace GLPIDotNet_API.Dashboard.Administration
{
    public class Entity : Dashboard<Entity>
    {
        public string completename { get; set; }
        public int level { get; set; }
        public object sons_cache { get; set; }
        public object ancestors_cache { get; set; }
        public object registration_number { get; set; }
        public object address { get; set; }
        public object postcode { get; set; }
        public object town { get; set; }
        public object state { get; set; }
        public object country { get; set; }
        public object website { get; set; }
        public object phonenumber { get; set; }
        public object fax { get; set; }
        public object email { get; set; }
        public string admin_email { get; set; }
        public string admin_email_name { get; set; }
        public object replyto_email { get; set; }
        public object replyto_email_name { get; set; }
        public string notification_subject_tag { get; set; }
        public string ldap_dn { get; set; }
        public object tag { get; set; }
        public long? authldaps_id { get; set; }
        public string mail_domain { get; set; }
        public object entity_ldapfilter { get; set; }
        public string mailing_signature { get; set; }
        public long? cartridges_alert_repeat { get; set; }
        public long? consumables_alert_repeat { get; set; }
        public long? use_licenses_alert { get; set; }
        public long? send_licenses_alert_before_delay { get; set; }
        public long? use_certificates_alert { get; set; }
        public long? send_certificates_alert_before_delay { get; set; }
        public long? certificates_alert_repeat_interval { get; set; }
        public long? use_contracts_alert { get; set; }
        public long? send_contracts_alert_before_delay { get; set; }
        public long? use_infocoms_alert { get; set; }
        public long? send_infocoms_alert_before_delay { get; set; }
        public long? use_reservations_alert { get; set; }
        public long? use_domains_alert { get; set; }
        public long? send_domains_alert_close_expiries_delay { get; set; }
        public long? send_domains_alert_expired_delay { get; set; }
        public long? autoclose_delay { get; set; }
        public long? autopurge_delay { get; set; }
        public long? notclosed_delay { get; set; }
        public long? calendars_id { get; set; }
        public long? auto_assign_mode { get; set; }
        public int? tickettype { get; set; }
        public object max_closedate { get; set; }
        public long? inquest_config { get; set; }
        public long? inquest_rate { get; set; }
        public long? inquest_delay { get; set; }
        public string inquest_URL { get; set; }
        public string autofill_warranty_date { get; set; }
        public string autofill_use_date { get; set; }
        public string autofill_buy_date { get; set; }
        public string autofill_delivery_date { get; set; }
        public string autofill_order_date { get; set; }
        public long? tickettemplates_id { get; set; }
        public long? changetemplates_id { get; set; }
        public long? problemtemplates_id { get; set; }
        public long? entities_id_software { get; set; }
        public long? default_contract_alert { get; set; }
        public long? default_infocom_alert { get; set; }
        public long? default_cartridges_alarm_threshold { get; set; }
        public long? default_consumables_alarm_threshold { get; set; }
        public long? delay_send_emails { get; set; }
        public long? is_notif_enable_default { get; set; }
        public long? inquest_duration { get; set; }
        public string autofill_decommission_date { get; set; }
        public long? suppliers_as_private { get; set; }
        public long? anonymize_support_agents { get; set; }
        public long? contracts_id_default { get; set; }
        public long? display_users_initials { get; set; }
        public long? enable_custom_css { get; set; }
        public long? custom_css_code { get; set; }
        public object latitude { get; set; }
        public object longitude { get; set; }
        public object altitude { get; set; }
        public long? calendars_strategy { get; set; }
        public long? changetemplates_strategy { get; set; }
        public long? contracts_strategy_default { get; set; }
        public long? entities_strategy_software { get; set; }
        public long? problemtemplates_strategy { get; set; }
        public long? tickettemplates_strategy { get; set; }
        public long? transfers_strategy { get; set; }
        public object from_email { get; set; }
        public object from_email_name { get; set; }
        public object noreply_email { get; set; }
        public object noreply_email_name { get; set; }
        public long? transfers_id { get; set; }
        public object agent_base_url { get; set; }

    }
}
