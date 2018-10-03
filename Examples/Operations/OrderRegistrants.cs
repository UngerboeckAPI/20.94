using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class OrderRegistrants : Base
  {
    public OrderRegistrants(HttpClient USISDKClient) : base(USISDKClient)
    {
    }
    public OrderRegistrantsModel Get(string orgCode, int registrantSequenceNbr)
    {
      return APIUtil.GetOrderRegistrants(USISDKClient, orgCode, registrantSequenceNbr);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>   
    public IEnumerable<OrderRegistrantsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<OrderRegistrantsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public OrderRegistrantsModel Edit(string orgCode, int registrantSequenceNbr, string strNewUserFieldText)
    {
      var myOrderRegistrant = APIUtil.GetOrderRegistrants(USISDKClient, orgCode, registrantSequenceNbr);

      myOrderRegistrant.RegistrantUserFields.UserText01 = strNewUserFieldText;

      return APIUtil.UpdateOrderRegistrant(USISDKClient, myOrderRegistrant);
    }

  }
}
