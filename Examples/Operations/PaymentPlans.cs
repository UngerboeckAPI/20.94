using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PaymentPlans : Base
  {
    public PaymentPlans(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PaymentPlansModel Get(string orgCode, int paymentPlanID)
    {
      return APIUtil.GetPaymentPlan(USISDKClient, orgCode, paymentPlanID);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<PaymentPlansModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<PaymentPlansModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
