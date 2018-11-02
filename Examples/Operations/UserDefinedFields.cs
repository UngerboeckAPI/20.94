using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class UserDefinedFields : Base
  {
    public UserDefinedFields(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public UserDefinedFieldsModel Get(string orgCode, string issueOpportunityClass, string issueOpportunityType, int sequenceNumber)
    {
      return APIUtil.GetUserDefinedField(USISDKClient, orgCode, issueOpportunityClass, issueOpportunityType, sequenceNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<UserDefinedFieldsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<UserDefinedFieldsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
