using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chelab.AxREST.Interfaces;
using Chelab.AxREST.ServiceModel;
using BC.NET;
using Microsoft.Dynamics.BusinessConnectorNet;

namespace Chelab.AxREST.Logic
{
    public class SampleRepository : ISampleRepository
    {
        public Sample GetSample(string recId)
        {          
            return new Sample { SampleId = "12345" };
        }

        public List<Sample> GetAllSamples()
        {
            return new List<Sample> 
            { 
                new Sample { SampleId = "12345" }, 
                new Sample {SampleId = "67890" }
            };
        }
    }
}
