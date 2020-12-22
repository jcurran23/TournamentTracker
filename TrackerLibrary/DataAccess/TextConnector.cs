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
        private const string PersonFile = "PersonModels.csv";//TODO fix file name.

        public PersonModel CreatePerson(PersonModel model)
        {
            //*load the text file
            //*convert text to a list of PersonMdel
            List<PersonModel> people = PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();
            //find the ID
            int currentId = 1;

            if (people.Count() > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }
            //Add the recort with the new ID
            model.Id = currentId;
            people.Add(model);

            //convert the prizes to a list of string
            people.SaveToPersonFile(PersonFile);
            //save the list of string to the text file

            return model;

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

        public List<PersonModel> GetPerson_All()
        {
            throw new NotImplementedException();
        }
    }
}
