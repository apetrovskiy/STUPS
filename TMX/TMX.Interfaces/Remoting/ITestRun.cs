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
    using Tmx.Interfaces.Remoting.Actions;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of ITestRun.
    /// </summary>
    public interface ITestRun : IWorkflow
    {
        TestRunStatuses Status { get; set; }
        TestRunStartTypes StartType { get; set; }
        ICommonData Data { get; set; }
        List<ITestSuite> TestSuites { get; set; }
        List<ITestPlatform> TestPlatforms { get; set; }
        // ListOfTestSuites TestSuites { get; set; }
        Guid WorkflowId { get; }
        DateTime CreatedTime { get; set; }
        DateTime StartTime { get; set; }
        // 20150115
        // TimeSpan TimeTaken { get; set; }
        TimeSpan GetTimeTaken();
//        string GetTestLabName();
        List<IAction> BeforeActions { get; set; }
        List<IAction> AfterActions { get; set; }
        List<IAction> CancelActions { get; set; }
        List<IAction> FailureActions { get; set; }
    }
}
