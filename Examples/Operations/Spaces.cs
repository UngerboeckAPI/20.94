using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Spaces : Base
  {
    public Spaces(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public SpacesModel Get(string orgCode, string code)
    {
      return APIUtil.GetSpace(USISDKClient, orgCode, code);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<SpacesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<SpacesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary> 
    public SpacesModel Add(string orgCode, string code, string Text)
    {
      var mySpace = new SpacesModel
      {
        Organization = orgCode,
        Code = code,
        SpaceDescription = Text,
      };

      return APIUtil.AddSpace(USISDKClient, mySpace);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>  
    public SpacesModel Edit(string orgCode, string code, string newText)
    {
      var mySpace = APIUtil.GetSpace(USISDKClient, orgCode, code);

      mySpace.SpaceDescription = newText;

      return APIUtil.UpdateSpace(USISDKClient, mySpace);
    }
  }
}
