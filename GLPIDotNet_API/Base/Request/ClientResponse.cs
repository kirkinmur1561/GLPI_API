using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using GLPIDotNet_API.Base.GLPI;

namespace GLPIDotNet_API.Base.Request
{
    public class ClientResponse
    {
        public readonly HttpResponseMessage Response;       
        public readonly PropertyInfo RequestedProperty;
        public readonly IGlpiClient Client;
        

        public ClientResponse()
        {
            
        }

        public ClientResponse(HttpResponseMessage responseMessage) =>
            Response = responseMessage;

        public ClientResponse(
            HttpResponseMessage responseMessage,
            PropertyInfo requestedProperty,
            IGlpiClient client) : this(responseMessage)
        {
            RequestedProperty = requestedProperty;
            Client = client;
        }


    }
}