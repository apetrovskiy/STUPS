/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/8/2014
 * Time: 9:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Logic.ObjectModel.Objects
{
    using System.Collections.Generic;
    using System.Linq;
    using Tmx.Interfaces.Remoting;

    /// <summary>
    /// Description of WorkflowCollection.
    /// </summary>
    public class WorkflowCollection
    {
        public static List<ITestWorkflow> Workflows = new List<ITestWorkflow>();
        
        public static void AddWorkflow(ITestWorkflow workflow)
        {
            Workflows.Add(workflow);
        }
        
        public static void MergeWorkflow(ITestWorkflow workflow)
        {
            // Workflows.Add(workflow);
            var existingWorkflow = Workflows.First(wfl => wfl.Name == workflow.Name && wfl.Path == workflow.Path);
            existingWorkflow.DefaultData = workflow.DefaultData;
            existingWorkflow.Description = workflow.Description;
            // existingWorkflow.Id = workflow.Id;
            // existingWorkflow.IsDefault = 
            existingWorkflow.ParametersPageName = workflow.ParametersPageName;
            // existingWorkflow.TestLabId
            
            TaskPool.Tasks.RemoveAll(task => task.WorkflowId == existingWorkflow.Id);
        }
    }
}
