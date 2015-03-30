/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/20/2014
 * Time: 9:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Tmx.Interfaces.TestStructure;
namespace Tmx.Interfaces
{
    /// <summary>
    /// Description of ITestResultCmdletBaseDataObject.
    /// </summary>
    public interface ITestResultCmdletBaseDataObject : ICommonDataObject
    {
//        ITestSuite InputObject { get; set; }
        string TestResultName { get; set; }
        string Id { get; set; }
        string Description { get; set; }
        
        bool KnownIssue { get; set; }
        TestResultOrigins TestOrigin { get; set; }
        
//        string TestSuiteName { get; set; }
//        string TestSuiteId { get; set; }
//        string TestPlatformId { get; set; }
    }
}
