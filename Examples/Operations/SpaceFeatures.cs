using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class SpaceFeatures : Base
  {
    public SpaceFeatures(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SpaceFeaturesModel Get(string orgCode, string code)
    {
      return APIUtil.GetSpaceFeature(USISDKClient, orgCode, code);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<SpaceFeaturesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<SpaceFeaturesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
