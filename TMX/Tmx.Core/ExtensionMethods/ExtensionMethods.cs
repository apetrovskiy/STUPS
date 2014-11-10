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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
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
                // ClientId = 0,
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
                TestRunId = task.TestRunId,
                TaskType = task.TaskType,
                StartTime = task.StartTime
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
                TaskStatus = task.TaskStatus
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
        
        public static bool IsFinished(this ITestTask task)
        {
            return TestTaskStatuses.CompletedSuccessfully == task.TaskStatus || TestTaskStatuses.Interrupted == task.TaskStatus || TestTaskStatuses.Canceled == task.TaskStatus;
        }
        
        public static bool IsCancelled(this ITestTask task)
        {
            return TestTaskStatuses.Canceled == task.TaskStatus;
        }
        
        public static bool IsFailed(this ITestTask task)
        {
            return TestTaskStatuses.Interrupted == task.TaskStatus;
        }
//        
//        public static int GetNextId<T>(this List<T> list)
//        {
//            int result = 0;
//            result = list.Max<T>(t => t.Id);
//            return result++;
//        }
        
        public static bool IsActive(this ITestRun testRun)
        {
            return TestRunStatuses.Running == testRun.Status;
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
            return TestRunStatuses.Completed == testRun.Status;
        }
        
        public static bool IsQueued(this ITestRun testRun)
        {
        	return TestRunStatuses.Running == testRun.Status || TestRunStatuses.Pending == testRun.Status;
        }
        
        public static void SetStartTime(this ITestRun testRun)
        {
            testRun.StartTime = DateTime.Now;
        }
        
//        public static string SerializeToString<T>(this T testResultsCollection)
//        {
//			var serializer = new XmlSerializer(typeof(T));
//            
//			try {
//	            using (var writer = new StringWriter())
//	            {
//	                serializer.Serialize(writer, testResultsCollection);
//	                return writer.ToString();
//	            }
//			}
////			catch {
////				return string.Empty;
////			}
//			catch (Exception e) {
//Console.WriteLine(e.GetType().Name);
//Console.WriteLine(e.Message);
//Console.WriteLine(e.InnerException.Message);
//				return string.Empty;
//			}
//        }
//		
//        public static T DeserializeFromString<T>(this string testResultsCollection)
//        {
//			var serializer = new XmlSerializer(typeof(T));
//			
//			try {
//				using (var stream = new MemoryStream()) {
//					using (var writer = new StreamWriter(stream, Encoding.Unicode)) {
//						writer.Write(testResultsCollection);
//						writer.Flush();
//						stream.Position = 0;
//						return (T)serializer.Deserialize(stream);
//					}
//				}
//			}
//			catch {
//				return default(T);
//			}
//        }
        
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
    }
}
