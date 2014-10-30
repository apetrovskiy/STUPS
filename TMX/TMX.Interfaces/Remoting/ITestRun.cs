/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/26/2014
 * Time: 10:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
	using System;
	using System.Collections.Generic;
	using Tmx.Interfaces.TestStructure;
	
	/// <summary>
	/// Description of ITestRun.
	/// </summary>
	public interface ITestRun : IWorkflow
	{
		TestRunStatuses Status { get; set; }
		TestRunStartTypes StartType { get; set; }
        Dictionary<string, string> Data { get; set; }
        List<ITestSuite> TestSuites { get; set; }
        // int WorkflowId { get; set; }
        // int WorkflowId { get; }
        Guid WorkflowId { get; }
        
        // ITestWorkflow Workflow { get; set; }
        DateTime StartTime { get; set; }
	}
}
