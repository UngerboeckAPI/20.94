using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class OpportunityStatuses : Base
  {
    public OpportunityStatuses(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public OpportunityStatusesModel Get(string orgCode, string code, string designation)
    {
      return APIUtil.GetOpportunityStatus(USISDKClient, orgCode, code, designation);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<OpportunityStatusesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<OpportunityStatusesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
