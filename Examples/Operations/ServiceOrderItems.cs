using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ServiceOrderItems : Base
  {
    public ServiceOrderItems(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ServiceOrderItemsModel Get(string orgCode, int orderNumber, int orderLineNumber)
    {
      return APIUtil.GetServiceOrderItem(USISDKClient, orgCode, orderNumber, orderLineNumber);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<ServiceOrderItemsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ServiceOrderItemsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="orderNumber">The order number of the item's parent order</param>
    /// <param name="units">The amount of items you want on the order</param>
    /// <param name="priceListDetailSeqNbr">This should be filled in as the Price List Sequence number (CC716_SEQ) of the item you wish to add.  It should belong to the Order's price list items (Check CC716_PRICE_LIST_DTL).  You can see this value by going to v20->main menu->price lists-> edit price list-> price list item grid -> show column "Sequence"</param>    
    public ServiceOrderItemsModel Add(string orgCode, int orderNumber, int units, int priceListDetailSeqNbr)
    {
      var myServiceOrderItem = new ServiceOrderItemsModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        Units = units,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now,
        StartTime = System.DateTime.Now,
        EndTime = System.DateTime.Now,
        PriceListDetailSeqNbr = priceListDetailSeqNbr,
      };

      return APIUtil.AddServiceOrderItem(USISDKClient, myServiceOrderItem);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="itemStatus">The order item status is set to the code found in the Order Item Status Master window of v20</param>
    /// <returns></returns>
    public ServiceOrderItemsModel Edit(string orgCode, int orderNumber, int orderLineNumber, string itemStatus)
    {
      var myServiceOrderItem = APIUtil.GetServiceOrderItem(USISDKClient, orgCode, orderNumber, orderLineNumber);

      myServiceOrderItem.ItemStatus = itemStatus;

      return APIUtil.UpdateServiceOrderItem(USISDKClient, myServiceOrderItem);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, int orderNumber, int orderLineNumber)
    {
      APIUtil.AwaitDeleteServiceOrderItem(USISDKClient, orgCode, orderNumber, orderLineNumber).Wait();
    }

    public ServiceOrderItemsModel EditAdvanced(string orgCode, int orderNbr, int orderLineNbr)
    {

      var myServiceOrderItem = APIUtil.GetServiceOrderItem(USISDKClient, orgCode, orderNbr, orderLineNbr);

      string strAccountCode = "FAKEACCT"; //Use an account code


      myServiceOrderItem.AltDesc = "AltDesc1";
      myServiceOrderItem.AltDesc2 = "AltDesc2";
      myServiceOrderItem.AltDesc3 = "AltDesc3";
      myServiceOrderItem.AltDesc4 = "AltDesc4";
      myServiceOrderItem.AltDesc5 = "AltDesc5";
      myServiceOrderItem.Billable = "N";
      myServiceOrderItem.Note = "Note Text";
      myServiceOrderItem.EndDate = System.DateTime.Now.AddDays(1);
      myServiceOrderItem.EndTime = System.DateTime.Now;
      myServiceOrderItem.Internal = "Y"; //Y or N
      myServiceOrderItem.EstimateTBD = "N";
      myServiceOrderItem.Fixed = "Y";
      myServiceOrderItem.UserNumber1 = 5;
      myServiceOrderItem.UserNumber2 = 5;
      myServiceOrderItem.UserNumber3 = 5;
      myServiceOrderItem.Supplier = strAccountCode;
      myServiceOrderItem.UserText = "User Text";
      myServiceOrderItem.LeadHours = 5;
      myServiceOrderItem.MaximumUnits = 5;
      myServiceOrderItem.ManagementReport = "FLIGHT";  //This should be the code for the Management Report.
      myServiceOrderItem.MinimumUnits = 5;
      myServiceOrderItem.OrderForm = "BK"; //This should be the code of the Order Form, which comes from the order form window in Ungerboeck.
      myServiceOrderItem.OriginalRate = 5;
      myServiceOrderItem.BaseRate = 5;
      myServiceOrderItem.PrintSequence = "5";
      myServiceOrderItem.SecondaryPrintSequence = "5";
      myServiceOrderItem.Reference = "Reference"; //This is just a text field
      myServiceOrderItem.SerialNbr = "5";
      myServiceOrderItem.ShowEndDate = "Y";
      myServiceOrderItem.ShowEndTime = "Y";
      myServiceOrderItem.ShowExtendedCharge = "Y";
      myServiceOrderItem.ShowRate = "Y";
      myServiceOrderItem.ShowStartDate = "Y";
      myServiceOrderItem.ShowStartTime = "Y";
      myServiceOrderItem.ShowUnits = "Y";
      myServiceOrderItem.StartDate = System.DateTime.Now;
      myServiceOrderItem.StartTime = System.DateTime.Now;
      myServiceOrderItem.StrikeHours = 5;
      myServiceOrderItem.UnitCharge = 25; //You should use UnitCharge to change the price when adding an item.  Leave this blank if you want the default price and don't want the price overriden.
      myServiceOrderItem.UnitsSchemeCode = "TEST1";  //Use the code from the Unit Scheme window
      myServiceOrderItem.DiscountPercent = 5;
      myServiceOrderItem.SurchargePercent = 5;


      //''Please check the v20 windows for what you can change for your configurations.  Certain fields cannot be changed under conditions.
      //'.Daily = "N"
      //'.Per = 0
      //'.MaximumCharge = 5.00
      //'.MinimumCharge = 5.00
      //'.ExtendedCharge = ""
      //'.UseSeasonal = "Y"
      //'.ExtendedCost = 250.00
      //'.Multiplier = 5.00

      return APIUtil.UpdateServiceOrderItem(USISDKClient, myServiceOrderItem);
    }
  }
}
