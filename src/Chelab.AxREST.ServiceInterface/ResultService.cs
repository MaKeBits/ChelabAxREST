using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chelab.AxREST.ServiceModel;
using ServiceStack.ServiceInterface;
using Chelab.AxREST.Interfaces;
using ServiceStack.Common;

namespace Chelab.AxREST.ServiceInterface
{
    public class ResultService : RestServiceBase<Result>
    {
        public IResultRepository ResultRepository { get; set; }

        public override object OnGet(Result request)
        {
            if (!request.ResultId.IsNullOrEmpty())
            {
                var res = ResultRepository.getResult(request.SampleId, request.ResultId, request.RsltRepetition);
                return new ResultResponse { Result = res };
            }

            var response = new ResultResponse { Results = ResultRepository.getResults(request.SampleId) };
            return response;
        }

        public override object OnPost(Result request)
        {
            return new ResultResponse();
        }

        public override object OnPut(Result request)
        {
            //Enter a result for the sample measurement and write it into AX
            //some code here...

            return new ResultResponse();
        }

        public override object OnDelete(Result request)
        {
            return new ResultResponse();
        }
    }
}
