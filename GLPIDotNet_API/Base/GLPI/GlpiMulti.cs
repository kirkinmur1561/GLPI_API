using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Base.Request;


namespace GLPIDotNet_API.Base.GLPI
{
    public class GlpiMulti : IGlpiMulti
    {
        public string AppToken { get;}
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

        public uint TimeOut { get; }

        public Task<Initialization> Initialization(bool isFullInit, bool isRephresh = false, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public void SetHeaderDefault()
        {
            throw new NotImplementedException();
        }

        public Task KillSession(CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task Close()
        {
            throw new NotImplementedException();
        }

        private int _timeOutDelayMotor = 100;
        public Queue<ClientResponse> QueueRequest => new();
        public List<IGlpiClient> Clients { get; } = new();
        
        private GlpiMulti(
            int timeOutDelayMotor,
            string appToken,
            string userToken,            
            string login,
            string password,
            Initialization init,
            HttpClient client)
        {
            _timeOutDelayMotor = timeOutDelayMotor;
            AppToken = appToken;
            UserToken = userToken;
            Login = login;
            Password = password;
            Init = init;
            Client = client;
        }

        private GlpiMulti(string baseAddress,
            string appToken)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(baseAddress);
            AppToken = appToken;
        }

        public GlpiMulti(string baseAddress,
            string appToken,
            string userToken) : this(baseAddress, appToken) => UserToken = userToken;
        
            
        

        [Obsolete("Obsolete")]
        public GlpiMulti(string baseAddress, string appToken, string login, string password):this(baseAddress,appToken)
        {
            Login = login;
            Password = password;
        }

        public bool Equals(GlpiMulti other) =>
            UserToken == other.UserToken &&
            Login == other.Login &&
            Password == other.Password;
        

        public bool Equals(IGlpiMulti other) =>
            other != null && GetHashCode() == other.GetHashCode();

        public bool Equals(IGlpi other) =>
            other != null && GetHashCode() == other.GetHashCode();       

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((GlpiMulti)obj);
        }

        public override int GetHashCode() =>
            HashCode.Combine(UserToken, Login, Password);

        public object Clone() =>
            new GlpiMulti(
                _timeOutDelayMotor,
                AppToken,
                UserToken, 
                Login, 
                Password, 
                Init, 
                Client
            );

    }
}
