/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/8/2014
 * Time: 9:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of WorkflowCollection.
    /// </summary>
    public class WorkflowCollection
    {
        public static List<ITestWorkflow> Workflows = new List<ITestWorkflow>();
        // public static IWorkflow ActiveWorkflow { get; set; }
        // static ITestWorkflow _activeWorkflow;
//        public static ITestWorkflow ActiveWorkflow {
//            get { return _activeWorkflow; }
////            set {
////                _activeWorkflow = value;
//////                ClientsCollection.Clients.Where(client => WorkflowCollection.Workflows.All(wfl => wfl.Id != client.WorkflowId)).ToList().ForEach(client => client.WorkflowId = _activeWorkflow.Id);
//////                TaskPool.TasksForClients.Where(task => TaskPool.TasksForClients.All(t => t.WorkflowId != 
////            }
//        }
//        
//        public static void SetActiveWorkflow(ITestWorkflow workflow)
//        {
//            _activeWorkflow = workflow;
//        }
        
        public static void AddWorkflow(ITestWorkflow workflow)
        {
//            if (!Workflows.Any())
//                // _activeWorkflow = workflow;
//                SetActiveWorkflow(workflow);
//            else
//                if (!Workflows.HasActiveWorkflow())
//                    // _activeWorkflow = Workflows.FirstInRow();
//                    SetActiveWorkflow(Workflows.FirstInRow());
//            Workflows.Add(workflow);
//            
//            var wfl = GetActiveWorkflow();
//            if (null == wfl) workflow.IsActive = true;
            Workflows.Add(workflow);
        }
//        
//        public static ITestWorkflow GetActiveWorkflow()
//        {
//            return !Workflows.Any() ? null : !Workflows.HasActiveWorkflow() ? null : Workflows.First(wfl => wfl.IsActive());
//        }
    }
}
