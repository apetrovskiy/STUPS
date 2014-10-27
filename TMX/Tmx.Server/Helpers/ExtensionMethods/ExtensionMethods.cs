/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2014
 * Time: 4:53 PM
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
    /// Description of ExtensionMethods.
    /// </summary>
    public static class ExtensionMethods
    {
//        public static bool IsInProgress(this IWorkflow workflow)
//        {
//            return WorkflowStatuses.WorkflowInProgress == workflow.WorkflowStatus;
//        }
        
        public static bool IsFirstInRow(this IWorkflow workflow)
        {
            return WorkflowCollection.Workflows.Min(wfl => wfl.Id) == workflow.Id;
        }
        
//        public static bool IsActive(this IWorkflow workflow)
//        {
//            return WorkflowCollection.Workflows.Any(IsInProgress) ? workflow.IsInProgress() : workflow.IsFirstInRow();
//        }
        
        public static bool HasActiveWorkflow(this List<IWorkflow> list)
        {
            // return list.Any(IsActive);
//            var activeWorkflow = list.First(IsActive);
//            if (null == activeWorkflow) return false;
//            WorkflowCollection.ActiveWorkflow = activeWorkflow;
            return true;
        }
        
        public static IWorkflow FirstInRow(this List<IWorkflow> list)
        {
            return list.First(IsFirstInRow);
        }
        
//        public static bool IsInActiveWorkflow(this ITestClient testClient)
//        {
//            return WorkflowCollection.ActiveWorkflow.Id == testClient.TestRunId;
//        }
    }
}
