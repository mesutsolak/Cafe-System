using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class CampaignOperation : BaseOperation
    {
        public static int CampaignAdd(Campaign campaign)
        {
            _data.CampaignRepository.Add(campaign);
            return _data.Complete();
        }

        public static int CampaignUpdate(Campaign campaign)
        {
            _data.CampaignRepository.Update(campaign);
            return _data.Complete();
        }

        public static int CampaignRemove(int CampaignId)
        {
            _data.CampaignRepository.Remove(CampaignId);
            return _data.Complete();
        }

        public static Campaign GetCampaign(int CampaignId)
        {
            return _data.CampaignRepository.GetById(CampaignId);
        }

        public static List<Campaign> GetListCampaigns()
        {
            return _data.CampaignRepository.GetAll(null, x => x.IsDeleted == false);
        }
    }
}
