using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class RequisitionApproval : Base
  {
    public RequisitionApproval(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public RequisitionApprovalModel Get(string orgCode, int number, int line, int sequence)
    {
      return APIUtil.GetRequisitionApproval(USISDKClient, orgCode, number, line, sequence);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<RequisitionApprovalModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<RequisitionApprovalModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
