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
    using System.Linq;
    using Nancy;
    using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of TestResultsViewsModule.
    /// </summary>
    public class TestResultsViewsModule : NancyModule
    {
        public TestResultsViewsModule() : base(UrnList.TestResultsViews_Root)
        {
            // Get[UrnList.TestResultsViews_OverviewPage] = parameters => View[UrnList.TestResultsViews_OverviewPageName, TestData.TestSuites];
            Get[UrnList.TestResultsViews_OverviewPage] = parameters => {
                var data = TestData.TestSuites.Select(suite => suite.TestScenarios.Select(scenario => { return new[] { scenario.Id, scenario.Name, scenario.Status, scenario.SuiteId}; }));
                return View[UrnList.TestResultsViews_OverviewPageName, data];
            };
        }
    }
}
