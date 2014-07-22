/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/4/2012
 * Time: 2:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of DatabaseFileCmdletBase.
    /// </summary>
    public class DatabaseFileCmdletBase : DatabaseCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true,
                   ParameterSetName = "File")]
        public string FileName { get; set; }
        #endregion Parameters
    }
}
