using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class WorkOrders : Base
  {
    public WorkOrders(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public WorkOrdersModel Get(string orgCode, int order, string department)
    {
      return APIUtil.GetWorkOrder(USISDKClient, orgCode, order, department);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<WorkOrdersModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<WorkOrdersModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
