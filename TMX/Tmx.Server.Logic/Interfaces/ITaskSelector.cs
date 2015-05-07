/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2014
 * Time: 10:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Logic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Tmx.Interfaces.Remoting;

    /// <summary>
    /// Description of ITaskSelector.
    /// </summary>
    public interface ITaskSelector
    {
        List<ITestTask> SelectTasksForClient(Guid clientId, List<ITestTask> tasks);
        ITestTask GetFirstLegitimateTask(Guid clientId);
        ITestTask GetNextLegitimateTask(Guid clientId, int currentTaskId);
        void CancelFurtherTasksOfTestClient(Guid clientId);
        void CancelFurtherTasksOfTestRun(Guid testRunId);
//        internal virtual IEnumerable<ITestTask> getOnlyNewTestTasksForClient(Guid clientId);
//        internal virtual bool isItTimeToPublishTask(ITestTask task);
//        internal virtual void AddTasksForEveryClient(IEnumerable<ITestTask> activeWorkflowsTasks, Guid testRunId);
    }
}
