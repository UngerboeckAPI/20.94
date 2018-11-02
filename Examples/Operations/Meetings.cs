using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Meetings : Base
  {
    public Meetings(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MeetingsModel Get(string orgCode, int meetingSequence)
    {
      return APIUtil.GetMeeting(USISDKClient, orgCode, meetingSequence);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<MeetingsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<MeetingsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
