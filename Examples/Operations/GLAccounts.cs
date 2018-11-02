using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class GLAccounts : Base
  {
    public GLAccounts(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public GlAccountsModel Get(string orgCode, string gLAccount, string subAccount)
    {
      return APIUtil.GetGLAccount(USISDKClient, orgCode, gLAccount, subAccount);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<GlAccountsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<GlAccountsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
