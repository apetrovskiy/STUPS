/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2014
 * Time: 4:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
	using System.Collections.Generic;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestTask.
    /// </summary>
	public class TestTask : ITestTask
	{
		public int Id { get; set; }
		// public int Order { get; set; }
		public int PreviousTaskId { get; set; }
		public int AfterTask { get; set; }
		public bool IsActive { get; set; }
		public bool TaskFinished { get; set; }
		public int Timeout { get; set; }
		public int RetryCount { get; set; }
		public bool IsCritical { get; set; }
		
		public TestTaskExecutionTypes TaskType { get; set; }
		public string Rule { get; set; }
		
		public string Name { get; set; }
		public string StoryId { get; set; }
		public string Action { get; set; }
		public List<object> ActionParameters { get; set; }
		public string BeforeAction { get; set; }
		public List<object> BeforeActionParameters { get; set; }
		public string AfterAction { get; set; }
		public List<object> AfterActionParameters { get; set; }
		public string[] ExpectedResult { get; set; }
		
		public string TaskBanner { get; set; }
		public TestTaskStatuses TaskStatus { get; set; }
		public List<object> PreviousTaskResult { get; set; }
		public List<object> TaskResult { get; set; }
		public int ClientId { get; set; }
		
		public void StartTimer()
		{
		    // TODO: implement a timer
		}
	}
}
