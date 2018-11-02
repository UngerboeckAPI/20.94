using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Contracts : Base
  {
    public Contracts(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public ContractsModel Get(string orgCode, int sequence)
    {
      return APIUtil.GetContract(USISDKClient, orgCode, sequence);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<ContractsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ContractsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
