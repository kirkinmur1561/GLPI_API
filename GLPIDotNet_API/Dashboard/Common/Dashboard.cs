﻿using GLPIDotNet_API.Base;
using GLPIDotNet_API.Dashboard.Search;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        protected internal static bool Check(Glpi glpi) =>
            (glpi == null ||
            glpi.Client == null ||
            string.IsNullOrEmpty(glpi.AppToken) ||
            glpi.Init == null ||
            string.IsNullOrEmpty(glpi.Init.SessionToken));

        /// <summary>
        /// Получить объект D в формате JSON
        /// </summary>
        /// <param name="glpi">Подключенный объект к GLPI</param>
        /// <param name="parameter">Параметры запроса</param>
        /// <param name="cancel">Принудительная остановка процесса</param>
        /// <exception cref="Exception"></exception>
        public static async Task<string> GetJson(Glpi glpi, Parameter parameter,CancellationToken cancel = default)
        {
            if (Check(glpi) || parameter == null) throw new Exception("Not check the check or the parameter equal null");

            HttpResponseMessage response = null;
            Request request = new Request
            (() => glpi.Client.GetAsync($"{typeof(TD).Name}{parameter}"),
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
            else throw new Exception($"status code:{response.StatusCode} content:{await response.Content?.ReadAsStringAsync(cancel)}");

        }


        /// <summary>
        /// Получить объект типа D
        /// </summary>
        /// <param name="glpi">Основное подключение к glpi</param>
        /// <param name="parameter">Параметры поиска</param>
        /// <param name="cancel"></param>
        /// <exception cref="JsonException"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task<TD> GetAsync(Glpi glpi, Parameter parameter,CancellationToken cancel = default)
        {
            if (Check(glpi) | parameter.id == null | parameter.id < 0) return null;
            string data;
            data = await GetJson(glpi, parameter, cancel);

            if (data == "*NULL*") throw new Exception("Json value null");

            try
            {
                return JsonConvert.DeserializeObject<TD>(data);
            }
            catch(JsonException je)
            {
                throw;
            }
        }

        /// <summary>
        /// Получить объект D по ссылке
        /// </summary>
        /// <param name="glpi"></param>
        /// <param name="link">Ex. http://localhost/apirest.php/Ticket/55</param>
        /// <param name="skip_segment_uri"> Для примера нужно пропустить 2 сегмента. Корень + apirest</param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<TD> GetAsync(Glpi glpi,string link,int skipSegmentUri,CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new Exception("Not going check the checker glpi");

            HttpResponseMessage response = null;
            Request request = new Request(async () => await glpi.Client.GetAsync($"{string.Join("", new Uri(link).Segments.Skip(skipSegmentUri))}"), a => response = a);
            glpi.QueueRequest.Enqueue(request);
            while (response == null)
            {
                if (cancel.IsCancellationRequested) cancel.ThrowIfCancellationRequested();
            }

            if (response.IsSuccessStatusCode) return JsonConvert.DeserializeObject<TD>(await response.Content.ReadAsStringAsync(cancel));
            else throw new Exception($"Error in request.Status code:{response.StatusCode} content?:{await response.Content?.ReadAsStringAsync(cancel) ?? "*NULL*"}");
        }

        /// <summary>
        /// Поиск объектов типа D
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static async Task<ResponseSearch> GetAsync(Glpi glpi,IEnumerable<Criteria> criterias,Parameter parameter = null, CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new Exception("Not going check the checker GLPI");
            HttpResponseMessage response = null;
            Request request;

            var adr = Criteria.GetURI(criterias);

            if (parameter == null) request = new Request(async () => await glpi.Client.GetAsync($"search/{typeof(TD).Name}?{Criteria.GetURI(criterias)}"),
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
                    else throw new Exception($"Status code:{response.StatusCode} content?:{await response.Content.ReadAsStringAsync(cancel)}");

                    return seatchEnd;
                }
                return seatchStart;
            }
            else throw new Exception($"Status code:{response.StatusCode} content?:{await response.Content.ReadAsStringAsync(cancel)}");
            
        }

        /// <summary>
        /// Получить список объектов D
        /// </summary>
        /// <param name="glpi">Основное подключение к glpi</param>
        
        public static async Task<string> GetEnumerableJson(Glpi glpi, CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new Exception("Not going check the checker glpi");
            return JsonConvert.SerializeObject(await GetEnumerable(glpi, cancel));
        }

        /// <summary>
        /// Получить список объектов D
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static async Task<IEnumerable<TD>> GetEnumerable(Glpi glpi,CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new Exception("Not going check the checker glpi");

            List<TD> start;
            List<TD> middle;
            List<TD> end;

            HttpResponseMessage responseStart = null;
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
            else throw new Exception("Error in read response (start collection)");

            HttpResponseMessage responseEnd = null;
            Request requestEnd = new Request(async () => await glpi.Client.GetAsync($"{typeof(TD).Name}?{new Parameter() { order = Parameter.EOrder.DESC }}"), a => responseEnd = a);
            glpi.QueueRequest.Enqueue(requestEnd);

            while (responseEnd == null)
            {

                if (cancel.IsCancellationRequested)
                {
                    cancel.ThrowIfCancellationRequested();
                }
            }

            if (responseEnd.IsSuccessStatusCode) end = JsonConvert.DeserializeObject<List<TD>>(await responseEnd.Content.ReadAsStringAsync());
            else throw new Exception("Error in read response (end collection)");

            end.Reverse();

            HttpResponseMessage responseMiddle = null;
            Request request = new Request(async () => await glpi.Client.GetAsync($"{typeof(TD).Name}?{new Parameter() { range = new Base.Range(0, end.Last().Id ?? 50) }}"), a => responseMiddle = a);
            glpi.QueueRequest.Enqueue(request);

            while (responseMiddle == null)
            {

                if (cancel.IsCancellationRequested)
                {
                    cancel.ThrowIfCancellationRequested();
                }
            }

            if (responseMiddle.IsSuccessStatusCode) middle = JsonConvert.DeserializeObject<List<TD>>(await responseMiddle.Content.ReadAsStringAsync());
            else throw new Exception("Error in read response (middle collection)");

            return middle;
            
        }

        /// <summary>
        /// добавляет объект D в коллекцию GLPI
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static async Task<IEnumerable<TD>> AddItem(GlpiClient glpi,IEnumerable<TD> ds, CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new Exception("Not going check the checker glpi");
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;


            StringContent content = new StringContent(JsonConvert.SerializeObject(new { input = ds },Formatting.Indented, settings), Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            Request request = new Request(async () => await glpi.Client.PostAsync(typeof(TD).Name, content), a => response = a);
            glpi.QueueRequest.Enqueue(request);

            while (response == null)
            {
                if (cancel.IsCancellationRequested) cancel.ThrowIfCancellationRequested();
            }

            if (response.IsSuccessStatusCode) return JsonConvert.DeserializeObject<List<TD>>(await response.Content.ReadAsStringAsync(cancel));
            throw new Exception($"Status code:{response.StatusCode} content?:{await response.Content.ReadAsStringAsync(cancel)}");

        }

        public int CompareTo(TD other)
        {
            if (Id < other.Id) return 1;
            if (Id > other.Id) return 1;
            return 0;
        }
    }
}