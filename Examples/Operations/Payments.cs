using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Payments : Base
  {
    public Payments(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PaymentsModel Get(string orgCode, string accountCode, int sequence)
    {
      return APIUtil.GetPayment(USISDKClient, orgCode, accountCode, sequence);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<PaymentsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<PaymentsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary>  
    /// <param name="transaction">This is the value from the AR005_TSM column in AR005_TRANS_TYPES.  This sets the default for various fields in the background</param>
    public PaymentsModel Add(string orgCode, string accountCode, string noteText, string transaction, int paidAmount, int orderNumber)
    {
      var myPayment = new PaymentsModel
      {
        Organization = orgCode,
        Account = accountCode,
        Note = noteText,
        Transaction = transaction,
        PaidAmount = paidAmount,
        OrderNumber = orderNumber //Note that Event information is defaulted in from the order
      };

      return APIUtil.AddPayment(USISDKClient, myPayment);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public PaymentsModel Edit(string orgCode, string accountCode, int sequence, string NewNoteText)
    {
      var myPayment = APIUtil.GetPayment(USISDKClient, orgCode, accountCode, sequence);

      myPayment.Note = NewNoteText;

      return APIUtil.UpdatePayment(USISDKClient, myPayment);
    }
    public PaymentsModel EditAdvanced(string orgCode, string accountCode, int sequence)
    {

      var myPayment = APIUtil.GetPayment(USISDKClient, orgCode, accountCode, sequence);

      myPayment.Reference = "Check";    //This should not contain sensitive info for API use.  Corresponds with AR020_CC_CHECK
      myPayment.UserReference = "Some user info"; //Corresponds with AR020_USER_REFERENCE
      myPayment.Internal = "Y";          //Y or N for if the payment is internal or not
      myPayment.Date = System.DateTime.Now;              //This defaults to current date if not filled


      //The payor info fields should only be edited if the payor is a 3rd party
      //.Name = "Some Company"; Used for Organization Accounts
      myPayment.FirstName = "Adam";
      myPayment.LastName = "Jensen";
      myPayment.Address1 = "123 Some Street";
      myPayment.Address2 = "Block 4";
      myPayment.Address3 = "Apt D";
      myPayment.City = "Chicago";
      myPayment.State = "Illinois";
      myPayment.PostalCode = "60290";
      myPayment.Country = "***";  //The country code from the Ungerboeck Countries window.  *** is the default country.


      return APIUtil.UpdatePayment(USISDKClient, myPayment);
    }

    /// <summary>
    /// How to add a payment tied to an invoice 
    /// </summary>  
    /// <param name="transaction">This is the value from the AR005_TSM column in AR005_TRANS_TYPES.  This sets the default for various fields in the background</param>
    /// <param name="invoiceNumber">This is the sequence of the invoice (This is found in v20 under Invoices window -> Sequence column in grid.  Also in database as AR030_INVOICE)</param>
    public PaymentsModel AddInvoicePayment(string orgCode, string accountCode, string noteText, string transaction, int paidAmount, int invoiceNumber)
    {
      var myPayment = new PaymentsModel
      {
        Organization = orgCode,
        Account = accountCode,
        Note = noteText,
        Transaction = transaction,
        PaidAmount = paidAmount,
        Invoice = invoiceNumber,
        Date = System.DateTime.Now
      };

      return APIUtil.AddPayment(USISDKClient, myPayment);
    }
  }
}
