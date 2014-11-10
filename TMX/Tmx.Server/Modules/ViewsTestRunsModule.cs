/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/27/2014
 * Time: 8:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.Dynamic;
    using Nancy;
    using Nancy.ModelBinding;
    using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of ViewsTestRunsModule.
    /// </summary>
    public class ViewsTestRunsModule : NancyModule
    {
        public ViewsTestRunsModule() : base(UrnList.ViewTestRuns_Root)
        {
            Get[UrnList.ViewTestRuns_NewTestRunPage] = _ => {
                dynamic data = new ExpandoObject();
                data.Workflows = WorkflowCollection.Workflows;
                data.TestLabs = TestLabCollection.TestLabs;
                return View[UrnList.ViewTestRuns_NewTestRunPageName, data];
            };
        }
    }
}
