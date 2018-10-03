using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PurchaseOrders : Base
  {
    public PurchaseOrders(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PurchaseOrdersModel Get(string orgCode, int number)
    {
      return APIUtil.GetPurchaseOrders(USISDKClient, orgCode, number);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<PurchaseOrdersModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<PurchaseOrdersModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }


        public UngerboeckSDKPackage.PurchaseOrdersModel Add(string orgCode, string department, string supplier, string description)
        {
            var myPurchaseOrderModel = new UngerboeckSDKPackage.PurchaseOrdersModel
            {
                Organization = orgCode,
                Department = department,
                Supplier = supplier,
                Description = description,
                Date = System.DateTime.Now
            };
            return UngerboeckSDKWrapper.APIUtil.AddPurchaseOrder(USISDKClient, myPurchaseOrderModel);
        }
    }
}
