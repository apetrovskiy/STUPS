/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/26/2014
 * Time: 6:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Runner
{
    using System;
    using System.Net.NetworkInformation;
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
//    using System.Net;
//    using System.Net.NetworkInformation;
//    using Tmx.Client;
//    using Spring.Rest.Client;
    
    class Program
    {
        public static void Main(string[] args)
        {
            
            // var testSuite = new TestSuite { Id = "1", Name = "s01" };
            // var testScenario = new TestScenario { Id = "1", Name = "sc01", TestResults = { new TestResult { Id = "1", Name = "ddd" }, new TestResult { Id = "2", Name = "eeee", Origin = TestResultOrigins.Logical } } };
            // testSuite.TestScenarios.Add(testScenario);
            // TestData.TestSuites.Add(testSuite);
            // TestData.TestSuites.Add(new TestSuite { Id = "1", Name = "s01" });
            // TestData.CurrentTestSuite.TestScenarios.Add(new TestScenario { Id = "1", Name = "sc01", TestResults = { new TestResult { Id = "1", Name = "ddd" }, new TestResult { Id = "2", Name = "eeee", Origin = TestResultOrigins.Logical } } });
            // TestData.CurrentTestSuite.TestScenarios.Add(new TestScenario { Id = "1", Name = "sc01" });
            // TestData.TestSuites[0].TestScenarios.Add(new TestScenario { Id = "1", Name = "sc01" });
            // TestData.CurrentTestScenario.TestResults.Add(new TestResult { Id = "1", Name = "ddd" });
            // TestData.CurrentTestScenario.TestResults.Add(new TestResult { Id = "2", Name = "eeee", Origin = TestResultOrigins.Logical });
//            TmxHelper.NewTestSuite("s01", "1", (new TestPlatform { Id = "1", Name = "pl" }).Id, "aaaa", null, null);
//            var scenario = new AddScenarioCmdletBaseDataObject();
//            scenario.Id = "1";
//            scenario.Name = "sc01";
//            TmxHelper.AddTestScenario(scenario);
//            TmxHelper.CloseTestResult("tr 01", "1", true, false, null, null, "aaaaaa", TestResultOrigins.Logical, true);
//            
//            foreach (var suite in TestData.TestSuites) {
//                Console.WriteLine("suite Id=" + suite.Id + ", Name=" + suite.Name);
//                if (null != suite.TestScenarios)
//                    foreach (var sc in suite.TestScenarios) {
//                        Console.WriteLine("scenario Id=" + sc.Id + ", Name=" + sc.Name);
//                        if (null != sc.TestResults)
//                            foreach (var result in sc.TestResults) {
//                                Console.WriteLine("result Id=" + result.Id + ", Name=" + result.Name);
//                            }
//                    }
//            }
            
            ServerControl.Start(@"http://localhost:" + 12340);
            
            Console.Write("Press any key to stop server . . . ");
            Console.ReadKey(true);
            ServerControl.Stop();
        }
    }
}