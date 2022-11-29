using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Exception;
using Newtonsoft.Json;
using ArgumentException = System.ArgumentException;
using Convert = System.Convert;
using ICloneable = System.ICloneable;

namespace GLPIDotNet_API.Base.GLPI
{
    /// <summary>
    /// Общий интерфейс для всех объектов инициализации
    /// </summary>
    public interface IGlpi: System.IEquatable<IGlpi>,ICloneable
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
        Initialization Init { get; set; }

        /// <summary>
        /// Http для запросов к GLPI
        /// </summary>
        HttpClient Client { get; }

        /// <summary>
        /// Время ожидания проверки очереди. Диапозон от 20 до 1000. по умолчанию 100 
        /// </summary>
        [Range(20, 1000), DefaultValue(100)]
        int TimeOutDelayMotor { get; set; }
        
        /// <summary>
        /// Время ожидания ответа от сервера
        /// </summary>
        uint TimeOut { get; }

        /// <summary>
        /// Обязательная функция к вызову после создания объекта, которая инициализирует на стороне GLPI
        /// </summary>
        /// <param name="isFullInit">True - для полной инициализации, false - быстрая инициализация</param>
        /// <param name="isRephresh">True</param>
        /// <param name="cancel"></param>
        /// <exception cref="JsonException"/>
        /// <exception cref="Exception"/>
        /// <returns>Статус инициализации. Ответ 200 мб в 2 случаях. Если Init != null или запрос прошел успешно.</returns>
        Task<Initialization> Initialization(bool isFullInit, bool isRephresh = false,
            CancellationToken cancel = default);

        /// <summary>
        /// Заголовок по умолчанию
        /// </summary>
        void SetHeaderDefault();        

        /// <summary>
        /// Отправляет запрос на завершение сессии
        /// </summary>
        /// <param name="cancel"></param>
        Task KillSession(CancellationToken cancel = default);

        /// <summary>
        /// Закрытие сессии. Dont use model the using
        /// </summary>
        /// <returns></returns>
        Task Close();
        

        /// <summary>
        /// Проверка вводных данных
        /// </summary>      
        /// <returns>Если true  есть ошибка;False  иначе </returns>
        virtual bool Checker()
        {            
            bool isCheck = Client == null ||
                           string.IsNullOrEmpty(AppToken) ||
                           Init == null ||
                           string.IsNullOrEmpty(Init.SessionToken);
            
            if (!isCheck) return false;

            throw new ExceptionCheck(this);
        }
    }
}