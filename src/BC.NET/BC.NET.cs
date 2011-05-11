using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Web.Services.Protocols;
using System.Xml;
using Microsoft.Dynamics.BusinessConnectorNet;
using ServiceStack.Configuration;

namespace BC.NET
{
    public class AxConfig
    {
        public AxConfig() { }

        public AxConfig(IResourceManager appConfig)
        {
            Ax_UserName = appConfig.GetString("Ax_UserName");
            Ax_UserDomain = appConfig.GetString("Ax_UserDomain");
            Ax_Company = appConfig.GetString("Ax_Company");
            Ax_Configuration = appConfig.GetString("Ax_Configuration");
            Ax_ProxyUserName = appConfig.GetString("Ax_ProxyUserName");
            Ax_ProxyUserPassword = appConfig.GetString("Ax_ProxyUserPassword");
            Ax_ProxyUserDomain = appConfig.GetString("Ax_ProxyUserDomain");
        }
        public string Ax_UserName { get; private set; }
        public string Ax_UserDomain { get; private set; }
        public string Ax_Company { get; private set; }
        public string Ax_Configuration { get; private set; }
        public string Ax_ProxyUserName { get; private set; }
        public string Ax_ProxyUserPassword { get; private set; }
        public string Ax_ProxyUserDomain { get; private set; }
    }

    public class DAX2009ConnectorServer
    {

        #region Private
        private Axapta _Axapta = new Axapta();
        private IIdentity _userIdentity = null;
        private AxConfig _AxConfig = new AxConfig(new ConfigurationResourceManager());
        #endregion

        /// <summary>
        /// Queries Ax
        /// </summary>
        /// <param name="className">Class name</param>
        /// <param name="methodName">Method name</param>
        /// <param name="paramList">Parameter list</param>
        /// <returns></returns>
        public Byte[] GetAxData(string className, string methodName, params object[] paramList)
        {
            try
            {
                this.AxLoginAs();
                AxaptaObject axObj = _Axapta.CreateAxaptaObject(className);
                string ret = (string)this.callMethod(className, methodName, paramList);

                Byte[] buf = Encoding.UTF8.GetBytes(ret);

                MemoryStream ms = new MemoryStream();
                System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress);
                zip.Write(buf, 0, buf.Length);
                zip.Close();
                ms.Close();
                axObj.Dispose();

                return ms.GetBuffer();
            }
            catch (Microsoft.Dynamics.AxaptaException ex)
            {
                this.WriteErrorToEventLog(ex);
                SoapException se = new SoapException(ex.Message, SoapException.ServerFaultCode, ex.InnerException);
                throw se;
            }
            catch (Exception ex)
            {
                this.WriteErrorToEventLog(ex);
                SoapException se = new SoapException(ex.Message, SoapException.ClientFaultCode, ex.InnerException);
                throw se;
            }
            finally
            {
                this.AxLogoff();
            }
        }

        /// <summary>
        /// Creates the XML schema
        /// </summary>
        /// <param name="className">Class name</param>
        /// <param name="methodName">Method name</param>
        /// <param name="paramList">Parameters list</param>
        /// <returns></returns>
        public Byte[] GetAxDataCreateSchema(string className, string methodName, params object[] paramList)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                //this.AxLogin();
                this.AxLoginAs();
                AxaptaObject axObj = _Axapta.CreateAxaptaObject(className);
                string ret = (string)this.callMethod(className, methodName, paramList);

                //convert string into XML document
                xmlDoc.LoadXml(ret);

                //create XML data reader to populate dataset
                XmlNodeReader xmlReader = new XmlNodeReader(xmlDoc.DocumentElement);
                System.Data.DataSet ds = new System.Data.DataSet();

                //load dataset with XML data (load schema)
                ds.ReadXml(xmlReader, System.Data.XmlReadMode.InferSchema);

                //GZIP compress dataset with schema. Return byte array
                MemoryStream ms = new MemoryStream();
                System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress);
                ds.WriteXml(zip, System.Data.XmlWriteMode.WriteSchema);
                zip.Close();
                ms.Close();
                axObj.Dispose();

                return ms.GetBuffer();
            }
            catch (Microsoft.Dynamics.AxaptaException ex)
            {
                this.WriteErrorToEventLog(ex);
                SoapException se = new SoapException(ex.Message, SoapException.ServerFaultCode, ex.InnerException);
                throw se;
            }
            catch (Exception ex)
            {
                this.WriteErrorToEventLog(ex);
                SoapException se = new SoapException(ex.Message, SoapException.ClientFaultCode, ex.InnerException);
                throw se;
            }
            finally
            {
                this.AxLogoff();
            }
        }

        /// <summary>
        /// Calls an AX method
        /// </summary>
        /// <param name="className">Class name</param>
        /// <param name="methodName">Method name</param>
        /// <param name="paramList">Parameters list</param>
        /// <returns></returns>
        public Object CallAxMethod(string className, string methodName, params object[] paramList)
        {
            try
            {
                this.AxLoginAs();
                return this.callMethod(className, methodName, paramList);
            }
            catch (Microsoft.Dynamics.AxaptaException ex)
            {
                this.WriteErrorToEventLog(ex);
                SoapException se = new SoapException(ex.Message, SoapException.ServerFaultCode, ex.InnerException);
                throw se;
            }
            catch (Exception ex)
            {
                this.WriteErrorToEventLog(ex);
                SoapException se = new SoapException(ex.Message, SoapException.ClientFaultCode, ex.InnerException);
                throw se;
            }
            finally
            {
                this.AxLogoff();
            }
        }

        /// <summary>
        /// Calls an AX method
        /// </summary>
        /// <param name="className">Class name</param>
        /// <param name="methodName">Method name</param>
        /// <param name="paramList">Parameters list</param>
        /// <returns></returns>
        private Object callMethod(string className, string methodName, params object[] paramList)
        {
            AxaptaObject axObj = _Axapta.CreateAxaptaObject(className);
            Object ret = null;
            if (paramList != null)
                ret = axObj.Call(methodName, paramList);
            else
                ret = axObj.Call(methodName);

            axObj.Dispose();

            return ret;
        }

        /// <summary>
        /// Login to AX using current User Identity
        /// </summary>
        private void AxLogin()
        {
            string[] array = _userIdentity.Name.Split(new char[] { '\\' });
            _Axapta.LogonAs(array[1], array[0], null, _AxConfig.Ax_Company, "", "", _AxConfig.Ax_Configuration);

#if DEBUG
            _Axapta.Refresh();
#endif

        }

        /// <summary>
        /// Login to AX using credentials specified in the web.config
        /// </summary>
        private void AxLoginAs()
        {
            NetworkCredential nc = new NetworkCredential(_AxConfig.Ax_ProxyUserName, _AxConfig.Ax_ProxyUserPassword, _AxConfig.Ax_ProxyUserDomain);

            _Axapta.LogonAs(_AxConfig.Ax_UserName, _AxConfig.Ax_UserDomain, nc, _AxConfig.Ax_Company, "", "", _AxConfig.Ax_Configuration);

#if DEBUG
            _Axapta.Refresh();
#endif
        }

        /// <summary>
        /// Writes to Windows Event Log
        /// </summary>
        /// <param name="ex"></param>
        private void WriteErrorToEventLog(Exception ex)
        {
            EventLog eventLog = new EventLog();
            eventLog.Log = "Application";
            eventLog.Source = "BC.NET";
            StringBuilder msg = new StringBuilder();
            msg.AppendLine("Message: " + ex.Message);
            msg.AppendLine("Source: " + ex.Source);
            msg.AppendLine("Stack Trace: " + ex.StackTrace);
            eventLog.WriteEntry(msg.ToString(), EventLogEntryType.Error);
            eventLog.Close();
        }

        /// <summary>
        /// Closes AX connection
        /// </summary>
        private void AxLogoff()
        {
            _Axapta.Logoff();
        }
    }
}
