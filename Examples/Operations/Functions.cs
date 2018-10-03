using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Functions : Base
  {
    public Functions(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public FunctionsModel Get(string orgCode, int EventID, int functionID)
    {
      return APIUtil.GetFunction(USISDKClient, orgCode, EventID, functionID);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<FunctionsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<FunctionsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public FunctionsModel Edit(string orgCode, int EventID, int functionID, string newText)
    {
      var myFunction = APIUtil.GetFunction(USISDKClient, orgCode, EventID, functionID);

      myFunction.Description = newText;

      return APIUtil.UpdateFunction(USISDKClient, myFunction);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, int EventID, int functionID)
    {
      APIUtil.AwaitDeleteFunction(USISDKClient, orgCode, EventID, functionID).Wait();
    }

    public FunctionsModel EditAdvanced(string orgCode, int EventID, int functionID)
    {

      var myFunction = APIUtil.GetFunction(USISDKClient, orgCode, EventID, functionID);

      string myAccount = "00032364";  //Represents an account code
      string myContact = "ANA"; //Also represents an account code

      myFunction.Description = "New Description";
      myFunction.Class = "P";
      myFunction.EndDate = System.DateTime.Now;
      myFunction.EndTime = System.DateTime.Now;
      myFunction.StartTime = System.DateTime.Now;
      myFunction.StartDate = System.DateTime.Now;
      myFunction.Search = "NewSearch";
      myFunction.AlternateDescription = "Alt1";
      myFunction.AlternateDescription2 = "Alt2";
      myFunction.AlternateDescription3 = "Alt3";
      myFunction.AlternateDescription4 = "Alt4";
      myFunction.AlternateDescription5 = "Alt5";
      myFunction.Usage = "100";
      myFunction.Department = "ADMIN";
      myFunction.SOChecklist = "SERORDON";
      myFunction.FunctionGLCode = "GLCODE";
      myFunction.DefaultPaymentSchedule = "ONE";
      myFunction.Coordinator = myAccount;
      myFunction.Account = myAccount; //This should be a single account code
      myFunction.Contact = myContact;
      myFunction.UserText = "Text";
      myFunction.UserNumber = 15;
      myFunction.Space = "HALL-A";
      myFunction.BackgroundColor = 5287936; //This contains an OLE integer value.  You can convert from RGB.
      myFunction.TextColor = 10498160; //This contains an OLE integer value.  You can convert from RGB.
      myFunction.Statistics = "Y"; //Y or N
      myFunction.StatusCode = "25"; //This is the user-configurable status code on the function
      myFunction.ActualAttendance = 5;
      myFunction.SyncwithEventAttendance = "Y"; //Y or N.  If this is Y, the attendance figures will fill automatically.
      myFunction.ForecastAttendance = 5;
      myFunction.OrderedAttendance = 5;
      myFunction.RevisedAttendance = 5;
      myFunction.RegistrationQualification = "Y"; //Y or N
      myFunction.Location = "My Location";
      myFunction.WebAddress = "www.website.com";
      myFunction.TrackID = 17; //The integer value of the Track you wish to assign
      myFunction.SessionDetails = "Details Here";
      myFunction.EarlyDeadline = System.DateTime.Now;
      myFunction.StandardDeadline = System.DateTime.Now;

      //Check to make sure the functions are of the proper type before setting these properties
      //.BoothIssue = "TP" 'Used only used for Assignment Functions.  Set to the code value for the Assignment Issue Type
      //.CheckRegistrationConflicts = "Y" 'Used for registration functions only
      //.BookingLink = "1" 'For functions linked to bookings.Fill this in with the Booking Sequence Number.


      return APIUtil.UpdateFunction(USISDKClient, myFunction);
    }

    public FunctionsModel InsertAfterFunction(string orgCode, int eventID, int functionID, string newText, string statusCode, string coordinator)
    {
      var myFunction = new FunctionsModel
      {
        OrganizationCode = orgCode,
        EventID = eventID,
        Description = newText,
        StatusCode = statusCode,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now.AddDays(1),
        Coordinator = coordinator
      };

      return APIUtil.InsertAfterFunction(USISDKClient, functionID, myFunction);
    }

    public FunctionsModel InsertIndentedFunction(string orgCode, int eventID, int functionID, string functionDescription, string statusCode, string coordinator)
    {
      var myFunction = new FunctionsModel
      {
        OrganizationCode = orgCode,
        EventID = eventID,
        Description = functionDescription,
        StatusCode = statusCode,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now.AddDays(1),
        Coordinator = coordinator
      };

      return APIUtil.InsertIndentedFunction(USISDKClient, functionID, myFunction);
    }

    public FunctionsModel AddWithUserFields(string orgCode, int eventID, int functionID, string statusCode, string issueType, int newUserNumber03)
    {
      var myFunction = new FunctionsModel
      {
        OrganizationCode = orgCode,
        EventID = eventID,
        StatusCode = statusCode,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now.AddDays(1)
      };

      //Here's how to add a user field set with values to a new function
      myFunction.FunctionUserFieldSets = new List<UngerboeckSDKPackage.UserFields>();
      UngerboeckSDKPackage.UserFields myUserField = new UngerboeckSDKPackage.UserFields();

      //Note that class is always EventSales (C) and is automatically set in Ungerboeck.
      myUserField.Type = issueType; //Use the Opportunity Type code from your user field.  This matches the value stored in Ungerboeck table column CR073_ISSUE_TYPE.
      myUserField.UserNumber03 = newUserNumber03; //Set the value in the user field property
      myFunction.FunctionUserFieldSets.Add(myUserField); //Then add it back into the EventModel object.  You can add multiple user field sets to the same event object before saving.

      return APIUtil.InsertAfterFunction(USISDKClient, functionID, myFunction); //You can also use APIUtil.InsertIndentedFunction()
    }
  }
}
