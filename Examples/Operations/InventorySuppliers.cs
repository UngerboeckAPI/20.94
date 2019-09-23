using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
public	class InventorySuppliers : Base
			{
		public InventorySuppliers(HttpClient USISDKClient) : base(USISDKClient)
		{
		}

		/// <summary>
		/// A basic retrieve example
		/// </summary>
		public InventorySuppliersModel Get(string orgCode, string priceList, string supplier)
		{
			return APIUtil.GetPriceListItem(USISDKClient, orgCode, priceList, supplier);
		}

		/// <summary>
		/// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
		/// </summary>   
		public IEnumerable<InventorySuppliersModel> RetrieveAll(string orgCode)
		{
			SearchMetadataModel searchMetadata = null;
			return APIUtil.GetSearchList<InventorySuppliersModel>(USISDKClient, ref searchMetadata, orgCode, "All");
		}

	}
}
