/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/20/2014
 * Time: 9:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of ITestResultDetailCmdletBaseDataObject.
    /// </summary>
    public interface ITestResultDetailCmdletBaseDataObject : ICommonDataObject
    {
        TestResultStatuses TestResultStatus { get; set; }
        bool Finished { get; set; }
    }
}
