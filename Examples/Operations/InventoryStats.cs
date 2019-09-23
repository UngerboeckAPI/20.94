using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class InventoryStats : Base
  {
    public InventoryStats(HttpClient USISDKClient) : base(USISDKClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public InventoryStatsModel Get(string orgCode, string item, string space, string lotSerialNumber)
    {
      return APIUtil.GetInventoryStats(USISDKClient, orgCode, item, space, lotSerialNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<InventoryStatsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<InventoryStatsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
