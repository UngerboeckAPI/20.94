using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PriceListItems : Base
  {
    public PriceListItems(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PriceListItemsModel Get(string orgCode, string priceList, int sequence)
    {
      return APIUtil.GetPriceListItem(USISDKClient, orgCode, priceList, sequence);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<PriceListItemsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<PriceListItemsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
