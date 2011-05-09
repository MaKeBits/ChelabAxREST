using System.Collections.Generic;
using ServiceStack.ServiceInterface.ServiceModel;

namespace Chelab.AxREST.ServiceModel
{
    public class Sample
    {
        public string SampleId { get; set; }
        public string RecId { get; set; }
    }

    public class SampleResponse : IHasResponseStatus
    {
        public SampleResponse()
        {
            this.Samples = new List<Sample>();
            this.ResponseStatus = new ResponseStatus();
        }

        public Sample Sample { get; set; }

        public List<Sample> Samples { get; set; }

        public ResponseStatus ResponseStatus { get; set; } //Exceptions get injected here
    }
}
