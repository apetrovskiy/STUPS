/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/28/2013
 * Time: 2:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SingleNameCmdletBase.
    /// </summary>
    public class SingleNameCmdletBase : TFSCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        // 20131102
        // ReSharper warning
        public new string Name { get; set; }
        #endregion Parameters
    }
}
