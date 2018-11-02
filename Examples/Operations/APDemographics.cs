using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class APDemographics : Base
  {
    public APDemographics(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public APDemographicsModel Get(string orgCode, string supplier)
    {
      return APIUtil.GetAPDemographic(USISDKClient, orgCode, supplier);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<APDemographicsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<APDemographicsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
