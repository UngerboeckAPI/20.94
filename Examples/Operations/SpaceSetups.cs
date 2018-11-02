using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class SpaceSetups : Base
  {
    public SpaceSetups(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SpaceSetupsModel Get(string orgCode, string space, string code)
    {
      return APIUtil.GetSpaceSetup(USISDKClient, orgCode, space, code);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<SpaceSetupsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<SpaceSetupsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
