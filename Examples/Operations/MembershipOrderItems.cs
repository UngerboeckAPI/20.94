using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class MembershipOrderItems : Base
  {
    public MembershipOrderItems(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MembershipOrderItemsModel Get(string orgCode, int orderNumber, int orderLineNumber)
    {
      return APIUtil.GetMembershipOrderItem(USISDKClient, orgCode, orderNumber, orderLineNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<MembershipOrderItemsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<MembershipOrderItemsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="orderNumber">The order number of the item's parent order</param>
    /// <param name="unitValue">The amount of items you want on the order</param>
    /// <param name="resource">This should be filled in as the Price List Sequence number (CC716_SEQ) of the item you wish to add.  It should belong to the Order's price list items (Check CC716_PRICE_LIST_DTL).</param>
    public MembershipOrderItemsModel Add(string orgCode, int orderNumber, int unitValue, string resource)
    {

      var myMembershipOrderItems = new MembershipOrderItemsModel
      {
        OrganizationCode = orgCode,
        Units = unitValue,
        OrderNumber = orderNumber,
        Resource = resource,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now.AddDays(1)
      };

      return APIUtil.AddMembershipOrderItem(USISDKClient, myMembershipOrderItems);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="unitValue">Change the number of units of the item on the order</param>    
    public MembershipOrderItemsModel Edit(string orgCode, int orderNumber, int orderLineNumber, int unitValue)
    {
      var myMembershipOrderItem = APIUtil.GetMembershipOrderItem(USISDKClient, orgCode, orderNumber, orderLineNumber);

      myMembershipOrderItem.Units = unitValue;

      return APIUtil.UpdateMembershipOrderItem(USISDKClient, myMembershipOrderItem);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, int orderNumber, int orderLineNumber)
    {
      APIUtil.AwaitDeleteMembershipOrderItem(USISDKClient, orgCode, orderNumber, orderLineNumber).Wait();
    }

    public MembershipOrderItemsModel EditAdvanced(string orgCode, int orderNumber, int orderLineNumber)
    {

      var myMembershipOrderItem = APIUtil.GetMembershipOrderItem(USISDKClient, orgCode, orderNumber, orderLineNumber);

      myMembershipOrderItem.AltDesc = "AltDesc1";
      myMembershipOrderItem.AltDesc2 = "AltDesc2";
      myMembershipOrderItem.AltDesc3 = "AltDesc3";
      myMembershipOrderItem.AltDesc4 = "AltDesc4";
      myMembershipOrderItem.AltDesc5 = "AltDesc5";
      myMembershipOrderItem.Note = "Note Text";
      myMembershipOrderItem.EstimateTBD = "N";
      myMembershipOrderItem.UserNumber1 = 5;
      myMembershipOrderItem.UserNumber2 = 5;
      myMembershipOrderItem.UserNumber3 = 5;
      myMembershipOrderItem.LeadHours = 5;
      myMembershipOrderItem.MaximumUnits = 5;
      myMembershipOrderItem.MinimumUnits = 5;
      //.OrderForm = "5"
      myMembershipOrderItem.PrintSequence = "5";
      myMembershipOrderItem.SecondaryPrintSequence = "5";
      myMembershipOrderItem.Reference = "Reference";
      myMembershipOrderItem.SerialNbr = "5";
      myMembershipOrderItem.ShowEndDate = "Y";
      myMembershipOrderItem.ShowEndTime = "Y";
      myMembershipOrderItem.ShowExtendedCharge = "Y";
      myMembershipOrderItem.ShowRate = "Y";
      myMembershipOrderItem.ShowStartDate = "Y";
      myMembershipOrderItem.ShowStartTime = "Y";
      myMembershipOrderItem.ShowUnits = "Y";
      myMembershipOrderItem.UseSeasonal = "N";
      myMembershipOrderItem.StartDate = System.DateTime.Now;
      myMembershipOrderItem.StartTime = System.DateTime.Now;
      myMembershipOrderItem.EndDate = System.DateTime.Now.AddDays(1);
      myMembershipOrderItem.EndTime = System.DateTime.Now.AddDays(1);
      myMembershipOrderItem.UserText = "User Text";


      //Please check the v20 windows for what you can change for your configurations.  Certain fields cannot be changed under conditions.
      //.TimeUnits = ""
      //.OverrideTimeUnits = ""
      //.Multiplier = ""
      //.Per = 0
      //.Daily = "N"
      //.MaximumCharge = 0
      //.MinimumCharge = 0

      return APIUtil.UpdateMembershipOrderItem(USISDKClient, myMembershipOrderItem);
    }
  }
}
