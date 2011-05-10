using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chelab.AxREST.Interfaces;
using Chelab.AxREST.ServiceModel;

namespace Chelab.AxREST.Logic
{
    public class ResultRepository : IResultRepository
    {
        public List<Result> getAllResults(string SampleId)
        {
            return new List<Result> 
            { 
                new Result { SampleId = "123", ResultId = "456" },
                new Result { SampleId = "789", ResultId = "012" } 
            };
        }

        public Result getResult(string SampleId, string ResultId, int RsltRepetition)
        {
            return new Result { SampleId = "123", ResultId = "456" };
        }
    }
}
