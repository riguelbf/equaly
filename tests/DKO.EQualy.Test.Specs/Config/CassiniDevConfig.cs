using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using CassiniDev;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Config
{
    [Binding]
    public class CassiniDevConfig
    {
        private static CassiniDev.CassiniDevServer _server;
        public static int ServerPort { get; private set; }
         
        [BeforeTestRun]
        public static void BeforeScenario()
        {
            _server = new CassiniDevServer();
            _server.StartServer(VirtualPathUtility.ToAbsolute("/EQualy/"));
            ServerPort = _server.Port();
        }

        [AfterTestRun]
        public static void AfterScenario()
        {
            _server.StopServer();
        }
    }

    internal static class CassiniDevExtension
    {
        public static int Port(this CassiniDevServer server)
        {
            var match = Regex.Match(server.RootUrl, @":(?<porta>\d+)\/?");
            return match.Success ? 0 : int.Parse(match.Groups["porta"].Value);
            return 1;
        }
    }
}
