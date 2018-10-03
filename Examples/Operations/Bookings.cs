using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System;
using System.Data;

namespace Examples.Operations
{
  public class Bookings : Base
  {
    public Bookings(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public BookingsModel Get(string orgCode, int eventId, int sequenceNumber)
    {
      return APIUtil.GetBooking(USISDKClient, orgCode, eventId, sequenceNumber);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<BookingsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<BookingsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }


    /// <summary>
    /// Example of how to add a booking
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="Event">The ID of the event you want to attach the booking to</param>
    /// <param name="space">This is the user-configurable space code the booking takes place in</param>
    /// <param name="startDate">This should be set to the start date of the booking </param>
    /// <param name="endDate">This should be set to the start time of the booking </param>
    /// <param name="startTime">This should be set to the end date of the booking </param>
    /// <param name="endTime">This should be set to the end time of the booking </param>    
    public BookingsModel Add(string orgCode, int Event, string space, DateTime startDate, DateTime endDate, DateTime startTime, DateTime endTime)
    {
      var myBooking = new BookingsModel
      {
        OrganizationCode = orgCode,
        Event = Event, 
        Daily = "Y", //Y or N
        Space = space,
        StartTime = startTime,
        StartDate = startDate,
        EndTime = endTime,
        EndDate = endDate,
      };

      return APIUtil.AddBookingWithoutConflictCheck(USISDKClient, myBooking);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>  
    public BookingsModel Edit(string orgCode, int Event, int sequenceNumber, string NewStatus)
    {
      var myBooking = APIUtil.GetBooking(USISDKClient, orgCode, Event, sequenceNumber);

      myBooking.Status = NewStatus;

      return APIUtil.UpdateBookingWithoutConflictCheck(USISDKClient, myBooking);
    }

    /// <summary>
    /// This example is designed to show sample values to use in other editable properties.  For more information, see the model property info in the /api/help sandbox.
    /// </summary>
    public BookingsModel EditAdvanced(string orgCode, int eventID, int sequenceNbr)
    {

      var myBooking = APIUtil.GetBooking(USISDKClient, orgCode, eventID, sequenceNbr);

      myBooking.Description = "modified description";

      myBooking.LeadHours = 1;    //Too long of a lead time may return an error if it crosses another booking or is invalid
      myBooking.RequestedSetup = "dub-real";     //this will automatically accept, even if the setup is not configured on the event
      myBooking.Space = "ALPHA";
      myBooking.UnitofTime = "day";
      myBooking.Units = 5;
      myBooking.Usage = "con";
      myBooking.UserNumber1 = 5;
      myBooking.UserNumber2 = 10;
      myBooking.UserNumber3 = 15;
      myBooking.UserText = "user text";
      myBooking.UsageType = "1182";     //This is used to determine the rate.  This is the resource type that appears in the Rate value description.
      myBooking.UseSeasonalDiscount = "y";
      myBooking.Daily = "y";
      myBooking.CreateFunctions = "y"; //Setting this to Y will automatically create a function for the added booking.
      myBooking.Billable = "n";

      //various date values
      myBooking.StartDate = Convert.ToDateTime("2018-04-11 00:00:00.000");
      myBooking.StartTime = Convert.ToDateTime("2000-01-01 00:00:00.000");
      myBooking.EndDate = Convert.ToDateTime("2018-04-11 00:00:00.000");
      myBooking.EndTime = Convert.ToDateTime("2000-01-01 00:00:00.000");

      return APIUtil.UpdateBookingWithoutConflictCheck(USISDKClient, myBooking);
    }
  }
}
