using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class MeetingNotes : Base
  {
    public MeetingNotes(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MeetingNotesModel Get(string orgCode, string bulletinApplication, int meeting, int bulletinSeqNbr, int sequenceNbr)
    {
      return APIUtil.GetMeetingNote(USISDKClient, orgCode, bulletinApplication, meeting, bulletinSeqNbr, sequenceNbr);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<MeetingNotesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<MeetingNotesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
