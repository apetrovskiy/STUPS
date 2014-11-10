/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/26/2014
 * Time: 10:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
	using System;
    using System.Collections.Generic;
	using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.TestStructure;
	
	/// <summary>
	/// Description of TestRun.
	/// </summary>
	public class TestRun : ITestRun
	{
		ITestWorkflow _workflow;
		
		public TestRun()
		{
		    Data = new CommonData();
		    // 20141106
            TestSuites = new List<ITestSuite>();
            // TestSuites = new ListOfTestSuites();
            Status = TestRunStatuses.Pending;
            Id = Guid.NewGuid();
		}
		
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICommonData Data { get; set; }
        // 20141106
        public List<ITestSuite> TestSuites { get; set; }
        // public ListOfTestSuites TestSuites { get; set; }
        public Guid TestLabId {
            get { return _workflow.TestLabId; }
        }
        
		public TestRunStatuses Status { get; set; }
		public TestRunStartTypes StartType { get; set; }
		public Guid WorkflowId
		{
		    get { return _workflow.Id; }
		}
		
		internal void SetWorkflow(ITestWorkflow testWorkflow)
		{
		    _workflow = testWorkflow;
		}
		
		public DateTime CreatedTime { get; set; }
		public DateTime StartTime { get; set; }
		public TimeSpan TimeTaken { get; set; }
	}
}
