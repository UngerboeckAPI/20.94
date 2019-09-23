using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class OrderRegistrants : Base
  {
    public OrderRegistrants(HttpClient USISDKClient) : base(USISDKClient)
    {
    }
    public OrderRegistrantsModel Get(string orgCode, int registrantSequenceNbr)
    {
      return APIUtil.GetOrderRegistrant(USISDKClient, orgCode, registrantSequenceNbr);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<OrderRegistrantsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<OrderRegistrantsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public OrderRegistrantsModel Edit(string orgCode, int registrantSequenceNbr, string strNewUserFieldText)
    {
      var myOrderRegistrant = APIUtil.GetOrderRegistrant(USISDKClient, orgCode, registrantSequenceNbr);

      myOrderRegistrant.RegistrantUserFields.UserText01 = strNewUserFieldText;

      return APIUtil.UpdateOrderRegistrant(USISDKClient, myOrderRegistrant);
    }

    /// <summary>
    /// A edit example updating approval status
    /// </summary> 
    /// <param name="orgCode">Organization code</param>
    /// <param name="registrantSequenceNbr">Registration Order Sequence Number</param>
    /// <param name="approvalAction">Action for the Registration Approval. Either 'A' for Approved or 'R' for Rejected</param>
    /// <param name="approvalLevel">Integer value representing the Approval Level</param>
    /// <param name="approvalComment">string value for comments regarding the approval or rejection</param>
    public HttpResponseMessage EditUpdatingApprovalStatus(string orgCode, int registrantSequenceNbr, string approvalAction, int approvalLevel, string approvalComment)
    {
      var myOrderRegistrantApproval = new UngerboeckSDKPackage.RegistrationApprovalsModel();
      myOrderRegistrantApproval.OrganizationCode = orgCode;
      myOrderRegistrantApproval.RegistrantSequenceNbr = registrantSequenceNbr;
      myOrderRegistrantApproval.RegistrantApprovalAction = approvalAction;
      myOrderRegistrantApproval.RegistrantApprovalLevel = approvalLevel;
      myOrderRegistrantApproval.ApprovalComment = approvalComment;

      return APIUtil.SetRegistrantApproval(USISDKClient, myOrderRegistrantApproval);      
    }
  }
}
