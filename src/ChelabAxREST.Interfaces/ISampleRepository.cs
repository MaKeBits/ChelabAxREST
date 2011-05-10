using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chelab.AxREST.ServiceModel;

namespace Chelab.AxREST.Interfaces
{
    public interface ISampleRepository
    {
        Sample GetSample(string SampleId);

        List<Sample> GetAllSamples();
    }
}
