using System;
using System.Web;
using Castle.Facilities.WcfIntegration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace CastleWindsor_AOP_WCF
{
    public class Global : HttpApplication
    {
        public IWindsorContainer Container { get; private set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            //Todo Can be use fluently registration
            //Todo Wcf message buffer size and service timeout settings
            Container =
                new WindsorContainer().AddFacility<WcfFacility>().Install(Configuration.FromXmlFile("Windsor.config"));
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
            if (Container != null)
            {
                Container.Dispose();
            }
        }
    }
}