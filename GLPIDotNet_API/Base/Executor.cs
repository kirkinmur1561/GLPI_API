using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using GLPIDotNet_API.Dashboard.Common;
using GLPIDotNet_API.Exception;

namespace GLPIDotNet_API.Base
{
    public class Executor:Dashboard<Executor>
    {
        /// <summary>
        /// load data from glpi from uri
        /// </summary>
        /// <param name="glpi"></param>
        /// <param name="endPoint">ex. Computer/23</param>
        /// <param name="cancel"></param>
        /// <exception cref="ExceptionCheck"></exception>
        /// <exception cref="Exception"></exception>
        /// <returns></returns>
        public new static async Task<string> GetJson(Glpi glpi,string endPoint,CancellationToken cancel = default)
        {
            if (Check(glpi)) throw new ExceptionCheck(glpi);

            HttpResponseMessage response = null;
            Request request = new Request(async () =>await glpi.Client.GetAsync(endPoint, cancel),a=>response = a);
            glpi.QueueRequest.Enqueue(request);

            while (response == null)
            {
                if (cancel.IsCancellationRequested) cancel.ThrowIfCancellationRequested();
            }

            if (response.IsSuccessStatusCode) return await response.Content.ReadAsStringAsync(cancel);
            throw new System.Exception(
                $"Status code:{response.StatusCode}\nContext:{response.Content.ReadAsStringAsync(cancel)}");
        }
    }
}
