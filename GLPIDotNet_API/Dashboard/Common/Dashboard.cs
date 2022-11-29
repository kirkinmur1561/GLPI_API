using GLPIDotNet_API.Dashboard.Search;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Attributes;
using GLPIDotNet_API.Base.GLPI;
using GLPIDotNet_API.Base.Request;
using GLPIDotNet_API.Dashboard.Administration;
using GLPIDotNet_API.Dashboard.Administration.User;
using GLPIDotNet_API.Dashboard.Assets.LinkComputer;
using Range = GLPIDotNet_API.Dashboard.Search.Range;
using GLPIDotNet_API.Exception;
using Microsoft.VisualBasic;

namespace GLPIDotNet_API.Dashboard.Common
{
    public abstract class Dashboard<TD>:IDashboard,IComparable<TD> where TD: IDashboard
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("entities_id")]
        public long? IdEntity
        {
            get => _idEntity;
            set
            {
                if (value == _idEntity) return;
                _idEntity = value;
                Change();
            }
        }

        private long? _idEntity;

        [JsonProperty("is_recursive")]
        public bool? IsRecursive
        {
            get => _isRecursive;
            set
            {
                if (value == _isRecursive) return;
                _isRecursive = value;
                Change();
            }
        }

        private bool? _isRecursive;

        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                Change();
            }
        }

        private string _name;

        [JsonProperty("comment")]
        public string Comment
        {
            get => _comment;
            set
            {
                if (value == _comment) return;
                _comment = value;
                Change();
            }
        }

        private string _comment;
        
        [JsonProperty("locations_id")]
        public long? IdLocation
        {
            get => _idLocation;
            set
            {
                if (value == _idLocation) return;
                _idLocation = value;
                Change();
            }
        }

        private long? _idLocation;


        [JsonProperty("users_id_tech")]
        public long? IdUsersTech
        {
            get =>_idUsersTech;
            set
            {
                if (value == _idUsersTech) return;
                _idUsersTech = value;
                Change();
            }
        }

        private long? _idUsersTech;

        [JsonProperty("groups_id_tech")]
        public long? IdGroupsTech
        {
            get=>_idGroupsTech;
            set
            {
                if (value == _idGroupsTech) return;
                _idGroupsTech = value;
                Change();
            }
        }

        private long? _idGroupsTech;

        [JsonProperty("manufacturers_id")]
        public long? IdManufacturer
        {
            get => _idManufacturer;
            set
            {
                if (value == _idManufacturer) return;
                _idManufacturer = value;
                Change();
            }
         }
        
        private long? _idManufacturer;

        [JsonProperty("is_deleted")]
        public bool? IsDeleted
        {
            get => _isDeleted;
            set
            {
                if (value == _isDeleted) return;
                _isDeleted = value;
                Change();
            }
         }
        
        private bool? _isDeleted;

        [JsonProperty("is_template")]
        public bool? IsTemplate 
        { 
            get =>_isTemplate;
            set
            {
                if (value == _isTemplate) return;
                _isTemplate = value;
                Change();
            }
         }
        
        private bool? _isTemplate;

        [JsonProperty("template_name")]
        public string TemplateName
        {
            get => _templateName;
            set
            {
                if (value == _templateName) return;
                _templateName = value;
                Change();
            }
         }
        
        private string _templateName;

        [JsonProperty("date_mod")]
        public DateTime? DateMod
        {
            get => _dateMod;
            set
            {
                if (value == _dateMod) return;
                _dateMod = value;
                Change();
            }
         }
        
        private DateTime? _dateMod;

        [JsonProperty("users_id")]
        public long? IdUser
        {
            get => _idUser;
            set
            {
                if (value == _idUser) return;
                _idUser = value;
                Change();
            }
         }
        
        private long? _idUser;

        [JsonProperty("groups_id")]
        public long? IdGroup
        {
            get => _idGroup;
            set
            {
                if (value == _idGroup) return;
                _idGroup = value;
                Change();
            }
         }
        
        private long? _idGroup;

        [JsonProperty("ticket_tco")]
        public double? TicketTco
        {
            get => _ticketTco;
            set
            {
                if (value == _ticketTco) return;
                _ticketTco = value;
                Change();
            }
         }
        
        private double? _ticketTco;

        [JsonProperty("date_creation")]
        public DateTime? DateCreation
        {
            get => _dateCreation;
            set
            {
                if (value == _dateCreation) return;
                _dateCreation = value;
                Change();
            }
         }
        
        private DateTime? _dateCreation;

        [JsonProperty("links")]
        public List<Link> Links { get; set; }

        [BaseEntity]
        public User User { get; set; }        
        
        [BaseEntity]
        public Group Group { get; set; }        
        
        [BaseEntity]
        public Manufacturer Manufacturer { get; set; }        
        
        [BaseEntity]
        public Location Location { get; set; }
        
        [BaseEntity]
        public Entity Entity { get; set; }


        public Dictionary<string, object> ChangeProperty { get; } = new Dictionary<string, object>();
            
            

        public void Change([CallerMemberName] string str = "")
        {
            PropertyInfo pr = GetType().GetProperty(str);
            if(pr == null) return;
            
            string propertyName = pr.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName;
            if (string.IsNullOrEmpty(propertyName)) 
                throw new System.Exception("Свойство должено содержать атрибут Newton.Json" +
                                           " JsonPropertyAttribute и поле name не должно быть пустым");
            object value = pr.GetValue(this);

            if (ChangeProperty.ContainsKey(propertyName)) ChangeProperty[propertyName] = value ?? "";
            else ChangeProperty.Add(propertyName, value ?? "");
        }


        #region Single

         /// <summary>
        /// Получить объект D в формате JSON
        /// </summary>
        /// <param name="clt"> подключенный объект к GLPI</param>
        /// <param name="parameter">Параметры запроса</param>
        /// <param name="cancel">Принудительная остановка процесса</param>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="TimeoutException"></exception>
        /// <exception cref="Exception"></exception>       
        public static async Task<string> GetJson(
            IGlpiClient clt,
            Parameter parameter,
            CancellationToken cancel = default)
        {
            if (clt.Checker())      throw new ExceptionCheck(clt);
            if (clt.IsClone)        throw new System.Exception("Объект не должен быть клоном");
            if (parameter == null)  throw new System.Exception("Error parameter.");
            
            IGlpiClient client = (IGlpiClient)clt.Clone();
            client.SetHeaderDefault();
            
            HttpResponseMessage response = null;

            clt.QueueRequest.Enqueue(new ClientRequest(
                async () => await client.Client.GetAsync(string.Join("", typeof(TD).Name, parameter), cancel),
                w => response = w.Response));

            var timeSpan = DateTime.Now + TimeSpan.FromSeconds(client.TimeOut);            
            
            while (response == null) 
            {                
                if (cancel.IsCancellationRequested)                
                    cancel.ThrowIfCancellationRequested();                

                if (timeSpan < DateTime.Now) 
                    throw new TimeoutException("Привышено время ожидания ответа от сервера!");
            }

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync(cancel);
            
            throw new System.Exception($"status code:{response.StatusCode} " +
                                       $"content:{await response.Content.ReadAsStringAsync(cancel)}");
        }


        /// <summary>
        /// Загружает объекты с атрибутом BaseEntity
        /// </summary>
        /// <param name="clt"></param>
        /// <param name="cancel"></param>
        /// <exception cref="ExceptionCheck"></exception>
        public virtual async Task LoadBaseEntity(IGlpiClient clt, CancellationToken cancel = default)
        {
            if (clt.Checker())      throw new ExceptionCheck(clt);
            if (clt.IsClone)        throw new System.Exception("Объект не должен быть клоном");
            
            IGlpiClient client = (IGlpiClient)clt.Clone();
            client.SetHeaderDefault();

            int iteration = 0;            
            List<ClientResponse> responseMessages = new List<ClientResponse>();            

            foreach (var entity in GetType().GetProperties()
                         .Where(w => w.GetCustomAttributes(typeof(BaseEntityAttribute), true).Any()))
            {
                long? id = (long?)GetType()
                    .GetProperty(string.Join("", "Id", entity.Name))
                    ?.GetValue(this);

                if (id == null) continue;

                clt.QueueRequest.Enqueue(
                    new ClientRequest(
                        async () => await client.Client.GetAsync(string.Join("/", entity.Name, id), cancel),
                        response => responseMessages.Add(response), null, entity));
                
                iteration++;
            }
            
            var timeSpan = DateTime.Now + TimeSpan.FromSeconds(client.TimeOut);            
            
            while (responseMessages.Count != iteration) 
            {                
                if (cancel.IsCancellationRequested)                
                    cancel.ThrowIfCancellationRequested();                

                if (timeSpan < DateTime.Now) 
                    throw new TimeoutException("Привышено время ожидания ответа от сервера!");
            }
           

            foreach (ClientResponse response in responseMessages
                         .Where(w => w.Response.IsSuccessStatusCode))
                response
                    .RequestedProperty
                    .SetValue(this,
                        JsonConvert.DeserializeObject(await response.Response.Content.ReadAsStringAsync(cancel),
                            response.RequestedProperty.PropertyType));
        }
        
        /// <summary>
        /// Получить объект типа TD
        /// </summary>
        /// <param name="clt">Основное подключение к glpi</param>
        /// <param name="parameter">Параметры поиска</param>
        /// <param name="cancel"></param>
        /// <exception cref="JsonException"></exception>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task<TD> GetAsync(IGlpiClient clt, Parameter parameter,CancellationToken cancel = default)
        {
            if (clt.Checker()) throw new ExceptionCheck(clt);           
            clt.SetHeaderDefault();            
            
            if (parameter?.id is null or < 0) throw new System.Exception("Error parameter.");
            try
            {
                return JsonConvert.DeserializeObject<TD>(await GetJson(clt, parameter, cancel));
            }
            catch (TimeoutException tr)
            {
                throw;
            }
            catch
            {
                throw new System.Exception("Json value null");
            }            
        }        
        
        /// <summary>
        /// Поиск объектов типа D
        /// </summary>
        /// <param name="clt"></param>
        /// <param name="criterias"></param>
        /// <param name="parameter"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="TimeoutException"></exception>
        public static async Task<ResponseSearch> GetAsync(
            IGlpiClient clt,
            IEnumerable<Criteria> criterias,
            Parameter parameter = null, 
            CancellationToken cancel = default)
        {
            if (clt.Checker())      throw new ExceptionCheck(clt);
            if (clt.IsClone)        throw new System.Exception("Объект не должен быть клоном");
            
            IGlpiClient client = (IGlpiClient)clt.Clone();
            client.SetHeaderDefault();
            
            HttpResponseMessage response = null;
            ClientRequest clientRequest;


            if (parameter == null)
                clientRequest = new ClientRequest(
                    async () => await client.Client.GetAsync($"search" +
                                                             $"/{typeof(TD).Name}" +
                                                             $"?{Criteria.GetURI(criterias)}",
                        cancel),
                    a => response = a.Response);
            else
                clientRequest = new ClientRequest(
                    async () => await client.Client.GetAsync(
                        $"search/{typeof(TD).Name}?{Criteria.GetURI(criterias)}&{parameter}", cancel),
                    a => response = a.Response);
        
            clt.QueueRequest.Enqueue(clientRequest);
        
            var timeSpan = DateTime.Now + TimeSpan.FromSeconds(client.TimeOut);            
            
            while (response == null) 
            {                
                if (cancel.IsCancellationRequested)                
                    cancel.ThrowIfCancellationRequested();                

                if (timeSpan < DateTime.Now) 
                    throw new TimeoutException("Привышено время ожидания ответа от сервера!");
            }
        
            ResponseSearch seatchStart;
            ResponseSearch seatchEnd;

            if (!response.IsSuccessStatusCode)
                throw new System.Exception(
                    $"Status code:{response.StatusCode} " +
                    $"content?:{await response.Content.ReadAsStringAsync(cancel)}");
            {
                seatchStart = 
                    JsonConvert
                        .DeserializeObject<ResponseSearch>(await response.Content.ReadAsStringAsync(cancel));
                
                if (seatchStart == null || seatchStart.Count >= seatchStart.TotalCount) return seatchStart;
                HttpResponseMessage responseSearchEnd = null;
                if (parameter == null)
                    clt.QueueRequest.Enqueue(new ClientRequest(
                        async () => await client.Client.GetAsync(
                            $"search" +
                            $"/{typeof(TD).Name}" +
                            $"?{Criteria.GetURI(criterias)}" +
                            $"&{new Parameter { range = new Range(0, seatchStart.TotalCount) }}",
                            cancel), 
                        a => responseSearchEnd = a.Response));
                else
                {
                    parameter.range = new Range(0, seatchStart.TotalCount);
                    clt.QueueRequest.Enqueue(
                        new ClientRequest(
                            async () => 
                                await client
                                    .Client
                                    .GetAsync($"search" +
                                              $"/{typeof(TD).Name}" +
                                              $"?{Criteria.GetURI(criterias)}" +
                                              $"&{parameter}", cancel), 
                            a => responseSearchEnd = a.Response));
                }
                
                timeSpan = DateTime.Now + TimeSpan.FromSeconds(client.TimeOut);  
                
                while (responseSearchEnd == null)
                {
                    if (cancel.IsCancellationRequested) cancel.ThrowIfCancellationRequested();
                    
                    if (timeSpan < DateTime.Now) 
                        throw new TimeoutException("Привышено время ожидания ответа от сервера!");
                }

                if (responseSearchEnd.IsSuccessStatusCode)
                    seatchEnd =
                        JsonConvert
                            .DeserializeObject<ResponseSearch>(
                                await responseSearchEnd.Content.ReadAsStringAsync(cancel));
                else throw 
                    new System.Exception($"Status code:{response.StatusCode} " +
                                         $"content?:{await response.Content.ReadAsStringAsync(cancel)}");
        
                return seatchEnd;
            }

        }
        
        
        /// <summary>
        /// Получить список объектов D
        /// </summary>
        /// <param name="glpiClient"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionCheck"></exception>
        public static async Task<string> GetEnumerableJson(
            IGlpiClient glpiClient, 
            CancellationToken cancel = default)=>        
             glpiClient.Checker()
                ? throw new ExceptionCheck(glpiClient)
                : JsonConvert.SerializeObject(await GetEnumerable(glpiClient, cancel));
        
        
        /// <summary>
        /// Get date from uri
        /// </summary>
        /// <param name="clt"></param>
        /// <param name="endPoint"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="TimeoutException"></exception>
        public static async Task<string> GetJsonFromUri(IGlpiClient clt, string endPoint, CancellationToken cancel = default)
        {            
            if (clt.Checker())      throw new ExceptionCheck(clt);
            if (clt.IsClone)        throw new System.Exception("Объект не должен быть клоном");
            
            IGlpiClient client = (IGlpiClient)clt.Clone();
            client.SetHeaderDefault();           
        
            HttpResponseMessage response = null;
            ClientRequest req = new ClientRequest(async () => await client.Client.GetAsync(endPoint, cancel),
                r => response = r.Response);
            clt.QueueRequest.Enqueue(req);

            var timeSpan = DateTime.Now + TimeSpan.FromSeconds(client.TimeOut);  
            
            while (response == null)
            {
                if (cancel.IsCancellationRequested)
                    cancel.ThrowIfCancellationRequested();
                
                if (timeSpan < DateTime.Now) 
                    throw new TimeoutException("Привышено время ожидания ответа от сервера!");
            }
        
            if (response.IsSuccessStatusCode) return await response.Content.ReadAsStringAsync(cancel);
            throw new System.Exception(
                $"Status code:{response.StatusCode} " +
                $"content?:{await response.Content.ReadAsStringAsync(cancel)}");
        }
        
        /// <summary>
        /// Получить список объектов D
        /// </summary>
        /// <param name="clt"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="TimeoutException"></exception>
        public static async Task<IEnumerable<TD>> GetEnumerable(IGlpiClient clt,CancellationToken cancel = default)
        {
            if (clt.Checker())      throw new ExceptionCheck(clt);
            if (clt.IsClone)        throw new System.Exception("Объект не должен быть клоном");
            
            IGlpiClient client = (IGlpiClient)clt.Clone();
            client.SetHeaderDefault();

            HttpResponseMessage responsEnd = null;
            
            ClientRequest clientRequestEnd = new ClientRequest(async () =>
                    await client.Client.GetAsync($"{typeof(TD).Name}" +
                                                 $"?{new Parameter { order = Parameter.EOrder.DESC }}",
                        cancel),
                a => responsEnd = a.Response);
            
            clt.QueueRequest.Enqueue(clientRequestEnd);
        
            var timeSpan = DateTime.Now + TimeSpan.FromSeconds(client.TimeOut);  
            
            while (responsEnd == null)
            {
                if (cancel.IsCancellationRequested)
                    cancel.ThrowIfCancellationRequested();
                
                if (timeSpan < DateTime.Now) 
                    throw new TimeoutException("Привышено время ожидания ответа от сервера!");
            }

            IEnumerable<TD> end = responsEnd.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<TD>>(await responsEnd.Content.ReadAsStringAsync(cancel))
                : throw new System.Exception("Error in read response (end collection)");

            end?.Reverse();
        
            HttpResponseMessage responseMiddle = null;
            
            ClientRequest clientRequest =
                new ClientRequest(
                    async () => 
                        await client.Client.GetAsync($"{typeof(TD).Name}" +
                                                     $"?{new Parameter { range = new Range(0, end?.Last().Id ?? 50) }}", cancel),
                    a => responseMiddle = a.Response);
            
            clt.QueueRequest.Enqueue(clientRequest);
            
            timeSpan = DateTime.Now + TimeSpan.FromSeconds(client.TimeOut);  
            
            while (responseMiddle == null)
            {
                if (cancel.IsCancellationRequested)
                    cancel.ThrowIfCancellationRequested();
                
                if (timeSpan < DateTime.Now) 
                    throw new TimeoutException("Привышено время ожидания ответа от сервера!");
            }

            return responseMiddle.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<TD>>(await responseMiddle.Content.ReadAsStringAsync(cancel))
                : throw new System.Exception("Error in read response (middle collection)");                   
        }

       
        
        /// <summary>
        /// добавляет объект D в коллекцию GLPI
        /// </summary>
        /// <param name="clt"></param>
        /// <param name="ds"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="TimeoutException"></exception>
        public static async Task<IEnumerable<TD>> AddItem(IGlpiClient clt,IEnumerable<TD> ds, CancellationToken cancel = default)
        {
            if (clt.Checker())      throw new ExceptionCheck(clt);
            if (clt.IsClone)        throw new System.Exception("Объект не должен быть клоном");
            
            IGlpiClient client = (IGlpiClient)clt.Clone();
            client.SetHeaderDefault();
            
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };


            StringContent content = new StringContent(JsonConvert.SerializeObject(new { input = ds },Formatting.Indented, settings), Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            ClientRequest clientRequest = new ClientRequest(async () => await client.Client.PostAsync(typeof(TD).Name, content,cancel), a => response = a.Response);
            clt.QueueRequest.Enqueue(clientRequest);
        
            var timeSpan = DateTime.Now + TimeSpan.FromSeconds(client.TimeOut);  
            
            while (response == null)
            {
                if (cancel.IsCancellationRequested)
                    cancel.ThrowIfCancellationRequested();
                
                if (timeSpan < DateTime.Now) 
                    throw new TimeoutException("Привышено время ожидания ответа от сервера!");
            }

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<TD>>(await response.Content.ReadAsStringAsync(cancel))
                : throw new System.Exception(
                    $"Status code: {response.StatusCode} content: {await response.Content.ReadAsStringAsync(cancel)}");
        }

        
        public static async Task<IEnumerable<ResponseToChange>> UpdateItem(
            IGlpiClient clt,
            List<TD> ds,
            CancellationToken cancel = default)
        {
            if (clt.Checker())      throw new ExceptionCheck(clt);
            if (clt.IsClone)        throw new System.Exception("Объект не должен быть клоном");
            
            IGlpiClient client = (IGlpiClient)clt.Clone();
            client.SetHeaderDefault();
            
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            List<Dictionary<string, object>> kv = new List<Dictionary<string, object>>();
            for (int index = 0; index < ds.Count(); index++)
            {
                var q = ds[index].ChangeProperty;
                q.Add("id", ds[index].Id);
                kv.Add(q);
            }

            StringContent content = new StringContent(JsonConvert.SerializeObject(new { input = kv },Formatting.Indented, settings), Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            ClientRequest clientRequest = new ClientRequest(async () => await client.Client.PutAsync(typeof(TD).Name, content,cancel), a => response = a.Response);
            clt.QueueRequest.Enqueue(clientRequest);
        
            var timeSpan = DateTime.Now + TimeSpan.FromSeconds(client.TimeOut);  
            
            while (response == null)
            {
                if (cancel.IsCancellationRequested)
                    cancel.ThrowIfCancellationRequested();
                
                if (timeSpan < DateTime.Now) 
                    throw new TimeoutException("Привышено время ожидания ответа от сервера!");
            }

            return response.IsSuccessStatusCode
                ? ResponseToChange.ParseItem(await response.Content.ReadAsStringAsync(cancel))
                : throw new System.Exception(
                    $"Status code: {response.StatusCode} content: {await response.Content.ReadAsStringAsync(cancel)}");
        }

        public async Task<ResponseToChange> Update(
            IGlpiClient clt,
            CancellationToken cancel = default)
        {
            if (clt.Checker())      throw new ExceptionCheck(clt);
            if (clt.IsClone)        throw new System.Exception("Объект не должен быть клоном");
            
            IGlpiClient client = (IGlpiClient)clt.Clone();
            client.SetHeaderDefault();
            
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            HttpResponseMessage response = null;
                       
            
            StringContent content = new StringContent(JsonConvert.SerializeObject(new{input = ChangeProperty},
                Formatting.Indented, 
                settings), 
                Encoding.UTF8,
                "application/json");
            ClientRequest clientRequest = new ClientRequest(async () => await client.Client.PutAsync(string.Join("/",typeof(TD).Name,Id), content,cancel), a => response = a.Response);
            clt.QueueRequest.Enqueue(clientRequest);
        
            var timeSpan = DateTime.Now + TimeSpan.FromSeconds(client.TimeOut);  
            
            while (response == null)
            {
                if (cancel.IsCancellationRequested)
                    cancel.ThrowIfCancellationRequested();
                
                if (timeSpan < DateTime.Now) 
                    throw new TimeoutException("Привышено время ожидания ответа от сервера!");
            }

            return response.IsSuccessStatusCode
                ? ResponseToChange.Parse( await response.Content.ReadAsStringAsync(cancel))                
            : throw new System.Exception(
                $"Status code: {response.StatusCode} content: {await response.Content.ReadAsStringAsync(cancel)}"); 

        }

        public async Task<TD> Delete(
            IGlpiClient clt,
            CancellationToken cancel = default)
        {
            if (clt.Checker())      throw new ExceptionCheck(clt);
            if (clt.IsClone)        throw new System.Exception("Объект не должен быть клоном");
            
            IGlpiClient client = (IGlpiClient)clt.Clone();
            client.SetHeaderDefault();
            
            

            HttpResponseMessage response = null;
            ClientRequest clientRequest =
                new ClientRequest(
                    async () => await client.Client.DeleteAsync(string.Join("/", typeof(TD).Name, Id), cancel),
                    a => response = a.Response);
            clt.QueueRequest.Enqueue(clientRequest);
        
            var timeSpan = DateTime.Now + TimeSpan.FromSeconds(client.TimeOut);  
            
            while (response == null)
            {
                if (cancel.IsCancellationRequested)
                    cancel.ThrowIfCancellationRequested();
                
                if (timeSpan < DateTime.Now) 
                    throw new TimeoutException("Привышено время ожидания ответа от сервера!");
            }

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<TD>(await response.Content.ReadAsStringAsync(cancel))
                : throw new System.Exception(
                    $"Status code: {response.StatusCode} content: {await response.Content.ReadAsStringAsync(cancel)}");
        }
        
        /// <summary>
        /// Метод загрузки элеметов из объекта Links
        /// </summary>
        /// <param name="clt"></param>
        /// <param name="properties">Список черных/белых типов</param>
        /// <param name="isIgnoreProperties">Если false = список типов используется как белый список,если true список используется как черный спиок</param>
        /// <param name="cancel"></param>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="TimeoutException"></exception>
        public virtual async Task LoadFromLinkAsync(
            IGlpiClient clt, 
            IEnumerable<PropertyInfo> properties = null,
            bool? isIgnoreProperties = null,            
            CancellationToken cancel = default)
        {
            if (Links == null || Links.Count == 0) return;
            
            if (clt.Checker())      throw new ExceptionCheck(clt);
            if (clt.IsClone)        throw new System.Exception("Объект не должен быть клоном");
            
            IGlpiClient client = (IGlpiClient)clt.Clone();
            client.SetHeaderDefault();            

            HttpResponseMessage response = null;
        
            IEnumerable<string>
                appendIgnore = //свойсва, которые будут игнорироваться по умолчанию через атрибут NoLinkAttribute
                    GetType().GetProperties()
                        .Where(w => w.GetCustomAttributes(true).Contains(typeof(NoLinkAttribute)))
                        .Select(s => s.Name.ToLower());            
        
            IEnumerable<string> propertiesStr =
                properties != null ? properties.Select(s => s.Name.ToLower()) : Array.Empty<string>();//строковое предстваления свойства
        
            IEnumerable<Link> links = isIgnoreProperties switch
            {
                true => Links.Where(w => !appendIgnore.Contains(w.Rel) && !propertiesStr.Contains(w.Rel.ToLower())),
                false => Links.Where(w => !appendIgnore.Contains(w.Rel) && propertiesStr.Contains(w.Rel.ToLower())),
                _ => Links.Where(w => !appendIgnore.Contains(w.Rel))
            };
        
            foreach (Link link in links)
            {
                PropertyInfo rel = GetType().GetProperty(link.Rel);//Получаем свойство
                if(rel == null || rel.GetCustomAttributes(typeof(NoLinkAttribute)).Any()) continue;//Проверка на существование или есть атрибут пропуска загрузки               
                var request = new ClientRequest(
                    async () => await client.Client.GetAsync(
                        string.Join("", link.Address.Segments.Skip(client.Client.BaseAddress!.Segments.Length)),
                        cancel), a => response = a.Response);
                
                clt.QueueRequest.Enqueue(request); // отправка запроса в очерель запросов                
                
                var timeSpan = DateTime.Now + TimeSpan.FromSeconds(client.TimeOut);  
            
                while (response == null)
                {
                    if (cancel.IsCancellationRequested)
                        cancel.ThrowIfCancellationRequested();
                
                    if (timeSpan < DateTime.Now) 
                        throw new TimeoutException("Привышено время ожидания ответа от сервера!");
                }
        
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        // если ответ положительный, то идет запись объекта
                        rel.SetValue(this, JsonConvert.DeserializeObject(
                            await response.Content.ReadAsStringAsync(cancel),
                            rel.PropertyType));
                    }
                    catch (System.Exception er)
                    {
                        //Debug.WriteLine($"{er.Message}\n{link.Rel}\n{link.Address}");
                    }
                }
                response = null;
            }           
        }

        #endregion

        #region Multies

         // public virtual async Task LoadBaseEntity(
        //     IGlpiMulti glpiMulti,
        //     IGlpiClient client, 
        //     CancellationToken cancel = default)
        // {
        //     if (glpiMulti.Checker()) throw new ExceptionCheck(glpiMulti);
        //     if (client.Checker()) throw new ExceptionCheck(client);
        //     
        //     int iteration = 0;
        //     List<ClientResponse> responseMessages = new List<ClientResponse>();
        //     
        //     
        //     foreach (var entity in GetType().GetProperties()
        //                  .Where(w => w.GetCustomAttributes(typeof(BaseEntityAttribute), true).Any()))  
        //     {
        //
        //         long? id = (long?)GetType().GetProperty($"Id{entity.Name}")
        //             ?.GetValue(this);
        //         if (id == null) continue;
        //
        //         glpiMulti.QueueRequest.Enqueue(new MultiRequest());
        //         glpiMulti.QueueRequest.Enqueue(new MultiRequest(
        //             async () => await client.Client.GetAsync($"{entity.Name}/{id}", cancel),
        //             a => responseMessages.Add(a), client, entity));
        //         iteration++;
        //     }
        //
        //     while (responseMessages.Count != iteration)
        //     {
        //         if (cancel.IsCancellationRequested)
        //             cancel.ThrowIfCancellationRequested();
        //     }
        //
        //     foreach (ClientResponse response in responseMessages.Where(w=>w.ResponseMessage.IsSuccessStatusCode))
        //     {                
        //         response.RequestedProperty.SetValue(this, await response.ResponseMessage.Content.ReadAsStringAsync(cancel));
        //     } 
        //     
        // }
        //
       
       
        //
        // /// <summary>
        // /// Получить объект D в формате JSON
        // /// </summary>
        // /// /// <param name="glpiMulti"> подключенный общий клиент к GLPI</param>
        // /// <param name="glpiClient"> подключенный клиент к GLPI</param>
        // /// <param name="parameter">Параметры запроса</param>
        // /// <param name="isClientOperator"></param>
        // /// <param name="cancel">Принудительная остановка процесса</param>
        // /// <exception cref="ExceptionCheck"></exception>
        // /// <exception cref="Exception"></exception>
        // public static async Task<string> GetJson(
        //     IGlpiMulti glpiMulti,
        //     IGlpiClient glpiClient,
        //     Parameter parameter, 
        //     bool isClientOperator = true,
        //     CancellationToken cancel = default)
        // {
        //     if (glpiMulti.Checker()) throw new ExceptionCheck(glpiMulti);            
        //     if (glpiClient.Checker()) throw new ExceptionCheck(glpiClient);            
        //     
        //     if (parameter == null) throw new System.Exception("Error parameter.");
        //     HttpResponseMessage response = null;
        //     MultiRequest multiRequest;
        //     if (isClientOperator)
        //     {
        //         glpiClient.SetHeaderDefault();
        //         multiRequest = new MultiRequest(
        //             () => glpiClient.Client.GetAsync($"{typeof(TD).Name}{parameter}", cancel),
        //             w => response = w, glpiClient);
        //     }
        //     else
        //     {
        //         glpiMulti.SetHeaderDefault();
        //         multiRequest = new MultiRequest(
        //             () => glpiMulti.Client.GetAsync($"{typeof(TD).Name}{parameter}", cancel),
        //             w => response = w, glpiClient);
        //     }
        //
        //     glpiMulti.QueueRequest.Enqueue(multiRequest);
        //
        //     while (response == null) 
        //     {
        //         if (cancel.IsCancellationRequested)
        //         {
        //             cancel.ThrowIfCancellationRequested();
        //         }                
        //     }
        //     
        //     if (response.IsSuccessStatusCode)
        //         return await Task.FromResult(await response.Content.ReadAsStringAsync(cancel));
        //     
        //     throw new System.Exception($"status code: {response.StatusCode} content: {await response.Content.ReadAsStringAsync(cancel)}");
        // }
        //
        //
        
        //
        // /// <summary>
        // /// 
        // /// </summary>
        // /// <param name="glpiMulti"></param>
        // /// <param name="glpiClient"></param>
        // /// <param name="parameter"></param>
        // /// <param name="isClientOperator"></param>
        // /// <param name="cancel"></param>
        // /// <returns></returns>
        // /// <exception cref="ExceptionCheck"></exception>
        // /// <exception cref="Exception"></exception>
        // public static async Task<TD> GetAsync(
        //     IGlpiMulti glpiMulti,
        //     IGlpiClient glpiClient,
        //     Parameter parameter,
        //     bool isClientOperator = true,
        //     CancellationToken cancel = default)
        // {
        //     if (glpiMulti.Checker()) throw new ExceptionCheck(glpiClient);
        //     
        //     if (glpiClient.Checker()) throw new ExceptionCheck(glpiClient);
        //    
        //     
        //     if (parameter?.id is null or < 0) throw new System.Exception("Error parameter.");
        //    
        //     try
        //     {
        //         return JsonConvert.DeserializeObject<TD>(await GetJson(glpiMulti, glpiClient, parameter,
        //             isClientOperator, cancel));
        //     }
        //     catch
        //     {
        //         throw new System.Exception("Json value null");
        //     }           
        //
        //     
        // }

        #endregion


        public int CompareTo(TD other) =>
            Id < other.Id ? -1 : Id > other.Id ? 1 : 0;
        
        public bool Equals(IDashboard other) =>
            other != null && Id == other.Id;
    }
}