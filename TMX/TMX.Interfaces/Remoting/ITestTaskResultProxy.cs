/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/20/2014
 * Time: 3:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of ITestTaskResultProxy.
    /// </summary>
    public interface ITestTaskResultProxy : ITestTaskProxy
    {
//		int Id { get; set; }
		// int Order { get; set; }
		// int PreviousTaskId { get; set; }
		// int AfterTask { get; set; }
		// bool IsActive { get; set; }
//		bool TaskFinished { get; set; }
//		int TimeLimit { get; set; }
//		DateTime StartTime { get; set; }
		// int RetryCount { get; set; }
		// bool IsCritical { get; set; }
		
		// TestTaskExecutionTypes TaskType { get; set; }
		// string Rule { get; set; }
		
//		string Name { get; set; }
		// string StoryId { get; set; }
//		string Action { get; set; }
//		IDictionary<string, string> ActionParameters { get; set; }
//		string BeforeAction { get; set; }
//		IDictionary<string, string> BeforeActionParameters { get; set; }
//		string AfterAction { get; set; }
//		IDictionary<string, string> AfterActionParameters { get; set; }
		// string[] ExpectedResult { get; set; }
		
//		string TaskBanner { get; set; }
//		TestTaskStatuses TaskStatus { get; set; }
//		IDictionary<string, string> PreviousTaskResult { get; set; }
		IDictionary<string, string> TaskResult { get; set; }
//		int ClientId { get; set; }
//		int WorkflowId { get; set; }
//		
//		void StartTimer();
    }
}
