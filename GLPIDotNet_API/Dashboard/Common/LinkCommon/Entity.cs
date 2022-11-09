using Newtonsoft.Json;

namespace GLPIDotNet_API.Dashboard.Common.LinkCommon
{
    public class Entity:Dashboard<Entity>
    {       
        
        [JsonProperty("completename")]
        public string CompleteName {get; set;}       
        
        [JsonProperty("level")]
        public long? Level {get; set;}
        
        [JsonProperty("sons_cache")]
        public object SonsCache {get; set;}
        
        [JsonProperty("ancestors_cache")]
        public object AncestorsCache {get; set;}
        
        [JsonProperty("registration_number")]
        public object RegistrationNumber {get; set;}
        
        [JsonProperty("address")]
        public object Address {get; set;}
        
        [JsonProperty("postcode")]
        public object Postcode {get; set;}
        
        [JsonProperty("town")]
        public object Town {get; set;}
        
        [JsonProperty("state")]
        public object State {get; set;}
        
        [JsonProperty("country")]
        public object Country {get; set;}
        
        [JsonProperty("website")]
        public object Website {get; set;}
        
        [JsonProperty("phonenumber")]
        public object PhoneNumber {get; set;}
        
        [JsonProperty("fax")]
        public object Fax {get; set;}
        
        [JsonProperty("email")]
        public string Email {get; set;}
        
        [JsonProperty("admin_email")]
        public string EmailAdmin {get; set;}
        
        [JsonProperty("admin_email_name")]
        public string EmailAdminName {get; set;}
        
        [JsonProperty("replyto_email")]
        public string EmailReply {get; set;}
        
        [JsonProperty("replyto_email_name")]
        public string EmailReplyName {get; set;}
        
        [JsonProperty("notification_subject_tag")]
        public string TagNotificationSubject {get; set;}
        
        [JsonProperty("ldap_dn")]
        public string LDAP_DN {get; set;}
        
        [JsonProperty("tag")]
        public string Tag {get; set;}
        
        [JsonProperty("authldaps_id")]
        public long? IdAuthLDAP {get; set;}
        
        [JsonProperty("mail_domain")]
        public string EmailDomain {get; set;}
        
        [JsonProperty("entity_ldapfilter")]
        public string EntityLDAP_Filter {get; set;}
        
        [JsonProperty("mailing_signature")]
        public string EmailingSignature {get; set;}
        
        [JsonProperty("cartridges_alert_repeat")]
        public long? AlertRepeatCartridges {get; set;}
        
        [JsonProperty("consumables_alert_repeat")]
        public long? AlertRepeatConsumables {get; set;}
        
        [JsonProperty("use_licenses_alert")]
        public long? AlertUseLicenses {get; set;}
        
        [JsonProperty("send_licenses_alert_before_delay")]
        public long? AlertBeforeDelaySendLicenses {get; set;}
        
        [JsonProperty("use_certificates_alert")]
        public long? AlertUseCertificates {get; set;}
        
        [JsonProperty("send_certificates_alert_before_delay")]
        public long? AlertBeforeDelaySendCertificates {get; set;}
        
        [JsonProperty("certificates_alert_repeat_interval")]
        public long? AlertRepeatIntervalCertificates {get; set;}
        
        [JsonProperty("use_contracts_alert")]
        public long? AlertUseContracts {get; set;}
        
        [JsonProperty("send_contracts_alert_before_delay")]
        public long? send_contracts_alert_before_delay {get; set;}
        
        [JsonProperty("use_infocoms_alert")]
        public long? use_infocoms_alert {get; set;}
        
        [JsonProperty("send_infocoms_alert_before_delay")]
        public long? send_infocoms_alert_before_delay {get; set;}
        
        [JsonProperty("use_reservations_alert")]
        public long? use_reservations_alert {get; set;}
        
        [JsonProperty("use_domains_alert")]
        public long? use_domains_alert {get; set;}
        
        [JsonProperty("send_domains_alert_close_expiries_delay")]
        public long? send_domains_alert_close_expiries_delay {get; set;}
        
        [JsonProperty("send_domains_alert_expired_delay")]
        public long? send_domains_alert_expired_delay {get; set;}
        
        [JsonProperty("autoclose_delay")]
        public long? autoclose_delay {get; set;}
        
        [JsonProperty("autopurge_delay")]
        public long? autopurge_delay {get; set;}
        
        [JsonProperty("notclosed_delay")]
        public long? notclosed_delay {get; set;}
        
        [JsonProperty("calendars_id")]
        public long? calendars_id {get; set;}
        
        [JsonProperty("auto_assign_mode")]
        public long? auto_assign_mode {get; set;}
        
        [JsonProperty("tickettype")]
        public long? tickettype {get; set;}
        
        [JsonProperty("max_closedate")]
        public object max_closedate {get; set;}
        
        [JsonProperty("inquest_config")]
        public object inquest_config {get; set;}
        
        [JsonProperty("inquest_rate")]
        public object inquest_rate {get; set;}
        
        [JsonProperty("inquest_delay")]
        public object inquest_delay {get; set;}
        
        [JsonProperty("inquest_URL")]
        public object inquest_URL {get; set;}
        
        [JsonProperty("autofill_warranty_date")]
        public object autofill_warranty_date {get; set;}
        
        [JsonProperty("autofill_use_date")]
        public object autofill_use_date {get; set;}
        
        [JsonProperty("autofill_buy_date")]
        public object autofill_buy_date {get; set;}
        
        [JsonProperty("autofill_delivery_date")]
        public object autofill_delivery_date {get; set;}
        
        [JsonProperty("autofill_order_date")]
        public object autofill_order_date {get; set;}
        
        [JsonProperty("tickettemplates_id")]
        public object tickettemplates_id {get; set;}
        
        [JsonProperty("changetemplates_id")]
        public object changetemplates_id {get; set;}
        
        [JsonProperty("problemtemplates_id")]
        public object problemtemplates_id {get; set;}
        
        [JsonProperty("entities_id_software")]
        public object entities_id_software {get; set;}
        
        [JsonProperty("default_contract_alert")]
        public object default_contract_alert {get; set;}
        
        [JsonProperty("default_infocom_alert")]
        public object default_infocom_alert {get; set;}
        
        [JsonProperty("default_cartridges_alarm_threshold")]
        public object default_cartridges_alarm_threshold {get; set;}
        
        [JsonProperty("default_consumables_alarm_threshold")]
        public object default_consumables_alarm_threshold {get; set;}
        
        [JsonProperty("delay_send_emails")]
        public object delay_send_emails {get; set;}
        
        [JsonProperty("is_notif_enable_default")]
        public object is_notif_enable_default {get; set;}
        
        [JsonProperty("inquest_duration")]
        public object inquest_duration {get; set;}
        
        [JsonProperty("date_mod")]
        public object date_mod {get; set;}
        
        [JsonProperty("date_creation")]
        public object date_creation {get; set;}
        
        [JsonProperty("autofill_decommission_date")]
        public object autofill_decommission_date {get; set;}
        
        [JsonProperty("suppliers_as_private")]
        public object suppliers_as_private {get; set;}
        
        [JsonProperty("anonymize_support_agents")]
        public object anonymize_support_agents {get; set;}
        
        [JsonProperty("contracts_id_default")]
        public object contracts_id_default {get; set;}
        
        [JsonProperty("display_users_initials")]
        public object display_users_initials {get; set;}
        
        [JsonProperty("enable_custom_css")]
        public object enable_custom_css {get; set;}
        
        [JsonProperty("custom_css_code")]
        public object custom_css_code {get; set;}
        
        [JsonProperty("latitude")]
        public object latitude {get; set;}
        
        [JsonProperty("longitude")]
        public object longitude {get; set;}
        
        [JsonProperty("altitude")]
        public object altitude {get; set;}
        
        [JsonProperty("calendars_strategy")]
        public object calendars_strategy {get; set;}
        
        [JsonProperty("changetemplates_strategy")]
        public object changetemplates_strategy {get; set;}
        
        [JsonProperty("contracts_strategy_default")]
        public object contracts_strategy_default {get; set;}
        
        [JsonProperty("entities_strategy_software")]
        public object entities_strategy_software {get; set;}
        
        [JsonProperty("problemtemplates_strategy")]
        public object problemtemplates_strategy {get; set;}
        
        [JsonProperty("tickettemplates_strategy")]
        public object tickettemplates_strategy {get; set;}
        
        [JsonProperty("transfers_strategy")]
        public object transfers_strategy {get; set;}
        
        [JsonProperty("from_email")]
        public object from_email {get; set;}
        
        [JsonProperty("from_email_name")]
        public object from_email_name {get; set;}
        
        [JsonProperty("noreply_email")]
        public object noreply_email {get; set;}
        
        [JsonProperty("noreply_email_name")]
        public object noreply_email_name {get; set;}
        
        [JsonProperty("transfers_id")]
        public object transfers_id {get; set;}
        
        [JsonProperty("agent_base_url")]
        public object agent_base_url {get; set;}        
    }
}