using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PaymentPlanHeaders : Base
  {
    public PaymentPlanHeaders(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PaymentPlanHeadersModel Get(string orgCode, int payPlanID, int payNumber)
    {
      return APIUtil.GetPaymentPlanHeader(USISDKClient, orgCode, payPlanID, payNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<PaymentPlanHeadersModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<PaymentPlanHeadersModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
