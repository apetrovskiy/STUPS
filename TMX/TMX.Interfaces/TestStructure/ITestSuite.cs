/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:03 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.TestStructure
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    /// <summary>
    /// Description of ITestSuite.
    /// </summary>
    public interface ITestSuite
    {
        int DbId { get; set; }
        // 20140725
        // string Name { get; }
        // string Id { get; }
        string Name { get; set; }
        string Id { get; set; }
        // 20140720
        // List<ITestScenario> TestScenarios { get; }
        List<ITestScenario> TestScenarios { get; set; }
        string Description { get; set; }
        string Status { get; }
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
        //ScriptBlock[] BeforeTest { get; set; }
        //ScriptBlock[] AfterTest { get; set; }
        ScriptBlock[] BeforeScenario { get; set; }
        ScriptBlock[] AfterScenario { get; set; }
        object[] BeforeScenarioParameters { get; set; }
        object[] AfterScenarioParameters { get; set; }
        
        // 20140720
        double TimeSpent { get; set; }
        void SetTimeSpent(double timeSpent);
        TestStat Statistics { get; set; }
        TestSuiteStatuses enStatus { get; set; }
    }
}
