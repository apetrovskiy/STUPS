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
        public ViewsTestResultsModule() : base(UrnList.TestResultsViews_Root)
        {
            Get[UrnList.TestResultsViews_OverviewPage] = parameters => {
                var data = TestData.TestSuites.SelectMany(suite => { return suite.TestScenarios; });
                return View[UrnList.TestResultsViews_OverviewPageName, data];
            };
            
            Get[UrnList.TestResultsViews_OverviewNewPage] = parameters => {
                // var data = TestData.TestSuites.SelectMany(suite => { return suite.TestScenarios; });
                // var data = new TestData();
//                var data = new ContainerForTests();
//                data.TestSuites = TestData.TestSuites;
//                return View[UrnList.TestResultsViews_OverviewNewPageName, data];
                dynamic data = new ExpandoObject();
                data.TestSuites = TestData.TestSuites;
                data.Tasks = TaskPool.TasksForClients;
                return View[UrnList.TestResultsViews_OverviewNewPageName, data];
            };
        }
    }
}
