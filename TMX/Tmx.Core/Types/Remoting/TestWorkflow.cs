/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/8/2014
 * Time: 9:07 PM
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
    /// Description of TestWorkflow.
    /// </summary>
    public class TestWorkflow : ITestWorkflow
    {
//        public TestWorkflow()
//        {
//            Data = new Dictionary<string, string>();
//            TestSuites = new List<ITestSuite>();
//        }
//        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // public WorkflowStatuses WorkflowStatus { get; set; }
        // public Dictionary<string, string> Data { get; set; }
        // public List<ITestSuite> TestSuites { get; set; }
        public bool IsActive { get; set; }
        public int TestLabId { get; set; }
    }
}
