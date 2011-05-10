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
            throw new NotImplementedException();
        }

        public Result getResult(string SampleId, string ResultId, int RsltRepetition)
        {
            throw new NotImplementedException();
        }
    }
}
