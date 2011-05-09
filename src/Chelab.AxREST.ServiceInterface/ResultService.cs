using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chelab.AxREST.ServiceModel;
using ServiceStack.ServiceInterface;
using ChelabAxREST.Interfaces;
using ServiceStack.Common;

namespace Chelab.AxREST.ServiceInterface
{
    public class ResultService : RestServiceBase<Result>
    {
        public IResultRepository ResultRepository { get; set; }

        public override object OnGet(Result request)
        {
            if (!request.ResultRecId.IsNullOrEmpty())
            {
                var res = ResultRepository.getResult(request.ResultRecId);
                return new ResultResponse { Result = res };
            }

            var response = new ResultResponse { Results = ResultRepository.getAllResults(request.SampleRecId) };
            return response;
        }

        public override object OnPost(Result address)
        {
            return new ResultResponse();
        }

        public override object OnPut(Result address)
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
