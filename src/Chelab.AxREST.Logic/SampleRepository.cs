using System;
using System.Collections.Generic;
using BC.NET;
using Chelab.AxREST.Interfaces;
using Chelab.AxREST.ServiceModel;
using Microsoft.Dynamics.BusinessConnectorNet;
using ServiceStack.Common;

namespace Chelab.AxREST.Logic
{
    public class SampleRepository : ISampleRepository
    {
        private DAX2009ConnectorServer dax = new DAX2009ConnectorServer();
        private string className = "LabX_BCNET";
        private string getSamplesAxMethodName = "getSamples";
        private string getSampleAxMethodName = "getSample";
        private string sampleIdAxFieldName = "SamplelId";
        private string completionLevelAxFieldName = "CompletionLevel";
        private string approvalLevelAxFieldName = "ApprovalLevel";

        public Sample GetSample(string sampleId)
        {
            Sample s = null;
            dax.AxLoginAs();
            AxaptaRecord SampleTable = (AxaptaRecord)dax.CallAxMethod(className, getSampleAxMethodName, sampleId);

            if (SampleTable.Found)
            {
                string sampleid = (String)SampleTable.get_Field(sampleIdAxFieldName);
                Int32 completionLevel = (Int32)SampleTable.get_Field(completionLevelAxFieldName);
                Int32 approvalLevel = (Int32)SampleTable.get_Field(approvalLevelAxFieldName);
                if (!sampleid.IsNullOrEmpty())
                {
                    s = new Sample
                      {
                          SampleId = sampleid,
                          CompletionLevel = completionLevel,
                          ApprovalLevel = approvalLevel
                      };
                }
            }

            dax.AxLogoff();
            return s;
        }

        public List<Sample> GetAllSamples()
        {
            dax.AxLoginAs();
            AxaptaRecord SampleTable = (AxaptaRecord)dax.CallAxMethod(className, getSamplesAxMethodName, null);

            List<Sample> samples = new List<Sample>();

            if (SampleTable.Found)
                while (SampleTable.Next())
                {
                    string sampleid = (String)SampleTable.get_Field(sampleIdAxFieldName);
                    Int32 completionLevel = (Int32)SampleTable.get_Field(completionLevelAxFieldName);
                    Int32 approvalLevel = (Int32)SampleTable.get_Field(approvalLevelAxFieldName);
                    if (!sampleid.IsNullOrEmpty())
                    {
                        Sample s = new Sample
                        {
                            SampleId = sampleid,
                            CompletionLevel = completionLevel,
                            ApprovalLevel = approvalLevel
                        };
                        samples.Add(s);
                    }

                }

            dax.AxLogoff();
            return samples;
        }
    }
}
