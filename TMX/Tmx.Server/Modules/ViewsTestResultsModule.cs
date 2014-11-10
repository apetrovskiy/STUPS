/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2014
 * Time: 8:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.Dynamic;
    using System.Linq;
    using Nancy;
    using Tmx.Interfaces;
    using Tmx.Interfaces.Server;
    using Tmx.Interfaces.TestStructure;
    using DotLiquid;
    using DotLiquid.NamingConventions;
    using DotLiquid.Tags.Html;
    using DotLiquid.Util;
    using Nancy.ViewEngines.DotLiquid;
    
//	using System;
//	using System.Linq;
//	using Nancy;
//	using Nancy.ModelBinding;
//	using DotLiquid;
//	using DotLiquid.NamingConventions;
//	using DotLiquid.Tags.Html;
//	using DotLiquid.Util;
    
    /// <summary>
    /// Description of TestResultsViewsModule.
    /// </summary>
    public class ViewsTestResultsModule : NancyModule
    {
        public ViewsTestResultsModule() : base(UrnList.ViewTestResults_Root)
        {
            // deprecated
            Get[UrnList.ViewTestResults_OverviewPage] = parameters => {
                var data = TestData.TestSuites.SelectMany(suite => { return suite.TestScenarios; });
                return View[UrnList.ViewTestResults_OverviewPageName, data];
            };
            
            Get[UrnList.ViewTestResults_OverviewNewPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TestRuns = TestRunQueue.TestRuns;
                data.Tasks = TaskPool.TasksForClients;
                return View[UrnList.ViewTestResults_OverviewNewPageName, data];
            };
            
            Get[UrnList.ViewTestResults_TestRunResultsPage] = parameters => {
                // var data = TestRunQueue.TestRuns.First(testRun => testRun.Id == parameters.id).TestSuites.SelectMany(suite => { return suite.TestScenarios; });
                dynamic data = new ExpandoObject();
                data.TestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == parameters.id);
                return View[UrnList.ViewTestResults_TestRunResultsPageName, data];
            };
        }
    }
}
