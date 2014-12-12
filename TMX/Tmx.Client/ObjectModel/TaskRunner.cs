/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2014
 * Time: 6:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

// namespace Tmx.Client.ObjectModel
namespace Tmx.Client
{
    using System;
    using System.Diagnostics;
    using Tmx.Interfaces.Remoting;
    using Tmx.Client.ObjectModel.Runners;
    
    /// <summary>
    /// Description of TaskRunnerNew.
    /// </summary>
    public class TaskRunner
    {
        public virtual bool Run(ITestTask task)
        {
            // TODO: move to an aspect
            try {
                Trace.TraceInformation("Run(ITestTask task).1");
                
                var runnerSelector = new TaskRunnerSelector();
                
                Trace.TraceInformation("Run(ITestTask task).2");
                
                var runner = runnerSelector.GetRunnableClient(task.TaskRuntimeType);
                
                Trace.TraceInformation("Run(ITestTask task).3");
                
                var result = runner.RunBeforeAction(task.BeforeAction, task.BeforeActionParameters, task.PreviousTaskResult);
                
                Trace.TraceInformation("Run(ITestTask task).4");
                
                if (!result) return result;
                
                Trace.TraceInformation("Run(ITestTask task).5");
                
                result = runner.RunMainAction(task.Action, task.ActionParameters, task.PreviousTaskResult);
                
                Trace.TraceInformation("Run(ITestTask task).6");
                
                return !result ? result : runner.RunAfterAction(task.AfterAction, task.AfterActionParameters, task.PreviousTaskResult);
            }
            catch (Exception eOnRunningTaskCode) {
                // TODO: AOP
                Trace.TraceError("Run(ITestTask task)");
                Trace.TraceError(eOnRunningTaskCode.Message);
                return false;
            }
        }
    }
}
