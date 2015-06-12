/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/9/2014
 * Time: 3:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.Modules
{
    using System;
    using System.Linq;
    using Logic.ObjectModel.Objects;
    using Nancy;
    using Nancy.Responses.Negotiation;
    using Interfaces.Server;

    /// <summary>
    /// Description of TestWorkflowsModule.
    /// </summary>
    public class TestWorkflowsModule : NancyModule
    {
        public TestWorkflowsModule() : base(UrlList.TestWorkflows_Root)
        {
            Get[UrlList.TestWorkflows_GetByWorkflowId_relPath] = parameters => ReturnWorkflowById(parameters.id);
            Get[UrlList.TestWorkflows_All_relPath] = _ => ReturnAllWorkflows();
            Delete[UrlList.TestWorkflows_GetByWorkflowId_relPath] = parameters => DeleteWorkflowById(parameters.id);
        }
        
        Negotiator ReturnWorkflowById(Guid workflowId)
        {
            if (WorkflowCollection.Workflows.All(wfl => wfl.Id != workflowId))
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed);
            var workflow = WorkflowCollection.Workflows.First(wfl => wfl.Id == workflowId);
            return Negotiate.WithModel(workflow).WithStatusCode(HttpStatusCode.OK);
        }
        
        Negotiator ReturnAllWorkflows()
        {
            if (null == WorkflowCollection.Workflows || !WorkflowCollection.Workflows.Any())
                return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
            return Negotiate.WithModel(WorkflowCollection.Workflows).WithStatusCode(HttpStatusCode.OK);
        }
        
        Negotiator DeleteWorkflowById(Guid workflowId)
        {
            if (WorkflowCollection.Workflows.All(wfl => wfl.Id != workflowId))
                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            WorkflowCollection.Workflows.RemoveAll(wfl => wfl.Id == workflowId);
            return Negotiate.WithStatusCode(HttpStatusCode.OK);
        }
    }
}
