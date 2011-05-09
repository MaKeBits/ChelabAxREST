using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface.ServiceModel;

namespace Chelab.AxREST.ServiceModel
{
    public class Result
    {
        public string SampleId { get; set; }
        public string ResultId { get; set; }
        public string SampleRecId { get; set; }
        public string ResultRecId { get; set; }
    }

    public class ResultResponse : IHasResponseStatus
    {
        public ResultResponse()
        {
            this.Results = new List<Result>();
            this.ResponseStatus = new ResponseStatus();
        }

        public Result Result { get; set; }

        public List<Result> Results { get; set; }

        public ResponseStatus ResponseStatus { get; set; } //Exceptions get injected here
    }
}
