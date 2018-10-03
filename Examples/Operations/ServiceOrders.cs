using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ServiceOrders : Base
  {
    public ServiceOrders(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public ServiceOrdersModel Get(string orgCode, int orderNumber)
    {
      return APIUtil.GetServiceOrder(USISDKClient, orgCode, orderNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<ServiceOrdersModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ServiceOrdersModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="Event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus">This is the user-configurable status code on the order</param>
    /// <param name="accountCode">This should be a single account code</param>
    /// <param name="function">The event ID of the event attached to the order</param>
    /// <param name="billToAccount"></param>
    /// <param name="priceList">The price list code. You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>    
    public ServiceOrdersModel Add(string orgCode, int Event, string orderStatus, string accountCode, int function, string billToAccount, string priceList)
    {
      var myServiceOrder = new ServiceOrdersModel
      {
        OrganizationCode = orgCode,
        Event = Event,
        OrderStatus = orderStatus,
        Account = accountCode,
        Function = function,
        BillToAccount = billToAccount,
        PriceList = priceList,
      };

      return APIUtil.AddServiceOrder(USISDKClient, myServiceOrder);
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="Event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus">This is the user-configurable status code on the order</param>
    /// <param name="accountCode">This should be a single account code</param>
    /// <param name="function">The event ID of the event attached to the order</param>
    /// <param name="billToAccount"></param>
    /// <param name="priceList">The price list code. You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>    
    /// <param name="issueType">This is the Issue Type code of the registration user field set.  Example string value "CK"</param>
    /// <param name="userText05Value">This is just an example of the user fields you can set</param>
    public ServiceOrdersModel AddWithUserFields(string orgCode, int Event, string orderStatus, string accountCode, int function, string billToAccount, string priceList, string issueType, int userNumber03Value)
    {
      var myServiceOrder = new ServiceOrdersModel
      {
        OrganizationCode = orgCode,
        Event = Event,
        OrderStatus = orderStatus,
        Account = accountCode,
        Function = function,
        BillToAccount = billToAccount,
        PriceList = priceList
      };

      myServiceOrder.ServiceOrderUserFieldSets = new List<UserFields>();
      var myUserField = new UngerboeckSDKPackage.UserFields();

      myUserField.Type = issueType; //Use the Opportunity Type code from your user field.  This matches the value stored in Ungerboeck table column CR073_ISSUE_TYPE.
      myUserField.UserNumber03 = userNumber03Value; //Set the value in the user field property
      myServiceOrder.ServiceOrderUserFieldSets.Add(myUserField); //Then add it back into the RegistrationOrdersModel object.  You can add multiple user field sets to the same registration order object before saving.
      
      return APIUtil.AddServiceOrder(USISDKClient, myServiceOrder);
    }


    public ServiceOrdersModel Edit(string orgCode, int orderNumber, string orderStatus)
    {
      var myServiceOrder = APIUtil.GetServiceOrder(USISDKClient, orgCode, orderNumber);

      myServiceOrder.OrderStatus = orderStatus;

      return APIUtil.UpdateServiceOrder(USISDKClient, myServiceOrder);
    }

    /// <summary>
    /// This example is designed to show sample values to use in other editable properties.  For more information, see the model property info in the /api/help sandbox.
    /// </summary>
    public ServiceOrdersModel EditAdvanced(string orgCode, int orderNbr)
    {

      var myServiceOrder = APIUtil.GetServiceOrder(USISDKClient, orgCode, orderNbr);

      const string myAccount = "EZIO";  //This represents an account code in Ungerboeck
      const string myContact = "00026260"; //This represents an account code for a contact of the above account in Ungerboeck
      const string myInternalUserAccountCode = "00014106"; //This represents a personnel designated account code in Ungerboeck


      myServiceOrder.Account = myAccount; //This is on the example web layout
      myServiceOrder.Contact = myContact;

      myServiceOrder.BillToContact = myContact;

      myServiceOrder.RequesterAccount = myAccount;
      myServiceOrder.RequesterContact = myContact;

      myServiceOrder.ShipToAccount = myAccount;
      myServiceOrder.ShiptoContact = myContact;

      myServiceOrder.Exhibitor = 15910;  //The code of the Exhibitor.  This is matching the "Exhibitor" order field in Ungerboeck.

      myServiceOrder.OrderAccountRep = myInternalUserAccountCode;

      myServiceOrder.Category = 11; //This is the Order Categories sequence.  You can find this on the Order Categories window in Ungerboeck
      myServiceOrder.OrderDate = System.DateTime.Now;
      myServiceOrder.GLAccount = "TEST";
      myServiceOrder.PONumber = "123456";
      myServiceOrder.Promotion = "MSP"; //This correlates with the code of the Promotion (ER098_PROMOTIONS -> ER098_PROMO_CODE)
      myServiceOrder.ShippingMethod = "1ST"; //This is the Shipping Method code
      myServiceOrder.Department = "AUDIO"; //The department code
      myServiceOrder.PaymentPlan = 22133;  //In v20, this field is represented as a hyperlink that allows you to create a new plan or add to a selected plan.  Here, you are allowed to attach the Service Order to a valid pre-existing payment plan ID.  This is the ER200_PAY_PLAN_ID column on table ER200_PAYMENT_PLAN.

      //Y or N
      myServiceOrder.Taxable = "Y";
      myServiceOrder.FixedOrder = "Y";
      myServiceOrder.Printed = "Y";

      return APIUtil.UpdateServiceOrder(USISDKClient, myServiceOrder);
    }

    /// <summary>
    /// Move order example
    /// </summary>
    /// <param name="orderNumber">Set OrderNumber as an integers of the order number to move</param>
    /// <param name="newEventID">This is the destination event ID.  You can find this attached this to the Events window in Ungerboeck</param>
    /// <param name="functionID">This is the destination function ID on the destination event. This is required for service orders</param>
    public void MoveOrder(string orgCode, int orderNumber, int newEventID, int functionID)
    {
      var myserviceOrder = new MoveOrderModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        DestinationEventID = newEventID,
        Function = functionID,
        KeepDateTimes = "N" //If "Y", the original order item start/end date will be preserved.  If "N", the moved order will adapt to the function start/end date.
      };

      APIUtil.AwaitMoveServiceOrder(USISDKClient, myserviceOrder).Wait();
    }

    /// <summary>
    /// Move order example
    /// </summary>
    /// <param name="orderNumber">Set OrderNumber as an array of integers</param>
    /// <param name="newEventID">This is the destination event ID.  You can find this attached this to the Events window in Ungerboeck</param>
    /// <param name="functionID">This is the destination function ID on the destination event. This is required for service orders</param>
    public IEnumerable<MoveOrdersBulkErrorsModel> MoveOrderBulk(string orgCode, int[] orderNumber, int newEventID, int functionID)
    {
      var mymoveBulkOrder = new MoveOrdersBulkModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        DestinationEventID = newEventID,
        Function = functionID,
        KeepDateTimes = "N" //If "Y", the original order item start/end date will be preserved.  If "N", the moved order will adapt to the function start/end date.
      };

      //For bulk operations, 200 only signifies that the process successfully ran.  Individual items might have had issues saving.  Check the response object for bulk errors.
      //One or more errors with saving the items if an error object was returned.        
      return APIUtil.MoveServiceOrdersBulk(USISDKClient, mymoveBulkOrder);
    }

    public void CompleteWorkOrder(string orgCode, int orderNumber)
    {
      APIUtil.AwaitCompleteWorkOrders(USISDKClient, orgCode, orderNumber).Wait();
    }
  }
}
