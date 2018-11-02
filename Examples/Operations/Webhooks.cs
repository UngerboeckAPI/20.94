using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Webhooks : Base
  {
    public Webhooks(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public WebhooksModel Get(string orgCode, int sequenceNbr)
    {
      return APIUtil.GetWebHook(USISDKClient, orgCode, sequenceNbr);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<WebhooksModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<WebhooksModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
