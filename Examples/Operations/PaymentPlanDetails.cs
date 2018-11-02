using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PaymentPlanDetails : Base
  {
    public PaymentPlanDetails(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PaymentPlanDetailsModel Get(string orgCode, int payPlanID, int payNumber, int sequence)
    {
      return APIUtil.GetPaymentPlanDetail(USISDKClient, orgCode, payPlanID, payNumber, sequence);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<PaymentPlanDetailsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<PaymentPlanDetailsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
