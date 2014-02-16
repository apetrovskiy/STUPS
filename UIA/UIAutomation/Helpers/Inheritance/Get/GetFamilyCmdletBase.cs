/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/12/2013
 * Time: 11:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetFamilyCmdletBase.
    /// </summary>
    public class GetFamilyCmdletBase : GetRelativesCmdletBase
    {
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        internal new string[] ControlType { get; set; }
        #endregion Parameters
    }
}
