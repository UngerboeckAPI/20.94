using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Quotes : Base
  {
    public Quotes(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public QuotesModel Get(string orgCode, int sequence)
    {
      return APIUtil.GetQuote(USISDKClient, orgCode, sequence);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<QuotesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<QuotesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
