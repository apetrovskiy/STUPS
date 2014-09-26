/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 1:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultCmdletBaseDataObject.
    /// </summary>
    public class TestResultCmdletBaseDataObject : ITestResultCmdletBaseDataObject
    {
        public string TestResultName { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        
        public bool KnownIssue { get; set; }
        public TestResultOrigins TestOrigin { get; set; }
    }
}
