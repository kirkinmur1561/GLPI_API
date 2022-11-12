using GLPIDotNet_API.Base;
using GLPIDotNet_API.Dashboard.Search;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Attributes;
using GLPIDotNet_API.Dashboard.Administration;
using GLPIDotNet_API.Exception;

namespace GLPIDotNet_API.Dashboard.Common
{
    public abstract class Dashboard<TD>:IDashboard,IComparable<TD> where TD: Dashboard<TD>
    {
        public long? Id { get; set; }
        public long? IdEntities { get; set; }       
        public bool? IsRecursive { get; set; }       
        public string Name { get; set; }       
        public string Comment { get; set; }       
        public long? IdLocations { get; set; }       
        public long? IdUsersTech { get; set; }       
        public long? IdGroupsTech { get; set; }       
        public long? IdManufacturers { get; set; }       
        public bool? IsDeleted { get; set; }       
        public bool? IsTemplate { get; set; }       
        public string TemplateName { get; set; }       
        public DateTime? DateMod { get; set; }       
        public long? IdUsers { get; set; }       
        public long? IdGroups { get; set; }       
        public double? TicketTco { get; set; }       
        public DateTime? DateCreation { get; set; }       
        public List<Link> Links { get; set; }

        /// <summary>
        /// Проверка вводных данных
        /// </summary>
        /// <param name="glpi">Объект подключения к GLPI</param>
        /// <returns>Если true  есть ошибка;False  иначе </returns>
        protected internal static bool Check(Glpi glpi)
        {
            bool isCheck = glpi?.Client == null ||
                            string.IsNullOrEmpty(glpi.AppToken) ||
                            glpi.Init == null ||
                            string.IsNullOrEmpty(glpi.Init.SessionToken);
            if (!isCheck) return false;
            
            throw new ExceptionCheck(glpi);
        }
            

        /// <summary>
        /// Получить объект D в формате JSON
        /// </summary>
        /// <param name="glpi">Подключенный объект к GLPI</param>
        /// <param name="parameter">Параметры запроса</param>
        /// <param name="cancel">Принудительная остановка процесса</param>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task<string> GetJson(Glpi glpi, Parameter parameter,CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new ExceptionCheck(glpi);
            await glpi.SetHeaderDefault();
            if (parameter == null) throw new System.Exception("Error parameter.");

            HttpResponseMessage response = null;
            Request request = new Request
            (() => glpi.Client.GetAsync($"{typeof(TD).Name}{parameter}", cancel),
            w => response = w);

            glpi.QueueRequest.Enqueue(request);

            while (response == null) 
            {
                if (cancel.IsCancellationRequested)
                {
                    cancel.ThrowIfCancellationRequested();
                }                
            }
            
            if (response.IsSuccessStatusCode)
                return await Task.FromResult(await response.Content.ReadAsStringAsync(cancel));
            
            throw new System.Exception($"status code:{response.StatusCode} content:{await response.Content?.ReadAsStringAsync(cancel)}");
        }


        /// <summary>
        /// Получить объект типа TD
        /// </summary>
        /// <param name="glpi">Основное подключение к glpi</param>
        /// <param name="parameter">Параметры поиска</param>
        /// <param name="cancel"></param>
        /// <exception cref="JsonException"></exception>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task<TD> GetAsync(Glpi glpi, Parameter parameter,CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new ExceptionCheck(glpi);
            await glpi.SetHeaderDefault();
            
            if (parameter?.id is null or < 0) throw new System.Exception("Error parameter.");
            string data = default;
            try
            {
                data = await GetJson(glpi, parameter, cancel);
            }
            catch
            {
                throw new System.Exception("Json value null");
            }           

            return JsonConvert.DeserializeObject<TD>(data);
        }
        

        /// <summary>
        /// Получить объект D по ссылке
        /// </summary>
        /// <param name="glpi"></param>
        /// <param name="link">Ex. http://localhost/apirest.php/Ticket/55</param>
        /// <param name="skipSegmentUri"> Для примера нужно пропустить 2 сегмента. Корень + apirest</param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ExceptionCheck"></exception>
        public static async Task<TD> GetAsync(Glpi glpi,string link,int skipSegmentUri,CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new ExceptionCheck(glpi);
            await glpi.SetHeaderDefault();

            HttpResponseMessage response = null;
            Request request = new Request(async () => await glpi.Client.GetAsync($"{string.Join("", new Uri(link).Segments.Skip(skipSegmentUri))}"), a => response = a);
            glpi.QueueRequest.Enqueue(request);
            while (response == null)
            {
                if (cancel.IsCancellationRequested) cancel.ThrowIfCancellationRequested();
            }

            if (response.IsSuccessStatusCode) return JsonConvert.DeserializeObject<TD>(await response.Content.ReadAsStringAsync(cancel));
            throw new System.Exception($"Error in request.Status code:{response.StatusCode} content?:{await response.Content?.ReadAsStringAsync(cancel) ?? "*NULL*"}");
        }

        /// <summary>
        /// Поиск объектов типа D
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ExceptionCheck"></exception>
        public static async Task<ResponseSearch> GetAsync(Glpi glpi,IEnumerable<Criteria> criterias,Parameter parameter = null, CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new ExceptionCheck(glpi);
            HttpResponseMessage response = null;
            Request request;
            await glpi.SetHeaderDefault();
            var adr = Criteria.GetURI(criterias);

            if (parameter == null) request = new Request(async () => await glpi.Client.GetAsync($"search/{typeof(TD).Name}?{Criteria.GetURI(criterias)}",cancel),
                                                         a => response = a);

            

            else request = new Request(async () => await glpi.Client.GetAsync($"search/{typeof(TD).Name}?{Criteria.GetURI(criterias)}&{parameter.ToString()}", cancel),
                                       a => response = a);

            glpi.QueueRequest.Enqueue(request);

            while (response == null)
            {
                if (cancel.IsCancellationRequested) cancel.ThrowIfCancellationRequested();
            }

            ResponseSearch seatchStart;
            ResponseSearch seatchEnd;
            
            if (response.IsSuccessStatusCode)
            {
                seatchStart = JsonConvert.DeserializeObject<ResponseSearch>(await response.Content.ReadAsStringAsync(cancel));
                if (seatchStart != null && seatchStart.Count < seatchStart.TotalCount)
                {
                    HttpResponseMessage responseSearchEnd = null;
                    if (parameter == null) glpi.QueueRequest.Enqueue(new Request(async () => await glpi.Client.GetAsync($"search/{typeof(TD).Name}?{Criteria.GetURI(criterias)}&{new Parameter() { range = new Base.Range(0,seatchStart.TotalCount) }}", cancel), a => responseSearchEnd = a));
                    else
                    {
                        parameter.range = new Base.Range(0, seatchStart.TotalCount);
                        glpi.QueueRequest.Enqueue(new Request(async () => await glpi.Client.GetAsync($"search/{typeof(TD).Name}?{Criteria.GetURI(criterias)}&{parameter}", cancel), a => responseSearchEnd = a));
                    }
                    while (responseSearchEnd == null)
                    {
                        if (cancel.IsCancellationRequested) cancel.ThrowIfCancellationRequested();
                    }

                    if (responseSearchEnd.IsSuccessStatusCode) seatchEnd = JsonConvert.DeserializeObject<ResponseSearch>(await responseSearchEnd.Content.ReadAsStringAsync(cancel));
                    else throw new System.Exception($"Status code:{response.StatusCode} content?:{await response.Content.ReadAsStringAsync(cancel)}");

                    return seatchEnd;
                }
                return seatchStart;
            }
            throw new System.Exception($"Status code:{response.StatusCode} content?:{await response.Content.ReadAsStringAsync(cancel)}");
            
        }

        
        /// <summary>
        /// Получить список объектов D
        /// </summary>
        /// <param name="glpi"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionCheck"></exception>
        public static async Task<string> GetEnumerableJson(Glpi glpi, CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new ExceptionCheck(glpi);
            await glpi.SetHeaderDefault();
            return JsonConvert.SerializeObject(await GetEnumerable(glpi, cancel));
        }

        /// <summary>
        /// Get date from uri
        /// </summary>
        /// <param name="glpi"></param>
        /// <param name="address"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionCheck"></exception>
        public static async Task<string> GetJsonFromUri(Glpi glpi, Uri address, CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new ExceptionCheck(glpi);
            await glpi.SetHeaderDefault();

            string endPoint = string.Join("", address.Segments.Skip(glpi.Client.BaseAddress!.Segments.Length));

            HttpResponseMessage rm = null;
            Request req = new Request(async () => await glpi.Client.GetAsync(endPoint, cancel), r => rm = r);
            glpi.QueueRequest.Enqueue(req);
            while (rm == null)
            {
                if (cancel.IsCancellationRequested)
                {
                    cancel.ThrowIfCancellationRequested();
                }
            }

            if (rm.IsSuccessStatusCode) return await rm.Content.ReadAsStringAsync(cancel);
            return string.Empty;
        }

        /// <summary>
        /// Получить список объектов D
        /// </summary>
        /// <param name="glpi"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task<IEnumerable<TD>> GetEnumerable(Glpi glpi,CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new ExceptionCheck(glpi);

            List<TD> start;
            List<TD> middle;
            List<TD> end;

            HttpResponseMessage responseStart = null;
            await glpi.SetHeaderDefault();
            Request requestStart = new Request(async () => await glpi.Client.GetAsync($"{typeof(TD).Name}", cancel), a => responseStart = a);
            glpi.QueueRequest.Enqueue(requestStart);

            while (responseStart == null)
            {
                if (cancel.IsCancellationRequested)
                {
                    cancel.ThrowIfCancellationRequested();
                }

            }

            if (responseStart.IsSuccessStatusCode) start = JsonConvert.DeserializeObject<List<TD>>(await responseStart.Content.ReadAsStringAsync());
            else throw new System.Exception("Error in read response (start collection)");

            HttpResponseMessage responseEnd = null;
            Request requestEnd = new Request(async () => await glpi.Client.GetAsync($"{typeof(TD).Name}?{new Parameter() { order = Parameter.EOrder.DESC }}", cancel), a => responseEnd = a);
            glpi.QueueRequest.Enqueue(requestEnd);

            while (responseEnd == null)
            {

                if (cancel.IsCancellationRequested)
                {
                    cancel.ThrowIfCancellationRequested();
                }
            }

            if (responseEnd.IsSuccessStatusCode) end = JsonConvert.DeserializeObject<List<TD>>(await responseEnd.Content.ReadAsStringAsync(cancel));
            else throw new System.Exception("Error in read response (end collection)");

            end.Reverse();

            HttpResponseMessage responseMiddle = null;
            Request request = new Request(async () => await glpi.Client.GetAsync($"{typeof(TD).Name}?{new Parameter() { range = new Base.Range(0, end.Last().Id ?? 50) }}", cancel), a => responseMiddle = a);
            glpi.QueueRequest.Enqueue(request);

            while (responseMiddle == null)
            {

                if (cancel.IsCancellationRequested)
                {
                    cancel.ThrowIfCancellationRequested();
                }
            }

            if (responseMiddle.IsSuccessStatusCode) middle = JsonConvert.DeserializeObject<List<TD>>(await responseMiddle.Content.ReadAsStringAsync());
            else throw new System.Exception("Error in read response (middle collection)");

            return middle;
            
        }

        /// <summary>
        /// добавляет объект D в коллекцию GLPI
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ExceptionCheck"></exception>
        public static async Task<IEnumerable<TD>> AddItem(Glpi glpi,IEnumerable<TD> ds, CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new ExceptionCheck(glpi);
            await glpi.SetHeaderDefault();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;


            StringContent content = new StringContent(JsonConvert.SerializeObject(new { input = ds },Formatting.Indented, settings), Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            Request request = new Request(async () => await glpi.Client.PostAsync(typeof(TD).Name, content,cancel), a => response = a);
            glpi.QueueRequest.Enqueue(request);

            while (response == null)
            {
                if (cancel.IsCancellationRequested) cancel.ThrowIfCancellationRequested();
            }

            if (response.IsSuccessStatusCode) return JsonConvert.DeserializeObject<List<TD>>(await response.Content.ReadAsStringAsync(cancel));
            throw new System.Exception($"Status code:{response.StatusCode} content?:{await response.Content.ReadAsStringAsync(cancel)}");

        }

        public int CompareTo(TD other)
        {
            if (Id < other.Id) return -1;
            return Id > other.Id ? 1 : 0;
        }

        
        
        /// <summary>
        /// Метод загрузки элеметов из объекта Links
        /// </summary>
        /// <param name="glpi">авторизированный пользователь</param>
        /// <param name="isIgnoreProperties">Если false = список типов используется как белый список,если true список используется как черный спиок</param>
        /// <param name="properties">Список черных/белых типов</param>
        /// <param name="cancel"></param>
        /// <exception cref="ExceptionCheck"></exception>
        public virtual async Task LoadFromLinkAsync(
            Glpi glpi, 
            IEnumerable<PropertyInfo> properties = null,
            bool? isIgnoreProperties = null,            
            CancellationToken cancel = default)
        {
            if (Links == null || Links.Count == 0) return;

            if (Check(glpi)) throw new ExceptionCheck(glpi);
            await glpi.SetHeaderDefault();
            HttpResponseMessage responseMiddle = null;

            IEnumerable<string>
                appendIgnore = //свойсва, которые будут игнорироваться по умолчанию через атрибут NoLinkAttribute
                    GetType().GetProperties()
                        .Where(w => w.GetCustomAttributes(true).Contains(typeof(NoLinkAttribute)))
                        .Select(s => s.Name.ToLower());            

            IEnumerable<string> propertiesStr =
                properties != null ? properties.Select(s => s.Name.ToLower()) : Array.Empty<string>();//строковое предстваления свойства
            
            IEnumerable<Link> links;
            
            if (isIgnoreProperties == true)
                links = Links.Where(w =>!appendIgnore.Contains(w.Rel) && !propertiesStr.Contains(w.Rel.ToLower()));
            else if (isIgnoreProperties == false)
                links = Links.Where(w => !appendIgnore.Contains(w.Rel) && propertiesStr.Contains(w.Rel.ToLower()));
            else links = Links.Where(w => !appendIgnore.Contains(w.Rel));
            
            foreach (Link link in links)
            {
                PropertyInfo rel = GetType().GetProperty(link.Rel);//Получаем свойство
                if(rel == null || rel.GetCustomAttributes(typeof(NoLinkAttribute)).Any()) continue;//Проверка на существование или есть атрибут пропуска загрузки               
                var request = new Request(
                    async () => await glpi.Client.GetAsync(
                        string.Join("", link.Address.Segments.Skip(glpi.Client.BaseAddress!.Segments.Length)),
                        cancel), a => responseMiddle = a);
                
                glpi.QueueRequest.Enqueue(request); // отправка запроса в очерель запросов                
                
                while (responseMiddle == null) // ожидание ответа
                {
                    if (cancel.IsCancellationRequested)
                    {
                        cancel.ThrowIfCancellationRequested();
                    }
                }

                if (responseMiddle.IsSuccessStatusCode)
                {
                    try
                    {
                        // если ответ положительный, то идет запись объекта
                        rel.SetValue(this, JsonConvert.DeserializeObject(
                            await responseMiddle.Content.ReadAsStringAsync(cancel),
                            rel.PropertyType));
                    }
                    catch (System.Exception er)
                    {
                        Debug.WriteLine($"{er.Message}\n{link.Rel}\n{link.Address}");
                    }
                }
                responseMiddle = null;
            }           
        }

        // public virtual async Task LoadFromLinkWithWhiteListAsync(Glpi glpi,
        //     IEnumerable<Type> requiredProperties = default, CancellationToken cancel = default)
        // {
        //     
        // }
    }
}