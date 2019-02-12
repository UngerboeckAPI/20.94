using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventProductsAndServices : Base
  {
    public EventProductsAndServices(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventProductsAndServicesModel Get(string orgCode, int sequenceNumber)
    {
      return APIUtil.GetEventProductService(USISDKClient, orgCode, sequenceNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<EventProductsAndServicesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<EventProductsAndServicesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example with the minimal required fields for an Event product
    /// </summary> 
    public EventProductsAndServicesModel AddEventProduct(string orgCode, int eventId, string productCode) {
      var myProduct = new EventProductsAndServicesModel {
        OrganizationCode = orgCode,
        EventID = eventId,
        ProductServiceCode = productCode
      };

      return APIUtil.AddEventProductService(USISDKClient, myProduct);
    }

    /// <summary>
    /// A basic add example with the minimal required fields for an Exhibitor product
    /// </summary> 
    public EventProductsAndServicesModel AddExhibitorProduct(string orgCode, int exhibitorId, string productCode) {
      var myProduct = new EventProductsAndServicesModel {
        OrganizationCode = orgCode,
        ExhibitorID = exhibitorId,
        ProductServiceCode = productCode
      };

      return APIUtil.AddEventProductService(USISDKClient, myProduct);
    }

    /// <summary>
    /// A basic add example with a constructed EventProductsAndServicesModel object
    /// </summary> 
    public EventProductsAndServicesModel Add(EventProductsAndServicesModel myProduct) {
      return APIUtil.AddEventProductService(USISDKClient, myProduct);
    }

    /// <summary>
    /// A basic edit example with a constructed EventProductsAndServiceModel object
    /// </summary> 
    public EventProductsAndServicesModel Edit(EventProductsAndServicesModel myProduct) {
      return APIUtil.UpdateEventProductService(USISDKClient, myProduct);
    }

  }
}
