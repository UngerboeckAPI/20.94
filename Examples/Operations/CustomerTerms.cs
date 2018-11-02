using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class CustomerTerms : Base
  {
    public CustomerTerms(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public CustomerTermsModel Get(string orgCode, string code)
    {
      return APIUtil.GetCustomerTerm(USISDKClient, orgCode, code);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<CustomerTermsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<CustomerTermsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
