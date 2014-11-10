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
        ICommonData Data { get; set; }
        // 20141106
        List<ITestSuite> TestSuites { get; set; }
        // ListOfTestSuites TestSuites { get; set; }
        Guid WorkflowId { get; }
        DateTime CreatedTime { get; set; }
        DateTime StartTime { get; set; }
        TimeSpan TimeTaken { get; set; }
	}
}
