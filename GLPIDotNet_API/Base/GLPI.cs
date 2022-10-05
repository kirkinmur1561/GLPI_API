using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Exception;

namespace GLPIDotNet_API.Base
{
    public abstract class Glpi : IGlpi
    {
        public string AppToken { get; }
        public string UserToken { get; }
        public string Login { get; }
        public string Password { get; }
        public Initialization Init { get; private set; }
        public HttpClient Client { get; }

        public readonly Queue<Request> QueueRequest = new Queue<Request>();
        public readonly CancellationTokenSource Source = new CancellationTokenSource();

        public Glpi()
        {
            Motor();
            
        }

        /// <summary>
        /// Общий конструктор
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Glpi(string baseAddress, string appToken):this()
        {
            AppToken = appToken ?? throw new ArgumentNullException(nameof(appToken));
            Client = new HttpClient();
            Client.BaseAddress = new Uri(baseAddress);
        }

        /// <summary>
        /// Консруктор для инициализации через токен персоны
        /// </summary>
        /// <param name="baseAddress">Адрес к GLPI Api</param>
        /// <param name="appToken">Токен приложения. Его нужно получить на веб страницы GLPI</param>
        /// <param name="userToken">Нужен для иниициализации. Его нужно получить на веб страницы GLPI</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected Glpi(string baseAddress,
                       string appToken,
                       string userToken) : this(baseAddress, appToken) =>
            UserToken = userToken ?? throw new ArgumentNullException(nameof(userToken));

        /// <summary>
        /// Консруктор для инициализации через логин и пароль
        /// </summary>
        /// <param name="baseAddress">Адрес к GLPI Api</param>
        /// <param name="appToken">Токен приложения. Его нужно получить на веб страницы GLPI</param>
        /// <param name="login">Логин для входа в GLPI</param>
        /// <param name="password">Пароль к логину</param>
        /// <exception cref="ArgumentNullException"/>
        [Obsolete(message: "Ненадежно")]
        protected Glpi(string baseAddress,
                       string appToken,
                       string login,
                       string password) : this(baseAddress, appToken)
        {
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="appToken"></param>
        /// <param name="body"></param>
        /// <param name="isFullInit"></param>
        /// <param name="isUt"></param>
        /// <param name="cancel"></param>
        /// <exception cref="ExceptionTestConnection"></exception>
        /// <returns></returns>
        private static async Task<bool> PTestConnection(string baseAddress,
                                                                  string appToken,
                                                                  string body,
                                                                  bool isFullInit,
                                                                  bool isUt = true,
                                                                  CancellationToken cancel = default)
        {
            using HttpClient http = new HttpClient();
            
            http.Timeout = TimeSpan.FromSeconds(5);
            
            http.BaseAddress = new Uri(baseAddress);
            
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            http.DefaultRequestHeaders.Add("app_token", appToken);
            
            http.DefaultRequestHeaders.Authorization = isUt ?
                new AuthenticationHeaderValue("user_token", body) :
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(body)));
            
            HttpResponseMessage message = await http.GetAsync(
                $"{(isFullInit ? "initSession?get_full_session=true" : "initSession")}",
                cancel);



            if (!message.IsSuccessStatusCode)
                throw new ExceptionTestConnection(
                    $"Status code:{message.StatusCode}\n{await message.Content.ReadAsStringAsync(cancel)}");
            
            Initialization init = JsonConvert.DeserializeObject<Initialization>(await message.Content.ReadAsStringAsync(cancel));
            http.DefaultRequestHeaders.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Add("Session-Token", init.SessionToken);
            http.DefaultRequestHeaders.Add("app_token", appToken);
            await http.GetAsync($"killSession", cancel);
            return true;

        }

        /// <summary>
        /// Проверка соединения с GLPI
        /// </summary>
        /// <param name="baseAddress">Адрес к GLPI Api</param>
        /// <param name="appToken">Токен приложения. Его нужно получить на веб старницы GLPI</param>
        /// <param name="userToken">Нужен для иниициализации. Его нужно получить на веб страницы GLPI</param>
        /// <param name="isFullInit">True - для полной инициализации, false - быстрая инициализация</param>
        /// <param name="cancel"></param>
        /// <returns>Если ответ 400 - это могло произойти либо на стороне GLPI или перехват ошибки при запросе. Другие ответы отправляет GLPI.</returns>
        public static async Task<bool> TestConnection(string baseAddress,
            string appToken,
            string userToken,
            bool isFullInit,
            CancellationToken cancel = default) =>
            await PTestConnection(baseAddress,
                appToken,
                userToken,
                isFullInit, cancel: cancel);


        /// <summary>
        /// Проверка соединения с GLPI
        /// </summary>
        /// <param name="baseAddress">Адрес к GLPI Api</param>
        /// <param name="appToken">Токен приложения. Его нужно получить на веб старницы GLPI</param>
        /// <param name="login">Логин для входа в GLPI</param>
        /// <param name="password">Пароль к логину</param>
        /// <param name="isFullInit">True - для полной инициализации, false - быстрая инициализация</param>
        /// <returns>Если ответ 400 - это могло произойти либо на стороне GLPI или перехват ошибки при запросе. Другие ответы отправляет GLPI.</returns>
        public static async Task<bool> TestConnection(string baseAddress,
            string appToken,
            string login,
            string password,
            bool isFullInit,
            CancellationToken cancel = default) =>
            await PTestConnection(baseAddress,
                appToken,
                $"{login}:{password}",
                isFullInit,
                false,
                cancel: cancel);


        /// <summary>
        /// Обязательная функция к вызову после создания объекта, которая инициализирует на стороне GLPI
        /// </summary>
        /// <param name="isFullInit">True - для полной инициализации, false - быстрая инициализация</param>
        /// <param name="isRephresh">True</param>
        /// <param name="cancel"></param>
        /// <exception cref="JsonException"/>
        /// <exception cref="Exception"/>
        /// <returns>Статус инициализации. Ответ 200 мб в 2 случаях. Если Init != null или запрос прошел успешно.</returns>
        public async Task<Initialization> Initialization(bool isFullInit,bool isRephresh = default, CancellationToken cancel = default)
        {
            if (Init != null && !isRephresh) return Init;

            HttpResponseMessage response;
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("app_token", AppToken);
            Client.DefaultRequestHeaders.Authorization = !string.IsNullOrEmpty(UserToken) ?
                new AuthenticationHeaderValue("user_token", UserToken) :
                new AuthenticationHeaderValue("Basic", $"{Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Login}:{Password}"))}");
            if (isFullInit)
                response = await Client.GetAsync($"initSession?get_full_session=true", cancel);
            else
                response = await Client.GetAsync($"initSession", cancel);
            string data = await response.Content.ReadAsStringAsync(cancel);
            Init = JsonConvert.DeserializeObject<Initialization>(data);
            response.Dispose();
            return Init;
        }

        /// <summary>
        /// Отправляет запрос на завершение сессии
        /// </summary>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="Exception"/>
        private async Task KillSession(CancellationToken cancel = default)
        {
            await SetHeaderDefault();
            await Client.GetAsync($"killSession", cancel);
        }

        /// <summary>
        /// Заполнение заголовка.
        /// Очистка => Application json => Session token => app token
        /// </summary>
        public async Task SetHeaderDefault() =>
            await Task.Run(() =>
            {
                Client.DefaultRequestHeaders.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Client.DefaultRequestHeaders.Add("Session-Token", Init.SessionToken);
                Client.DefaultRequestHeaders.Add("app_token", AppToken);
            });

        /// <summary>
        /// Отправляет GLPI запрос на завершение сессии, и закрывает объект Client.
        /// </summary>
        public async void Dispose()
        {
            await KillSession();
            Client.Dispose();
            
        }

        protected void Motor() => Task.Run(async () =>
         {
             while (true)
             {
                 await Task.Delay(200);
                 Request request;
                 if (QueueRequest.TryDequeue(out request))
                     request.ActionOut.Invoke(await request.FuncIn.Invoke());
             }
         }, Source.Token);
    }
}
