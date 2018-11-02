using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class RequisitionItems : Base
  {
    public RequisitionItems(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public RequisitionItemsModel Get(string orgCode, int number, int sequence)
    {
      return APIUtil.GetRequisitionItem(USISDKClient, orgCode, number, sequence);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<RequisitionItemsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<RequisitionItemsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
