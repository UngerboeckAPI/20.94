using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class RelationshipTypes : Base
  {
    public RelationshipTypes(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public RelationshipTypesModel Get(string orgCode, string code)
    {
      return APIUtil.GetRelationshipType(USISDKClient, orgCode, code);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<RelationshipTypesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<RelationshipTypesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
