using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class CampaignDetails : Base
  {
    public CampaignDetails(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public CampaignDetailsModel Get(string orgCode, string CampaignDesignation, string Campaign, int SequenceNumber)
    {
      return APIUtil.GetCampaignDetail(USISDKClient, orgCode, CampaignDesignation, Campaign, SequenceNumber);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<CampaignDetailsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<CampaignDetailsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
