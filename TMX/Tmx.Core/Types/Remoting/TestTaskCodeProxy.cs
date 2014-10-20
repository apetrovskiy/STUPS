/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/20/2014
 * Time: 4:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
	using System.Collections.Generic;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestTaskCodeProxy.
    /// </summary>
    public class TestTaskCodeProxy : ITestTaskCodeProxy
    {
        public int Id { get; set; }
        public TestTaskStatuses TaskStatus { get; set; }
		public int TimeLimit { get; set; }
		public DateTime StartTime { get; set; }
		
		public string Name { get; set; }
		public string Action { get; set; }
		public IDictionary<string, string> ActionParameters { get; set; }
		public string BeforeAction { get; set; }
		public IDictionary<string, string> BeforeActionParameters { get; set; }
		public string AfterAction { get; set; }
		public IDictionary<string, string> AfterActionParameters { get; set; }
		
		public string TaskBanner { get; set; }
		public IDictionary<string, string> PreviousTaskResult { get; set; }
		
		public void StartTimer()
		{
		    // TODO: implement a timer
		    StartTime = DateTime.Now;
		}
    }
}
