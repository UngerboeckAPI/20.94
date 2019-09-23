using System.Collections.Generic;
using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using Newtonsoft.Json.Linq;

namespace Examples.Operations
{
  public class General : Base
  {
    public General(HttpClient USISDKClient) : base(USISDKClient) { }

    /// <summary>
    /// This method demonstrates searching in the API and navigation abilities.
    /// </summary>
    public IEnumerable<EventsModel> Search(string orgCode)
    {
      //For more info on searching in the Ungerboeck API, see this article:
      //https://supportcenter.ungerboeck.com/hc/en-us/articles/115010610608-Searching-Using-the-API

      SearchMetadataModel searchMetadata = null;
      const string orderBy = "EnteredBy"; //The results will bring back the list sorted on this property
      const int pageSize = 10; //This will be the amount of items brought back by the search.  Further results will be accessible through paging.


      //Here's a search that gets all events after this date
      IEnumerable<EventsModel> eventsList = APIUtil.GetSearchList<EventsModel>(USISDKClient, ref searchMetadata, orgCode, "ChangedOn gt DateTime'2017-09-28'", orderBy, pageSize);

      //eventsList now contains the first 10 entries in this query.  
      //searchMetadata is now populated with paging information            

      //This will get the next 10 entries
      eventsList = APIUtil.NavigateSearchList<EventsModel>(USISDKClient, ref searchMetadata, searchMetadata.Links.Next);

      //eventsList now contains entries 11-20 of the query.

      //This will get the last page
      eventsList = APIUtil.NavigateSearchList<EventsModel>(USISDKClient, ref searchMetadata, searchMetadata.Links.Last);

      //Notice that searchMetadata.Links.Next is null, since it's the last page.

      return eventsList;
    }

    /// <summary>
    /// This method demonstrates searching in the API using OData.
    /// </summary>
    public IEnumerable<EventsModel> SearchingWithOData(string OrgCode)
    {
      //For more info on searching in the Ungerboeck API, see this article:
      //https://supportcenter.ungerboeck.com/hc/en-us/articles/115010610608-Searching-Using-the-API

      SearchMetadataModel searchMetadata = null;
      IEnumerable<EventsModel> eventsList;

      //Here's examples of searches using OData.

      //Get all events with a description equal to a string
      eventsList = APIUtil.GetSearchList<EventsModel>(USISDKClient, ref searchMetadata, OrgCode, "Description eq 'Convention Name'");
      
      //Get all events with a description containing a substring
      eventsList = APIUtil.GetSearchList<EventsModel>(USISDKClient, ref searchMetadata, OrgCode, "substringof('Convention', Description)");

      //Get all events with a description starting with a substring
      eventsList = APIUtil.GetSearchList<EventsModel>(USISDKClient, ref searchMetadata, OrgCode, "startswith('Convention', Description)");

      //Get all events with a description ending with a substring
      eventsList = APIUtil.GetSearchList<EventsModel>(USISDKClient, ref searchMetadata, OrgCode, "endswith('Convention', Description)");

      //Get all events with a description equal to either of two strings
      eventsList = APIUtil.GetSearchList<EventsModel>(USISDKClient, ref searchMetadata, OrgCode, "Description eq 'Convention Name' or Description eq 'Conference Name'");

      //Get all events changed in 2010
      eventsList = APIUtil.GetSearchList<EventsModel>(USISDKClient, ref searchMetadata, OrgCode, "ChangedOn gt DateTime'2010-01-01' AND ChangedOn lt DateTime'2011-01-01'");

    
      return eventsList;
    }

    /// <summary>
    /// This method demonstrates searching for empty values or finding all entries that aren't empty
    /// </summary>
    public IEnumerable<AllAccountsModel> SearchingForNull(string OrgCode)
    {
      //For more info on searching in the Ungerboeck API, see this article:
      //https://supportcenter.ungerboeck.com/hc/en-us/articles/115010610608-Searching-Using-the-API

      SearchMetadataModel searchMetadata = null;
      IEnumerable<AllAccountsModel> accountsList;

      //Here's examples of searches using OData.

      //Get all accounts with certain first name and has an empty SynchronizedOrganization property
      accountsList = APIUtil.GetSearchList<AllAccountsModel>(USISDKClient, ref searchMetadata, OrgCode, "startswith('Jones', FirstName) and LegalName eq null");

      return accountsList;
    }

    /// <summary>
    /// This method demonstrates searching for empty values or finding all entries that aren't empty
    /// </summary>
    public IEnumerable<AllAccountsModel> SearchingForNotNull(string OrgCode)
    {
      //For more info on searching in the Ungerboeck API, see this article:
      //https://supportcenter.ungerboeck.com/hc/en-us/articles/115010610608-Searching-Using-the-API

      SearchMetadataModel searchMetadata = null;
      IEnumerable<AllAccountsModel> accountsList;

      //Get all accounts with certain first name and has a filled SynchronizedOrganization property
      accountsList = APIUtil.GetSearchList<AllAccountsModel>(USISDKClient, ref searchMetadata, OrgCode, "startswith('Jones', FirstName) and LegalName ne null");

      return accountsList;
    }

    /// <summary>
    /// This method demonstrates searching in the API and retrieving specific properties using the Select parameter.
    /// </summary>
    public IEnumerable<object> SearchingForSpecificPropertiesWithSelect(string OrgCode)
    {
      SearchMetadataModel searchMetadata = null;
      JArray eventsList; //Represents a custom object.
      List<string> modelProperties = new List<string> { "Description", "StartDate" };

      //Get all events and only return specific properties in the model
      var events = APIUtil.GetSearchList<EventsModel>(USISDKClient, ref searchMetadata, OrgCode, "ChangedOn gt DateTime'2017-01-01'", "", 10, 100000, modelProperties);
      eventsList = JArray.FromObject(events, new Newtonsoft.Json.JsonSerializer { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore }); //Remove the excess properties from the stock model object.  Those properties are never filled in this process.

      return eventsList;
    }

    /// <summary>
    /// If you would like to check authentication of another Ungerboeck user, this is an example of this.  
    /// </summary>
    /// <param name="userID">Your Ungerboeck user ID</param>
    /// <param name="password">Your Ungerboeck password</param>
    /// <param name="ungerboeckURI">Your Ungerboeck server domain</param>
    /// <param name="userIDToCheckValue">The Ungerboeck user ID of the user being checked</param>
    /// <param name="passwordToCheckValue">The Ungerboeck password of the user being checked</param>    
    public UngerboeckSDKPackage.UngerboeckAuthenticationCheck CheckUngerboeckUserAuthentication(string userID, string password, string ungerboeckURI, string userIDToCheckValue, string passwordToCheckValue)
    {
      //return APIUtil.CheckUngerboeckUserAuthentication(USISDKClient, userID, password, ungerboeckURI, userIDToCheckValue, passwordToCheckValue);
      return APIUtil.CheckUngerboeckUserAuthentication(new HttpClient(), userID, password, ungerboeckURI, userIDToCheckValue, passwordToCheckValue);
    }

  }
}
