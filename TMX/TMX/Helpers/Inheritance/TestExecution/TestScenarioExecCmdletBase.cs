/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 1:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TestScenarioExecCmdletBase.
    /// </summary>
    public class TestScenarioExecCmdletBase : TestExecCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        public object[] BeforeTestParameters { get; set; }
        
        [Parameter(Mandatory = false)]
        public object[] AfterTestParameters { get; set; }
        
        [Parameter(Mandatory = false)]
        public new string Name { get; set; }
        #endregion Parameters
        
        protected internal bool OnlySetParameters { get; set; }
    }
}
