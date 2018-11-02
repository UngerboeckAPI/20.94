using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ARDemographics : Base
  {
    public ARDemographics(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public ARDemographicsModel Get(string orgCode, string account)
    {
      return APIUtil.GetARDemographic(USISDKClient, orgCode, account);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<ARDemographicsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ARDemographicsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
