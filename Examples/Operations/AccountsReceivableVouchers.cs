using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AccountsReceivableVouchers : Base
  {
    public AccountsReceivableVouchers(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public AccountsReceivableVouchersModel Get(string orgCode, int voucherSequence)
    {
      return APIUtil.GetAccountsReceivableVoucher(USISDKClient, orgCode, voucherSequence);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<AccountsReceivableVouchersModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<AccountsReceivableVouchersModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

  }
}
