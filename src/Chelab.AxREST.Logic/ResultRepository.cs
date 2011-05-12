using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chelab.AxREST.Interfaces;
using Chelab.AxREST.ServiceModel;
using BC.NET;
using Microsoft.Dynamics.BusinessConnectorNet;
using ServiceStack.Common;

namespace Chelab.AxREST.Logic
{
    public class ResultRepository : IResultRepository
    {
        private DAX2009ConnectorServer dax = new DAX2009ConnectorServer();

        #region string
        private string _className = "LabX_BCNET";
        private string _getResultAxMethodName = "getResult";
        private string _getResultsAxMethodName = "getResults";

        private string _SampleId { get; set; }
        private string _ResultId { get; set; }
        private string _Description { get; set; }
        private string _RDPDescription { get; set; }
        private string _DescriptionId { get; set; }
        private string _ConfigId { get; set; }
        private string _PSMAlias { get; set; }
        private string _OutputValue { get; set; }
        private string _SetId { get; set; }
        #endregion

        #region double
        private double _RealInputValue { get; set; }
        private double _MatchingValue { get; set; }
        private double _ConvFactor { get; set; }
        private double _Recovery { get; set; }
        private double _UncertConstPar { get; set; }
        private double _UncertPropPar { get; set; }
        private double _DetectionLimit { get; set; }
        private double _FixedRounding { get; set; }
        private double _UncertUpperValue { get; set; }
        private double _UncertLowerValue { get; set; }
        private double _VariantCertificationLimit { get; set; }
        private double _VariantFixedRounding { get; set; }
        private double _VariantUncertConstParam { get; set; }
        private double _QuantitationLimit { get; set; }
        private double _VariantDetectionLimit { get; set; }
        private double _VariantRecovery { get; set; }
        private double _VariantUncertPropParam { get; set; }
        private double _MatchingUncertUpperValue { get; set; }
        private double _MatchingUncertLowerValue { get; set; }
        private double _WorkRangeLow { get; set; }
        private double _WorkRangeUp { get; set; }
        #endregion

        #region int
        private int _CompletionLevel { get; set; }
        private int _ApprovalLevel { get; set; }
        private int _FixedRoundingType { get; set; }
        private int _VariantFixedRoundingType { get; set; }
        private int _RsltRepetition;
        #endregion

        public List<Result> getResults(string sampleId)
        {
            List<Result> results = new List<Result>();
            dax.AxLoginAs();

            AxaptaRecord ResultTable = (AxaptaRecord)dax.CallAxMethod(_className, _getResultsAxMethodName, sampleId);
            if (ResultTable.Found)
                while (ResultTable.Next())
                {
                    #region string
                    _SampleId = (String)ResultTable.get_Field("SampleId");
                    _ResultId = (String)ResultTable.get_Field("ResultId");
                    _Description = (String)ResultTable.get_Field("Description");
                    _RDPDescription = (String)ResultTable.get_Field("RDPDescription");
                    _DescriptionId = (String)ResultTable.get_Field("DescriptionId");
                    _ConfigId = (String)ResultTable.get_Field("ConfigId");
                    _PSMAlias = (String)ResultTable.get_Field("PSMAlias");
                    _OutputValue = (String)ResultTable.get_Field("OutputValue");
                    _SetId = (String)ResultTable.get_Field("SetId");
                    #endregion

                    #region double
                    _RealInputValue = (Double)ResultTable.get_Field("RealInputValue");
                    _MatchingValue = (Double)ResultTable.get_Field("MatchingValue");
                    _ConvFactor = (Double)ResultTable.get_Field("ConvFactor");
                    _Recovery = (Double)ResultTable.get_Field("Recovery");
                    _UncertConstPar = (Double)ResultTable.get_Field("UncertConstPar");
                    _UncertPropPar = (Double)ResultTable.get_Field("UncertPropPar");
                    _DetectionLimit = (Double)ResultTable.get_Field("DetectionLimit");
                    _FixedRounding = (Double)ResultTable.get_Field("FixedRounding");
                    _UncertUpperValue = (Double)ResultTable.get_Field("UncertUpperValue");
                    _UncertLowerValue = (Double)ResultTable.get_Field("UncertLowerValue");
                    _VariantCertificationLimit = (Double)ResultTable.get_Field("VariantCertificationLimit");
                    _VariantFixedRounding = (Double)ResultTable.get_Field("VariantFixedRounding");
                    _VariantUncertConstParam = (Double)ResultTable.get_Field("VariantUncertConstParam");
                    _QuantitationLimit = (Double)ResultTable.get_Field("QuantitationLimit");
                    _VariantDetectionLimit = (Double)ResultTable.get_Field("VariantDetectionLimit");
                    _VariantRecovery = (Double)ResultTable.get_Field("VariantRecovery");
                    _VariantUncertPropParam = (Double)ResultTable.get_Field("VariantUncertPropParam");
                    _MatchingUncertUpperValue = (Double)ResultTable.get_Field("MatchingUncertUpperValue");
                    _MatchingUncertLowerValue = (Double)ResultTable.get_Field("MatchingUncertLowerValue");
                    _WorkRangeLow = (Double)ResultTable.get_Field("WorkRangeLow");
                    _WorkRangeUp = (Double)ResultTable.get_Field("WorkRangeUp");
                    #endregion

                    #region int
                    _CompletionLevel = (Int32)ResultTable.get_Field("CompletionLevel");
                    _ApprovalLevel = (Int32)ResultTable.get_Field("ApprovalLevel");
                    _FixedRoundingType = (Int32)ResultTable.get_Field("FixedRoundingType");
                    _VariantFixedRoundingType = (Int32)ResultTable.get_Field("VariantFixedRoundingType");
                    _RsltRepetition = (Int32)ResultTable.get_Field("RsltRepetition");
                    #endregion

                    Result r = new Result
                    {
                        ApprovalLevel = _ApprovalLevel,
                        CompletionLevel = _CompletionLevel,
                        ConfigId = _ConfigId,
                        ConvFactor = _ConvFactor,
                        Description = _Description,
                        DescriptionId = _DescriptionId,
                        DetectionLimit = _DetectionLimit,
                        FixedRounding = _FixedRounding,
                        FixedRoundingType = _FixedRoundingType,
                        MatchingUncertLowerValue = _MatchingUncertLowerValue,
                        MatchingUncertUpperValue = _MatchingUncertUpperValue,
                        MatchingValue = _MatchingValue,
                        OutputValue = _OutputValue,
                        PSMAlias = _PSMAlias,
                        QuantitationLimit = _QuantitationLimit,
                        RDPDescription = _RDPDescription,
                        RealInputValue = _RealInputValue,
                        Recovery = _Recovery,
                        ResultId = _ResultId,
                        RsltRepetition = _RsltRepetition,
                        SampleId = _SampleId,
                        SetId = _SetId,
                        UncertConstPar = _UncertConstPar,
                        UncertLowerValue = _UncertLowerValue,
                        UncertPropPar = _UncertPropPar,
                        UncertUpperValue = _UncertUpperValue,
                        VariantCertificationLimit = _VariantCertificationLimit,
                        VariantDetectionLimit = _VariantDetectionLimit,
                        VariantFixedRounding = _VariantFixedRounding,
                        VariantFixedRoundingType = _VariantFixedRoundingType,
                        VariantRecovery = _VariantRecovery,
                        VariantUncertConstParam = _VariantUncertConstParam,
                        VariantUncertPropParam = _VariantUncertPropParam,
                        WorkRangeLow = _WorkRangeLow,
                        WorkRangeUp = _WorkRangeUp
                    };
                    results.Add(r);
                }

            dax.AxLogoff();
            return results;
        }

        public Result getResult(string SampleId, string ResultId, int RsltRepetition)
        {
            Result r = null;
            dax.AxLoginAs();

            AxaptaRecord ResultTable = (AxaptaRecord)dax.CallAxMethod(_className, _getResultAxMethodName, SampleId, ResultId, RsltRepetition);
            if (ResultTable.Found)
            {
                #region string
                _SampleId = (String)ResultTable.get_Field("SampleId");
                _ResultId = (String)ResultTable.get_Field("ResultId");
                _Description = (String)ResultTable.get_Field("Description");
                _RDPDescription = (String)ResultTable.get_Field("RDPDescription");
                _DescriptionId = (String)ResultTable.get_Field("DescriptionId");
                _ConfigId = (String)ResultTable.get_Field("ConfigId");
                _PSMAlias = (String)ResultTable.get_Field("PSMAlias");
                _OutputValue = (String)ResultTable.get_Field("OutputValue");
                _SetId = (String)ResultTable.get_Field("SetId");
                #endregion

                #region double
                _RealInputValue = (Double)ResultTable.get_Field("RealInputValue");
                _MatchingValue = (Double)ResultTable.get_Field("MatchingValue");
                _ConvFactor = (Double)ResultTable.get_Field("ConvFactor");
                _Recovery = (Double)ResultTable.get_Field("Recovery");
                _UncertConstPar = (Double)ResultTable.get_Field("UncertConstPar");
                _UncertPropPar = (Double)ResultTable.get_Field("UncertPropPar");
                _DetectionLimit = (Double)ResultTable.get_Field("DetectionLimit");
                _FixedRounding = (Double)ResultTable.get_Field("FixedRounding");
                _UncertUpperValue = (Double)ResultTable.get_Field("UncertUpperValue");
                _UncertLowerValue = (Double)ResultTable.get_Field("UncertLowerValue");
                _VariantCertificationLimit = (Double)ResultTable.get_Field("VariantCertificationLimit");
                _VariantFixedRounding = (Double)ResultTable.get_Field("VariantFixedRounding");
                _VariantUncertConstParam = (Double)ResultTable.get_Field("VariantUncertConstParam");
                _QuantitationLimit = (Double)ResultTable.get_Field("QuantitationLimit");
                _VariantDetectionLimit = (Double)ResultTable.get_Field("VariantDetectionLimit");
                _VariantRecovery = (Double)ResultTable.get_Field("VariantRecovery");
                _VariantUncertPropParam = (Double)ResultTable.get_Field("VariantUncertPropParam");
                _MatchingUncertUpperValue = (Double)ResultTable.get_Field("MatchingUncertUpperValue");
                _MatchingUncertLowerValue = (Double)ResultTable.get_Field("MatchingUncertLowerValue");
                _WorkRangeLow = (Double)ResultTable.get_Field("WorkRangeLow");
                _WorkRangeUp = (Double)ResultTable.get_Field("WorkRangeUp");
                #endregion

                #region int
                _CompletionLevel = (Int32)ResultTable.get_Field("CompletionLevel");
                _ApprovalLevel = (Int32)ResultTable.get_Field("ApprovalLevel");
                _FixedRoundingType = (Int32)ResultTable.get_Field("FixedRoundingType");
                _VariantFixedRoundingType = (Int32)ResultTable.get_Field("VariantFixedRoundingType");
                _RsltRepetition = (Int32)ResultTable.get_Field("RsltRepetition");
                #endregion

                r.ApprovalLevel = _ApprovalLevel;
                r.CompletionLevel = _CompletionLevel;
                r.ConfigId = _ConfigId;
                r.ConvFactor = _ConvFactor;
                r.Description = _Description;
                r.DescriptionId = _DescriptionId;
                r.DetectionLimit = _DetectionLimit;
                r.FixedRounding = _FixedRounding;
                r.FixedRoundingType = _FixedRoundingType;
                r.MatchingUncertLowerValue = _MatchingUncertLowerValue;
                r.MatchingUncertUpperValue = _MatchingUncertUpperValue;
                r.MatchingValue = _MatchingValue;
                r.OutputValue = _OutputValue;
                r.PSMAlias = _PSMAlias;
                r.QuantitationLimit = _QuantitationLimit;
                r.RDPDescription = _RDPDescription;
                r.RealInputValue = _RealInputValue;
                r.Recovery = _Recovery;
                r.ResultId = _ResultId;
                r.RsltRepetition = _RsltRepetition;
                r.SampleId = _SampleId;
                r.SetId = _SetId;
                r.UncertConstPar = _UncertConstPar;
                r.UncertLowerValue = _UncertLowerValue;
                r.UncertPropPar = _UncertPropPar;
                r.UncertUpperValue = _UncertUpperValue;
                r.VariantCertificationLimit = _VariantCertificationLimit;
                r.VariantDetectionLimit = _VariantDetectionLimit;
                r.VariantFixedRounding = _VariantFixedRounding;
                r.VariantFixedRoundingType = _VariantFixedRoundingType;
                r.VariantRecovery = _VariantRecovery;
                r.VariantUncertConstParam = _VariantUncertConstParam;
                r.VariantUncertPropParam = _VariantUncertPropParam;
                r.WorkRangeLow = _WorkRangeLow;
                r.WorkRangeUp = _WorkRangeUp;
            }
            dax.AxLogoff();
            return r;
        }
    }
}
