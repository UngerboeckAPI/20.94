using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class InventoryItems : Base
  {
    public InventoryItems(HttpClient USISDKClient) : base(USISDKClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public InventoryItemsModel Get(string orgCode, string code)
    {
      return APIUtil.GetInventoryItems(USISDKClient, orgCode, code);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<InventoryItemsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<InventoryItemsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
