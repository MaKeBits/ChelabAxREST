﻿using Chelab.AxREST.ServiceModel;
using ServiceStack.ServiceInterface;
using Chelab.AxREST.Interfaces;
using ServiceStack.Common;

namespace Chelab.AxREST.ServiceInterface
{
    public class SampleService : RestServiceBase<Sample>
    {
        public ISampleRepository SampleRepository { get; set; }

        public override object OnGet(Sample request)
        {
            if (!request.SampleId.IsNullOrEmpty())
            {
                var address = SampleRepository.GetSample(request.SampleId);
                return new SampleResponse { Sample = address };
            }

            var response = new SampleResponse { Samples = SampleRepository.GetAllSamples() };
            return response;
        }

        public override object OnPost(Sample address)
        {
            return new SampleResponse();
        }

        public override object OnPut(Sample address)
        {
            return new SampleResponse();
        }

        public override object OnDelete(Sample request)
        {
            return new SampleResponse();
        }
    }
}
