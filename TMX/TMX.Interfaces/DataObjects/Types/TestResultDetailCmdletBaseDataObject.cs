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
        public TestStatuses TestResultStatus { get; set; }
        public bool Finished { get; set; }
    }
}
