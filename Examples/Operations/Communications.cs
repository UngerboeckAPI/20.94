using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Communications : Base
  {
    public Communications(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public CommunicationsModel Get(string orgCode, string accountCode, int sequenceNumber)
    {
      return APIUtil.GetCommunication(USISDKClient, orgCode, accountCode, sequenceNumber);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<CommunicationsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<CommunicationsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// Example of how to add a communication entry
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="accountCode">This is the account code you need to attach the communication to.</param>
    /// <param name="Type">This is the type foreign key that is pulled from the CC801_COMM_TYPES table</param>
    /// <param name="Value">This is the actual communication entry value (e.g. the phone number or mobile number)</param>    
    public CommunicationsModel Add(string orgCode, string accountCode, string Type, string Value)
    {
      //Note that sequence number isn't set for POST operations.  Ungerboeck will assign the sequence number automatically
      var myProductService = new CommunicationsModel
      {
        OrganizationCode = orgCode,
        AccountCode = accountCode,
        Type = Type,
        Value = Value,
        Private = UngerboeckSDKPackage.USISDKConstants.CommunicationSensitivity.Public //You can set the sensitivity
      };

      return APIUtil.AddCommunication(USISDKClient, myProductService);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>  
    public CommunicationsModel Edit(string orgCode, string accountCode, int sequenceNumber, string Type, string Value)
    {
      var myCommunication = APIUtil.GetCommunication(USISDKClient, orgCode, accountCode, sequenceNumber);

      myCommunication.Type = Type; //This is the type foreign key that is pulled from the CC801_COMM_TYPES table
      myCommunication.Value = Value; //This is the actual communication entry value (e.g. the phone number or mobile number)

      return APIUtil.UpdateCommunication(USISDKClient, myCommunication);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, string accountCode, int sequenceNumber)
    {
      APIUtil.AwaitDeleteCommunication(USISDKClient, orgCode, accountCode, sequenceNumber).Wait();
    }

  }
}
