/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/13/2014
 * Time: 2:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Nancy;
    using Nancy.ModelBinding;
	using TMX.Interfaces;
	using Tmx;
	// using Tmx.Core;
	using Tmx.Interfaces;
	using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultsModule.
    /// </summary>
    public class TestResultsModule : NancyModule
    {
        public TestResultsModule() : base(UrnList.TestStructure_Root)
        {
            StaticConfiguration.DisableErrorTraces = false;
            
            Post[UrnList.TestStructure_Suites] = parameters => {
                var testSuite = this.Bind<TestSuite>();
                TmxHelper.NewTestSuite(testSuite.Name, testSuite.Id, testSuite.PlatformId, testSuite.Description, testSuite.BeforeScenario, testSuite.AfterScenario);
                TestData.SetSuiteStatus(true);
				return TmxHelper.OpenTestSuite(testSuite.Name, testSuite.Id, testSuite.PlatformId) ? HttpStatusCode.Created : HttpStatusCode.InternalServerError;
            };
        	
        	Post[UrnList.TestStructure_Scenarios] = parameters => {
Console.WriteLine("Post[UrnList.TestStructure_Scenarios] 00001");
                // var testScenario = this.Bind<TestScenario>();
                var testScenario = this.Bind<TestScenario>("DbId", "TestResults", "Timestamp", "BeforeTest", "AfterTest", "BeforeTestParameters", "AfterTestParameters", "TestCases", "TimeSpent", "Statistics", "enStatus");
Console.WriteLine("Post[UrnList.TestStructure_Scenarios] 00002");
//ITestScenario testScenario = null;
//try {
//        		testScenario = this.Bind<TestScenario>("DbId", "TestResults", "Timestamp", "BeforeTest", "AfterTest", "BeforeTestParameters", "AfterTestParameters", "TestCases", "TimeSpent", "Statistics", "enStatus");
//        		
////        		        int DbId { get; set; }
////        string Name { get; }
////        string Id { get; }
////        List<ITestResult> TestResults { get; }
////        string Description { get; set; }
////        string Status { get; }
////        
////        string SuiteId { get; }
////        // 20130301
////        // 20140720
////        // DateTime Timestamp { get; }
////        DateTime Timestamp { get; set; }
////        void SetNow();
////        
////        //List<string> Tags { get; set; }
////        string Tags { get; set; }
////        //List<string> PlatformIds { get; set; }
////        string PlatformId { get; set; }
////        
////        // 20130615
////        ScriptBlock[] BeforeTest { get; set; }
////        ScriptBlock[] AfterTest { get; set; }
////        //ScriptBlock[] AlternateBeforeScenario { get; set; }
////        //ScriptBlock[] AlternateAfterScenario { get; set; }
////        object[] BeforeTestParameters { get; set; }
////        object[] AfterTestParameters { get; set; }
////        List<ITestCase> TestCases { get; set; }
////        
////        // 20140720
////        double TimeSpent { get; set; }
////        void SetTimeSpent(double timeSpent);
////        TestStat Statistics { get; set; }
////        TestScenarioStatuses enStatus { get; set; }
//}
//catch (Exception eeee) {
//	Console.WriteLine(eeee.Message);
//}

Console.WriteLine(testScenario.Name);
Console.WriteLine(testScenario.Id);
Console.WriteLine(testScenario.SuiteId);
Console.WriteLine(testScenario.PlatformId);
Console.WriteLine(TestData.TestPlatforms.First(tp => tp.Name == TestData.DefaultPlatformName).Id);

        		var dataObjectAdd = new AddScenarioCmdletBaseDataObject {
					AfterTest = testScenario.AfterTest,
					BeforeTest = testScenario.BeforeTest,
					Description = testScenario.Description,
					Id = testScenario.Id,
        			Name = testScenario.Name,
        			TestPlatformId = testScenario.PlatformId,
        			TestSuiteId = testScenario.SuiteId
        		};
        		TmxHelper.AddTestScenario(dataObjectAdd);
        		TestData.SetScenarioStatus(true);
        		
        		var dataObjectOpen = new OpenScenarioCmdletBaseDataObject {
        			Name = testScenario.Name,
        			Id = testScenario.Id,
        			TestPlatformId = testScenario.PlatformId
        		};
//        		return TmxHelper.OpenTestScenario(dataObjectOpen) ? HttpStatusCode.Created : HttpStatusCode.InternalServerError;
        		
var result = TmxHelper.OpenTestScenario(dataObjectOpen);
Console.WriteLine(result);
        		return HttpStatusCode.Created;
        	};
            
        	Post[UrnList.TestStructure_Results] = parameters => {
Console.WriteLine("Post[UrnList.TestStructure_Results] 00001");
ITestResult testResult = null;
try {
	testResult = this.Bind<TestResult>(); // "DbId", "TestResults", "Timestamp", "BeforeTest", "AfterTest", "BeforeTestParameters", "AfterTestParameters", "TestCases", "TimeSpent", "Statistics", "enStatus");
        		
}
catch (Exception eeee) {
	Console.WriteLine(eeee.Message);
}

//        		var dataObjectAdd = new AddScenarioCmdletBaseDataObject {
//					AfterTest = testResult.AfterTest,
//					BeforeTest = testResult.BeforeTest,
//					Description = testResult.Description,
//					Id = testResult.Id,
//        			Name = testResult.Name,
//        			TestPlatformId = testResult.PlatformId,
//        			TestSuiteId = testResult.SuiteId
//        		};
//        		TmxHelper.AddTestScenario(dataObjectAdd);
//        		TestData.SetScenarioStatus(true);
//        		
//        		var dataObjectOpen = new OpenScenarioCmdletBaseDataObject {
//        			Name = testResult.Name,
//        			Id = testResult.Id,
//        			TestPlatformId = testResult.PlatformId
//        		};
//        		return TmxHelper.OpenTestScenario(dataObjectOpen) ? HttpStatusCode.Created : HttpStatusCode.InternalServerError;
//        		
//var result = TmxHelper.OpenTestScenario(dataObjectOpen);
//Console.WriteLine(result);
        		return HttpStatusCode.Created;
        	};
        }
    }
}
