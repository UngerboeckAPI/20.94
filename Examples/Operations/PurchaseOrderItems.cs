using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PurchaseOrderItems : Base
  {
        public PurchaseOrderItems(HttpClient USISDKClient) : base(USISDKClient)
        {
        }

        /// <summary>
        /// A basic retrieve example
        /// </summary>
        public PurchaseOrderItemsModel Get(string orgCode, int number, int itemSequence)
        {
          return APIUtil.GetPurchaseOrderItem(USISDKClient, orgCode, number, itemSequence);
        }

        /// <summary>
        /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
        /// </summary>   
        public IEnumerable<PurchaseOrderItemsModel> RetrieveAll(string orgCode)
        {
          SearchMetadataModel searchMetadata = null;
          return APIUtil.GetSearchList<PurchaseOrderItemsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
        }


        public UngerboeckSDKPackage.PurchaseOrderItemsModel Add(string orgCode, int purchaseOrderNumber, string department, string supplier, string description, string itemCode,
                                                            decimal units, string uom, decimal unitCost, decimal extendedCost, string taxable, decimal tax,
                                                            decimal total, decimal subtotal, string inclusiveExclusiveTax)
        {
            var myPurchaseOrderModel = new UngerboeckSDKPackage.PurchaseOrderItemsModel
            {
                Organization = orgCode,
                Department = department,
                Supplier = supplier,
                Description = description,
                Number = purchaseOrderNumber,
                Item = itemCode,
                Units = units,
                UM = uom, 
                UnitCost = unitCost,
                ExtendedCost = extendedCost,
                Taxable = taxable,
                Tax = tax,
                Total = total,
                Subtotal = subtotal,
                InclusiveExclusive = inclusiveExclusiveTax
            };
            return UngerboeckSDKWrapper.APIUtil.AddPurchaseOrderItem(USISDKClient, myPurchaseOrderModel);
        }
    }
}
