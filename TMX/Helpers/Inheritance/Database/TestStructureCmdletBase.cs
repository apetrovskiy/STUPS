/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/10/2012
 * Time: 1:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TestStructureCmdletBase.
    /// </summary>
    public class TestStructureCmdletBase : DatabaseCmdletBase
    {
        public TestStructureCmdletBase()
        {
        }
                
        #region Parameters
        [Parameter(Mandatory = false)]
        public string[] Tag { get; set; }
        
        [Parameter(Mandatory = false)]
        public string[] Description { get; set; }
        #endregion Parameters
    }
}
