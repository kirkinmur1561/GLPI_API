using System;
using System.Text;
using GLPIDotNet_API.Base;
using GLPIDotNet_API.Base.GLPI;

namespace GLPIDotNet_API.Exception
{
    public class ExceptionCheck:System.Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="glpiClientaram>
        public ExceptionCheck(IGlpi glpiClient):base("Error in object. Check source property.")
        {
            var textError = new[]
            {
                "GLPI Client not equal null. ",
                "GLPI App token in correct or not equal null or empty. ",
                "GLPI Init not equal null. May be you not action function Initialization. ",
                "GLPI Session token not equal null or empty. ",
                "Error base address."
            };
            Uri uri;
            StringBuilder sbError = new StringBuilder("Check GLPI object. ");
            if (glpiClient.Client != null)
            {
                if (!Uri.TryCreate(glpiClient.Client?.BaseAddress?.ToString(), UriKind.Absolute, out uri))
                    sbError.Append(textError[4]);
            }
            else
                sbError.Append(textError[0]);

            if (string.IsNullOrEmpty(glpiClient.AppToken)) sbError.Append(textError[1]);
            if (glpiClient.Init == null) sbError.Append(textError[2]);
            if (string.IsNullOrEmpty(glpiClient.Init?.SessionToken)) sbError.Append(textError[3]);
           
            Source =  sbError.ToString();
        }
    }
}