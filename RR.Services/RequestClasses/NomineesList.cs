using RR.Models.OtherRewardsInfo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.Services.RequestClasses
{
    public class NomineesList
    {
        public int IDOfNomination { get; set; }
        public string NominatorId {  get; set; }

        public string NomineeId { get; set; }

        public int stars { get; set; }

        public string voterId { get; set; }

        public int campaignId { get; set; }

        public string designation { get;set; }

        public string name { get; set; }

        public string citation { get; set; }

        public virtual ICollection<LeadCitationReplies> LeadCitationReplies { get; set; }



    }
}
