using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class OrganizationParameters : Base
  {
    public OrganizationParameters(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public OrganizationParametersModel Get(string orgCode, string applicationCode, string parameterCode)
    {
      return APIUtil.GetOrganizationParameter(USISDKClient, orgCode, applicationCode, parameterCode);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<OrganizationParametersModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<OrganizationParametersModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
