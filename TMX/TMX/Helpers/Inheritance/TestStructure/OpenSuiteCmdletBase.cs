/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/22/2012
 * Time: 11:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of OpenSuiteCmdletBase.
    /// </summary>
    public class OpenSuiteCmdletBase : CommonCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        public new string Name { get; set; }
        #endregion Parameters
    }
}
