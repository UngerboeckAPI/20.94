using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Operations
{
  public class Booths : Base
  {
    public Booths(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public BoothsModel Get(string orgCode, int sequenceNumber)
    {
      return APIUtil.GetBooth(USISDKClient, orgCode, sequenceNumber);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<BoothsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<BoothsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A retrieve all booths on a function.
    /// </summary> 
    public IEnumerable<BoothsModel> GetByEventFunction(string orgCode, int eventID, int functionID) {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<BoothsModel>(USISDKClient, ref searchMetadata, orgCode, $"Function eq {functionID} and Event eq {eventID}");
    }

    /// <summary>
    /// Retrieve a booth by Booth name. Event and function are required
    /// </summary> 
    public BoothsModel GetByName(string orgCode, int eventID, int functionID, string boothName) {
      SearchMetadataModel searchMetadata = null;
      BoothsModel returnBooth = null;

      var boothsResult = APIUtil.GetSearchList<BoothsModel>(USISDKClient, ref searchMetadata, orgCode, $"Function eq {functionID} and Event eq {eventID} and Booth eq '{boothName}'");

      if (boothsResult?.Count() == 1) {
        returnBooth = boothsResult.First();
      }

      return returnBooth;
    }

    /// <summary>
    /// A basic add example with the minimal required fields
    /// </summary> 
    public BoothsModel Add(string orgCode, int eventId, int functionId, string assignCode) {
      var myBooth = new BoothsModel {
        OrganizationCode = orgCode,
        Event = eventId,
        Function = functionId,
        Booth = assignCode
      };

      return APIUtil.AddBooth(USISDKClient, myBooth);
    }

    /// <summary>
    /// A basic add example with a constructed Booth Model object
    /// </summary> 
    public BoothsModel Add(BoothsModel myBooth) {
      return APIUtil.AddBooth(USISDKClient, myBooth);
    }

    /// <summary>
    /// A basic edit example for status
    /// </summary> 
    public BoothsModel Edit(string orgCode, int seqNumber, string newStatus) {
      var myBooth = APIUtil.GetBooth(USISDKClient, orgCode, seqNumber);

      myBooth.BoothStatus = newStatus;

      return APIUtil.UpdateBooth(USISDKClient, myBooth);
    }

    /// <summary>
    /// A basic edit example with a constructed Exhibitors Model object
    /// </summary> 
    public BoothsModel Edit(BoothsModel myBooth) {
      return APIUtil.UpdateBooth(USISDKClient, myBooth);
    }

    /// <summary>
    /// A basic delete booth example
    /// </summary>    
    public void Delete(string OrgCode, int seqNumber) {
      APIUtil.AwaitDeleteBooth(USISDKClient, OrgCode, seqNumber).Wait();  //Only error responses are returned from Delete calls --.Wait() allows errors to catch properly here.
    }

  }
}
