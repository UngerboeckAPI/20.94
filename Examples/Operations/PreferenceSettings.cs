using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PreferenceSettings : Base
  {
    public PreferenceSettings(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public PreferenceSettingsModel Get(string orgCode, int ID)
    {
      return APIUtil.GetPreferenceSetting(USISDKClient, orgCode, ID);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<PreferenceSettingsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<PreferenceSettingsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    public PreferenceSettingsModel Add(string orgCode, string contact, int consentSettingsID)
    {
      var myPreferenceSetting = new PreferenceSettingsModel
      {
        Organization = orgCode,
        Contact = contact,
        PreferenceType = consentSettingsID
      };

      return APIUtil.AddPreferenceSetting(USISDKClient, myPreferenceSetting);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>    
    public PreferenceSettingsModel Edit(string orgCode, int ID, string newConsentGiven)
    {
      var myPreferenceSetting = APIUtil.GetPreferenceSetting(USISDKClient, orgCode, ID);

      myPreferenceSetting.ConsentGiven = newConsentGiven;

      return APIUtil.UpdatePreferenceSetting(USISDKClient, myPreferenceSetting);
    }

    /// <summary>
    /// A delete example
    /// </summary>    
    public void Delete(string orgCode, int ID)
    {
      APIUtil.AwaitDeletePreferenceSetting(USISDKClient, orgCode, ID).Wait();
    }
  }
}
