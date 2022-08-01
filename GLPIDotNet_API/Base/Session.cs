using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GLPIDotNet_API.Base
{
    public class Session
    {
        [JsonProperty("valid_id")]
        public string IdValid { get; set; }

        [JsonProperty("glpi_currenttime")]
        public DateTime? CurrentTimeString { get; set; }

        [JsonProperty("glpi_use_mode")]
        public int? UseMode { get; set; }

        [JsonProperty("glpiID")]
        public long? IdGlpi { get; set; }

        [JsonProperty("glpiis_ids_visible")]
        public string GlpiIsIdsVisible { get; set; }

        [JsonProperty("glpifriendlyname")]
        public string NameFull { get; set; }

        [JsonProperty("glpiname")]
        public string NameGlpi { get; set; }

        [JsonProperty("glpirealname")]
        public string NameReadl { get; set; }

        [JsonProperty("glpifirstname")]
        public string NameFirst { get; set; }

        [JsonProperty("glpidefault_entity")]
        public int? EntityGlpiDefault { get; set; }

        [JsonProperty("glpiextauth")]
        public int? AuthGlpiExt { get; set; }

        [JsonProperty("glpiauthtype")]
        public int? AuthGlpiType { get; set; }

        [JsonProperty("glpiroot")]
        public string GlpiRoot { get; set; }

        [JsonProperty("glpi_plannings")]
        public List<object> GlpiPlannings { get; set; }

        [JsonProperty("glpicrontimer")]
        public long? GlpiCronTimer { get; set; }

        [JsonProperty("glpi_tabs")]
        public List<object> GlpiTabs { get; set; }

        [JsonProperty("glpibackcreated")]
        public string GlpiBackCreated { get; set; }

        [JsonProperty("glpicsv_delimiter")]
        public string GlpiCsvDelimiter { get; set; }

        [JsonProperty("glpidate_format")]
        public string GlpiDateFormat { get; set; }

        [JsonProperty("glpidefault_requesttypes_id")]
        public string IdGlpiDefaultRequestTypes { get; set; }

        [JsonProperty("glpidisplay_count_on_home")]
        public string GlpiDisplayCountHome { get; set; }

        [JsonProperty("glpiduedatecritical_color")]
        public string GlpiDueDateCriticalColor { get; set; }

        [JsonProperty("glpiduedatecritical_less")]
        public string GlpiDueDateCriticalLess { get; set; }

        [JsonProperty("glpiduedatecritical_unit")]
        public string GlpiDueDateCriticalUnit { get; set; }

        [JsonProperty("glpiduedateok_color")]
        public string GlpiDueDateOkColor { get; set; }

        [JsonProperty("glpiduedatewarning_color")]
        public string GlpiDueDateWarningColor { get; set; }

        [JsonProperty("glpiduedatewarning_less")]
        public string GlpiDueDateWarningLess { get; set; }

        [JsonProperty("GlpiDueDateWarningUnit")]
        public string GlpiduedatewarningUnit { get; set; }

        [JsonProperty("glpifollowup_private")]
        public string GlpiFollowUpPrivate { get; set; }

        [JsonProperty("glpikeep_devices_when_purging_item")]
        public string GlpiKeepDevicesWhenPurgingItem { get; set; }

        [JsonProperty("glpilanguage")]
        public string GlpiLanguage { get; set; }

        [JsonProperty("glpilist_limit")]
        public string GlpiListLimit { get; set; }

        [JsonProperty("glpilock_autolock_mode")]
        public string GlpiLockAutoLockMode { get; set; }

        [JsonProperty("glpilock_directunlock_notification")]
        public string GlpiLockDirectUnlockNotification { get; set; }

        [JsonProperty("glpinames_format")]
        public string GlpiNamesFormat { get; set; }

        [JsonProperty("glpinotification_to_myself")]
        public string GlpiNotificationToMyself { get; set; }

        [JsonProperty("glpinumber_format")]
        public string GlpiNumberFormat { get; set; }

        [JsonProperty("glpipdffont")]
        public string GlpiPdfFont { get; set; }

        [JsonProperty("glpipriority_1")]
        public string GlpiPriority1 { get; set; }

        [JsonProperty("glpipriority_2")]
        public string GlpiPriority2 { get; set; }

        [JsonProperty("glpipriority_3")]
        public string GlpiPriority3 { get; set; }

        [JsonProperty("glpipriority_4")]
        public string GlpiPriority4 { get; set; }

        [JsonProperty("glpipriority_5")]
        public string GlpiPriority5 { get; set; }

        [JsonProperty("glpipriority_6")]
        public string GlpiPriority6 { get; set; }

        [JsonProperty("glpirefresh_views")]
        public string GlpiRefreshViews { get; set; }

        [JsonProperty("glpiset_default_tech")]
        public string GlpiSetDefaultTech { get; set; }

        [JsonProperty("glpiset_default_requester")]
        public string GlpiSetDefaultRequester { get; set; }

        [JsonProperty("glpishow_count_on_tabs")]
        public string GlpiShowCountTabs { get; set; }

        [JsonProperty("glpishow_jobs_at_login")]
        public string GlpiShowJobsLogin { get; set; }

        [JsonProperty("glpitask_private")]
        public string GlpiTaskPrivate { get; set; }

        [JsonProperty("glpitask_state")]
        public string GlpiTaskState { get; set; }

        [JsonProperty("glpiuse_flat_dropdowntree")]
        public string GlpiUseFlatDropdownTree { get; set; }

        [JsonProperty("glpilayout")]
        public string GlpiLayout { get; set; }

        [JsonProperty("glpipalette")]
        public string GlpiPalette { get; set; }

        [JsonProperty("glpihighcontrast_css")]
        public string GlpiHighContrastCss { get; set; }

        [JsonProperty("glpidefault_dashboard_central")]
        public string GlpiDefaultDashboardCentral { get; set; }

        [JsonProperty("glpidefault_dashboard_assets")]
        public string GlpiDefaultDashboardAssets { get; set; }

        [JsonProperty("glpidefault_dashboard_helpdesk")]
        public string GlpiDefaultDashboardHelpdesk { get; set; }

        [JsonProperty("glpidefault_dashboard_mini_ticket")]
        public string GlpiDefaultDashboardMiniTicket { get; set; }

        [JsonProperty("glpi_dropdowntranslations")]
        public List<object> GlpiDropdownTranslations { get; set; }

        [JsonProperty("glpipluralnumber")]
        public int? GlpiPluralNumber { get; set; }
        
        public override string ToString() =>
            string.Join("\n", GetType().GetProperties().Select(s => 
            {
                var t = s.PropertyType;
                string v;
                if (t.IsGenericType) 
                {
                    IList<Object> val = s.GetValue(this) as IList<object> ?? new List<Object>();
                    v = string.Join(", ", val);
                } 
                else v = s.GetValue(this)?.ToString() ?? "*NULL*";
                return $"{t.Name} {s.Name} = {v}";
                
            }));
        
    }
}
