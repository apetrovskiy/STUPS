/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/13/2014
 * Time: 2:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.Management.Automation;
    using Nancy;
    using Nancy.ModelBinding;
	using TMX;
	using TMX.Commands;
	using TMX.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultsModule.
    /// </summary>
    public class TestResultsModule : NancyModule
    {
        public TestResultsModule() : base("/Results")
        {
            StaticConfiguration.DisableErrorTraces = false;
            
            Post["/suites/"] = parameters => {
                var testSuite = this.Bind<TestSuite>();
                TmxHelper.NewTestSuite(testSuite.Name, testSuite.Id, testSuite.PlatformId, testSuite.Description, testSuite.BeforeScenario, testSuite.AfterScenario);
                TestData.SetSuiteStatus(true);
				return TmxHelper.OpenTestSuite(testSuite.Name, testSuite.Id, testSuite.PlatformId) ? HttpStatusCode.Created : HttpStatusCode.InternalServerError;
            };
        	
        	Post["/scenarios/"] = parameters => {
        		var testScenario = this.Bind<TestScenario>();
        		var cmdletAdd = new AddScenarioCmdletBase {
        			Name = testScenario.Name,
        			Id = testScenario.Id,
        			TestPlatformId = testScenario.PlatformId,
        			TestSuiteId = testScenario.SuiteId,
        			Description = testScenario.Description
        		};
        		TmxHelper.AddTestScenario(cmdletAdd);
        		TestData.SetScenarioStatus(true);
        		
        		var cmdletOpen = new OpenScenarioCmdletBase {
        			Name = testScenario.Name,
        			Id = testScenario.Id,
        			TestPlatformId = testScenario.PlatformId
        		};
        		return TmxHelper.OpenTestScenario(cmdletOpen) ? HttpStatusCode.Created : HttpStatusCode.InternalServerError;
        	};
        }
    }
}
