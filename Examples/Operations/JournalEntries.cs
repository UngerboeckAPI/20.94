using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class JournalEntries : Base
  {
    public JournalEntries(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public JournalEntriesModel Get(string orgCode, int year, int period, string source, string entryNumber)
    {
      return APIUtil.GetJournalEntries(USISDKClient, orgCode, year, period, source, entryNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<JournalEntriesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<JournalEntriesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
