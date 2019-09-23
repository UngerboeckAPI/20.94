using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class FunctionSeatingCharts : Base
  {
    public FunctionSeatingCharts(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    /// <param name="orgCode">The organization code of the function seating chart.</param>
    /// <param name="sequenceNumber">The primary key of the function seating chart.</param>
    public FunctionSeatingChartsModel Get(string orgCode, int sequenceNumber)
    {
      return APIUtil.GetFunctionSeatingChart(USISDKClient, orgCode, sequenceNumber);
    }

    /// <summary>
    /// A retrieve all by organization code
    /// </summary> 
    /// <param name="orgCode">The organization code of the function seating chart.</param>
    public IEnumerable<FunctionSeatingChartsModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<FunctionSeatingChartsModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }

    /// <summary>
    /// A basic add example
    /// </summary>  
    /// <param name="orgCode">The organization code of the function seating chart.</param>
    /// <param name="chartName">Function chart description.</param>
    /// <param name="capacity">Function Chart capacity</param>
    /// <param name="eventId">Function Chart EventId, must be specified for which event and function the chart will apply to.</param>
    /// <param name="functionId">Function Chart FunctionId, must be specified for which event and function the chart will apply to.</param>
    /// <param name="fillMethod">Manual or Auto-Assign, Fill method. Manual = 2, Auto-Assign = 1.</param>
    /// <param name="groupCodeA">One of the group code descriptors to ghelp group tables in the grid.</param>
    /// <param name="inventoryCode">A unique code to help users search for the function seating chart.</param>
    public FunctionSeatingChartsModel Add(string orgCode, string chartName, int capacity, 
                                          int eventId, int functionId, int fillMethod,
                                          string groupCodeA, string inventoryCode)
    {
      var myFunctionSeatingChart = new FunctionSeatingChartsModel
      {
        OrgCode = orgCode,
        Description = chartName,
        Capacity = capacity,
        EventId = eventId,
        FunctionId = functionId,
        FillMethod = fillMethod,
        GroupCodeA = groupCodeA,
        InventoryCode = inventoryCode
      };

      return APIUtil.AddFunctionSeatingChart(USISDKClient, myFunctionSeatingChart);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    /// <param name="orgCode">The organization code of the function seating chart.</param>
    /// <param name="sequenceNumber">The primary key of the function seating chart.</param>
    /// <param name="newChartDescription">New Function Seating Chart Description.</param>
    public FunctionSeatingChartsModel Edit(string orgCode, int sequenceNumber, string newChartDescription)
    {
      var myFunctionSeatingChart = APIUtil.GetFunctionSeatingChart(USISDKClient, orgCode, sequenceNumber);

      myFunctionSeatingChart.Description = newChartDescription;

      return APIUtil.UpdateFunctionSeatingChart(USISDKClient, myFunctionSeatingChart);
    }

    public FunctionSeatingChartsModel AddWithFilledFields(string orgCode, string description, string newTxt12Value)
    {
      var myFunctionSeatingChart = new FunctionSeatingChartsModel
      {
        OrgCode = orgCode,
        Description = description,
      };


      return APIUtil.AddFunctionSeatingChart(USISDKClient, myFunctionSeatingChart);
    }
  }
}
