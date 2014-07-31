/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:02 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.TestStructure
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    /// <summary>
    /// Description of ITestScenario.
    /// </summary>
    public interface ITestScenario
    {
        int DbId { get; set; }
        string Name { get; }
        string Id { get; }
        // 20140723
        // List<ITestResult> TestResults { get; }
        List<ITestResult> TestResults { get; set; }
        string Description { get; set; }
        string Status { get; }
        // 20140723
        // string SuiteId { get; }
        string SuiteId { get; set; }
        // 20130301
        // 20140720
        // DateTime Timestamp { get; }
        DateTime Timestamp { get; set; }
        void SetNow();
        
        //List<string> Tags { get; set; }
        string Tags { get; set; }
        //List<string> PlatformIds { get; set; }
        string PlatformId { get; set; }
        
        // 20130615
        ScriptBlock[] BeforeTest { get; set; }
        ScriptBlock[] AfterTest { get; set; }
        //ScriptBlock[] AlternateBeforeScenario { get; set; }
        //ScriptBlock[] AlternateAfterScenario { get; set; }
        object[] BeforeTestParameters { get; set; }
        object[] AfterTestParameters { get; set; }
        List<ITestCase> TestCases { get; set; }
        
        // 20140720
        double TimeSpent { get; set; }
        void SetTimeSpent(double timeSpent);
        TestStat Statistics { get; set; }
        TestScenarioStatuses enStatus { get; set; }
    }
}
