using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class TransactionMethods : Base
  {
    public TransactionMethods(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public TransactionMethodsModel Get(string orgCode, string code)
    {
      return APIUtil.GetTransactionMethod(USISDKClient, orgCode, code);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<TransactionMethodsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<TransactionMethodsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
