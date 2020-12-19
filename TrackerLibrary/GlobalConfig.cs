using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {

        public static IDataConnection Connection { get; private set; } 



        public static void InitializeConnections(DatabaseType db) 
        {

            if (db == DatabaseType.Sql)
            {
                //TODO - setup the sql connector properly
                SQLConnector sql = new SQLConnector();
                Connection = sql;
            }

            else if (db == DatabaseType.Textfile)
            {
                //TODO - setup the text connector properly
                TextConnector text = new TextConnector();
                Connection = text;

            }

 /*
switch (db)
{
    case DatabaseType.Sql:
        break;
    case DatabaseType.Textfile:
        break;
    default:
        break;
}
*/
        }

        public static string CnnString(string name)
        {
           return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
