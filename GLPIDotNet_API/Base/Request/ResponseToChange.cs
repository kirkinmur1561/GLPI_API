using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace GLPIDotNet_API.Base.Request
{
    public class ResponseToChange
    {
        private ResponseToChange(
            long? id,
            bool? isChange,
            string msg)
        {
            Id = id;
            IsChange = isChange;
            Msg = msg;
        }

        /// <summary>
        /// Id объекта
        /// </summary>
        public readonly long? Id;
        
        /// <summary>
        /// Статус изменения
        /// </summary>
        public readonly bool? IsChange;
        
        /// <summary>
        /// Описание изменения
        /// </summary>
        public readonly string Msg;
  

        public static ResponseToChange Parse(string data)
        {
            var kvData = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(data)?.FirstOrDefault();
            if (kvData != null)
                return new ResponseToChange(
                    long.Parse(kvData.FirstOrDefault().Key),
                    (bool)kvData.FirstOrDefault().Value,
                    kvData["message"].ToString());

            return new ResponseToChange(0, null, "");
        }

        public static IEnumerable<ResponseToChange> ParseItem(string data) =>
            JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(data)
                ?.Select(s => 
                    new ResponseToChange
                    (
                        long.Parse(s.FirstOrDefault().Key),
                        (bool)s.FirstOrDefault().Value,
                    s["message"].ToString())
                    );

    }
}