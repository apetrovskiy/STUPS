/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:02 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Description of ITestScenario.
    /// </summary>
    public interface ITestScenario
    {
        string Name { get; } //set; }
        string Id { get; } //set; }
        List<ITestResult >  TestResults { get; } //set; }
        string Description { get; set; }
        string Status { get; }
        
        string SuiteId { get; }
        
//        double TimeSpent { get; }
        //TestScenarioStatuses enStatus { set; }
        
//        void SetTimeSpent(double timeSpent);
    }
}
