using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Distributions : Base
  {
    public Distributions(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public DistributionsModel Get(string orgCode, string bulletinApplication, int meeting, int bulletin, int distributionEntrySeqNbr)
    {
      return APIUtil.GetDistribution(USISDKClient, orgCode, bulletinApplication, meeting, bulletin, distributionEntrySeqNbr);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<DistributionsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<DistributionsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
