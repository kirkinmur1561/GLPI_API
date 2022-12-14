using GLPIDotNet_API.Base;
using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Attributes;
using GLPIDotNet_API.Base.GLPI;
using GLPIDotNet_API.Base.Request;
using GLPIDotNet_API.Exception;

namespace GLPIDotNet_API.Dashboard.Administration.User
{
    public class User:Dashboard<User>
    {
        public User()
        {
            
        }

        [JsonProperty("password_last_update")]
        public string PasswordLastUpdate { get; set; }
        
        /// <summary>
        /// Первый телефон
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }
        
        /// <summary>
        /// Второй телефон
        /// </summary>
        [JsonProperty("phone2")]
        public string Phone2 { get; set; }
        
        /// <summary>
        /// Мобильный телефон
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        
        /// <summary>
        /// Фамилия
        /// </summary>
        [JsonProperty("realname")]
        public string Realname { get; set; }
        
        /// <summary>
        /// Имя + Отчество
        /// </summary>
        [JsonProperty("firstname")]
        public string Firstname { get; set; }
        
        [JsonProperty("language")]
        public string Luse_modeanguage{get;set;}
        [JsonProperty("use_mode")]
        public int UseMode{get;set;}
        [JsonProperty("list_limit")]
        public object ListLimit{get;set;}
        
        /// <summary>
        /// Активен ли пользователь
        /// </summary>
        [JsonProperty("is_active")]
        public bool? IsActive{get;set;}
        
        [JsonProperty("auths_id")]
        public long? AuthsId{get;set;}
        [JsonProperty("authtypel")]
        public int Authtypel{get;set;}
        [JsonProperty("last_logi")]
        public DateTime? LastLogi{get;set;}
        [JsonProperty("date_sync")]
        public DateTime? DateSync{get;set;}
        
        /// <summary>
        /// Id Профиль по умолчанию
        /// </summary>
        [JsonProperty("profiles_id")]
        public long? IdProfiles{get;set;}
        
        /// <summary>
        /// Id Должности
        /// </summary>
        [JsonProperty("usertitles_id")]
        public long? IdUsertitles{get;set;}
        
        /// <summary>
        /// Id Категории
        /// </summary>
        [JsonProperty("usercategories_id")]
        public long IdUsercategories{get;set;}
        
        [JsonProperty("date_format")]
        public object DateFormat{get;set;}
        [JsonProperty("number_format")]
        public object NumberFormat{get;set;}
        [JsonProperty("names_format")]
        public object NamesFormat{get;set;}
        [JsonProperty("csv_delimiter")]
        public object CSVDelimiter{get;set;}
        [JsonProperty("is_ids_visible")]
        public bool? IsIdsVisible{get;set;}
        [JsonProperty("use_flat_dropdowntree")]
        public object UseFlatDropdowntree{get;set;}
        [JsonProperty("show_jobs_at_login")]
        public object ShowJobsAtLogin{get;set;}
        [JsonProperty("priority_1")]
        public object Priority1{get;set;}
        [JsonProperty("priority_2")]
        public object Priority2{get;set;}
        [JsonProperty("priority_3")]
        public object Priority3{get;set;}
        [JsonProperty("priority_4")]
        public object Priority4{get;set;}
        [JsonProperty("priority_5")]
        public object Priority5{get;set;}
        [JsonProperty("priority_6")]
        public object Priority6{get;set;}
        [JsonProperty("followup_private")]
        public object FollowupPrivate{get;set;}
        [JsonProperty("task_private")]
        public object TaskPrivate{get;set;}
        [JsonProperty("default_requesttypes_id")]
        public long? IdDefaultRequesttypes{get;set;}
        [JsonProperty("password_forget_token")]
        public DateTime? PasswordForgetToken{get;set;}
        [JsonProperty("password_forget_token_date")]
        public DateTime? PasswordForgetTokenDate{get;set;}
        [JsonProperty("user_dn")]
        public string UserDn{get;set;}
        
        /// <summary>
        /// Административный номер
        /// </summary>
        [JsonProperty("registration_number")]
        public object RegistrationNumber{get;set;}
        
        [JsonProperty("show_count_on_tabs")]
        public object ShowCountOnTabs{get;set;}
        [JsonProperty("refresh_views")]
        public object RefreshViews{get;set;}
        [JsonProperty("set_default_tech")]
        public object SetDefaultTech{get;set;}
        [JsonProperty("personal_token_date")]
        public DateTime? PersonalTokenDate{get;set;}
        [JsonProperty("api_token_date")]
        public DateTime? ApiTokenDate{get;set;}
        [JsonProperty("cookie_token_date")]
        public DateTime? CookieTokenDate{get;set;}
        [JsonProperty("display_count_on_home")]
        public object DisplayCountOnHome{get;set;}
        [JsonProperty("notification_to_myself")]
        public object NotificationToMyself{get;set;}
        [JsonProperty("duedateok_color")]
        public object DuedateokColor{get;set;}
        [JsonProperty("duedatewarning_color")]
        public object DuedatewarningColor{get;set;}
        [JsonProperty("duedatecritical_color")]
        public object DuedatecriticalColor{get;set;}
        [JsonProperty("duedatewarning_less")]
        public object DuedatewarningLess{get;set;}
        [JsonProperty("duedatecritical_less")]
        public object DuedatecriticalLess{get;set;}
        [JsonProperty("duedatewarning_unit")]
        public object DuedatewarningUnit{get;set;}
        [JsonProperty("duedatecritical_unit")]
        public object DuedatecriticalUnit{get;set;}
        [JsonProperty("display_options")]
        public object DisplayOptions{get;set;}
        [JsonProperty("is_deleted_ldap")]
        public bool? IsDeletedLDAP{get;set;}
        [JsonProperty("pdffont")]
        public object PDFfont{get;set;}
        [JsonProperty("picture")]
        public object Picture{get;set;}
        [JsonProperty("begin_date")]
        public DateTime? BeginDate{get;set;}
        [JsonProperty("end_date")]
        public DateTime? EndDate{get;set;}
        [JsonProperty("keep_devices_when_purging_item")]
        public object KeepDevicesWhenPurgingItem{get;set;}
        [JsonProperty("privatebookmarkorder")]
        public object Privatebookmarkorder{get;set;}
        [JsonProperty("backcreated")]
        public object Backcreated{get;set;}
        [JsonProperty("task_state")]
        public object TaskState{get;set;}
        [JsonProperty("palette")]
        public object Palette{get;set;}
        [JsonProperty("page_layout")]
        public object PageLayout{get;set;}
        [JsonProperty("fold_menu")]
        public object FoldMenu{get;set;}
        [JsonProperty("fold_search")]
        public object FoldSearch{get;set;}
        [JsonProperty("savedsearches_pinned")]
        public object SavedsearchesPinned{get;set;}
        [JsonProperty("timeline_order")]
        public object TimelineOrder{get;set;}
        [JsonProperty("itil_layout")]
        public object ItilLayout{get;set;}
        [JsonProperty("richtext_layout")]
        public object RichtextLayout{get;set;}
        [JsonProperty("set_default_requester")]
        public object SetDefaultRequester{get;set;}
        [JsonProperty("lock_autolock_mode")]
        public object LockAutolockMode{get;set;}
        [JsonProperty("lock_directunlock_notification")]
        public object LockDirectunlockNotification{get;set;}
        [JsonProperty("highcontrast_css")]
        public object HighcontrastCSS{get;set;}
        [JsonProperty("plannings")]
        public object Plannings{get;set;}
        [JsonProperty("sync_field")]
        public string SyncField{get;set;}
        [JsonProperty("users_id_supervisor")]
        public long? IdUserSupervisor{get;set;}
        /// <summary>
        /// Часовой пояс
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone{get;set;}
        [JsonProperty("default_dashboard_central")]
        public object DefaultDashboardCentral{get;set;}
        [JsonProperty("default_dashboard_assets")]
        public object DefaultDashboardAssets{get;set;}
        [JsonProperty("default_dashboard_helpdesk")]
        public object DefaultDashboardHelpdesk{get;set;}
        [JsonProperty("default_dashboard_mini_ticket")]
        public object DefaultDashboardMiniTicket{get;set;}
        [JsonProperty("default_central_tab")]
        public object DefaultCentralTab{get;set;}
        [JsonProperty("nickname")]
        public string Nickname{get;set;}
        
        [JsonIgnore]
        public UserTitle UserTitle { get; set; }        
        
        [JsonIgnore]
        public AuthLDAP AuthLDAP { get; set; }
        
        [JsonIgnore]
        public UserCategory UserCategory { get; set; }        
               
        [JsonIgnore]
        public Profile.Profile Profile { get; set; }        
        
        
        //[JsonIgnore]
        //public Document_Item Document_Item { get; set; }       

        /// <summary>
        /// Получить изображение пользователя
        /// </summary>
        /// <exception cref="Exception"></exception>
        // public async Task GetPicture(IGlpiClient glpiClient, CancellationToken cancel = default,int? timeOutRequest = 200)
        // {
        //     if (glpiClient.Checker()) throw new ExceptionCheck(glpiClient);
        //     if (Id == null) throw new System.Exception("Id is null");
        //
        //     HttpResponseMessage response = null;
        //     ClientRequest clientRequest = new ClientRequest(async () => await glpiClient.Client.GetAsync($"User/{Id}/Picture", cancel), a => response = a);
        //
        //     glpiClient.QueueRequest.Enqueue(clientRequest);
        //
        //     if (timeOutRequest != null)
        //     {
        //         int timeOut = timeOutRequest > 0 ? (int)timeOutRequest : 200;
        //         while (response == null)
        //         {
        //             await Task.Delay(timeOut, cancel);
        //             if (cancel.IsCancellationRequested)
        //             {
        //                 cancel.ThrowIfCancellationRequested();
        //             }
        //         }
        //     }
        //     else
        //     {
        //         while (response == null)
        //         {                    
        //             if (cancel.IsCancellationRequested)
        //             {
        //                 cancel.ThrowIfCancellationRequested();
        //             }
        //         }
        //     }
        //
        //     if (response.IsSuccessStatusCode) return;
        //     throw new System.Exception($"status code:{response.StatusCode} content:{await response.Content.ReadAsStringAsync(cancel)}");
        // }
        //
        //
        // /// <summary>
        // /// Получить изображение пользователя
        // /// </summary>
        // /// <exception cref="Exception"></exception>
        // public async Task GetPicture(IGlpiClient glpiMulti, IGlpiClient glpiClient, CancellationToken cancel = default,int? timeOutRequest = 200)
        // {
        //     if(glpiMulti.Checker()) throw new ExceptionCheck(glpiClient);
        //     if (glpiClient.Checker()) throw new ExceptionCheck(glpiClient);
        //     if (Id == null) throw new System.Exception("Id is null");
        //
        //     HttpResponseMessage response = null;
        //     MultiRequest multiRequest =
        //         new MultiRequest(async () => await glpiClient.Client.GetAsync($"User/{Id}/Picture", cancel),
        //             a => response = a, glpiClient);
        //
        //     glpiMulti.QueueRequest.Enqueue(multiRequest);
        //
        //     if (timeOutRequest != null)
        //     {
        //         int timeOut = timeOutRequest > 0 ? (int)timeOutRequest : 200;
        //         while (response == null)
        //         {
        //             await Task.Delay(timeOut, cancel);
        //             if (cancel.IsCancellationRequested)
        //             {
        //                 cancel.ThrowIfCancellationRequested();
        //             }
        //         }
        //     }
        //     else
        //     {
        //         while (response == null)
        //         {                    
        //             if (cancel.IsCancellationRequested)
        //             {
        //                 cancel.ThrowIfCancellationRequested();
        //             }
        //         }
        //     }            
        //
        //     if (response.IsSuccessStatusCode) return;
        //     throw new System.Exception($"status code:{response.StatusCode} content:{await response.Content.ReadAsStringAsync(cancel)}");
        // }
        
    }
}
