using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class WorkOrderItems : Base
  {
    public WorkOrderItems(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public WorkOrderItemsModel Get(string orgCode, int OrderNbr, int OrderLineNbr)
    {
      return APIUtil.GetWorkOrderItem(USISDKClient, orgCode, OrderNbr, OrderLineNbr);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<WorkOrderItemsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<WorkOrderItemsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
