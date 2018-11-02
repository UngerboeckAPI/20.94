using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Bulletins : Base
  {
    public Bulletins(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public BulletinsModel Get(string orgCode, string bulletinApplication, int meeting, int bulletin)
    {
      return APIUtil.GetBulletin(USISDKClient, orgCode, bulletinApplication, meeting, bulletin);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<BulletinsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<BulletinsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
