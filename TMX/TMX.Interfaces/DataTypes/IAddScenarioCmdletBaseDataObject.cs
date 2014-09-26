/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/20/2014
 * Time: 9:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
	using System.Management.Automation;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of IAddScenarioCmdletBaseDataObject.
    /// </summary>
    public interface IAddScenarioCmdletBaseDataObject : ICommonDataObject
    {
        ITestSuite InputObject { get; set; }
        string Name { get; set; }
        string Id { get; set; }
        string Description { get; set; }
        
        string TestSuiteName { get; set; }
        string TestSuiteId { get; set; }
        string TestPlatformId { get; set; }
        
        ScriptBlock[] BeforeTest { get; set; }
        ScriptBlock[] AfterTest { get; set; }
    }
}
