using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Invoices : Base
  {
    public Invoices(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public InvoicesModel Get(string orgCode, string source, int invoiceNumber)
    {
      return APIUtil.GetInvoice(USISDKClient, orgCode, invoiceNumber, source);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<InvoicesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<InvoicesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public InvoicesModel Edit(string orgCode, int invoice, string source, string newStatus)
    {
      var myInvoice = APIUtil.GetInvoice(USISDKClient, orgCode, invoice, source);

      myInvoice.CollectionStatus = newStatus;

      return APIUtil.UpdateInvoice(USISDKClient, myInvoice);
    }
  }
}
