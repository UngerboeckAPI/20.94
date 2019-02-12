using System.Collections.Generic;
using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System;

namespace Examples.Operations
{
  public class Reports : Base
  {

    public Reports(HttpClient USISDKClient) : base(USISDKClient) { }

    /// <summary>
    /// Tests the Get Parameters for the Controls Test
    /// </summary>
    public ParametersModel GetReportParameters(string astrOrgCode, int aintSequenceNumber)
    {
      ParametersModel parametersModel = APIUtil.GetReportParameters(USISDKClient, astrOrgCode, aintSequenceNumber);

      return parametersModel;
    }

    /// <summary>
    /// Tests the running of the controls text exported to pdf
    /// </summary>
    public ReportResponseModel RunReport(string astrOrgCode, int aintSequenceNumber, ReportRequestModel reportRequestModel)
    {
      ReportResponseModel reportResponseModel = APIUtil.RunReport(USISDKClient, astrOrgCode, aintSequenceNumber, reportRequestModel);

      return reportResponseModel;
    }

    /// <summary>
    /// Tests the running of the controls text exported to word
    /// </summary>
    public ReportResponseModel RunReport(string astrOrgCode, int aintSequenceNumber)
    {
      ParameterValues parameter;
      ReportRequestModel reportRequestModel = new ReportRequestModel();
      reportRequestModel.ExportType = USISDKConstants.ReportConstants.ExportType.PDF;

      parameter = new ParameterValues();
      parameter.ParameterName = "Single Select Text Custom Values";
      parameter.Values.Add("Value_2");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Single Select No Custom Values";
      parameter.Values.Add("Value_1");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Multi Select No Custom Values";
      parameter.Values.Add("Value_1");
      parameter.Values.Add("Value_2");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Number Type";
      parameter.Values.Add("8");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Single Date";
      parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Currency Type";
      parameter.Values.Add("8.95");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Multi Select Text Box Custom Values";
      parameter.Values.Add("Value_1");
      parameter.Values.Add("I'm Custom");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Time Field";
      parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Date Time Field";
      parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Numeric Range Dropdown";
      parameter.Values.Add("1");
      parameter.Values.Add("2");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Numeric Range";
      parameter.Values.Add("1");
      parameter.Values.Add("2");
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Date Range";
      parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      parameter.Values.Add(DateTime.Now.AddDays(7).ToString(USISDKConstants.ReportConstants.ReportDateFormat));
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Boolean Value with Text";
      parameter.Values.Add(true.ToString());
      reportRequestModel.Parameters.Add(parameter);

      parameter = new ParameterValues();
      parameter.ParameterName = "Boolean Value No Text";
      parameter.Values.Add("True");
      reportRequestModel.Parameters.Add(parameter);

      ReportResponseModel reportResponseModelTest = APIUtil.RunReport(USISDKClient, astrOrgCode, aintSequenceNumber, reportRequestModel);

      return reportResponseModelTest;
    }

    /// <summary>
    /// Tests the running of the controls text exported to word
    /// </summary>
    public ReportResponseModel RunReportFullTest(string astrOrgCode, int aintSequenceNumber)
    {
      ParametersModel parametersModel = APIUtil.GetReportParameters(USISDKClient, astrOrgCode, aintSequenceNumber);
      ReportRequestModel reportRequestModel = new ReportRequestModel();

      ParameterValues parameter;
      
      foreach (ParameterInfo parameterPulled in parametersModel.Parameters)
      {
        parameter = new ParameterValues();
        parameter.ParameterName = parameterPulled.ParameterName;

        switch (parameterPulled.ParameterName)
        {
          case "Single Select Text Custom Values":
            //This one for me is true already but as an example
            //parameterPulled.AllowCustomValues would be true
            if (parameterPulled.AllowCustomValues)
            {
              parameter.Values.Add("I'm Custom");
            }
            else
            {
              if (parameterPulled.DefaultValues.Count > 0)
              {
                //This one is a single select.
                foreach (string key in parameterPulled.DefaultValues.Keys)
                {
                  parameter.Values.Add(key);
                  break;
                }
              }
            }

            break;
          case "Single Select No Custom Values":
            //It should have values in parameterPulled.DefaultValues and it needs to use one of those keys
            //parameterPulled.AllowCustomValues would be false
            parameter.Values.Add("Value_1");
            break;
          case "Multi Select No Custom Values":
            //It should have values in parameterPulled.DefaultValues and it needs to use those keys, not all but in that list
            parameter.Values.Add("Value_1");
            parameter.Values.Add("Value_2");
            break;
          case "Number Type":
            //Basic number as string, no decimal places
            parameter.Values.Add("8");
            break;
          case "Single Date":
            //Format is 100% important, use the constant provided
            parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
            break;
          case "Currency Type":
            parameter.Values.Add("8.95");
            break;
          case "Multi Select Text Box Custom Values":
            parameter.Values.Add("Value_1");
            parameter.Values.Add("I'm Custom");
            break;
          case "Time Field":
            //Format is 100% important, use the constant provided
            //It only uses the time portion
            parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
            break;
          case "Date Time Field":
            //Format is 100% important, use the constant provided
            //It only uses the date portion
            parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
            break;
          case "Numeric Range Dropdown":
            //The first value must be less then the second value
            //It should have values in parameterPulled.DefaultValues and its used for both sides of the range
            //parameterPulled.AllowCustomValues would be false
            parameter.Values.Add("1");
            parameter.Values.Add("2");
            break;
          case "Numeric Range":
            //The first value must be less then the second value
            //Any numbers can be used
            parameter.Values.Add("1");
            parameter.Values.Add("2");
            break;
          case "Date Range":
            //Format is 100% important, use the constant provided
            //The first value must be less then the second value
            parameter.Values.Add(DateTime.Now.ToString(USISDKConstants.ReportConstants.ReportDateFormat));
            parameter.Values.Add(DateTime.Now.AddDays(7).ToString(USISDKConstants.ReportConstants.ReportDateFormat));
            break;
          case "Boolean Value with Text":
            //It should have values in parameterPulled.DefaultValues for true/false descriptions
            parameter.Values.Add("True");
            break;
          case "Boolean Value No Text":
            parameter.Values.Add(true.ToString());
            break;
        }
        reportRequestModel.Parameters.Add(parameter);
      }
      
      ReportResponseModel reportResponseModelTest = APIUtil.RunReport(USISDKClient, astrOrgCode, aintSequenceNumber, reportRequestModel);

      return reportResponseModelTest;
    }
  }
}
