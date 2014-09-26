/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 11:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of IGetTmxTestSuiteStatusDataObject.
    /// </summary>
    public interface IGetTmxTestSuiteStatusDataObject : IOpenSuiteCmdletBaseDataObject, ICommonCmdletBaseDataObject
    {
        SwitchParameter FilterOutAutomaticResults { get; set; }
    }
}
