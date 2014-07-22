/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2012
 * Time: 2:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of DatabaseFileOpenCmdletBase.
    /// </summary>
    public class DatabaseFileOpenCmdletBase : DatabaseFileCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        public SwitchParameter StructureDB { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter RepositoryDB { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter ResultsDB { get; set; }
        #endregion Parameters
    }
}
