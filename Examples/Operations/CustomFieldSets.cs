using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class CustomFieldSets : Base
  {
    public CustomFieldSets(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public CustomFieldSetsModel Get(string orgCode, string Class, string code)
    {
      return APIUtil.GetCustomFieldSet(USISDKClient, orgCode, Class, code);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<CustomFieldSetsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<CustomFieldSetsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
