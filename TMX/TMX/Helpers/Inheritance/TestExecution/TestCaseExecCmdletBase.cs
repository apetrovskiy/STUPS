/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 1:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TestCaseExecCmdletBase.
    /// </summary>
    public class TestCaseExecCmdletBase : TestExecCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false,
                   Position = 0,
                   ValueFromPipeline = true)]
        public ScriptBlock[] TestCode { get; set; }
        
        [Parameter(Mandatory = false)]
        public object[] TestCodeParameters { get; set; }
        
        [Parameter(Mandatory = false)]
        public new string Name { get; set; }
        #endregion Parameters
        
        protected internal bool OnlySetParameters { get; set; }
    }
}
