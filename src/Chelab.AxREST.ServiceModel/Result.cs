using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface.ServiceModel;
using System.ComponentModel;

namespace Chelab.AxREST.ServiceModel
{
    public class Result
    {
        private Int16 _RsltRepetition = 1;

        public String SampleId { get; set; }
        public String ResultId { get; set; }
        [DefaultValue(true)]
        public Int16 RsltRepetition
        {
            get { return _RsltRepetition; }
            set { _RsltRepetition = value; }
        }
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
