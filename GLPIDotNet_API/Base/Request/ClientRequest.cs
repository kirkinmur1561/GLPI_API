using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using GLPIDotNet_API.Base.GLPI;

namespace GLPIDotNet_API.Base.Request
{
    public class ClientRequest:IEquatable<ClientRequest>
    {
        public readonly Guid Guid;
        public readonly Func<Task<HttpResponseMessage>> FuncInput;
        
        public readonly Action<ClientResponse> ActionOut;

        public readonly IGlpiClient Client;
        public readonly PropertyInfo PropertyInfo;

        private ClientRequest(Guid guid) =>
            Guid = guid == default ? Guid.NewGuid() : guid;
       
            
        
        public ClientRequest(
            Func<Task<HttpResponseMessage>> funcInput, 
            Action<ClientResponse> actionOut,
            Guid guid = default):this(guid)
        {
            FuncInput = funcInput;
            ActionOut = actionOut;
        }


        public ClientRequest(
            Func<Task<HttpResponseMessage>> funcInput,
            Action<ClientResponse> actionOut,
            IGlpiClient client,
            PropertyInfo propertyInfo,
            Guid guid = default) : this(funcInput, actionOut, guid)

        {            
            Client = client;
            PropertyInfo = propertyInfo;
        }

        public bool Equals(ClientRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Guid.Equals(other.Guid) && Equals(Client, other.Client);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ClientRequest)obj);
        }

        public override int GetHashCode() =>
            HashCode.Combine(Guid, Client);


        public static bool operator ==(ClientRequest left, ClientRequest right) =>
            Equals(left, right);


        public static bool operator !=(ClientRequest left, ClientRequest right) =>
            !Equals(left, right);

    }
}