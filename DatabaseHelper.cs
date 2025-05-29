using System.Configuration;

namespace RECMS.Helpers
{
    public class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["RE_DBMS"].ConnectionString;
        }
    }
}
