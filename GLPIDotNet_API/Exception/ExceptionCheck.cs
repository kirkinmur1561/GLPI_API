using System.Text;
using GLPIDotNet_API.Base;

namespace GLPIDotNet_API.Exception
{
    public class ExceptionCheck:System.Exception
    {
        public ExceptionCheck(IGlpi _glpi):base("Error in object. Check source property.")
        {
            var text_error = new[]
            {
                "GLPI Client not equal null. ",
                "GLPI App token in correct or not equal null or empty. ",
                "GLPI Init not equal null. May be you not action function Initialization. ",
                "GLPI Session token not equal null or empty. "
            };
            StringBuilder sb_error = new StringBuilder("Check GLPI object. ");
            if (_glpi.Client == null) sb_error.Append(text_error[0]);
            if (string.IsNullOrEmpty(_glpi.AppToken)) sb_error.Append(text_error[1]);
            if (_glpi.Init == null) sb_error.Append(text_error[2]);
            if (string.IsNullOrEmpty(_glpi.Init?.SessionToken)) sb_error.Append(text_error[3]);
            Source =  sb_error.ToString();
        }
    }
}