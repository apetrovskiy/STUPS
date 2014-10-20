/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/20/2014
 * Time: 2:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
	using System.Collections.Generic;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestTaskProxy.
    /// </summary>
    public class TestTaskProxy : ITestTaskProxy
    {
        public TestTaskProxy()
        {
	        ActionParameters = new Dictionary<string, string>();
	        BeforeActionParameters = new Dictionary<string, string>();
	        AfterActionParameters = new Dictionary<string, string>();
	        PreviousTaskResult = new Dictionary<string, string>();
	        // TaskResult = new Dictionary<string, string>();
        }
        
		public int Id { get; set; }
		// int Order { get; set; }
		// int PreviousTaskId { get; set; }
		// int AfterTask { get; set; }
		// bool IsActive { get; set; }
		public bool TaskFinished { get; set; }
		public int TimeLimit { get; set; }
		public DateTime StartTime { get; set; }
		// int RetryCount { get; set; }
		// bool IsCritical { get; set; }
		
		// TestTaskExecutionTypes TaskType { get; set; }
		// string Rule { get; set; }
		
		public string Name { get; set; }
		// string StoryId { get; set; }
		public string Action { get; set; }
		public IDictionary<string, string> ActionParameters { get; set; }
		public string BeforeAction { get; set; }
		public IDictionary<string, string> BeforeActionParameters { get; set; }
		public string AfterAction { get; set; }
		public IDictionary<string, string> AfterActionParameters { get; set; }
		// string[] ExpectedResult { get; set; }
		
		public string TaskBanner { get; set; }
		public TestTaskStatuses TaskStatus { get; set; }
		public IDictionary<string, string> PreviousTaskResult { get; set; }
		public IDictionary<string, string> TaskResult { get; set; }
		public int ClientId { get; set; }
		public int WorkflowId { get; set; }
		
		public void StartTimer()
		{
		    // TODO: implement a timer
		    StartTime = DateTime.Now;
		}
    }
}
