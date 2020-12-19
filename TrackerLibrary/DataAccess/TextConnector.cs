using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary
{
    public class TextConnector : IDataConnection
    {

        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PeopleModels.csv";//TODO fix file name.

        public PersonModel CreatePerson(PersonModel model)
        {
            throw new NotImplementedException();
        }

        //TODO wire up to save to file
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //*load the text file
            //*convert text to a list of prizemodel
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
            //find the ID
            int currentId = 1;

            if (prizes.Count() > 0) { 
            currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            //Add the recort with the new ID
            model.Id = currentId;
            prizes.Add(model);

            //convert the prizes to a list of string
            prizes.SaveToPrizeFile(PrizesFile);
            //save the list of string to the text file

            return model;
        }
    }
}
