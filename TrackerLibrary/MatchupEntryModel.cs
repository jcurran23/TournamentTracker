using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// Represents one team in the matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// represents score for this team
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// represents previous matchup this team won
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }

    }
}
