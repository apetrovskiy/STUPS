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
        string Name { get; }
        string Id { get; }
        List<ITestScenario >  TestScenarios { get; }
        string Description { get; set; }
        string Status { get; }
        // 20130301
        System.DateTime Timestamp { get; }
        void SetNow();
        
        List<string> Tags { get; set; }
    }
}
