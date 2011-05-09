using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChelabAxREST.Interfaces;
using Chelab.AxREST.ServiceModel;

namespace Chelab.AxREST.Logic
{
    public class SampleRepository : ISampleRepository
    {
        public Sample GetSample(string recId)
        {
            throw new NotImplementedException();
        }

        public List<Sample> GetAllSamples()
        {
            throw new NotImplementedException();
        }
    }
}
