using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RR.DataBaseConnect;
using RR.Models.EmployeeInfo;
using RR.Models.OtherRewardsInfo;
using RR.Models.Rewards_Campaigns;
using RR.Services.RequestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.Services
{
    public class OtherRewardsServices
    {
        private readonly DataBaseAccess dataBaseAccess;

        public OtherRewardsServices()
        {

        }

        public OtherRewardsServices(DataBaseAccess dataBaseAccess)
        {
            this.dataBaseAccess = dataBaseAccess;
        }


        public async Task<ActionResult<IEnumerable<OtherRewards>>> GetRewards()
        {
            var result = await dataBaseAccess.OtherRewards.ToListAsync();
            return result;
        }

        public async Task<ActionResult<OtherRewards>> AddReward(RequestOtherRewards requestOtherRewards)
        {
            OtherRewards otherRewards = new OtherRewards();

            otherRewards.CampaignId = requestOtherRewards.CampaignId;

            otherRewards.NominatorId = requestOtherRewards.NominatorId;

            otherRewards.NomineeId = requestOtherRewards.NomineeId;

            otherRewards.AwardCategory = requestOtherRewards.AwardCategory;

            otherRewards.Month = requestOtherRewards.Month;

            otherRewards.Stars = requestOtherRewards.Stars;

            Campaigns campaign = await dataBaseAccess.Campaigns.FirstOrDefaultAsync(x => x.Id == otherRewards.CampaignId);

            otherRewards.RewardId = campaign.RewardId;


            // Add Employee reference

            Employee employee = await dataBaseAccess.Employee.FirstOrDefaultAsync(x => x.EmployeeId.Equals(otherRewards.NomineeId));

            otherRewards.Employee = employee;




            // Add Campaign reference

            Campaigns campaigns = await dataBaseAccess.Campaigns.FirstOrDefaultAsync(x => x.Id == otherRewards.CampaignId);

            otherRewards.Campaigns = campaigns;



            // Results table post

            OtherRewardResults otherRewardResults = new OtherRewardResults();

            otherRewardResults.RewardId = otherRewards.RewardId;



            otherRewardResults.CampaignId = otherRewards.CampaignId;

            otherRewardResults.NominatorId = otherRewards.NominatorId;

            otherRewardResults.NomineeId = otherRewards.NomineeId;

            otherRewardResults.AwardCategory = otherRewards.AwardCategory;

            otherRewardResults.Employee = employee;

            otherRewardResults.Campaigns = campaigns;

            otherRewardResults.Stars = otherRewards.Stars;

            otherRewardResults.CampaignName = dataBaseAccess.Campaigns.Find(otherRewardResults.CampaignId).CampaignName;

            // add Citation

            LeadCitation citation = new LeadCitation();

            citation.Citation = requestOtherRewards.Citation;
            citation.NominatorId = requestOtherRewards.NominatorId;
            otherRewards.LeadCitation = citation;

            /// cmp added 
            citation.Campaigns = campaigns;




            // Add Final Connections

            otherRewards.LeadCitation = citation;

            otherRewards.OtherRewardResults = otherRewardResults;



            //save to database

            await dataBaseAccess.OtherRewards.AddAsync(otherRewards);

            await dataBaseAccess.SaveChangesAsync();


            return otherRewards;



        }



        // CitationReplyController
        public async Task<ActionResult<LeadCitationReplies>> AddReply(RequestLeadCitationReplies requestLeadCitationReplies)
        {
            LeadCitationReplies leadCitationReplies = new LeadCitationReplies();

            // Foreign KEy values added

            leadCitationReplies.Campaigns = dataBaseAccess.Campaigns.FirstOrDefault(x => x.Id == requestLeadCitationReplies.CampaignId);


            // required values

            leadCitationReplies.ReplyCitation = requestLeadCitationReplies.ReplyCitation;

            leadCitationReplies.NominatorId = requestLeadCitationReplies.NominatorId;

            leadCitationReplies.ReplierId = requestLeadCitationReplies.ReplierId;

            leadCitationReplies.CampaignId = requestLeadCitationReplies.CampaignId;

            // leadCitationReplies.LeadCitation = dataBaseAccess.LeadCitation.
            //    FirstOrDefault(x => x.NominatorId.Equals(requestLeadCitationReplies.NominatorId) && x.Campaigns.Id == requestLeadCitationReplies.CampaignId);

            leadCitationReplies.LeadCitationId = requestLeadCitationReplies.leadCitationId;
            await dataBaseAccess.LeadCitationReplies.AddAsync(leadCitationReplies);

            await dataBaseAccess.SaveChangesAsync();

            return leadCitationReplies;
        }

        public async Task<ActionResult<IEnumerable<LeadCitation>>> getCitationWithReplies()
        {
            var result = await dataBaseAccess.LeadCitation.ToListAsync();

            result.ForEach(async x =>
            {
               // x.LeadCitationReplies = dataBaseAccess.LeadCitationReplies.Where(r => r.LeadCitation.Id == x.Id).ToList();
            });

            return result;
        }
    }
}
