/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/9/2013
 * Time: 4:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TLUserCmdletBase.
    /// </summary>
    internal class TLUserCmdletBase : TLSCmdletBase
    {
        internal TLUserCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string Login { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string Password { get; set; }
        
        [Parameter(Mandatory = false)]
        public string FirstName { get; set; }
        
        [Parameter(Mandatory = false)]
        public string LastName { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Email { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Role { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Locale { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Active { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Disabled { get; set; }
        #endregion Parameters
    }
}
