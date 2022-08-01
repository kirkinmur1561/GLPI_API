using Newtonsoft.Json;

namespace GLPIDotNet_API.Base
{
    public class Initialization
    {
        /// <summary>
        /// Токен для запросов к GLPI. Обязательно для запроса после инициализации
        /// </summary>
        [JsonProperty("session_token")]
        public string SessionToken { get; set; }

        /// <summary>
        /// Способ инициализации.
        /// </summary>
        public bool IsFullInIt
        {
            get => _isFullInIt;
            private set
            {
                if (value == _isFullInIt) return;
                _isFullInIt = value;
            }
        }
        private bool _isFullInIt;

        /// <summary>
        /// Информация о сессии
        /// </summary>
        [JsonProperty("session")]
        public Session Session
        {
            get => _session;
            set
            {
                _session = value;
                IsFullInIt = true;
            }
        }

        private Session _session;
    }
}
