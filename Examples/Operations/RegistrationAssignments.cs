using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class RegistrationAssignments : Base
  {
    public RegistrationAssignments(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    /// <param name="orgCode">Registration Assignment Organization Code.</param>
    /// <param name="sequenceNumber">Registration Assignment Primary key.</param>
    public RegistrationAssignmentsModel Get(string orgCode, int sequenceNumber)
    {
      return APIUtil.GetRegistrationAssignment(USISDKClient, orgCode, sequenceNumber);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    /// <param name="orgCode">Registration Assignments Organization Code.</param>
    public IEnumerable<RegistrationAssignmentsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<RegistrationAssignmentsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary>  
    /// <param name="orgCode">Registration Assignment Organization Code.</param>
    /// <param name="layoutSeq">The primary key for the function seating chart in which this Registration Assignment is on.</param>
    /// <param name="seatQuantity">The assignments seat quantity.</param>
    /// <param name="orderNumber">The order number for which this Registration Assignment was placed on.</param>
    /// <param name="orderLine">The order line for which this Registration Assignment was placed on.</param>
    /// <param name="assignmentNote">Assignment Note.</param>
    public RegistrationAssignmentsModel Add(string orgCode, int layoutSeq, int seatQuantity, 
                                            int orderNumber, int orderLine, string assignmentNote)
    {
      var myRegistrationAssignment = new RegistrationAssignmentsModel
      {
        OrgCode = orgCode,
        AssignmentNote = assignmentNote,
        LayoutSequence = layoutSeq,
        SeatQuantity = seatQuantity,
        OrderNumber = orderNumber,
        OrderLine = orderLine
      };

      return APIUtil.AddRegistrationAssignment(USISDKClient, myRegistrationAssignment);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    /// <param name="orgCode">Registration Assignment Organization Code.</param>
    /// <param name="sequenceNumber">Registration Assignment Primary key.</param>
    /// <param name="seatQuantity">New Registration Assignment seat quantity.</param>
    /// <param name="newAssignmentNote">New Registration Assignment Note.</param>
    public RegistrationAssignmentsModel Edit(string orgCode, int sequenceNumber, int seatQuantity, string newAssignmentNote)
    {
      var myRegistrationAssignment = APIUtil.GetRegistrationAssignment(USISDKClient, orgCode, sequenceNumber);

      myRegistrationAssignment.AssignmentNote = newAssignmentNote;
      myRegistrationAssignment.SeatQuantity = seatQuantity;

      return APIUtil.UpdateRegistrationAssignment(USISDKClient, myRegistrationAssignment);
    }
  }
}
