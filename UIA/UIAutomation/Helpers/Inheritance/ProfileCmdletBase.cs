/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/12/2012
 * Time: 8:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ProfileCmdletBase.
    /// </summary>
    public class ProfileCmdletBase : CommonCmdletBase
    {
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true,
                   ParameterSetName = "Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        #endregion Parameters
    }
}
