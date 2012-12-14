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
    /// Description of SetTMXTestCaseCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "TMXTestCase")]
    [OutputType(typeof(ITestCase))]
    public class SetTMXTestCaseCommand : TestCaseCmdletBase
    {
        public SetTMXTestCaseCommand()
        {
        }
    }
}
