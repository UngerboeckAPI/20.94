using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class BulletinApproval : Base
  {
    public BulletinApproval(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public BulletinApprovalModel Get(string orgCode, int meetingSequenceNumber, int bulletinSequenceNumber, int sequenceNumber, string bulletinFileID)
    {
      return APIUtil.GetBulletinApproval(USISDKClient, orgCode, meetingSequenceNumber, bulletinSequenceNumber, sequenceNumber, bulletinFileID);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<BulletinApprovalModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<BulletinApprovalModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
