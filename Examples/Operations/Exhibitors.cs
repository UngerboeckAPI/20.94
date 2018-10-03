using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Exhibitors : Base
  {
    public Exhibitors(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ExhibitorsModel Get(string orgCode, int exhibitorID) 
    {
      return APIUtil.GetExhibitors(USISDKClient, orgCode, exhibitorID);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<ExhibitorsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<ExhibitorsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}
