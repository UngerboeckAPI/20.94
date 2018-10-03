﻿using System.Net.Http;
using UngerboeckSDKWrapper;
using UngerboeckSDKPackage;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Cycles : Base
  {
    public Cycles(HttpClient USISDKClient) : base(USISDKClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public CyclesModel Get(string orgCode, string code)
    {
      return APIUtil.GetCycles(USISDKClient, orgCode, code);
    }

    /// <summary>
    /// A retrieve all.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public IEnumerable<CyclesModel> RetrieveAll(string orgCode)
    {
      SearchMetadataModel searchMetadata = null;
      return APIUtil.GetSearchList<CyclesModel>(USISDKClient, ref searchMetadata, orgCode, "All");
    }
  }
}