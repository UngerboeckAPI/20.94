using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Affiliations : Base
  {
    public Affiliations(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public AffiliationsModel Get(string orgCode, string affiliationCode)
    {
      return APIUtil.GetAffiliation(USISDKClient, orgCode, affiliationCode);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary>
    public IEnumerable<AffiliationsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<AffiliationsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
