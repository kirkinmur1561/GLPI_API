using GLPIDotNet_API.Base;
using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Exception;

namespace GLPIDotNet_API.Dashboard.Search
{
    public class SearchOption<TD> where TD : Dashboard<TD>
    {
        [JsonIgnore]
        public int id_option { get; set; }
        public string name { get; set; }
        public string table { get; set; }
        public string field { get; set; }
        public string datatype { get; set; }
        public string uid { get; set; }
        public bool nosearch { get; set; }
        public bool nodisplay { get; set; }
        public List<string> available_searchtypes { get; set; }


        /// <summary>
        /// Критерии поиска по объекту D
        /// </summary>
        /// <param name="glpi"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        public static async Task<Dictionary<string, List<SearchOption<TD>>>> GetListSearchOptions(Glpi glpi, CancellationToken cancel = default)
        {
            Dictionary<int, int> keys = new Dictionary<int, int>();
            if (Dashboard<TD>.Check(glpi)) throw new ExceptionCheck(glpi);
            await glpi.SetHeaderDefault();
            HttpResponseMessage response = null;
            Request request =
                new Request(async () => await glpi.Client.GetAsync($"listSearchOptions/{typeof(TD).Name}", cancel),
                    a => response = a);
            
            glpi.QueueRequest.Enqueue(request);
            
            while (response == null)
            {
                if (cancel.IsCancellationRequested) cancel.ThrowIfCancellationRequested();
            }

            if (!response.IsSuccessStatusCode)
                throw new System.Exception(
                    $"Status code:{response.StatusCode} content?:{await response.Content.ReadAsStringAsync(cancel)}");
            
            Dictionary<string, List<SearchOption<TD>>> pairs = new Dictionary<string, List<SearchOption<TD>>>();
            var abstract_objects = JsonConvert.DeserializeObject<Dictionary<string, object>>(await response.Content.ReadAsStringAsync(cancel));
            string last_key = string.Empty;
            List<SearchOption<TD>> last_searchOptions = new List<SearchOption<TD>>();

            foreach (var item in abstract_objects)
            {
                if (int.TryParse(item.Key, out int va))
                {
                    SearchOption<TD> search = JsonConvert.DeserializeObject<SearchOption<TD>>(item.Value?.ToString() ?? string.Empty);
                    if (search != null)
                    {
                        search.id_option = va;
                        last_searchOptions.Add(search);
                    }
                }
                else
                {
                    if (last_key == string.Empty) last_key = item.Key;
                    else
                    {
                        pairs.Add(last_key, last_searchOptions);
                        last_searchOptions = new List<SearchOption<TD>>();
                        last_key = item.Key;
                    }
                }
            }
            pairs.Add(last_key, last_searchOptions);

            return pairs;

        }

        
    }
}
