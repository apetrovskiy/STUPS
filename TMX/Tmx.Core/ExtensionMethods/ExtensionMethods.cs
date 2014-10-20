/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2014
 * Time: 4:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core
{
    using System;
	using Tmx.Interfaces.Remoting;
	using Tmx.Core.Types.Remoting;
    
    /// <summary>
    /// Description of ExtensionMethods.
    /// </summary>
    public static class ExtensionMethods
    {
        public static ITestTask CloneTaskForNewTestClient(this ITestTask task)
        {
            return new TestTask {
                Action = task.Action,
                ActionParameters = task.ActionParameters,
                AfterAction = task.AfterAction,
                AfterActionParameters = task.AfterActionParameters,
                BeforeAction = task.BeforeAction,
                BeforeActionParameters = task.BeforeActionParameters,
                ClientId = 0,
                TaskFinished = false,
                ExpectedResult = task.ExpectedResult,
                Id = task.Id,
                AfterTask = task.AfterTask,
                IsActive = task.IsActive,
                IsCritical = task.IsCritical,
                Name = task.Name,
                PreviousTaskId = task.PreviousTaskId, // ??
                PreviousTaskResult = task.PreviousTaskResult, // ??
                TaskBanner = task.TaskBanner,
                RetryCount = task.RetryCount,
                Rule = task.Rule,
                TaskStatus = task.TaskStatus,
                StoryId = task.StoryId,
                TaskResult = task.TaskResult, // ??
                TimeLimit = task.TimeLimit,
                WorkflowId = task.WorkflowId,
                TaskType = task.TaskType
            };
        }
        
        public static ITestTaskCodeProxy SqueezeTaskToTaskCodeProxy(this ITestTask task)
        {
            return new TestTaskCodeProxy {
                Action = task.Action,
                ActionParameters = task.ActionParameters,
                AfterAction = task.AfterAction,
                AfterActionParameters = task.AfterActionParameters,
                BeforeAction = task.BeforeAction,
                BeforeActionParameters = task.BeforeActionParameters,
                // ClientId = 0,
                // TaskFinished = false,
                // ExpectedResult = task.ExpectedResult,
                Id = task.Id,
                // AfterTask = task.AfterTask,
                // IsActive = task.IsActive,
                // IsCritical = task.IsCritical,
                Name = task.Name,
                // PreviousTaskId = task.PreviousTaskId, // ??
                PreviousTaskResult = task.PreviousTaskResult, // ??
                TaskBanner = task.TaskBanner,
                // RetryCount = task.RetryCount,
                // Rule = task.Rule,
                // TaskStatus = task.TaskStatus,
                // StoryId = task.StoryId,
                // TaskResult = task.TaskResult, // ??
                TimeLimit = task.TimeLimit// ,
                // new
                // 20141009
                // WorkflowId = task.WorkflowId
            };
        }
        
        public static ITestTaskResultProxy SqueezeTaskToTaskResultProxy(this ITestTask task)
        {
            return new TestTaskResultProxy {
//                Action = task.Action,
//                ActionParameters = task.ActionParameters,
//                AfterAction = task.AfterAction,
//                AfterActionParameters = task.AfterActionParameters,
//                BeforeAction = task.BeforeAction,
//                BeforeActionParameters = task.BeforeActionParameters,
//                ClientId = 0,
                // TaskFinished = false,
                // ExpectedResult = task.ExpectedResult,
                Id = task.Id,
                // AfterTask = task.AfterTask,
                // IsActive = task.IsActive,
                // IsCritical = task.IsCritical,
//                Name = task.Name,
                // PreviousTaskId = task.PreviousTaskId, // ??
//                PreviousTaskResult = task.PreviousTaskResult, // ??
//                TaskBanner = task.TaskBanner,
                // RetryCount = task.RetryCount,
                // Rule = task.Rule,
                TaskStatus = task.TaskStatus,
                // StoryId = task.StoryId,
                TaskResult = task.TaskResult //, // ??
//                TimeLimit = task.TimeLimit,
                // new
                // 20141009
//                WorkflowId = task.WorkflowId
            };
        }
        
        public static ITestTaskStatusProxy SqueezeTaskToTaskStatusProxy(this ITestTask task)
        {
            return new TestTaskStatusProxy {
//                Action = task.Action,
//                ActionParameters = task.ActionParameters,
//                AfterAction = task.AfterAction,
//                AfterActionParameters = task.AfterActionParameters,
//                BeforeAction = task.BeforeAction,
//                BeforeActionParameters = task.BeforeActionParameters,
//                ClientId = 0,
                TaskFinished = false,
                // ExpectedResult = task.ExpectedResult,
                Id = task.Id,
                // AfterTask = task.AfterTask,
                // IsActive = task.IsActive,
                // IsCritical = task.IsCritical,
//                Name = task.Name,
                // PreviousTaskId = task.PreviousTaskId, // ??
//                PreviousTaskResult = task.PreviousTaskResult, // ??
//                TaskBanner = task.TaskBanner,
                // RetryCount = task.RetryCount,
                // Rule = task.Rule,
                TaskStatus = task.TaskStatus //,
                // StoryId = task.StoryId,
                // TaskResult = task.TaskResult, // ??
//                TimeLimit = task.TimeLimit,
                // new
                // 20141009
//                WorkflowId = task.WorkflowId
            };
        }
    }
}
