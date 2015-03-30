/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 11:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultDetailCmdletBaseDataObject.
    /// </summary>
    public class TestResultDetailCmdletBaseDataObject : ITestResultDetailCmdletBaseDataObject
    {
        public TestResultStatuses TestResultStatus { get; set; }
        public bool Finished { get; set; }
    }
}
