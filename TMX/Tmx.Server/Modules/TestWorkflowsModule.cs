/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/9/2014
 * Time: 3:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.Linq;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of TestWorkflowsModule.
    /// </summary>
    public class TestWorkflowsModule : NancyModule
    {
        public TestWorkflowsModule() : base(UrlList.TestWorkflows_Root)
        {
            Get[UrlList.TestWorkflows_GetByWorkflowId_relPath] = parameters => returnWorkflowById(parameters.id);
            Get[UrlList.TestWorkflows_All_relPath] = _ => returnAllWorkflows();
            Delete[UrlList.TestWorkflows_GetByWorkflowId_relPath] = parameters => deleteWorkflowById(parameters.id);
        }
        
        Negotiator returnWorkflowById(Guid workflowId)
        {
            if (WorkflowCollection.Workflows.All(wfl => wfl.Id != workflowId))
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed);
            var workflow = WorkflowCollection.Workflows.First(wfl => wfl.Id == workflowId);
            return Negotiate.WithModel(workflow).WithStatusCode(HttpStatusCode.OK);
        }
        
        Negotiator returnAllWorkflows()
        {
            if (null == WorkflowCollection.Workflows || !WorkflowCollection.Workflows.Any())
                return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
            return Negotiate.WithModel(WorkflowCollection.Workflows).WithStatusCode(HttpStatusCode.OK);
        }
        
        Negotiator deleteWorkflowById(Guid workflowId)
        {
            if (WorkflowCollection.Workflows.All(wfl => wfl.Id != workflowId))
                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            WorkflowCollection.Workflows.RemoveAll(wfl => wfl.Id == workflowId);
            return Negotiate.WithStatusCode(HttpStatusCode.OK);
        }
    }
}
