using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface.ServiceModel;
using System.ComponentModel;

namespace Chelab.AxREST.ServiceModel
{
    public class Result
    {
        #region string
        public string SampleId { get; set; }
        public string ResultId { get; set; }
        public string Description { get; set; }
        public string RDPDescription { get; set; }
        public string DescriptionId { get; set; }
        public string ConfigId { get; set; }
        public string PSMAlias { get; set; }
        public string OutputValue { get; set; }
        public string SetId { get; set; }
        #endregion

        #region double
        public double RealInputValue { get; set; }
        public double MatchingValue { get; set; }
        public double ConvFactor { get; set; }
        public double Recovery { get; set; }
        public double UncertConstPar { get; set; }
        public double UncertPropPar { get; set; }
        public double DetectionLimit { get; set; }
        public double FixedRounding { get; set; }
        public double UncertUpperValue { get; set; }
        public double UncertLowerValue { get; set; }
        public double VariantCertificationLimit { get; set; }
        public double VariantFixedRounding { get; set; }
        public double VariantUncertConstParam { get; set; }
        public double QuantitationLimit { get; set; }
        public double VariantDetectionLimit { get; set; }
        public double VariantRecovery { get; set; }
        public double VariantUncertPropParam { get; set; }
        public double MatchingUncertUpperValue { get; set; }
        public double MatchingUncertLowerValue { get; set; }
        public double WorkRangeLow { get; set; }
        public double WorkRangeUp { get; set; } 
        #endregion

        #region int
        public int CompletionLevel { get; set; }
        public int ApprovalLevel { get; set; }
        public int FixedRoundingType { get; set; }
        public int VariantFixedRoundingType { get; set; }
        private Int32 _RsltRepetition = 1;
        [DefaultValue(true)]
        public Int32 RsltRepetition
        {
            get { return _RsltRepetition; }
            set { _RsltRepetition = value; }
        } 
        #endregion
    }

    public class ResultResponse : IHasResponseStatus
    {
        public ResultResponse()
        {
            this.Results = new List<Result>();
            this.ResponseStatus = new ResponseStatus();
        }

        public Result Result { get; set; }

        public List<Result> Results { get; set; }

        public ResponseStatus ResponseStatus { get; set; } //Exceptions get injected here
    }
}
