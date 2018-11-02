using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Requisitions : Base
  {
    public Requisitions(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public RequisitionsModel Get(string orgCode, int number)
    {
      return APIUtil.GetRequisition(USISDKClient, orgCode, number);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<RequisitionsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<RequisitionsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
