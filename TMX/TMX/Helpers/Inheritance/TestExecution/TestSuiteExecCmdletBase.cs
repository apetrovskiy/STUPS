/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 1:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TestSuiteExecCmdletBase.
    /// </summary>
    public class TestSuiteExecCmdletBase : TestExecCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        public object[] BeforeScenarioParameters { get; set; }
        
        [Parameter(Mandatory = false)]
        public object[] AfterScenarioParameters { get; set; }
        
        [Parameter(Mandatory = false)]
        public new string Name { get; set; }
        #endregion Parameters
        
        protected internal bool OnlySetParameters { get; set; }
    }
}
