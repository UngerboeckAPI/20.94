using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Examples.Operations
{
  public class Events:Base
  {
    public Events(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventsModel Get(string orgCode, int eventID)
    {
      return APIUtil.GetEvent(USISDKClient, orgCode, eventID);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<EventsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<EventsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary>  
    public EventsModel Add(string orgCode, string eventName, string accountCode)
    {
      var myEvent = new EventsModel
      {
        Organization = orgCode,
        Description = eventName,
        Account = accountCode,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now,
      };

      return APIUtil.AddEvent(USISDKClient, myEvent);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public EventsModel Edit(string orgCode, int eventID, string newEventName)
    {
      var myEvent = APIUtil.GetEvent(USISDKClient, orgCode, eventID);

      myEvent.Description = newEventName;

      return APIUtil.UpdateEvent(USISDKClient, myEvent);
    }

    public EventsModel CancelEvent(string orgCode, int eventID)
    {
      const string myCancelReasonCode = "sd";

      var myEvent = APIUtil.GetEvent(USISDKClient, orgCode, eventID);

      myEvent.Status = "80"; //'Setting to a status greater than or equal to 80 and less than or equal to 89 is sign for cancelling (80 <= x <= 89)
      myEvent.Reason = myCancelReasonCode + "|EC";  //You need to supply a Reason code when cancelling an event.  It's represented by the a pipe delimited code, namely (Reason code | Cancel Reason Application code).  The Cancel Reason Application code is always EC for events.You can find the Reason Code in the Ungerboeck window "Event Cancellation Reasons" from the main menu.The code is located under the 'code' column in the grid.You can also find it in the database under MM210_REASON_CODE
      
      myEvent.FunctionStatus = "82"; //When cancelling an event, the system needs to know what to status code to set on the event's functions.  Set it to a cancelled status of functions.
      //Note that FunctionStatus is never filled in the EventModel on a GET.  It's just a place to set Function Status when cancelling an event.
      
      return APIUtil.UpdateEvent(USISDKClient, myEvent);
    }

    public EventsModel AddWithUserFields(string orgCode, string eventName, string accountCode, string issueType, string newTxt12Value)
    {
      var myEvent = new EventsModel
      {
        Organization = orgCode,
        Description = eventName,
        Account = accountCode,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now,
      };
       
      //Here's how to add a user field set with values to a new event
      myEvent.EventUserFieldSets = new List<UngerboeckSDKPackage.UserFields>();
      UngerboeckSDKPackage.UserFields myUserField = new UngerboeckSDKPackage.UserFields();

      //Note that class is always EventSales (C) and is automatically set in Ungerboeck.
      myUserField.Type = issueType; //Use the Opportunity Type code from your user field.  This matches the value stored in Ungerboeck table column CR073_ISSUE_TYPE.
      myUserField.UserText12 = newTxt12Value; //Set the value in the user field property
      myEvent.EventUserFieldSets.Add(myUserField); //Then add it back into the EventModel object.  You can add multiple user field sets to the same event object before saving.

      return APIUtil.AddEvent(USISDKClient, myEvent);
    }

    public EventsModel EditWithUserFields(string orgCode, int eventID, string issueType, DateTime newDate02Value)
    {
      var myEvent = APIUtil.GetEvent(USISDKClient, orgCode, eventID);

      //Here's how to edit a user field set with values on an existing event
      var myEventUDFSet = (from o in myEvent.EventUserFieldSets where o.Type == issueType select o).FirstOrDefault();
      myEventUDFSet.UserDateTime02 = newDate02Value; //Set the value in the user field property

      return APIUtil.UpdateEvent(USISDKClient, myEvent);
    }

    /// <summary>
    /// This example is designed to show sample values to use in other editable properties.  For more information, see the model property info in the /api/help sandbox.
    /// </summary>
    public EventsModel EditAdvanced(string orgCode, int eventID)
    {
        const string myAccount = "RAYNOR";
        const string myParentAccount = "COMBINE";
        const string myContactAccount = "LSTRIDER";
        const int otherEventID = 11111;

        var myEvent = APIUtil.GetEvent(USISDKClient, orgCode, eventID);

        myEvent.Description = "Modified Description";
        myEvent.SecondCoordinator = myAccount;
        myEvent.ThirdCoordinator = myAccount;
        myEvent.FourthCoordinator = myAccount;
        myEvent.Abbreviation = "MD";
        myEvent.Account = "COMBINE"; //Just like in Ungerboeck, you may change the account even after an event is created.                                                                                                            
        myEvent.ActualAttendance = 5;
        myEvent.ActualCost = 5;
        myEvent.ActualRevenue = 5;
        myEvent.AlternateEvent = otherEventID;
        myEvent.AnchorVenue = "HALL-A"; //Code value for anchor venue                                                                                                                                                       
        myEvent.Attendance = 5;
        myEvent.BillTo = myParentAccount; //Account code of bill to account                                                                                                                                                 
        myEvent.BillToContact = myContactAccount;  //Account code of bill-to contact                                                                                                                                        
        myEvent.BoxOffice = "Y"; //Y or N                                                                                                                                                                                   
        myEvent.Category = "CO"; //Category code for event categories                                                                                                                                                       
        myEvent.Class = "EDU"; //Class code for event classes                                                                                                                                                               
        myEvent.Contact = myContactAccount;
        myEvent.ContractRequired = "Y";
        myEvent.Coordinator = myContactAccount;
        myEvent.Decision = DateTime.Now;
        myEvent.Description1 = "Event Description 1";
        myEvent.Description2 = "Event Description 2";
        myEvent.Description3 = "Event Description 3";
        myEvent.Description4 = "Event Description 4";
        myEvent.Description5 = "Event Description 5";
        myEvent.EarlyDeadline = DateTime.Now;
        myEvent.EconomicImpact = 5;
        myEvent.ForecastAttendance = 5;
        myEvent.ForecastCost = 5;
        myEvent.ForecastRevenue = 5;
        myEvent.FunctionUserFieldsType = "BU|C"; //Code of Function User fields. It consists of [Issue Type]|[Issue Class].  This is populated from [CR158_ISSUE_TYPE]|[CR158_ISSUE_CLASS].                                 
        myEvent.GLDistribution = "test";
        myEvent.GLSubAccount = myContactAccount;
        myEvent.Indicator = "JB";
        myEvent.Insurance = "Y";
        myEvent.InventoryChain = "CHAINB";
        myEvent.LegalName = "Legal Name";
        myEvent.LegalName1 = "Legal Name 1";
        myEvent.LegalName2 = "Legal Name 2";
        myEvent.LegalName3 = "Legal Name 3";
        myEvent.LegalName4 = "Legal Name 4";
        myEvent.LegalName5 = "Legal Name 5";
        myEvent.MajorGroup = "PRG";
        myEvent.MinorGroup = ".NET";
        myEvent.Note1 = "Test";
        myEvent.Note2 = "Test";
        myEvent.OnSiteOffice = "HALL-A";
        myEvent.OnSitePhone = "555-555-5555";
        myEvent.OrderUserFieldsType = "CK|C"; //This is the code of Order User fields.  It consists of [Issue Type]|[Issue Class].  This is populated from [CR158_ISSUE_TYPE]|[CR158_ISSUE_CLASS].                          
        myEvent.OrderedCost = 5;
        myEvent.OrderedRevenue = 5;
        myEvent.OtherActual = 5;
        myEvent.OtherForecast = 5;
        myEvent.OtherOrdered = 5;
        myEvent.OtherRevised = 5;
        myEvent.ParentEvent = otherEventID;
        myEvent.PaymentPlan = "50";
        myEvent.PreviousEvent = otherEventID;
        myEvent.PriceList = "2001-STD";
        myEvent.Public = "Y";
        myEvent.Rank = "T";
        myEvent.Release = DateTime.Now;
        myEvent.Requester = myParentAccount;
        myEvent.RequesterContact = myContactAccount;
        myEvent.RevisedAttendance = 5;
        myEvent.RevisedCost = 5;
        myEvent.RevisedRevenue = 5;
        myEvent.Salesperson = myAccount;
        myEvent.Search = "APISRCH";
        myEvent.Sensitivity = "1";
        myEvent.StandardDeadline = DateTime.Now;
        myEvent.Status = "30";  //This is the code for statuses.  Filling this in may affect other fields based on the value.  Greater than 29 is firm, greater than 79 is considered cancelled.                            
        myEvent.TaxScheme = "DEFAULT";
        myEvent.Type = "EDU";
        myEvent.WebAddress = "www.ungerboeck.com";

        //Various date values                                                                                                                                                                                              
        myEvent.StartDate = DateTime.Now.Date;
        myEvent.StartTime = DateTime.Now;
        myEvent.InDate = DateTime.Now.Date;
        myEvent.InTime = DateTime.Now;
        myEvent.OutDate = DateTime.Now.Date.AddDays(1);
        myEvent.OutTime = DateTime.Now;
        myEvent.EndDate = DateTime.Now.Date.AddDays(1);
        myEvent.EndTime = DateTime.Now;

         return APIUtil.UpdateEvent(USISDKClient, myEvent);
        }
  }
}
