using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class JournalEntryDetails : Base
  {
    public JournalEntryDetails(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public JournalEntryDetailsModel Get(string orgCode, int year, int period, string source, string entryNumber, int line)
    {
      return APIUtil.GetJournalEntryDetail(USISDKClient, orgCode, year, period, source, entryNumber, line);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<JournalEntryDetailsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<JournalEntryDetailsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
