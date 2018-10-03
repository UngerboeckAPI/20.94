using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class MembershipOrders : Base
  {
    public MembershipOrders(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MembershipOrdersModel Get(string orgCode, int orderNumber)
    {
      return APIUtil.GetMembershipOrder(USISDKClient, orgCode, orderNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<MembershipOrdersModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<MembershipOrdersModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="account">This should be a single account code</param>
    /// <param name="priceList">The price list code</param>
    /// <param name="billingCycle">This is the user-configurable Billing cycle code on the order, which is pulled from Order Cycle v20 window</param>
    /// <param name="periodCycle">This is the user-configurable Period cycle code on the order, which is pulled from Order Cycle v20 window</param>
    public MembershipOrdersModel Add(string orgCode, string account, string priceList, string billingCycle, string periodCycle)
    {

      var myMembershipOrder = new MembershipOrdersModel
      {
        OrganizationCode = orgCode,
        OrderStatus = "A", //This is the user-configurable status code on the order
        Account = account,
        MembershipStart = System.DateTime.Now,
        MembershipEnd = System.DateTime.Now,
        PriceList = priceList,
        BillToAccount = account,  //This can be a different account code
        BillingDate = System.DateTime.Now,
        BillingCycle = billingCycle,
        PeriodCycle = periodCycle,
      };

      return APIUtil.AddMembershipOrder(USISDKClient, myMembershipOrder);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public MembershipOrdersModel Edit(string orgCode, int orderNumber, string orderStatus)
    {
      var myMembershipOrder = APIUtil.GetMembershipOrder(USISDKClient, orgCode, orderNumber);

      myMembershipOrder.OrderStatus = orderStatus;

      return APIUtil.UpdateMembershipOrder(USISDKClient, myMembershipOrder);
    }

    public MembershipOrdersModel EditAdvanced(string orgCode, int orderNumber)
    {

      var myMembershipOrder = APIUtil.GetMembershipOrder(USISDKClient, orgCode, orderNumber);

      string myAccount = "12345678"; //This represents an account code in Ungerboeck

      myMembershipOrder.BillToContact = myAccount;
      myMembershipOrder.Contact = myAccount;
      myMembershipOrder.RequesterAccount = myAccount;
      myMembershipOrder.RequesterContact = myAccount;
      myMembershipOrder.AccountRep = myAccount;
      myMembershipOrder.OrderDate = System.DateTime.Now;
      myMembershipOrder.Description = "Test Description";
      myMembershipOrder.GLAccount = myAccount;
      myMembershipOrder.Terms = "TT"; //Code for Customer Terms
      myMembershipOrder.PONumber = "Test";
      myMembershipOrder.Printed = "Y";
      myMembershipOrder.Taxable = "Y";

      return APIUtil.UpdateMembershipOrder(USISDKClient, myMembershipOrder);
    }

    /// <summary>
    /// This is an example of how to prepare a membership order for invoicing
    /// </summary>
    /// <param name="orgCode">Organization Code attached to the Membership Order you want to prepare</param>
    /// <param name="orderNumber">The order number of the Membership order you want to prepare</param>
    public void PrepareMembershipOrderForInvoicing(string orgCode, int orderNumber)
    {
      //Note that only error responses are returned from this action call --.Wait() allows errors to catch properly here.
      APIUtil.AwaitPrepareMembershipOrderForInvoicing(USISDKClient, orgCode, orderNumber).Wait();
    }

    /// <summary>
    /// An example for how to close an order
    /// </summary>
    public MembershipOrdersModel CloseOrder(string orgCode, int orderNumber)
    {
      var myMembershipOrder = APIUtil.GetMembershipOrder(USISDKClient, orgCode, orderNumber);

      myMembershipOrder.OrderStatus = "C"; //Ensure this is a status code with a class of Closed on the v20 Order Status Master window
      myMembershipOrder.CloseDate = System.DateTime.Now;

      return APIUtil.UpdateMembershipOrder(USISDKClient, myMembershipOrder);
    }

    /// <summary>
    /// An example for how to open an order
    /// </summary>
    public MembershipOrdersModel OpenOrder(string orgCode, int orderNumber)
    {
      var myMembershipOrder = APIUtil.GetMembershipOrder(USISDKClient, orgCode, orderNumber);

      myMembershipOrder.OrderStatus = "A"; //Ensure this is a status code with a class of either Active or Hold on the v20 Order Status Master window
      //Note that clearing the CloseDate is not necessary.

      return APIUtil.UpdateMembershipOrder(USISDKClient, myMembershipOrder);
    }
  }
}
