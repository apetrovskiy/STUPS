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
                var runnerSelector = new TaskRunnerSelector();
                var runner = runnerSelector.GetRunnableClient(task.TaskRuntimeType);
                
                var result = runner.RunBeforeAction(task.BeforeAction, task.BeforeActionParameters, task.PreviousTaskResult);
                if (!result) return result;
                result = runner.RunMainAction(task.Action, task.ActionParameters, task.PreviousTaskResult);
                return !result ? result : runner.RunAfterAction(task.AfterAction, task.AfterActionParameters, task.PreviousTaskResult);
            }
            catch {
                return false;
            }
        }
    }
}
