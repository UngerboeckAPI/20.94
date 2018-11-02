using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class MarketSegments : Base
  {
    public MarketSegments(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MarketSegmentsModel Get(string orgCode, string major, string minor)
    {
      return APIUtil.GetMarketSegment(USISDKClient, orgCode, major, minor);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<MarketSegmentsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<MarketSegmentsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
