using System.Collections.Generic;
using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;

namespace Examples.Operations
{
  public class AccountAffiliations : Base
  {
    public AccountAffiliations(HttpClient USISDKClient) : base(USISDKClient) { }

    /// <summary>
    /// A basic retrieve example
    /// </summary>    
    public AccountAffiliationsModel Get(string orgCode, string accountCode, string affiliationCode)
    {
      return APIUtil.GetAccountAffiliation(USISDKClient, orgCode, accountCode, affiliationCode);
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    public AccountAffiliationsModel Add(string orgCode, string accountCode, string affiliationCode)
    {
      var myAccountAffiliation = new AccountAffiliationsModel
      {
        OrganizationCode = orgCode,
        AccountCode = accountCode,
        AffiliationCode = affiliationCode
      };

      return APIUtil.AddAffiliation(USISDKClient, myAccountAffiliation);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(string OrgCode, string accountCode, string affiliationCode)
    {
      APIUtil.AwaitDeleteAccountAffiliation(USISDKClient, OrgCode, accountCode, affiliationCode).Wait();  //Only error responses are returned from Delete calls --.Wait() allows errors to catch properly here.
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary>    
    public IEnumerable<AccountAffiliationsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<AccountAffiliationsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
