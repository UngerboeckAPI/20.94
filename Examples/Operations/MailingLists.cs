using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class MailingLists : Base
  {
    public MailingLists(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MailingListsModel Get(string orgCode, int ID)
    {
      return APIUtil.GetMailingList(USISDKClient, orgCode, ID);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<MailingListsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<MailingListsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
