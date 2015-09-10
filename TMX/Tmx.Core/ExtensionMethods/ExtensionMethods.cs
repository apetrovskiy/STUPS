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
    using System.IO;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Interfaces.ExtensionMethods;
    using Interfaces.Remoting;
    using Interfaces.TestStructure;
    using Types.Remoting;

    /// <summary>
    /// Description of ExtensionMethods.
    /// </summary>
    public static class ExtensionMethods
    {
        public static ITestTask CloneTaskForNewTestClient(this ITestTask task)
        {
            // 20150904
            return new TestTask {
            // return new TestTask(task.TaskRuntimeType) {
                Action = task.Action,
                ActionParameters = task.ActionParameters,
                AfterAction = task.AfterAction,
                AfterActionParameters = task.AfterActionParameters,
                BeforeAction = task.BeforeAction,
                BeforeActionParameters = task.BeforeActionParameters,
                // ClientId = 0,
                TaskFinished = false,
                ExpectedResult = task.ExpectedResult,
                Id = task.Id,
                AfterTask = task.AfterTask,
                IsActive = task.IsActive,
                IsCritical = task.IsCritical,
                IsCancel = task.IsCancel,
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
                TestRunId = task.TestRunId,
                TaskType = task.TaskType,
                TaskRuntimeType = task.TaskRuntimeType,
                StartTime = task.StartTime
                // 20150908
                ,
                TestStatus = task.TestStatus
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
                Id = task.Id,
                ClientId = task.ClientId,
                Name = task.Name,
                PreviousTaskResult = task.PreviousTaskResult,
                TaskBanner = task.TaskBanner,
                TimeLimit = task.TimeLimit,
                StartTime = task.StartTime,
                TaskStatus = task.TaskStatus,
                TaskType = task.TaskType,
                TaskRuntimeType = task.TaskRuntimeType
            };
        }
        
        public static ITestTaskResultProxy SqueezeTaskToTaskResultProxy(this ITestTask task)
        {
            return new TestTaskResultProxy {
                Id = task.Id,
                ClientId = task.ClientId,
                TaskStatus = task.TaskStatus,
                TaskResult = task.TaskResult
            };
        }
        
        public static ITestTaskStatusProxy SqueezeTaskToTaskStatusProxy(this ITestTask task)
        {
            return new TestTaskStatusProxy {
                TaskFinished = false,
                Id = task.Id,
                ClientId = task.ClientId,
                TaskStatus = task.TaskStatus
            };
        }
        
        public static bool IsAccepted(this ITestTask task)
        {
            return TestTaskStatuses.Running == task.TaskStatus;
        }
        
        public static bool IsActive(this ITestTask task)
        {
            return task.IsAccepted();
        }
        
        //public static bool IsFinished(this ITestTask task)
        //{
        //    return TestTaskStatuses.CompletedSuccessfully == task.TaskStatus || TestTaskStatuses.ExecutionFailed == task.TaskStatus || TestTaskStatuses.Canceled == task.TaskStatus;
        //}

        // 20150907
        public static bool IsFinished(this ITestTask task)
        {
            return TestTaskStatuses.CompletedSuccessfully == task.TaskStatus ||
                   TestTaskStatuses.ExecutionFailed == task.TaskStatus || TestTaskStatuses.Canceled == task.TaskStatus ||
                   TestTaskStatuses.FailedByTestResults == task.TaskStatus;
        }
        
        public static bool IsCanceled(this ITestTask task)
        {
            return TestTaskStatuses.Canceled == task.TaskStatus;
        }
        
        public static bool IsCompletedSuccessfully(this ITestTask task)
        {
            return TestTaskStatuses.CompletedSuccessfully == task.TaskStatus;
        }
        
        //public static bool IsFailed(this ITestTask task)
        //{
        //    return TestTaskStatuses.ExecutionFailed == task.TaskStatus;
        //}

        // 20150907
        public static bool IsFailed(this ITestTask task)
        {
            return TestTaskStatuses.ExecutionFailed == task.TaskStatus || TestTaskStatuses.FailedByTestResults == task.TaskStatus;
        }

        public static void CheckTestStatus(this ITestTask task)
        {
            if (task.IsCritical && TestStatuses.Failed == TestData.TestSuites.GetOveralStatus())
                task.TaskStatus = TestTaskStatuses.FailedByTestResults;
        }
        
        public static bool IsActive(this ITestRun testRun)
        {
            return TestRunStatuses.Running == testRun.Status;
        }
        
        public static bool IsNotQuiet(this ITestRun testRun)
        {
            return TestRunStatuses.Running == testRun.Status
            || TestRunStatuses.Canceling == testRun.Status;
        }
        
        public static bool IsPending(this ITestRun testRun)
        {
            return TestRunStatuses.Pending == testRun.Status;
        }
        
        public static bool IsScheduled(this ITestRun testRun)
        {
            return TestRunStatuses.Scheduled == testRun.Status;
        }
        
        public static bool IsCompleted(this ITestRun testRun)
        {
            return TestRunStatuses.Finished == testRun.Status
            || TestRunStatuses.InterruptedOnTaskFailure == testRun.Status
            // 20150908
            || TestRunStatuses.InterruptedOnCriticalTask == testRun.Status
            || TestRunStatuses.Canceled == testRun.Status;
        }
        
        public static bool IsQueued(this ITestRun testRun)
        {
            return TestRunStatuses.Running == testRun.Status || TestRunStatuses.Pending == testRun.Status;
        }
        
        public static void SetStartTime(this ITestRun testRun)
        {
            testRun.StartTime = DateTime.Now;
        }
        
        public static void SetTimeTaken(this ITestRun testRun)
        {
            (testRun as TestRun).SetFinishTime();
        }
        
        public static string SerializeToString(this XDocument document)
        {
            using (var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(document.Root.ToString())))
            {
                var xmlSerializer = new XmlSerializer(typeof(string));
                return (string)xmlSerializer.Deserialize(memoryStream);
            }
        }
        
        public static XDocument DeserializeFromString(this string documentAsString)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(XElement));
                    xmlSerializer.Serialize(streamWriter, documentAsString);
                    return XDocument.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                }
            }
        }
        
        public static void SetNoTasksStatus(this ITestClient testClient)
        {
            testClient.Status = TestClientStatuses.NoTasks;
            testClient.TaskId = 0;
            testClient.TaskName = string.Empty;
        }
    }
}
