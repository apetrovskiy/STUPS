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
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ProfileCmdletBase.
    /// </summary>
    public class ProfileCmdletBase : CommonCmdletBase
    {
        public ProfileCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   ParameterSetName = "Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        #endregion Parameters
    }
}
