using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AccountMailingLists : Base
  {
    public AccountMailingLists(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public AccountMailingListsModel Get(string orgCode, int iD)
    {
      return APIUtil.GetAccountMailingList(USISDKClient, orgCode, iD);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary>  
    public IEnumerable<AccountMailingListsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<AccountMailingListsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
