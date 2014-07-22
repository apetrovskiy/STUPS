/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/31/2013
 * Time: 3:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewPlatformCmdletBase.
    /// </summary>
    public class NewPlatformCmdletBase : PlatformCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        [AllowNull]
        [AllowEmptyString]
        public string Description { get; set; }
        
        [Parameter(Mandatory = false)]
        public string OperatingSystem { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Version { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Architecture { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Language { get; set; }
        #endregion Parameters
    }
}
