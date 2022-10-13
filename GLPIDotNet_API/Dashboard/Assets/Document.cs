using GLPIDotNet_API.Base;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using GLPIDotNet_API.Dashboard.Common;
using GLPIDotNet_API.Exception;

namespace GLPIDotNet_API.Dashboard.Assets
{
    public class Document:Dashboard<Document>
    {
        [JsonProperty("filename")]
        public string FileName { get; set; }
        [JsonProperty("filepath")]
        public string FilePath { get; set; }
        [JsonProperty("documentcategories_id")]
        public long? IdDocumentCategories { get; set; }
        [JsonProperty("mime")]
        public string Mime { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("tickets_id")]
        public long? IdTickets { get; set; }
        [JsonProperty("sha1sum")]
        public string Sha1 { get; set; }
        [JsonProperty("is_blacklisted")]
        public bool? IsBlockListed { get; set; }
        [JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="glpi"></param>
        /// <param name="cancel"></param>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        [Obsolete("No correct method!!!")]
        public async Task Download(Glpi glpi,CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new ExceptionCheck(glpi);

            HttpResponseMessage response = null;

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "Document");
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
            requestMessage.Headers.Add("Session-Token", glpi.Init.SessionToken);
            requestMessage.Headers.Add("app_token", glpi.AppToken);
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(new { input = new { id = this.Id } }), Encoding.UTF8, "application/json");

            var r = await glpi.Client.SendAsync(requestMessage, cancel);

            Request request = new Request
            (async () => 
            {
                
                return null;


            },
            w => 
            response = w);

            glpi.QueueRequest.Enqueue(request);

            while (response == null)
            {
                if (cancel.IsCancellationRequested)
                {
                    cancel.ThrowIfCancellationRequested();
                }

            }
            if (response.IsSuccessStatusCode) return;
            else throw new System.Exception($"status code:{response.StatusCode} content:{await response.Content?.ReadAsStringAsync() ?? "*NULL*"}");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="glpi"></param>
        /// <param name="uri"></param>
        /// <param name="cancel"></param>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        [Obsolete]
        public static async Task GetDoc(Glpi glpi, string uri, CancellationToken cancel = default)
        {
            Uri result;
            if (Check(glpi))
                throw new ExceptionCheck(glpi);

            if (string.IsNullOrEmpty(uri)) throw new System.Exception("URI is null or empty");
            if (!Uri.TryCreate(uri, UriKind.Absolute, out result)) throw new System.Exception("Error create URI.");
           

            HttpResponseMessage response = null;
            Request request = new Request
            (() => glpi.Client.GetAsync(result,cancel),
            w => response = w);

            glpi.QueueRequest.Enqueue(request);

            while (response == null)
            {
                if (cancel.IsCancellationRequested)
                {
                    cancel.ThrowIfCancellationRequested();
                }
            }

            if (response.IsSuccessStatusCode) return;
            throw new System.Exception(
                    $"status code:{response.StatusCode} content:{await response.Content.ReadAsStringAsync(cancel)}");
        }
    }
}
