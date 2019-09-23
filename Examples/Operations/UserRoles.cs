using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class UserRoles : Base
  {
    public UserRoles(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>    
    /// A basic retrieve example    
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="user">User ID</param>
    /// <param name="role">Role ID</param>
    /// <returns></returns>
    public UserRolesModel Get(string user, string role)
    {
      return APIUtil.GetUserRole(USISDKClient, user, role);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<UserRolesModel> RetrieveAll()
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<UserRolesModel>(USISDKClient, ref searchMetadata, null, "All"); //Note that this endpoint does not use OrgCode
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="user">User ID.  You can include a comma delimited list of User ID's or Role ID's, but not both. Example: "BILLW,ALEXY"</param>
    /// <param name="role">Role ID.  You can include a comma delimited list of User ID's or Role ID's, but not both.</param>
    /// <returns>A message for how many UserRole relationships were created.</returns>
    public string Add(string user, string role)
    {
      var myUserRole = new UserRolesModel
      {         
        User = user,
        Role = role
      };

      return APIUtil.AddUserRole(USISDKClient, myUserRole);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>
    /// <param name="user">User ID.  You can include a comma delimited list of User ID's or Role ID's, but not both.</param>
    /// <param name="role">Role ID.  You can include a comma delimited list of User ID's or Role ID's, but not both.</param>
    /// <returns>A message for how many UserRole relationships were removed.</returns>
    public string Delete(string user, string role)
    {
      return APIUtil.DeleteUserRole(USISDKClient, user, role);
    }
  }
}
