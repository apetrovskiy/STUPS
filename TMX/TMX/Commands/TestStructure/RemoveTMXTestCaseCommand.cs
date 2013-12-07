/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of RemoveTmxTestCaseCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "TmxTestCase")]
    [OutputType(typeof(ITestCase))]
    public class RemoveTmxTestCaseCommand : TestCaseCmdletBase
    {
        public RemoveTmxTestCaseCommand()
        {
        }
    }
}
