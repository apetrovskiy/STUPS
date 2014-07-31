/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/31/2014
 * Time: 5:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    using System;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Types.Remoting;
    
    /// <summary>
    /// Description of ExtensionMethods.
    /// </summary>
    public static class ExtensionMethods
    {
        public static ITestTask CloneTask(this ITestTask task)
        {
            return new TestTask {
                Action = task.Action,
                ActionParameters = task.ActionParameters,
                AfterAction = task.AfterAction,
                AfterActionParameters = task.AfterActionParameters,
                BeforeAction = task.BeforeAction,
                BeforeActionParameters = task.BeforeActionParameters,
                ClientId = 0,
                Completed = false,
                ExpectedResult = task.ExpectedResult,
                Id = task.Id,
                IsActive = task.IsActive,
                IsCritical = task.IsCritical,
                Name = task.Name,
                PreviousTaskId = task.PreviousTaskId, // ??
                PreviousTaskResult = task.PreviousTaskResult, // ??
                RetryCount = task.RetryCount,
                Rule = task.Rule,
                Status = task.Status,
                StoryId = task.StoryId,
                TaskResult = task.TaskResult, // ??
                Timeout = task.Timeout
            };
        }
    }
}
