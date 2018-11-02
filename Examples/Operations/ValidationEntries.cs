using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ValidationEntries : Base
  {
    public ValidationEntries(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public ValidationEntriesModel Get(string orgCode, int validationTableID, int sequenceNumber)
    {
      return APIUtil.GetValidationEntry(USISDKClient, orgCode, validationTableID, sequenceNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<ValidationEntriesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ValidationEntriesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
