using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AccountProductsAndServices : Base
  {
    public AccountProductsAndServices(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>   
    public AccountsProductsAndServicesModel Get(string orgCode, string accountCode, string productServiceCode)
    {
      return APIUtil.GetAccountProductService(USISDKClient, orgCode, accountCode, productServiceCode);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary>  
    public IEnumerable<AccountsProductsAndServicesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<AccountsProductsAndServicesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary> 
    public AccountsProductsAndServicesModel Add(string orgCode, string accountCode, string productServiceCode)
    {
      var myProductService = new AccountsProductsAndServicesModel
      {
        OrganizationCode = orgCode,
        AccountCode = accountCode,
        ProductServiceCode = productServiceCode
      };

      return APIUtil.AddProductService(USISDKClient, myProductService);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>  
    public void Delete(string orgCode, string accountCode, string productServiceCode)
    {
      APIUtil.AwaitDeleteAccountProductService(USISDKClient, orgCode, accountCode, productServiceCode).Wait();
    }

  }
}
