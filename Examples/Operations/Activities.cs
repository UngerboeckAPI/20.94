using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class Activities : Base
  {
    public Activities(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ActivitiesModel Get(string orgCode, string accountCode, int sequenceNumber)
    {
      return APIUtil.GetActivity(USISDKClient, orgCode, accountCode, sequenceNumber);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary>
    public IEnumerable<ActivitiesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ActivitiesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    public ActivitiesModel AddAccountActivity(string orgCode, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText, //This can contain HTML if desired.
        Account = accountCode
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);  //After saving, you can find the text with the html stripped out in the PlainText property
    }

    /// <summary>
    /// This example shows some other properties you can set while adding an activity
    /// </summary>
    public ActivitiesModel AddActivityAdvanced(string orgCode, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText, //This can contain HTML if desired.
        Account = accountCode,

        EntryDesignation = UngerboeckSDKPackage.USISDKConstants.AccountDesignations.EventSales,
        Status = "N", //You can set the activity status, or you can let it default in based on your Ungerboeck configuration
        Type = "PCF", //Add the activity entry type code

        //Recipient = "RAYNOR,FREEMAN" 'Add multiple recipients using a comma-delimited list.
        Recipient = "RAYNOR", //Otherwise, add a single account code like this

        //Here are other various examples of properties you can set
        Contact = "RAYNOR", //Add a contact of the diary account using the account code here
        ActualStartDate = DateTime.Now,
      ActualEndDate = DateTime.Now.AddDays(1),      
      Due = DateTime.Now.AddDays(1),
      DueTime = DateTime.Now.AddHours(-2),              
      Locked = "N", //"Y" or "N" to lock the diary entry
      Priority = UngerboeckSDKPackage.USISDKConstants.ActivityPriority.High, //Use this to set the priority to high (defaults to normal otherwise)
      Privileged = "Y", //Y or N, Y is privileged      
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }


    public ActivitiesModel AddEventActivity(string orgCode, int eventID, string newActivityText, string accountCode, string recipient)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        Event = eventID,
        Account = accountCode,
        Recipient = recipient
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }
    
    public ActivitiesModel AddNoteActivity(string orgCode, string noteCode, int noteSequenceNbr, string noteType, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        //Attach to a note using the note's identifying values
        OrganizationCode = orgCode,
        Text = newActivityText,        
        NoteCode = noteCode,
        NoteSequenceNbr = noteSequenceNbr,
        NoteType = noteType, //Use the NoteType to specify which note type it is (ex: UngerboeckSDKPackage.USISDKConstants.NoteType.AccountNote)
        Account = accountCode
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }

    public ActivitiesModel AddContractActivity(string orgCode, int contractSequence, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        ContractSequenceNbr = contractSequence,
        Account = accountCode
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }

    public ActivitiesModel AddMeetingActivity(string orgCode, int meetingSequence, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        SequenceNumber = meetingSequence,
        Account = accountCode
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }

    public ActivitiesModel AddQuoteActivity(string orgCode, int quoteSequence, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        Quote = quoteSequence,
        Account = accountCode
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }

    public ActivitiesModel AddExhibitorActivity(string orgCode, int exhibitorID, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        ExhibitorID = exhibitorID,
        Account = accountCode
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }

    public ActivitiesModel AddOrderActivity(string orgCode, int orderNbr, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        OrderNumber = orderNbr,
        Account = accountCode
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }

    public ActivitiesModel AddFunctionActivity(string orgCode, int functionID, int eventID, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        Function = functionID,
        Event = eventID,
        Account = accountCode
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }

    public ActivitiesModel AddFiscalYearPeriodActivity(string orgCode, string fyp, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        FiscalYearPeriod = fyp,
        Account = accountCode
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }

    public ActivitiesModel AddBlockActivity(string orgCode, string blockCode, int eventID, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        BlockCode = blockCode,
        Event = eventID,
        Account = accountCode
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }

    public ActivitiesModel AddProjectActivity(string orgCode, int eventID, string newActivityText, string accountCode, string recipient)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,

        //For project attachment, set the project ID and the project designation
        ProjectID = "5",
        ProjectDesignation = UngerboeckSDKPackage.USISDKConstants.AccountDesignations.Membership
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }

    public ActivitiesModel AddChecklistActivity(string orgCode, int eventID, string newActivityText, string accountCode, string recipient)
    {
      //It's possible to add a checklist code.  Do this if adding a checklist through the API.

      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        Checklist = "CL" //The checklist code
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }

    public ActivitiesModel AddInventoryItemActivity(string orgCode, string newActivityText, string inventoryItemCode, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        Account = accountCode,
        InventoryItemCode = inventoryItemCode //Add the inventory item code here to attach to an Inventory item
      };

      return APIUtil.AddActivity(USISDKClient, myActivity);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    public ActivitiesModel Edit(string orgCode, string accountCode, int sequenceNumber, string newText)
    {
      var myActivity = APIUtil.GetActivity(USISDKClient, orgCode, accountCode, sequenceNumber);

      myActivity.Text = newText; //Set the Text property with either plain text or HTML text.  

      return APIUtil.UpdateActivity(USISDKClient, myActivity);
    }

    /// <summary>
    /// A delete example
    /// </summary> 
    public void Delete(string orgCode, string accountCode, int sequenceNumber)
    {
      APIUtil.AwaitDeleteActivities(USISDKClient, orgCode, accountCode, sequenceNumber).Wait();
    }

  }
}
