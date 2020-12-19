using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public class SQLConnector : IDataConnection
    {
        public PersonModel CreatePerson(PersonModel model)
        {
           using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@CellphoneNumer", model.CellPhoneNumber); //TODO fix the cell phone references
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }


        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
               
               connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }
    }
}


//use Dapper as the connect URM (lookinto Entity framework, C# connection method...

//TODO - Make the create prize actually save to the database
/// <summary>
/// saves a new prize to the database
/// </summary>
/// <param name="model">the prize information</param> 
/// <returns></returns>


// @PlaceNumber int,
// @PlaceName nvarchar(50),
// @PrizeAmount money,
//  @prizePercentage float