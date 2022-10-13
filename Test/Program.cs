using System;
using System.Linq;

using System.Threading.Tasks;
using System.Threading;
using GLPIDotNet_API.Dashboard;
using GLPIDotNet_API.Dashboard.Assets;
using GLPIDotNet_API.Dashboard.Helpdesk;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using GLPIDotNet_API.Dashboard.Administration;

using GLPIDotNet_API.Base;
using GLPIDotNet_API.Dashboard.Search;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Test
{
    class Program
    {
        static string addresstest2 = "http://sch1561uz.mosedu.net/glpi-test2/apirest.php/";
        static string addresstest = "http://sch1561uz.mosedu.net/glpi-test/apirest.php/";
        static string address = "http://sch1561uz.mosedu.net/glpi/apirest.php/";

        static string appToken = "LIt5Bx125XNOnXXrRKS55NuVn2rRgutvan92h8cv";/*"BMgEex0fOs7aMMN29sFlWa1dNqB4ZOrcVImyXJ9f";*/
        static string appTokenTest = "d5t53zZFbnSO9jeq8KyKJOTAVgroHrabsTTPpBn2";

        static string ut_main = "5y4MQasgI06IqdZ5HPP7y0gSq3PngtmTDocilOXL";
        static string ut_main_test = "ncRwbrKOnSTl7W4a6xtFuUxYwVbg7WiJLaOQ9DuX";

        static string ut_base = "ghzqcKounFfeCL317wekwOiUttF03pphxuO0EU5v";

        static string login_main = "muratovka-5";
        static string password_main = "Nokia2021kir!";

        
        static string login_base = "BasePerson";
        static string password_base = "Zz8W5cr6piS5eW6";
        
        static async Task Main(string[] args)
        {
            
            GlpiClient client = null;
            try
            {
                client = new GlpiClient(addresstest2, appTokenTest, login_base, password_base);
                await client.Initialization(true);
                var locs = (await Location.GetEnumerable(client))
                    .OrderBy(ob =>
                    {
                        if (string.IsNullOrEmpty(ob.building))
                            ob.building = "Другое";
                        if (Regex.IsMatch(ob.building, "0[0-9]"))
                            ob.building = ob.building.Replace("0", "");
                        return ob.building;
                    },new Location())
                    .GroupBy(gb => gb.building);

                Console.WriteLine("Select address:\n" + string.Join("\n", locs.Select(s => s.Key)));
                
               
            
                Console.WriteLine("Is ok");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                client?.Dispose();
            }

            
        }
        
        public class MyClass
        {
            public Dictionary<string, string> sons_cache;
        }
    }
}