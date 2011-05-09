using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chelab.AxREST.ServiceModel;

namespace ChelabAxREST.Interfaces
{
    public interface IResultRepository
    {
        Result getResult(string ReciId);
        List<Result> getAllResults(string SampleId);
    }
}
