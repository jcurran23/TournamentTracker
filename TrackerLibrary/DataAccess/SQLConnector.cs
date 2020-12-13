using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public class SQLConnector : IDataConnection
    {

        //use Dapper as the connect URM (lookinto Entity framework, C# connection method...

        //TODO - Make the create prize actually save to the database
        /// <summary>
        /// saves a new prize to the database
        /// </summary>
        /// <param name="model">the prize information</param> 
        /// <returns></returns>

        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments"))) ;
            {

            }
        }
    }
}
