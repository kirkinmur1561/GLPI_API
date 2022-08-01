namespace GLPIDotNet_API.Base
{
     public class ResponseTestConnection
    {
        protected ResponseTestConnection(int numStatusCode, string responseContent)
        {
            NumStatusCode = numStatusCode;
            ResponseContent = responseContent;
        }

        public int NumStatusCode  { get; private set; }
        public string ResponseContent { get; private set; }

        public static ResponseTestConnection Convert(int sc, string content) =>
            new ResponseTestConnection(sc, content);
    }
}
