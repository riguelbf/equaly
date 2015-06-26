using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using Coypu;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Config
{
    [Binding]
    public class  StepBase
    {
        protected BrowserSession BrowserSession;
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            //BrowserSession browserActual;
            //if (ScenarioContext.Current.TryGetValue<BrowserSession>(out browserActual))
            //{
            //    BrowserSession = browserActual;
            //    return;
            //}

            //var config = new SessionConfiguration
            //{
            //    Port = CassiniDevConfig.ServerPort,
            //    AppHost = "localhost",
            //    Timeout = TimeSpan.FromSeconds(5),
            //    RetryInterval = TimeSpan.FromSeconds(0.1),
            //};

            //BrowserSession = new BrowserSession(config);
            //ScenarioContext.Current.Set<BrowserSession>(BrowserSession);
        }

        [AfterScenario]
        public void AfterScenario()
        {
           // BrowserSession.Dispose();
        }
    }
}
