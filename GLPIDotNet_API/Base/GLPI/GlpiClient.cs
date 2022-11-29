using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Base.Request;
using Newtonsoft.Json;

namespace GLPIDotNet_API.Base.GLPI
{
    public class GlpiClient : IGlpiClient
    {      
        public bool IsClone { get; private set; } = false;
        public string AppToken { get; }
        public string UserToken { get; }
        public string Login { get; }
        public string Password { get; }
        public Initialization Init { get; set; }
        public HttpClient Client { get; }
        public int TimeOutDelayMotor { get=>_timeOutDelayMotor;
            set
            {
                if (value == _timeOutDelayMotor) return;
                _timeOutDelayMotor = value is < 20 or > 1000 ? 100 : value;
            }
        }

        public uint TimeOut
        {
            get => _timeOut;
            set
            {
                if (_timeOut == value || value is < 5_000 or > 90_001) return;
                _timeOut = value;
            }
        }
        private uint _timeOut = 10_000;

        public async Task<Initialization> Initialization(bool isFullInit, bool isRephresh = false, CancellationToken cancel = default)
        {
            if (Client == null) throw new ArgumentException("No init object", nameof(Client));
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
            if (!response.IsSuccessStatusCode) throw new System.Exception(data);
            Init = JsonConvert.DeserializeObject<Initialization>(data);
            response.Dispose();
            return Init;
        }

        public void SetHeaderDefault()
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Session-Token", Init.SessionToken);
            Client.DefaultRequestHeaders.Add("app_token", AppToken);
        }

        public async Task KillSession(CancellationToken cancel = default) =>
            await Client.GetAsync($"killSession", cancel);
        
        public async Task Close()
        {
            await KillSession();
            Init = null;
            Client.Dispose();
        }

        private int _timeOutDelayMotor = 100;
        public Queue<ClientRequest> QueueRequest { get; private set; }
        public CancellationTokenSource StopMotor { get; }
        public void Motor()=> Task.Run(async () =>
        {
            if(StopMotor.IsCancellationRequested) return;            
            bool isNotStop = false;          
            while (true)
            {                
                if (!isNotStop) await Task.Delay(TimeOutDelayMotor, StopMotor.Token);

                if (QueueRequest.TryDequeue(out var request))
                {
                    var response = await request.FuncInput.Invoke();                    
                    request.ActionOut.Invoke(new ClientResponse(
                        response,
                        request.PropertyInfo,
                        request.Client)); 
                }
                                                        
                
                isNotStop = QueueRequest.Any();                
            }
        }, StopMotor.Token);
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="appToken"></param>
        /// <param name="isActiveMotor"></param>
        /// <param name="cancel"></param>
        private GlpiClient(string baseAddress,
            string appToken,
            bool isActiveMotor = true,
            CancellationTokenSource cancel = default)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(baseAddress);
            AppToken = appToken;
            QueueRequest = new Queue<ClientRequest>();
            StopMotor = cancel ?? new CancellationTokenSource();
            if (isActiveMotor) Motor();
        }
        
        /// <summary>
        /// Специально для интрефейса ICloneable
        /// </summary>        
        private GlpiClient(
            CancellationTokenSource cancel,
            int timeOutDelayMotor = default,
            string appToken = null,
            string userToken = null,
            string login = null,
            string password = null,
            Initialization init = null,
            HttpClient client = null)
        {
            _timeOutDelayMotor = timeOutDelayMotor;
            AppToken = appToken;
            UserToken = userToken;
            Login = login;
            Password = password;
            Init = init;
            Client = client;                       
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="appToken"></param>
        /// <param name="userToken"></param>
        /// <param name="isActiveMotor"></param>
        /// <param name="cancelMotor"></param>
        public GlpiClient(string baseAddress,
            string appToken,
            string userToken,
            bool isActiveMotor = true,
            CancellationTokenSource cancelMotor = default) : this(baseAddress, appToken, isActiveMotor, cancelMotor) =>
            UserToken = userToken;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="appToken"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="isActiveMotor"></param>
        /// <param name="cancelMotor"></param>
        [Obsolete("I do not recommend sending login and password. Use a constructor with a token.")]
        public GlpiClient(string baseAddress,
            string appToken,
            string login,
            string password,
            bool isActiveMotor = true,
            CancellationTokenSource cancelMotor = default) : this(baseAddress, appToken,isActiveMotor, cancelMotor)
        {
            Login = login;
            Password = password;            
        }
        
        protected bool Equals(GlpiMulti other) =>
            UserToken == other.UserToken &&
            Login == other.Login &&
            Password == other.Password;        

        public bool Equals(IGlpiMulti other) =>
            other != null && GetHashCode() == other.GetHashCode();

        public bool Equals(IGlpi other) =>
            other != null && GetHashCode() == other.GetHashCode();

        public bool Equals(IGlpiClient other) =>
            other != null && GetHashCode() == other.GetHashCode();            
        

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((GlpiClient)obj);
        }
        
        public override int GetHashCode() =>
            HashCode.Combine(UserToken, Login, Password);


        /// <summary>
        /// Используется совместно с GlpiMulty
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var clone = new GlpiClient(
                new CancellationTokenSource(),
                _timeOutDelayMotor,
                AppToken,
                UserToken,
                Login,
                Password,
                Init,
                Client
            );           
            clone.IsClone = true;
            _timeOut = clone._timeOut;
            return clone;
        }
                

        public bool Equals(GlpiClient other) =>
            UserToken == other.UserToken && Login == other.Login && Password == other.Password;
    }
}
