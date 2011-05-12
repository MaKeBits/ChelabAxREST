using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chelab.AxREST.ServiceModel;

namespace Chelab.AxREST.Interfaces
{
    public interface IResultRepository
    {
        Result getResult(string SampleId, string ResultId, int RsltRepetition);
        List<Result> getResults(string SampleId);
    }
}
