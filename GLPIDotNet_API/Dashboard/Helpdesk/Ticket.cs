using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Attributes;
using GLPIDotNet_API.Base;
using GLPIDotNet_API.Base.GLPI;
using GLPIDotNet_API.Base.Request;
using GLPIDotNet_API.Dashboard.Administration;
using GLPIDotNet_API.Dashboard.Administration.User;
using GLPIDotNet_API.Dashboard.Common;
using GLPIDotNet_API.Dashboard.Helpdesk.LinkTicket;
using GLPIDotNet_API.Exception;
using Newtonsoft.Json;

namespace GLPIDotNet_API.Dashboard.Helpdesk
{
    public class Ticket:Dashboard<Ticket>,IEquatable<Ticket>
    {

        /// <summary>
        /// Конструктор для создания заявки (min)
        /// </summary>
        /// <param name="idLocation"></param>
        /// <param name="idCategory"></param>
        /// <param name="idType"></param>   

        public Ticket(long idLocation,long idCategory,long idType)
        {
            IdLocation = idLocation;
            ItilCategoriesId = idCategory;
            Type = idType;              
        }

        public Ticket()
        {
            
        }

        /// <summary>
        /// Дата создания
        /// </summary>
        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        /// <summary>1
        /// Дата закрытия
        /// </summary>
        [JsonProperty("closedate")]
        public DateTime? CloseDate { get; set; }

        [JsonProperty("solvedate")]
        public DateTime? SolveDate { get; set; }

        /// <summary>
        /// Статус заявки
        /// </summary>
        [JsonProperty("status")]
        public EStatus Status { get; set; }

        /// <summary>
        /// Крайний редактор
        /// </summary>
        [JsonProperty("users_id_lastupdater")]
        public long? UsersIdLastUpdater { get; set; }

        /// <summary>
        /// Исполнитель заявки
        /// </summary>
        [JsonProperty("users_id_recipient")]
        public long? UsersIdRecipient { get; set; }


        [JsonProperty("requesttypes_id")]
        public long? RequestTypesId { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("urgency")]
        public long? Urgency { get; set; }

        [JsonProperty("impact")]
        public long? Impact { get; set; }

        /// <summary>
        /// Приоритет заявки
        /// </summary>
        [JsonProperty("priority")]
        public long? Priority { get; set; }

        [JsonProperty("itilcategories_id")]
        public long? ItilCategoriesId { get; set; }

        [JsonProperty("type")]
        public long? Type { get; set; }

        [JsonProperty("global_validation")]
        public long? GlobalValidation { get; set; }

        [JsonProperty("slas_id_ttr")]
        public long? SlAsIdTtr { get; set; }

        [JsonProperty("slas_id_tto")]
        public long? SlAsIdTto { get; set; }

        [JsonProperty("slalevels_id_ttr")]
        public long? SlaLevelsIdTtr { get; set; }

        [JsonProperty("time_to_resolve")]
        public DateTime? TimeToResolve { get; set; }

        [JsonProperty("time_to_own")]
        public DateTime? TimeToOwn { get; set; }

        [JsonProperty("begin_waiting_date")]
        public DateTime? BeginWaitingDate { get; set; }

        [JsonProperty("sla_waiting_duration")]
        public long? SlaWaitingDuration { get; set; }

        [JsonProperty("ola_waiting_duration")]
        public long? OlaWaitingDuration { get; set; }

        [JsonProperty("olas_id_tto")]
        public long? OlasIdTto { get; set; }

        [JsonProperty("olas_id_ttr")]
        public long? OlasIdTtr { get; set; }

        [JsonProperty("olalevels_id_ttr")]
        public long? OlaLevelsIdTtr { get; set; }

        [JsonProperty("ola_ttr_begin_date")]
        public DateTime? OlaTtrBeginDate { get; set; }

        [JsonProperty("internal_time_to_resolve")]
        public DateTime? InternalTimeToResolve { get; set; }

        [JsonProperty("internal_time_to_own")]
        public DateTime? InternalTimeToOwn { get; set; }

        [JsonProperty("waiting_duration")]
        public long? WaitingDuration { get; set; }

        [JsonProperty("close_delay_stat")]
        public long? CloseDelayStat { get; set; }

        [JsonProperty("solve_delay_stat")]
        public long? SolveDelayStat { get; set; }

        [JsonProperty("takeintoaccount_delay_stat")]
        public long? TakeIntoAccountDelayStat { get; set; }

        [JsonProperty("actiontime")]
        public long? ActionTime { get; set; }

        [JsonProperty("validation_percent")]
        public long? ValidationPercent { get; set; }

        /// <summary>
        /// User recipient
        /// </summary>
        [JsonIgnore,NoLink]
        public User UserRecipient { get;  set; }
        
        [JsonIgnore]
        public RequestType RequestType { get;  set; }
        
        [JsonIgnore]
        public ITILCategory ITILCategory { get; set; }        
        
        // [JsonIgnore]
        // public DocumentItem Document_Item { get; set; }
        
        [JsonIgnore]
        public List<TicketTask> TicketTasks { get;  set;}
        
        [JsonIgnore]
        public List<TicketValidation> TicketValidation { get;  set;}
        
        [JsonIgnore]
        public List<TicketCost> TicketCost { get;  set;}
        
        [JsonIgnore]
        public List<ProblemTicket> Problem_Ticket { get; set; }
        
        [JsonIgnore]
        public List<ChangeTicket> Change_Ticket { get;  set;}
        
        [JsonIgnore]
        public List<ItemTicket> Item_Ticket { get;  set;}
        
        /// <summary>
        /// Список сообщений, который оставил под статусом решенных
        /// </summary>
        [JsonIgnore]
        public List<ITILSolution> ITILSolution { get;  set;}
        
        [JsonIgnore]
        public List<ITILFollowup> ITILFollowup { get;  set;}
        
        [JsonIgnore]
        public List<TicketUser> Ticket_User { get;  set;}
        
        [JsonIgnore]
        public List<GroupTicket> Group_Ticket { get;  set;}
        
        [JsonIgnore]
        public List<SupplierTicket> Supplier_Ticket { get;  set;}
        

        // /// <summary>
        // /// Loader other property
        // /// </summary>
        // /// <param name="glpi"></param>
        // /// <param name="cancel"></param>
        // /// <exception cref="ExceptionCheck"></exception>
        // public async Task Load(Glpi glpi,CancellationToken cancel = default)
        // {
        //     if (Check(glpi)) throw new ExceptionCheck(glpi);
        //     if (UsersIdRecipient > 0)
        //         UserRecipient = await User.GetAsync(glpi, new Parameter() { id = UsersIdRecipient }, cancel);
        //
        //     var properties = GetType()
        //         .GetProperties()
        //         .Where(w =>
        //             w.CustomAttributes
        //                 .Select(s => s.AttributeType.Name)
        //                 .Contains(nameof(JsonIgnoreAttribute)) &&
        //                 w.Name != "UserRecipient" &&
        //                 (
        //                     w.PropertyType == typeof(long) &&
        //                     (long)w.GetValue(this) > 0) ||
        //                     w.GetValue(this) != null);
        //
        //     foreach (var property in properties)
        //     {
        //         Link linkProperty = Links.FirstOrDefault(f => f.Rel == property.Name);
        //         if(linkProperty == null) continue;
        //         string endPoint = string.Join("",
        //             linkProperty.Address.Segments.Except(glpi.Client.BaseAddress!.Segments));
        //         
        //         HttpResponseMessage response = null;
        //
        //
        //         ClientRequest request = new ClientRequest(async () => await glpi.Client.GetAsync(endPoint, cancel),
        //             a => response = a);
        //
        //         glpi.QueueRequest.Enqueue(request);
        //         
        //         while (response == null)
        //         {
        //             if(cancel.IsCancellationRequested) cancel.ThrowIfCancellationRequested();
        //         }
        //
        //         if (response.IsSuccessStatusCode) 
        //             property.SetValue(this,
        //                               JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(cancel),
        //                                                             property.PropertyType));                    
        //     }
        // }

        public enum EStatus
        {
            New = 1,
            InWork = 2,
            InProgress = 3,
            Await = 4,
            Resolved = 5,
            Close = 6
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual string TranlateEStatus(EStatus status) => status switch
        {
            EStatus.New => "Новый",
            EStatus.InWork => "В работе (назначена)",
            EStatus.InProgress => "В работе (Запланирована)",
            EStatus.Await => "Ожидание",
            EStatus.Resolved => "Решена",
            EStatus.Close => "Закрыта",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual EStatus ConverterEStatus(string text) => text switch
        {
            "Новый" => EStatus.New,
            "В работе (назначена)" => EStatus.InWork,
            "В работе (Запланирована)" => EStatus.InProgress,
            "Ожидание" => EStatus.Await,
            "Решена" => EStatus.Resolved,
            "Закрыта" => EStatus.Close,
            _ => throw new NotImplementedException(),
        };


        public bool Equals(Ticket other) =>
            GetHashCode() == other.GetHashCode();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="glpiClientram>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        // public async Task<string> GetDocumentItem(IGlpiClient glpiClient,CancellationToken cancel = default)
        // {
        //     if (glpiClient.Checker()) throw new ExceptionCheck(glpiClient);
        //     Link link = Links.FirstOrDefault(f => f.Rel == "TicketValidation");
        //
        //     if (link == null) throw new System.Exception("Object Link is null");
        //     StringBuilder sb = new StringBuilder();
        //     foreach (var item in Links.Skip(5))
        //     {
        //         HttpResponseMessage response = null;
        //         ClientRequest clientRequest = new ClientRequest(async () => await glpiClient.Client.GetAsync($"{nameof(Ticket)}/{Id}/{item.Rel}", cancel), a => response = a);
        //         glpiClient.QueueRequest.Enqueue(clientRequest);
        //         while (response == null)
        //         {
        //             if (cancel.IsCancellationRequested) cancel.ThrowIfCancellationRequested();
        //         }
        //
        //         if (response.IsSuccessStatusCode) sb.Append(await response.Content.ReadAsStringAsync(cancel));
        //         else
        //             throw new System.Exception(
        //                 $"Status code:{response.StatusCode}\nContext:{response.Content.ReadAsStringAsync(cancel)}");
        //     }
        //
        //     return sb.ToString();            
        // }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(IdEntity);
            hash.Add(IsRecursive);
            hash.Add(Name);
            hash.Add(Comment);
            hash.Add(IdLocation);
            hash.Add(IdUsersTech);
            hash.Add(IdGroupsTech);
            hash.Add(IdManufacturer);
            hash.Add(IsDeleted);
            hash.Add(IsTemplate);
            hash.Add(TemplateName);
            hash.Add(DateMod);
            hash.Add(IdUser);
            hash.Add(IdGroup);
            hash.Add(TicketTco);
            hash.Add(DateCreation);
            hash.Add(IdGroup);
            hash.Add(Date);
            hash.Add(CloseDate);
            hash.Add(SolveDate);
            hash.Add(Status);
            hash.Add(UsersIdLastUpdater);
            hash.Add(UsersIdRecipient);
            hash.Add(RequestTypesId);
            hash.Add(Content);
            hash.Add(Urgency);
            hash.Add(Impact);
            hash.Add(Priority);
            hash.Add(ItilCategoriesId);
            hash.Add(Type);
            hash.Add(GlobalValidation);
            hash.Add(SlAsIdTtr);
            hash.Add(SlAsIdTto);
            hash.Add(SlaLevelsIdTtr);
            hash.Add(TimeToResolve);
            hash.Add(TimeToOwn);
            hash.Add(BeginWaitingDate);
            hash.Add(SlaWaitingDuration);
            hash.Add(OlaWaitingDuration);
            hash.Add(OlasIdTto);
            hash.Add(OlasIdTtr);
            hash.Add(OlaLevelsIdTtr);
            hash.Add(OlaTtrBeginDate);
            hash.Add(InternalTimeToResolve);
            hash.Add(InternalTimeToOwn);
            hash.Add(WaitingDuration);
            hash.Add(CloseDelayStat);
            hash.Add(SolveDelayStat);
            hash.Add(TakeIntoAccountDelayStat);
            hash.Add(ActionTime);
            hash.Add(ValidationPercent);
            return hash.ToHashCode();
        }

        public override string ToString() =>
            Id.ToString();
    }
}
