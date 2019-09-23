using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Roles : Base
  {
    public Roles(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public RolesModel Get(string ID)
    {
      return APIUtil.GetRole(USISDKClient, ID);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<RolesModel> RetrieveAll()
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<RolesModel>(USISDKClient, ref searchMetadata, null, "All"); //Note that this endpoint does not use OrgCode
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <param name="organizationCode">This will be used as the initial organization for the Role.</param>
    /// <param name="ID">This will be the Role ID the Role can use to login.  It will be permanent.</param>
    /// <param name="displayName">This will be the name of the new Role</param>
    /// <returns></returns>
    public RolesModel Add(string ID, string displayName)
    {
      var myRole = new RolesModel
      {         
        ID = ID,
        DisplayName = displayName
      };

      return APIUtil.AddRole(USISDKClient, myRole);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="ID">This is the Role ID</param>
    /// <param name="email">You can edit the Role's email.  This example shows how.</param>
    /// <returns></returns>
    public RolesModel Edit(string ID, string displayName)
    {
      var myRole = APIUtil.GetRole(USISDKClient, ID);

      myRole.DisplayName = displayName;

      return APIUtil.UpdateRole(USISDKClient, myRole);
    }    
  }
}
