/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2013
 * Time: 5:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    using Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultStatusCmdletBase.
    /// </summary>
    public class TestResultStatusCmdletBase : TestResultCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new string TestResultName { get; set; }
        
        [Parameter(Mandatory = false)]
        // 20150805
        // internal new TestResultStatuses TestResultStatus { get; set; }
        internal new TestStatuses TestResultStatus { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter TestPassed { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter KnownIssue { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Description { get; set; }
        #endregion Parameters
    }
}
