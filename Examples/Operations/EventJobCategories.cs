using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventJobCategories : Base
  {
    public EventJobCategories(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventJobCategoriesModel Get(string orgCode, string code)
    {
      return APIUtil.GetEventJobCategory(USISDKClient, orgCode, code);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<EventJobCategoriesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<EventJobCategoriesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
