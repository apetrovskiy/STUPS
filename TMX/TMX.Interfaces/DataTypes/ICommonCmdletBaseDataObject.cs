/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 12:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    /// <summary>
    /// Description of ICommonCmdletBaseDataObject.
    /// </summary>
    public interface ICommonCmdletBaseDataObject : ICommonDataObject
    {
        string Name { get; set; }
        string Id { get; set; }
        string TestPlatformId { get; set; }
//        internal new SwitchParameter TestPassed { get; set; }
//        internal new SwitchParameter KnownIssue { get; set; }
//        internal new SwitchParameter TestLog { get; set; }
//        internal new string TestResultName { get; set; }
//        internal new string TestResultId { get; set; }
    }
}
