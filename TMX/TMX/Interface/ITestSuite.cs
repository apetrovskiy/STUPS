/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:03 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Description of ITestSuite.
    /// </summary>
    public interface ITestSuite
    {
        string Name { get; } // set; }
        string Id { get; } //set; }
        List<ITestScenario >  TestScenarios { get; } //set; }
        string Description { get; set; }
        string Status { get; }
        //double TimeSpent { get; }
        //TestSuiteStatuses enStatus { set; }
        
        //void SetTimeSpent(double timeSpent);
    }
}
