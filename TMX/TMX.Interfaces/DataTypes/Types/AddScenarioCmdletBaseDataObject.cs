/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/20/2014
 * Time: 11:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
	using System.Management.Automation;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of AddScenarioCmdletBaseDataObject.
    /// </summary>
    public class AddScenarioCmdletBaseDataObject : IAddScenarioCmdletBaseDataObject
    {
        // 20141117
        public AddScenarioCmdletBaseDataObject()
        {
            BeforeTest = new ScriptBlock[] {};
            AfterTest = new ScriptBlock[] {};
        }
        
        public ITestSuite InputObject { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        
        public string TestSuiteName { get; set; }
        public string TestSuiteId { get; set; }
        public string TestPlatformId { get; set; }
        // public Guid TestPlatformId { get; set; }
        
        public ScriptBlock[] BeforeTest { get; set; }
        public ScriptBlock[] AfterTest { get; set; }
    }
}
