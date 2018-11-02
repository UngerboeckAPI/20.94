using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AccountTypes : Base
  {
    public AccountTypes(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public AccountTypesModel Get(string orgCode, string code)
    {
      return APIUtil.GetAccountType(USISDKClient, orgCode, code);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<AccountTypesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<AccountTypesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
