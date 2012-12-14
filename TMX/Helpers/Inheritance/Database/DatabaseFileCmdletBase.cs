/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/4/2012
 * Time: 2:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of DatabaseFileCmdletBase.
    /// </summary>
    public class DatabaseFileCmdletBase : DatabaseCmdletBase
    {
        public DatabaseFileCmdletBase()
        {
        }
        
        #region Parameters
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "ConnString")]
//        public string ConnectionString { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "File")]
        public string FileName { get; set; }
        #endregion Parameters
    }
}
