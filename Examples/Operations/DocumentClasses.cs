using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class DocumentClasses : Base
  {
    public DocumentClasses(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public DocumentClassesModel Get(string orgCode, string Class)
    {
      return APIUtil.GetDocumentClass(USISDKClient, orgCode, Class);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<DocumentClassesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<DocumentClassesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
