/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddTMXTestCaseCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TMXTestCase")]
    [OutputType(typeof(ITestCase))]
    public class AddTMXTestCaseCommand : TestCaseCmdletBase
    {
        public AddTMXTestCaseCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public ScriptBlock[] TestCode { get; set; }
        #endregion Parameters
    }
}
