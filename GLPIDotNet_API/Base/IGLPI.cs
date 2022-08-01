using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GLPIDotNet_API.Base
{
    public interface IGlpi : IDisposable
    {
        /// <summary>
        /// Токен приложения. Его нужно получить на веб старницы GLPI
        /// </summary>
        string AppToken { get; }

        /// <summary>
        /// Нужен для иниициализации. Его нужно получить на веб страницы GLPI
        /// </summary>
        string UserToken { get; }

        /// <summary>
        /// Логин для входа в GLPI
        /// </summary>
        string Login { get; }

        /// <summary>
        /// Пароль к логину
        /// </summary>
        string Password { get; }

        /// <summary>
        /// Объект иницаализации
        /// </summary>
        Initialization Init { get; }

        /// <summary>
        /// Http для запросов к GLPI
        /// </summary>
        HttpClient Client { get; }

        Task<Initialization> Initialization(bool isFullInit, bool isRephresh = default);
    }
}
