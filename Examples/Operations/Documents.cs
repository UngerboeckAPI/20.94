using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Documents : Base
  {
    public Documents(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public DocumentsModel Get(string orgCode, string type, int sequenceNumber)
    {
      return APIUtil.GetDocument(USISDKClient, orgCode, type, sequenceNumber);
    }

    /// <summary>
    /// How to retrieve all.  For high volume, we recommend using a specific query when searching, shown in the General class.
    /// </summary>    
    public IEnumerable<DocumentsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<DocumentsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// An add example for account documents
    /// </summary>    
    public DocumentsModel AddAccountDocument(string orgCode, string type, string fileName, string documentData, string text, string accountCode)
    {
      //Note that sequence number isn't set for POST operations.  Ungerboeck will assign the sequence number automatically.
      var myDocument = new DocumentsModel
      {
        Organization = orgCode,
        Type = type, //The file extension must be mapped to one of the recognized Ungerboeck document types.  Use USISDKConstants.DocumentTypeCodes to get the list of type codes.
        NewFileName = fileName,
        NewDocumentData = documentData, //Files must be in the form of a byte array converted to a base 64 encoded string.  The APIUtil class contains conversion functions to help you: APIUtil.GetEncodedStringForDocuments(FileBytes)
        Description = text, //This will be the Ungerboeck description for the file
        Account = accountCode,
      };

      return APIUtil.AddDocument(USISDKClient, myDocument);
    }

    /// <summary>
    /// An add example for order documents
    /// </summary>    
    public DocumentsModel AddOrderDocument(string orgCode, string type, string fileName, string documentData, string text, int orderNbr, int eventID, string accountCode, int functionID)
    {
      //Note that sequence number isn't set for POST operations.  Ungerboeck will assign the sequence number automatically.
      var myDocument = new DocumentsModel
      {
        Organization = orgCode,
        Type = type, //The file extension must be mapped to one of the recognized Ungerboeck document types.  Use USISDKConstants.DocumentTypeCodes to get the list of type codes.
        NewFileName = fileName,
        NewDocumentData = documentData, //Files must be in the form of a byte array converted to a base 64 encoded string.  The APIUtil class contains conversion functions to help you: APIUtil.GetEncodedStringForDocuments(FileBytes)
        Description = text, //This will be the Ungerboeck description for the file
        Order = orderNbr,
        Event = eventID,
        Account = accountCode,
        Function = functionID
      };

      return APIUtil.AddDocument(USISDKClient, myDocument);
    }

    /// <summary>
    /// An add example for activity documents
    /// </summary>    
    public DocumentsModel AddActivityDocument(string orgCode, string type, string fileName, string documentData, string text, int activity, int eventID, string accountCode)
    {
      //Note that sequence number isn't set for POST operations.  Ungerboeck will assign the sequence number automatically.
      var myDocument = new DocumentsModel
      {
        Organization = orgCode,
        Type = type, //The file extension must be mapped to one of the recognized Ungerboeck document types.  Use USISDKConstants.DocumentTypeCodes to get the list of type codes.
        NewFileName = fileName,
        NewDocumentData = documentData, //Files must be in the form of a byte array converted to a base 64 encoded string.  The APIUtil class contains conversion functions to help you: APIUtil.GetEncodedStringForDocuments(FileBytes)
        Description = text, //This will be the Ungerboeck description for the file
        Activity = activity,
        Event = eventID,
        Account = accountCode
      };

      return APIUtil.AddDocument(USISDKClient, myDocument);
    }

    /// <summary>
    /// An add example for opportunity documents
    /// </summary>    
    public DocumentsModel AddOpportunityDocument(string orgCode, string type, string fileName, string documentData, string text, int opportunity, string accountCode)
    {
      //Note that sequence number isn't set for POST operations.  Ungerboeck will assign the sequence number automatically.
      var myDocument = new DocumentsModel
      {
        Organization = orgCode,
        Type = type, //The file extension must be mapped to one of the recognized Ungerboeck document types.  Use USISDKConstants.DocumentTypeCodes to get the list of type codes.
        NewFileName = fileName,
        NewDocumentData = documentData, //Files must be in the form of a byte array converted to a base 64 encoded string.  The APIUtil class contains conversion functions to help you: APIUtil.GetEncodedStringForDocuments(FileBytes)
        Description = text, //This will be the Ungerboeck description for the file
        Opportunity = opportunity,
        Account = accountCode
      };

      return APIUtil.AddDocument(USISDKClient, myDocument);
    }

    /// <summary>
    /// An add example for meeting documents
    /// </summary>    
    public DocumentsModel AddMeetingDocument(string orgCode, string type, string fileName, string documentData, string text, int meeting, string accountCode)
    {
      //Note that sequence number isn't set for POST operations.  Ungerboeck will assign the sequence number automatically.
      var myDocument = new DocumentsModel
      {
        Organization = orgCode,
        Type = type, //The file extension must be mapped to one of the recognized Ungerboeck document types.  Use USISDKConstants.DocumentTypeCodes to get the list of type codes.
        NewFileName = fileName,
        NewDocumentData = documentData, //Files must be in the form of a byte array converted to a base 64 encoded string.  The APIUtil class contains conversion functions to help you: APIUtil.GetEncodedStringForDocuments(FileBytes)
        Description = text, //This will be the Ungerboeck description for the file
        Meeting = meeting,
        Account = accountCode
      };

      return APIUtil.AddDocument(USISDKClient, myDocument);
    }

    /// <summary>
    /// An add example for exhibitor documents
    /// </summary>    
    public DocumentsModel AddExhibitorDocument(string orgCode, string type, string fileName, string documentData, string text, int exhibitor, string accountCode, int eventID)
    {
      //Note that sequence number isn't set for POST operations.  Ungerboeck will assign the sequence number automatically.
      var myDocument = new DocumentsModel
      {
        Organization = orgCode,
        Type = type, //The file extension must be mapped to one of the recognized Ungerboeck document types.  Use USISDKConstants.DocumentTypeCodes to get the list of type codes.
        NewFileName = fileName,
        NewDocumentData = documentData, //Files must be in the form of a byte array converted to a base 64 encoded string.  The APIUtil class contains conversion functions to help you: APIUtil.GetEncodedStringForDocuments(FileBytes)
        Description = text, //This will be the Ungerboeck description for the file
        Exhibitor = exhibitor,
        Account = accountCode,
        Event = eventID
      };

      return APIUtil.AddDocument(USISDKClient, myDocument);
    }

    /// <summary>
    /// An add example for contract documents
    /// </summary>    
    public DocumentsModel AddContractDocument(string orgCode, string type, string fileName, string documentData, string text, int contract, string accountCode, int eventID)
    {
      //Note that sequence number isn't set for POST operations.  Ungerboeck will assign the sequence number automatically.
      var myDocument = new DocumentsModel
      {
        Organization = orgCode,
        Type = type, //The file extension must be mapped to one of the recognized Ungerboeck document types.  Use USISDKConstants.DocumentTypeCodes to get the list of type codes.
        NewFileName = fileName,
        NewDocumentData = documentData, //Files must be in the form of a byte array converted to a base 64 encoded string.  The APIUtil class contains conversion functions to help you: APIUtil.GetEncodedStringForDocuments(FileBytes)
        Description = text, //This will be the Ungerboeck description for the file
        Contract = contract,
        Account = accountCode,
        Event = eventID
      };

      return APIUtil.AddDocument(USISDKClient, myDocument);
    }

    /// <summary>
    /// An add example for space resource documents
    /// </summary>    
    public DocumentsModel AddSpaceResourceDocument(string orgCode, string type, string fileName, string documentData, string text, string space, string accountCode, string resourceType, string resourceClass)
    {
      //Note that sequence number isn't set for POST operations.  Ungerboeck will assign the sequence number automatically.
      var myDocument = new DocumentsModel
      {
        Organization = orgCode,
        Type = type, //The file extension must be mapped to one of the recognized Ungerboeck document types.  Use USISDKConstants.DocumentTypeCodes to get the list of type codes.
        NewFileName = fileName,
        NewDocumentData = documentData, //Files must be in the form of a byte array converted to a base 64 encoded string.  The APIUtil class contains conversion functions to help you: APIUtil.GetEncodedStringForDocuments(FileBytes)
        Description = text, //This will be the Ungerboeck description for the file
        SpaceResourceCode = space,
        Account = accountCode,
        ResourceType = resourceType,
        ResourceClass = resourceClass
      };

      return APIUtil.AddDocument(USISDKClient, myDocument);
    }

    /// <summary>
    /// An add example for event documents
    /// </summary>    
    public DocumentsModel AddEventDocument(string orgCode, string type, string fileName, string documentData, string text, string accountCode, int eventID)
    {
      //Note that sequence number isn't set for POST operations.  Ungerboeck will assign the sequence number automatically.
      var myDocument = new DocumentsModel
      {
        Organization = orgCode,
        Type = type, //The file extension must be mapped to one of the recognized Ungerboeck document types.  Use USISDKConstants.DocumentTypeCodes to get the list of type codes.
        NewFileName = fileName,
        NewDocumentData = documentData, //Files must be in the form of a byte array converted to a base 64 encoded string.  The APIUtil class contains conversion functions to help you: APIUtil.GetEncodedStringForDocuments(FileBytes)
        Description = text, //This will be the Ungerboeck description for the file
        Account = accountCode,
        Event = eventID
      };

      return APIUtil.AddDocument(USISDKClient, myDocument);
    }

    /// <summary>
    /// An add example for invoice documents
    /// </summary>    
    public DocumentsModel AddInvoiceDocument(string orgCode, string type, string fileName, string documentData, string text, int invoiceNbr, string accountCode)
    {
      //Note that sequence number isn't set for POST operations.  Ungerboeck will assign the sequence number automatically.
      var myDocument = new DocumentsModel
      {
        Organization = orgCode,
        Type = type, //The file extension must be mapped to one of the recognized Ungerboeck document types.  Use USISDKConstants.DocumentTypeCodes to get the list of type codes.
        NewFileName = fileName,
        NewDocumentData = documentData, //Files must be in the form of a byte array converted to a base 64 encoded string.  The APIUtil class contains conversion functions to help you: APIUtil.GetEncodedStringForDocuments(FileBytes)
        Description = text, //This will be the Ungerboeck description for the file
        InvoiceNumber = invoiceNbr,
        Account = accountCode
      };

      return APIUtil.AddDocument(USISDKClient, myDocument);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>    
    public DocumentsModel Edit(string orgCode, string type, int sequenceNumber, string newText)
    {
      //This is just for the document properties.  If you are changing the document data, look at the ImportUpdatedDocument() example.  You can do both in the same edit operation.
      var myDocument = APIUtil.GetDocument(USISDKClient, orgCode, type, sequenceNumber);

      myDocument.Description = newText;

      return APIUtil.UpdateDocument(USISDKClient, myDocument);
    }


    public DocumentsModel ImportUpdatedDocument(string orgCode, string type, int sequenceNumber, string newFilename, string newDocumentBytes)
    {
      //If you include new file data with the DocumentModel, the PUT process will run the "Import Updated Document" on your behalf.
      //If the NewDocumentData property is empty, the file data will not be touched.

      //The max size uploaded is often affected by clients.  For example, you can change this setting by affecting a web.config settings of maxAllowedContentLength and maxRequestLength
      var myDocument = APIUtil.GetDocument(USISDKClient, orgCode, type, sequenceNumber);

      myDocument.NewFileName = newFilename;   //Make sure to include the filename of the document, even if its unchanged.  It's needed for file format verifying.

      myDocument.NewDocumentData = newDocumentBytes; // This should be a base 64 encoded string representing a byte array for the new data of the document when adding or updating a document entry.
                                                     //For example "SGVsbG8gVXBkYXRlZCBXb3JsZCE=" is a text document with the text "Hello World!"

      //We include a APIUtil function if you have a byte array:
      //myDocument.NewDocumentData = APIUtil.GetEncodedStringForDocuments(fileByteArray)

      return APIUtil.UpdateDocument(USISDKClient, myDocument);
    }

    /// <summary>
    /// A delete example
    /// </summary>    
    public void Delete(string orgCode, string type, int sequenceNumber)
    {
      APIUtil.AwaitDeleteDocument(USISDKClient, orgCode, type, sequenceNumber).Wait();
    }

    public string DownloadDocument(string orgCode, string type, int sequenceNumber)
    {
      return APIUtil.DownloadDocument(USISDKClient, orgCode, type, sequenceNumber);
    }

    public DocumentsModel EditAdvanced(string orgCode, string type, int sequenceNumber)
    {

      var myDocument = APIUtil.GetDocument(USISDKClient, orgCode, type, sequenceNumber);

      string strAccountCode = "FAKEACCT"; //Use an account code

      myDocument.Publish = "N";
      myDocument.Status = "CI";  //Use CI or CO to denote Checked In or Checked Out, respectively
      myDocument.SentReceived = "S"; //S or R to denote Sent or Received
      myDocument.Search = "TEST";
      myDocument.Sort = "1";
      myDocument.Category = "CTL"; //Set the category code
      myDocument.Contact = strAccountCode;
      myDocument.DocumentIsAccessibleTo = "O";  //Only Me = "O", Everyone = "E", Users With Roles = "U"

      //.Department = "*NONE,*WORK"  'If Publish is set to 'Y', you can send this in as a comma delimited list of department codes
      //.UsersAndRoles = "USER1,USER2" 'If DocumentIsAccessibleTo is set to U (Users With Roles), you are required to set this field to the User IDs or Role codes that have access to the document.

      return APIUtil.UpdateDocument(USISDKClient, myDocument);
    }
  }
}
