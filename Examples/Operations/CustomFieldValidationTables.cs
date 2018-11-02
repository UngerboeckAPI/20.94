using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class CustomFieldValidationTables : Base
  {
    public CustomFieldValidationTables(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public CustomFieldValidationTablesModel Get(string orgCode, int ID)
    {
      return APIUtil.GetCustomFieldValidationTable(USISDKClient, orgCode, ID);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<CustomFieldValidationTablesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<CustomFieldValidationTablesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
