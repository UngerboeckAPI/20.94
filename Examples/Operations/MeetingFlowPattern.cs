using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class MeetingFlowPattern : Base
  {
    public MeetingFlowPattern(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MeetingFlowPatternModel Get(string orgCode, string flowApplicationCode, int meetingTourSequenceNbr, int flowSequenceNumber)
    {
      return APIUtil.GetMeetingFlowPattern(USISDKClient, orgCode, flowApplicationCode, meetingTourSequenceNbr, flowSequenceNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>  
    public IEnumerable<MeetingFlowPatternModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<MeetingFlowPatternModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
