using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chelab.AxREST.ServiceModel;

namespace ChelabAxREST.Interfaces
{
    public interface ISampleRepository
    {
        Sample GetSample(string recId);

        List<Sample> GetAllSamples();
    }
}
