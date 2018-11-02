using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ProductsAndServices : Base
  {
    public ProductsAndServices(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ProductsAndServicesModel Get(string orgCode, string code)
    {
      return APIUtil.GetProductsAndService(USISDKClient, orgCode, code);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<ProductsAndServicesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ProductsAndServicesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
