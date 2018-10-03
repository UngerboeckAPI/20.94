using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Examples.Operations
{
    public class Base
    {
        protected readonly HttpClient USISDKClient;

        protected Base(HttpClient USISDKClient)
        {
            this.USISDKClient = USISDKClient;
        }
    }    
}
