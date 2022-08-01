using System.Collections.Generic;
using GLPIDotNet_API.Dashboard.Administration;
using Newtonsoft.Json;
namespace GLPIDotNet_API.Base
{
    public class ActiveProfile
    {
        [JsonProperty("id")]
        public string Id;
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("interface")]
        public string Interface;
        [JsonProperty("is_default")]
        public int IsDefault;
        [JsonProperty("helpdesk_hardware")]
        public string HelpdeskHardware;
        [JsonProperty("helpdesk_item_type")]
        public List<string> HelpdeskItemType;
        [JsonProperty("ticket_status")]
        public List<string> TicketStatus;
        [JsonProperty("comment")]
        public string Comment;
        [JsonProperty("problem_status")]
        public List<object> ProblemStatus;
        [JsonProperty("glpiactive_entity_name")]
        public string GlpiactiveEntityName;
        [JsonProperty("date_mod")]
        public object DateMod;
        [JsonProperty("create_ticket_on_login")]
        public int CreateTicketOnLogin;
        [JsonProperty("tickettemplates_id")]
        public int TickettemplatesId;
        [JsonProperty("changetemplates_id")]
        public int ChangetemplatesId;
        [JsonProperty("problemtemplates_id")]
        public int ProblemtemplatesId;      
        [JsonProperty("change_status")]
        public object ChangeStatus;
        [JsonProperty("anaged_domainrecordtypes")]
        public List<int> AnagedDomainrecordtypes;
        [JsonProperty("date_creation")]
        public string DateCreation;
        [JsonProperty("appliance")]
        public int Appliance;
        [JsonProperty("backup")]
        public int Backup;
        [JsonProperty("bookmark_public")]
        public int BookmarkPublic;
        [JsonProperty("budget")]
        public int Budget;
        [JsonProperty("calendar")]
        public int Calendar;
        [JsonProperty("cartridge")]
        public int Cartridge;
        [JsonProperty("certificate")]
        public int Certificate;
        [JsonProperty("change")]
        public int Change;
        [JsonProperty("changevalidation")]
        public int Changevalidation;
        [JsonProperty("cluster")]
        public int Cluster;
        [JsonProperty("computer")]
        public int Computer;
        [JsonProperty("config")]
        public int Config;
        [JsonProperty("consumable")]
        public int Consumable;
        [JsonProperty("contact_enterprise")]
        public int ContactEnterprise;
        [JsonProperty("contract")]
        public int Contract;
        [JsonProperty("dashboard")]
        public int Dashboard;
        [JsonProperty("datacenter")]
        public int Datacenter;
        [JsonProperty("device")]
        public int Device;
        [JsonProperty("devicesimcard_pinpuk")]
        public int DeviceSimcardPinpuk;
        [JsonProperty("document")]
        public int Document;
        [JsonProperty("domain")]
        public int Domain;
        [JsonProperty("dropdown")]
        public int Dropdown;
        [JsonProperty("entity")]
        public int Entity;
        [JsonProperty("externalevent")]
        public int ExternalEvent;
        [JsonProperty("followup")]
        public int Followup;
        [JsonProperty("global_validation")]
        public int GlobalValidation;
        [JsonProperty("group")]
        public int Group;
        [JsonProperty("infocom")]
        public int Infocom;
        [JsonProperty("internet")]
        public int Internet;
        [JsonProperty("itilcategory")]
        public int Itilcategory;
        [JsonProperty("itiltemplate")]
        public int Itiltemplate;
        [JsonProperty("knowbase")]
        public int Knowbase;
        [JsonProperty("knowbasecategory")]
        public int Knowbasecategory;
        [JsonProperty("license")]
        public int License;
        [JsonProperty("line")]
        public int Line;
        [JsonProperty("lineoperator")]
        public int Lineoperator;
        [JsonProperty("link")]
        public int Link;
        [JsonProperty("location")]
        public int Location;
        [JsonProperty("logs")]
        public int Logs;
        [JsonProperty("monitor")]
        public int Monitor;
        [JsonProperty("netpoint")]
        public int Netpoint;
        [JsonProperty("networking")]
        public int Networking;
        [JsonProperty("notification")]
        public int Notification;
        [JsonProperty("password_update")]
        public int PasswordUpdate;
        [JsonProperty("peripheral")]
        public int Peripheral;
        [JsonProperty("personalization")]
        public int Personalization;
        [JsonProperty("phone")]
        public int Phone;
        [JsonProperty("planning")]
        public int Planning;
        [JsonProperty("plugin_accounts")]
        public int PluginAccounts;
        [JsonProperty("plugin_accounts_hash")]
        public int PluginAccountsHash;
        [JsonProperty("plugin_accounts_my_groups")]
        public int PluginAccountsMyGroups;
        [JsonProperty("plugin_accounts_open_ticket")]
        public int PluginAccountsOpenTicket;
        [JsonProperty("plugin_accounts_see_all_users")]
        public int PluginAccountsSeeAllUsers;
        [JsonProperty("plugin_addressing")]
        public int PluginAddressing;
        [JsonProperty("plugin_addressing_use_ping_in_equipment")]
        public int PluginAddressingUsePingInEquipment;
        [JsonProperty("plugin_archimap")]
        public int PluginArchimap;
        [JsonProperty("plugin_archimap_open_ticket")]
        public int PluginArchimapOpenTicket;
        [JsonProperty("plugin_archires")]
        public int PluginArchires;
        [JsonProperty("plugin_barcode_barcode")]
        public int PluginBarcodeBarcode;
        [JsonProperty("plugin_barcode_config")]
        public int PluginBarcodeConfig;
        [JsonProperty("plugin_databases")]
        public int PluginDatabases;
        [JsonProperty("plugin_databases_open_ticket")]
        public int PluginDatabasesOpenTicket;
        [JsonProperty("plugin_datainjection_model")]
        public int PluginDatainjectionModel;
        [JsonProperty("plugin_datainjection_use")]
        public int PluginDatainjectionUse;
        [JsonProperty("plugin_domains")]
        public int PluginDomains;
        [JsonProperty("plugin_domains_dropdown")]
        public int PluginDomainsDropdown;
        [JsonProperty("plugin_domains_open_ticket")]
        public int PluginDomainsOpenTicket;
        [JsonProperty("plugin_environment")]
        public int PluginEnvironment;
        [JsonProperty("plugin_environment_accounts")]
        public int PluginEnvironmentAccounts;
        [JsonProperty("plugin_environment_badges")]
        public int PluginEnvironmentBadges;
        [JsonProperty("plugin_environment_databases")]
        public int PluginEnvironmentDatabases;
        [JsonProperty("plugin_environment_webapplications")]
        public int PluginEnvironmentWebapplications;
        [JsonProperty("plugin_fusioninventory_agent")]
        public int PluginFusioninventoryAgent;
        [JsonProperty("plugin_fusioninventory_blacklist")]
        public int PluginFusioninventoryBlacklist;
        [JsonProperty("plugin_fusioninventory_collect")]
        public int PluginFusioninventoryCollect;
        [JsonProperty("plugin_fusioninventory_configsecurity")]
        public int PluginFusioninventoryConfigsecurity;
        [JsonProperty("plugin_fusioninventory_configuration")]
        public int PluginFusioninventoryConfiguration;
        [JsonProperty("plugin_fusioninventory_credential")]
        public int PluginFusioninventoryCredential;
        [JsonProperty("plugin_fusioninventory_credentialip")]
        public int PluginFusioninventoryCredentialip;
        [JsonProperty("plugin_fusioninventory_deploymirror")]
        public int PluginFusioninventoryDeploymirror;
        [JsonProperty("plugin_fusioninventory_esx")]
        public int PluginFusioninventoryEsx;
        [JsonProperty("plugin_fusioninventory_group")]
        public int PluginFusioninventoryGroup;
        [JsonProperty("plugin_fusioninventory_ignoredimportdevice")]
        public int PluginFusioninventoryIgnoredimportdevice;
        [JsonProperty("plugin_fusioninventory_importxml")]
        public int PluginFusioninventoryImportxml;
        [JsonProperty("plugin_fusioninventory_iprange")]
        public int PluginFusioninventoryIprange;
        [JsonProperty("plugin_fusioninventory_lock")]
        public int PluginFusioninventoryLock;
        [JsonProperty("plugin_fusioninventory_menu")]
        public int PluginFusioninventoryMenu;
        [JsonProperty("plugin_fusioninventory_networkequipment")]
        public int PluginFusioninventoryNetworkequipment;
        [JsonProperty("plugin_fusioninventory_package")]
        public int PluginFusioninventoryPackage;
        [JsonProperty("plugin_fusioninventory_printer")]
        public int PluginFusioninventoryPrinter;
        [JsonProperty("plugin_fusioninventory_remotecontrol")]
        public int PluginFusioninventoryRemotecontrol;
        [JsonProperty("plugin_fusioninventory_reportnetworkequipment")]
        public int PluginFusioninventoryReportnetworkequipment;
        [JsonProperty("plugin_fusioninventory_reportprinter")]
        public int PluginFusioninventoryReportprinter;
        [JsonProperty("plugin_fusioninventory_rulecollect")]
        public int PluginFusioninventoryRulecollect;
        [JsonProperty("plugin_fusioninventory_ruleentity")]
        public int PluginFusioninventoryRuleentity;
        [JsonProperty("plugin_fusioninventory_ruleimport")]
        public int PluginFusioninventoryRuleimport;
        [JsonProperty("plugin_fusioninventory_rulelocation")]
        public int PluginFusioninventoryRulelocation;
        [JsonProperty("plugin_fusioninventory_selfpackage")]
        public int PluginFusioninventorySelfpackage;
        [JsonProperty("plugin_fusioninventory_task")]
        public int PluginFusioninventoryTask;
        [JsonProperty("plugin_fusioninventory_unmanaged")]
        public int PluginFusioninventoryUnmanaged;
        [JsonProperty("plugin_fusioninventory_userinteractiontemplate")]
        public int PluginFusioninventoryUserinteractiontemplate;
        [JsonProperty("plugin_fusioninventory_wol")]
        public int PluginFusioninventoryWol;
        [JsonProperty("plugin_genericobject_types")]
        public int PluginGenericobjectTypes;
        [JsonProperty("plugin_karastock_history")]
        public int PluginKarastockHistory;
        [JsonProperty("plugin_karastock_order")]
        public int PluginKarastockOrder;
        [JsonProperty("plugin_karastock_stock")]
        public int PluginKarastockStock;
        [JsonProperty("plugin_ocsinventoryng")]
        public int PluginOcsinventoryng;
        [JsonProperty("plugin_ocsinventoryng_clean")]
        public int PluginOcsinventoryngClean;
        [JsonProperty("plugin_ocsinventoryng_import")]
        public int PluginOcsinventoryngImport;
        [JsonProperty("plugin_ocsinventoryng_link")]
        public int PluginOcsinventoryngLink;
        [JsonProperty("plugin_ocsinventoryng_rule")]
        public int PluginOcsinventoryngRule;
        [JsonProperty("plugin_ocsinventoryng_sync")]
        public int PluginOcsinventoryngSync;
        [JsonProperty("plugin_ocsinventoryng_view")]
        public int PluginOcsinventoryngView;
        [JsonProperty("plugin_order_bill")]
        public int PluginOrderBill;
        [JsonProperty("plugin_order_order")]
        public int PluginOrderOrder;
        [JsonProperty("plugin_order_reference")]
        public int PluginOrderReference;
        [JsonProperty("plugin_pdf")]
        public int PluginPdf;
        [JsonProperty("plugin_printercounters")]
        public int PluginPrintercounters;
        [JsonProperty("plugin_printercounters_add_lower_records")]
        public int PluginPrintercountersAddLowerRecords;
        [JsonProperty("plugin_printercounters_snmpset")]
        public int PluginPrintercountersSnmpset;
        [JsonProperty("plugin_printercounters_update_records")]
        public int PluginPrintercountersUpdateRecords;
        [JsonProperty("plugin_processmaker_case")]
        public int PluginProcessmakerCase;
        [JsonProperty("plugin_processmaker_config")]
        public int PluginProcessmakerConfig;
        [JsonProperty("plugin_reports_applicationsbylocation")]
        public int PluginReportsApplicationsbylocation;
        [JsonProperty("plugin_reports_doublons")]
        public int PluginReportsDoublons;
        [JsonProperty("plugin_reports_equipmentbygroups")]
        public int PluginReportsEquipmentbygroups;
        [JsonProperty("plugin_reports_equipmentbylocation")]
        public int PluginReportsEquipmentbylocation;
        [JsonProperty("plugin_reports_globalhisto")]
        public int PluginReportsGlobalhisto;
        [JsonProperty("plugin_reports_histohard")]
        public int PluginReportsHistohard;
        [JsonProperty("plugin_reports_histoinst")]
        public int PluginReportsHistoinst;
        [JsonProperty("plugin_reports_infocom")]
        public int PluginReportsInfocom;
        [JsonProperty("plugin_reports_iteminstall")]
        public int PluginReportsIteminstall;
        [JsonProperty("plugin_reports_licenses")]
        public int PluginReportsLicenses;
        [JsonProperty("plugin_reports_licensesexpires")]
        public int PluginReportsLicensesexpires;
        [JsonProperty("plugin_reports_listequipmentbylocation")]
        public int PluginReportsListequipmentbylocation;
        [JsonProperty("plugin_reports_listgroups")]
        public int PluginReportsListgroups;
        [JsonProperty("plugin_reports_location")]
        public int PluginReportsLocation;
        [JsonProperty("plugin_reports_order_deliveryinfos")]
        public int PluginReportsOrderDeliveryinfos;
        [JsonProperty("plugin_reports_order_orderdelivery")]
        public int PluginReportsOrderOrderdelivery;
        [JsonProperty("plugin_reports_pcsbyentity")]
        public int PluginReportsPcsbyentity;
        [JsonProperty("plugin_reports_printers")]
        public int PluginReportsPrinters;
        [JsonProperty("plugin_reports_rules")]
        public int PluginReportsRules;
        [JsonProperty("plugin_reports_searchinfocom")]
        public int PluginReportsSearchinfocom;
        [JsonProperty("plugin_reports_softnotinstalled")]
        public int PluginReportsSoftnotinstalled;
        [JsonProperty("plugin_reports_softversioninstallations")]
        public int PluginReportsSoftversioninstallations;
        [JsonProperty("plugin_reports_statnightticketsbypriority")]
        public int PluginReportsStatnightticketsbypriority;
        [JsonProperty("plugin_reports_statticketsbyentity")]
        public int PluginReportsStatticketsbyentity;
        [JsonProperty("plugin_reports_statticketsbypriority")]
        public int PluginReportsStatticketsbypriority;
        [JsonProperty("plugin_reports_statusertas")]
        public int PluginReportsStatusertas;
        [JsonProperty("plugin_reports_transferreditems")]
        public int PluginReportsTransferreditems;
        [JsonProperty("plugin_reports_zombies")]
        public int PluginReportsZombies;
        [JsonProperty("plugin_satisfaction")]
        public int PluginSatisfaction;
        [JsonProperty("plugin_shellcommands")]
        public int PluginShellcommands;
        [JsonProperty("plugin_tasklists")]
        public int PluginTasklists;
        [JsonProperty("plugin_tasklists_config")]
        public int PluginTasklistsConfig;
        [JsonProperty("plugin_tasklists_see_all")]
        public int PluginTasklistsSeeAll;
        [JsonProperty("plugin_typology")]
        public int PluginTypology;
        [JsonProperty("plugin_vip")]
        public int PluginVip;
        [JsonProperty("plugin_webresources_resource")]
        public int PluginWebresourcesResource;
        [JsonProperty("printer")]
        public int Printer;
        [JsonProperty("problem")]
        public int Problem;
        [JsonProperty("profile")]
        public int Profile;
        [JsonProperty("project")]
        public int Project;
        [JsonProperty("projecttask")]
        public int Projecttask;
        [JsonProperty("queuednotification")]
        public int Queuednotification;
        [JsonProperty("reminder_public")]
        public int ReminderPublic;
        [JsonProperty("reports")]
        public int Reports;
        [JsonProperty("reservation")]
        public int Reservation;
        [JsonProperty("rssfeed_public")]
        public int RssfeedPublic;
        [JsonProperty("rule_asset")]
        public int RuleAsset;
        [JsonProperty("rule_dictionnary_dropdown")]
        public int RuleDictionnaryDropdown;
        [JsonProperty("rule_dictionnary_printer")]
        public int RuleDictionnaryPrinter;
        [JsonProperty("rule_dictionnary_software")]
        public int RuleDictionnarySoftware;
        [JsonProperty("rule_import")]
        public int RuleImport;
        [JsonProperty("rule_ldap")]
        public int RuleLdap;
        [JsonProperty("rule_mailcollector")]
        public int RuleMailcollector;
        [JsonProperty("rule_softwarecategories")]
        public int RuleSoftwarecategories;
        [JsonProperty("rule_ticket")]
        public int RuleTicket;
        [JsonProperty("search_config")]
        public int SearchConfig;
        [JsonProperty("shellcommands")]
        public int Shellcommands;
        [JsonProperty("show_group_hardware")]
        public int ShowGroupHardware;
        [JsonProperty("slm")]
        public int Slm;
        [JsonProperty("software")]
        public int Software;
        [JsonProperty("solutiontemplate")]
        public int Solutiontemplate;
        [JsonProperty("state")]
        public int State;
        [JsonProperty("statistic")]
        public int Statistic;
        [JsonProperty("task")]
        public int Task;
        [JsonProperty("taskcategory")]
        public int Taskcategory;
        [JsonProperty("ticket")]
        public int Ticket;
        [JsonProperty("ticketcost")]
        public int Ticketcost;
        [JsonProperty("ticketrecurrent")]
        public int Ticketrecurrent;
        [JsonProperty("ticketvalidation")]
        public int Ticketvalidation;
        [JsonProperty("transfer")]
        public int Transfer;
        [JsonProperty("typedoc")]
        public int Typedoc;
        [JsonProperty("user")]
        public int User;
        [JsonProperty("entities")]
        List<Entity> _entities;       
    }
}