using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class OrderStatuses : Base
  {
    public OrderStatuses(HttpClient USISDKClient) : base(USISDKClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public OrderStatusesModel Get(string orgCode, string code)
    {
      return APIUtil.GetOrderStatus(USISDKClient, orgCode, code);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<OrderStatusesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<OrderStatusesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
