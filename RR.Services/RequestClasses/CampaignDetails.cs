using RR.Models.Rewards_Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.Services.RequestClasses
{
    public  class CampaignDetails
    {

        public Campaigns Campaigns { get; set; }

        public int countOfNominations { get; set; }
    }
}
