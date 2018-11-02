using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AlternateAddresses : Base
  {
    public AlternateAddresses(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public AlternateAddressesModel Get(string orgCode, string account, int sequenceNumber, string recordType)
    {
      return APIUtil.GetAlternateAddress(USISDKClient, orgCode, account, sequenceNumber, recordType);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<AlternateAddressesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<AlternateAddressesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
