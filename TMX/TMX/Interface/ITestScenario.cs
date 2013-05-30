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
        int DbId { get; set; }
        string Name { get; }
        string Id { get; }
        List<ITestResult> TestResults { get; }
        string Description { get; set; }
        string Status { get; }
        
        string SuiteId { get; }
        // 20130301
        System.DateTime Timestamp { get; }
        void SetNow();
        
        //List<string> Tags { get; set; }
        string Tags { get; set; }
        //List<string> PlatformIds { get; set; }
        string PlatformId { get; set; }
    }
}
