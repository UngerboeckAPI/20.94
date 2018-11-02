using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Concessions : Base
  {
    public Concessions(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ConcessionsModel Get(string orgCode, int sequenceNumber)
    {
      return APIUtil.GetConcession(USISDKClient, orgCode, sequenceNumber);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<ConcessionsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ConcessionsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
