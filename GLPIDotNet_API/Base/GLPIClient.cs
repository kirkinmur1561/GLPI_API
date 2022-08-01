using System;

namespace GLPIDotNet_API.Base
{
    public class GlpiClient : Glpi
    {
        public GlpiClient(string baseAddress, string appToken, string userToken) : base(baseAddress, appToken, userToken)
        {
        }

        [Obsolete("Obsolete")]
        public GlpiClient(string baseAddress, string appToken, string login, string pass) : base(baseAddress, appToken,
            login, pass)
        {

        }
    }
}
