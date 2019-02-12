﻿using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class RegistrationOrders : Base
  {
    public RegistrationOrders(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public RegistrationOrdersModel Get(string orgCode, int orderNumber)
    {
      return APIUtil.GetRegistrationOrder(USISDKClient, orgCode, orderNumber);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<RegistrationOrdersModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<RegistrationOrdersModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A retrieve by odata query.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<RegistrationOrdersModel> RetrieveByOData(string orgCode, string oData)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<RegistrationOrdersModel>(USISDKClient, ref searchMetadata, orgCode, oData);
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="Event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus"></param>
    /// <param name="accountCode"></param>
    /// <param name="priceList">The price list code.  You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>
    /// <param name="registrants">This is an account code that you want to serve as a registrant on the order item generated by the order.  You can also set it as a list of comma-delimited account codes (ex: "CODE1,CODE2,CODE3") and it will make respective order items for each registrant.</param>
    /// <param name="registrantType">This is the registrant type code, configured by the event's registration setup.  This will pick the order items attached to the order registrants</param>
    /// <returns></returns>
    public RegistrationOrdersModel Add(string orgCode, int Event, string orderStatus, string accountCode, string priceList, string registrants, string registrantType, List<RegistrationOrderItemsModel> orderItems)
    {
      //Note that order number shouldn't be set for POST operations.  Ungerboeck will assign the order number automatically

      var myRegistrationOrder = new RegistrationOrdersModel
      {
        OrganizationCode = orgCode,
        Event = Event,
        Account = accountCode,
        BillToAccount = accountCode,
        PriceList = priceList,
        Registrants = registrants,
        OrderStatus = orderStatus,
        RegistrantType = registrantType
      };

      if (orderItems != null && orderItems.Count > 0)
      {
        myRegistrationOrder.RegistrationOrderItems = new List<RegistrationOrderItemsModel>();
        myRegistrationOrder.RegistrationOrderItems.AddRange(orderItems);
      }

      return APIUtil.AddRegistrationOrder(USISDKClient, myRegistrationOrder);
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="Event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus"></param>
    /// <param name="accountCode"></param>
    /// <param name="priceList">The price list code.  You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>
    /// <param name="registrants">This is an account code that you want to serve as a registrant on the order item generated by the order.  You can also set it as a list of comma-delimited account codes (ex: "CODE1,CODE2,CODE3") and it will make respective order items for each registrant.</param>
    /// <param name="registrantType">This is the registrant type code, configured by the event's registration setup.  This will pick the order items attached to the order registrants</param>
    /// <returns></returns>
    public RegistrationOrdersModel CalculateTaxes(string orgCode, int Event, string orderStatus, string accountCode, string priceList, string registrants, string registrantType, List<RegistrationOrderItemsModel> orderItems)
    {
      var myRegistrationOrder = new RegistrationOrdersModel
      {
        OrganizationCode = orgCode,
        Event = Event,
        Account = accountCode,
        BillToAccount = accountCode,
        PriceList = priceList,
        Registrants = registrants,
        OrderStatus = orderStatus,
        RegistrantType = registrantType
      };

      if (orderItems != null && orderItems.Count > 0)
      {
        myRegistrationOrder.RegistrationOrderItems = new List<RegistrationOrderItemsModel>();
        myRegistrationOrder.RegistrationOrderItems.AddRange(orderItems);
      }

      return APIUtil.CalculateTaxesRegistrationOrder(USISDKClient, myRegistrationOrder);
    }

    /// <summary>
    /// Here's how to add a user field set with values to a new event
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="Event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus"></param>
    /// <param name="accountCode"></param>
    /// <param name="priceList">The price list code.  You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>
    /// <param name="registrants">This is an account code that you want to serve as a registrant on the order item generated by the order.  You can also set it as a list of comma-delimited account codes (ex: "CODE1,CODE2,CODE3") and it will make respective order items for each registrant.</param>
    /// <param name="registrantType">This is the registrant type code, configured by the event's registration setup.  This will pick the order items attached to the order registrants</param>
    /// <param name="issueType">This is the Issue Type code of the registration user field set.  Example string value "CK"</param>    
    /// <param name="userText05Value">This is just an example of the user fields you can set</param>
    public RegistrationOrdersModel AddWithUserFields(string orgCode, int Event, string orderStatus, string accountCode, string priceList, string registrants, string registrantType, string issueType, string userText05Value, List<RegistrationOrderItemsModel> orderItems)
    {
      //Note that order number shouldn't be set for POST operations.  Ungerboeck will assign the order number automatically

      var myRegistrationOrder = new RegistrationOrdersModel
      {
        OrganizationCode = orgCode,
        Event = Event,
        Account = accountCode,
        BillToAccount = accountCode,
        PriceList = priceList,
        Registrants = registrants,
        OrderStatus = orderStatus,
        RegistrantType = registrantType        
      };

      if (orderItems != null && orderItems.Count > 0)
      {
        myRegistrationOrder.RegistrationOrderItems = new List<RegistrationOrderItemsModel>();
        myRegistrationOrder.RegistrationOrderItems.AddRange(orderItems);
      }

      myRegistrationOrder.RegistrationOrderUserFieldSets = new List<UserFields>();
      var myUserField = new UngerboeckSDKPackage.UserFields();

      myUserField.Type = issueType; //Use the Opportunity Type code from your user field.  This matches the value stored in Ungerboeck table column CR073_ISSUE_TYPE.
      myUserField.UserText05 = userText05Value; //Set the value in the user field property
      myRegistrationOrder.RegistrationOrderUserFieldSets.Add(myUserField); //Then add it back into the RegistrationOrdersModel object.  You can add multiple user field sets to the same registration order object before saving.
      
      return APIUtil.AddRegistrationOrder(USISDKClient, myRegistrationOrder);
    }


    /// <summary>
    /// A basic edit example
    /// </summary> 
    public RegistrationOrdersModel Edit(string orgCode, int orderNumber, string newStatus, List<RegistrationOrderItemsModel> orderItems)
    {
      var myRegistrationOrder = APIUtil.GetRegistrationOrder(USISDKClient, orgCode, orderNumber);

      if (orderItems != null && orderItems.Count > 0)
      {
        myRegistrationOrder.RegistrationOrderItems = new List<RegistrationOrderItemsModel>();
        myRegistrationOrder.RegistrationOrderItems.AddRange(orderItems);
      }

      myRegistrationOrder.OrderStatus = newStatus;

      return APIUtil.UpdateRegistrationOrder(USISDKClient, myRegistrationOrder);
    }

    public void MoveOrder(string orgCode, int orderNumber, int newEventID, int functionID)
    {
      var mymoveOrder = new MoveOrderModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        DestinationEventID = newEventID,
        Function = functionID
      };

      APIUtil.AwaitMoveRegistrationOrder(USISDKClient, mymoveOrder).Wait();
    }

    /// <summary>
    /// This is an example of how to move many orders at once
    /// </summary>
    /// <param name="orderNumber">OrderNumber is an array of integers for the various order numbers</param>
    /// <param name="newEventID">This is the destination event ID.  You can find this attached this to the Events window in Ungerboeck</param>
    /// <param name="functionID"></param>
    public IEnumerable<MoveOrdersBulkErrorsModel> MoveOrderBulk(string orgCode, int[] orderNumber, int newEventID, int functionID)
    {
      var myMoveBulkOrder = new MoveOrdersBulkModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        DestinationEventID = newEventID,
        Function = functionID
      };

      //Note: Function and KeepDateTimes properties are not used for Registration Orders.

      IEnumerable<MoveOrdersBulkErrorsModel> results = APIUtil.MoveRegistrationOrdersBulk(USISDKClient, myMoveBulkOrder);

      //For bulk operations, 200 only signifies that the process successfully ran.  Individual items might have had issues saving.  Check the response object for bulk errors.
      //One or more errors with saving the items if an error object was returned.        

      return results;
    
   }
  }
}
