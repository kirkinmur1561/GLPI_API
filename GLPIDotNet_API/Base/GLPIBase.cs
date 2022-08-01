using System;
using System.Threading.Tasks;

namespace GLPIDotNet_API.Base
{
    public class GlpiBase : Glpi
    {

        public GlpiBase(string baseAddress,
                        string appToken,
                        string userToken) : base(baseAddress, appToken, userToken){}

        [Obsolete("Obsolete")]
        public GlpiBase(string baseAddress,string appToken,string login,string password):
            base(baseAddress, appToken, login, password){}

        public new async Task Dispose()
        {
            base.Dispose();
            Source.Cancel();
            await Task.Delay(1000);
            Source.Dispose();
            
        }
    }
}
