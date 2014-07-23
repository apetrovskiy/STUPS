/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 9:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Types.Remoting
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
		public bool On { get; set; }
		public bool Completed { get; set; }
		public int Timeout { get; set; }
		public int RetryCount { get; set; }
		public bool IsCritical { get; set; }
		
		public TestTaskExecutionTypes TaskType { get; set; }
		public string Rule { get; set; }
		
		public string Name { get; set; }
		public string StoryId { get; set; }
		public ITestTaskAction[] BeforeAction { get; set; }
		public ITestTaskAction[] Action { get; set; }
		public ITestTaskAction[] AfterAction { get; set; }
		// public string[] ExpectedResult { get; set; } // ?
		public List<object> ExpectedResult { get; set; } // ?
		
		public TestTaskStatuses Status { get; set; }
		public List<object> TaskResult { get; set; }
	}
}
