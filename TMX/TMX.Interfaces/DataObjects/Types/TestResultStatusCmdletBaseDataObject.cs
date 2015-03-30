/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 11:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultStatusCmdletBaseDataObject.
    /// </summary>
    public class TestResultStatusCmdletBaseDataObject : ITestResultStatusCmdletBaseDataObject
    {
        public string Id { get; set; }
        
//        public string TestResultName { get; set; }
        public TestResultStatuses TestResultStatus { get; set; }
//        public new SwitchParameter TestPassed { get; set; }
//        public new SwitchParameter KnownIssue { get; set; }
//        public string Description { get; set; }
        public TestResultOrigins TestOrigin { get; set; }
        
//        [Parameter(Mandatory = false)]
//        internal new string Name { get; set; }
//        public TestResultStatuses TestResultStatus { get; set; }
//        public string Id { get; set; }
        
//        public string TestResultName { get; set; }
//        public TestResultStatuses TestResultStatus { get; set; }
//        public SwitchParameter TestPassed { get; set; }
//        public SwitchParameter KnownIssue { get; set; }
//        public string Description { get; set; }
        
//        [Parameter(Mandatory = false)]
//        internal new string TestResultName { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        internal new TestResultStatuses TestResultStatus { get; set; }
//
//        [Parameter(Mandatory = false)]
//        internal new SwitchParameter TestPassed { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        internal new SwitchParameter KnownIssue { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        internal new string Description { get; set; }
    }
}
