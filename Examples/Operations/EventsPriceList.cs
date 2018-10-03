using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventsPriceList : Base
  {
    public EventsPriceList(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventsPriceListModel Get(string orgCode, string code, int eventID)
    {
      return APIUtil.GetEventsPriceList(USISDKClient, orgCode, code, eventID);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<EventsPriceListModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<EventsPriceListModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
