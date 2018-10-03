using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Relationships : Base
  {
    public Relationships(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public RelationshipsModel Get(string orgCode, string masterAccountCode, string subordinateAccountCode, string relationshipType)
    {
      return APIUtil.GetRelationship(USISDKClient, orgCode, masterAccountCode, subordinateAccountCode, relationshipType);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<RelationshipsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<RelationshipsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">The org code of both accounts</param>
    /// <param name="masterAccountCode">The account code of the parent account</param>
    /// <param name="subordinateAccountCode">The account code of the child account</param>
    /// <param name="relationshipType">This is the code for the relationship type of the relationship.  This is the foreign key code from the EV876 master table</param>
    /// <param name="eventSalesDesignation">Set at least one designation and whether if it's Primary or Secondary.  NOTE: Both the master and subordinate account should belong to that designation.  You can use the RelationshipDesignationStatus class to set the designation (ex: UngerboeckSDKPackage.USISDKConstants.RelationshipDesignationStatus.Primary)</param>    
    public RelationshipsModel Add(string orgCode, string masterAccountCode, string subordinateAccountCode, string relationshipType, string eventSalesDesignation)
    {
      var myRelationship = new RelationshipsModel
      {        
        MasterOrganizationCode = orgCode,
        MasterAccountCode = masterAccountCode,
        SubordinateAccountCode = subordinateAccountCode,
        RelationshipType = relationshipType,
        SubordinateOrganizationCode = orgCode, //Note that multi-organization relationships aren't yet supported by the API.
        EventSalesDesignation = eventSalesDesignation        
      };

      return APIUtil.AddRelationship(USISDKClient, myRelationship);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public RelationshipsModel Edit(string orgCode, string masterAccountCode, string subordinateAccountCode, string relationshipType, string newRelationshipText)
    {
      var myRelationship = APIUtil.GetRelationship(USISDKClient, orgCode, masterAccountCode, subordinateAccountCode, relationshipType);

      myRelationship.RelationshipNote = newRelationshipText;

      return APIUtil.UpdateRelationship(USISDKClient, myRelationship);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, string masterAccountCode, string subordinateAccountCode, string relationshipType)
    {
      APIUtil.AwaitDeleteRelationship(USISDKClient, orgCode, masterAccountCode, subordinateAccountCode, relationshipType).Wait();
    }
    public RelationshipsModel EditAdvanced(string orgCode, string masterAccountCode, string subordinateAccountCode, string relationshipType)
    {

      var myRelationship = APIUtil.GetRelationship(USISDKClient, orgCode, masterAccountCode, subordinateAccountCode, relationshipType);

      myRelationship.Contact = "ACCTCODE";  //This represents the contact for the relationship itself (EV873_ACCT_CODE3)

      //Ensure the two accounts actually have the account designation before setting the respective relationship designation!
      myRelationship.EventSalesDesignation = USISDKConstants.RelationshipDesignationStatus.Primary;
      myRelationship.TourSalesDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.PublicRelationsDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.MembershipDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.ReceivablesDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.PayablesDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.VisitorInquiryDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.RegistrationDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.SpeakerMgmtDesignation = USISDKConstants.RelationshipDesignationStatus.Inactive;
      myRelationship.PersonnelDesignation = USISDKConstants.RelationshipDesignationStatus.Secondary;


      return APIUtil.UpdateRelationship(USISDKClient, myRelationship);
    }
  }
}
