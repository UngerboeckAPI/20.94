using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventProductsAndServices : Base
  {
    public EventProductsAndServices(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventProductsAndServicesModel Get(string orgCode, int sequenceNumber)
    {
      return APIUtil.GetEventProductService(USISDKClient, orgCode, sequenceNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<EventProductsAndServicesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<EventProductsAndServicesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
