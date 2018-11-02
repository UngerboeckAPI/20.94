using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Campaigns : Base
  {
    public Campaigns(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public CampaignsModel Get(string orgCode, string ID, string designation)
    {
      return APIUtil.GetCampaign(USISDKClient, orgCode, ID, designation);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<CampaignsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<CampaignsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
