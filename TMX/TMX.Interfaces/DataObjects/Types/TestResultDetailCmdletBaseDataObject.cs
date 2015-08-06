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
    using TestStructure;

    /// <summary>
    /// Description of TestResultDetailCmdletBaseDataObject.
    /// </summary>
    public class TestResultDetailCmdletBaseDataObject : ITestResultDetailCmdletBaseDataObject
    {
        // 20150805
        // public TestResultStatuses TestResultStatus { get; set; }
        public TestStatuses TestResultStatus { get; set; }
        public bool Finished { get; set; }
    }
}
