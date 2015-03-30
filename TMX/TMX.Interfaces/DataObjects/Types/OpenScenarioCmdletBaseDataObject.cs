/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/20/2014
 * Time: 11:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of OpenScenarioCmdletBaseDataObject.
    /// </summary>
    public class OpenScenarioCmdletBaseDataObject : IOpenScenarioCmdletBaseDataObject
    {
        public ITestSuite InputObject { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        
        public string TestSuiteName { get; set; }
        public string TestSuiteId { get; set; }
        public string TestPlatformId { get; set; }
        
//        public ScriptBlock[] BeforeTest { get; set; }
//        public ScriptBlock[] AfterTest { get; set; }
    }
}
