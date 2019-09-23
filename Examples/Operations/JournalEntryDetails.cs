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

    /// <summary>
    /// Adds a Journal Entry 
    /// </summary>
    public JournalEntryDetailsModel Add(string orgCode, int Event, int year, int period, string source, string entryNumber, string status, string description, System.DateTime date)
    {
      var myJournalEntryDetail = new JournalEntryDetailsModel
      {
        Organization = orgCode,
        Event = Event,
        Year = year,
        Period = period,
        Source = source,
        EntryNumber = entryNumber,
        Status = status,
        Description = description,
        Date = date
      };

      return APIUtil.AddJournalEntryDetail(USISDKClient, myJournalEntryDetail);
    }

    /// <summary>
    /// Updates an existing journal entry by updating the description value
    /// </summary>
    public JournalEntryDetailsModel Edit(string orgCode, int year, int period, string source, string entryNumber, int line)
    {
      JournalEntryDetailsModel journalEntryDetailModel = APIUtil.GetJournalEntryDetails(USISDKClient, orgCode, year, period, source, entryNumber, line);
      string description = journalEntryDetailModel.Description + " : description edited via test " + System.DateTime.Now.ToString();
      journalEntryDetailModel.Description = description;

      journalEntryDetailModel = APIUtil.UpdateJouralEntryDetail(USISDKClient, journalEntryDetailModel);
      return journalEntryDetailModel;
    }
  }
}
