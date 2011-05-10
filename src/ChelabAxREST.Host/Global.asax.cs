using System;
using Chelab.AxREST.Interfaces;
using Chelab.AxREST.Logic;
using Chelab.AxREST.ServiceInterface;
using Chelab.AxREST.ServiceModel;
using Funq;
using ServiceStack.WebHost.Endpoints;

namespace Chelab.AxREST.Host
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("Ax ReST Result Entry", typeof(Result).Assembly) { }

        public override void Configure(Container container)
        {
            container.Register<IResultRepository>(new ResultRepository());

            //Register user-defined REST-ful routes         
            Routes
              .Add<Result>("/result/{SampleId}")
              .Add<Result>("/result/{SampleId}/{ResultId}")
              .Add<Result>("/result/{SampleId}/{ResultId}{RsltRepetition}")
              .Add<Sample>("/sample")
              .Add<Sample>("/sample/{SampleId}");
        }
    }

    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
