/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
	using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of SetTmxTestCaseCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "TmxTestCase")]
    [OutputType(typeof(ITestCase))]
    public class SetTmxTestCaseCommand : TestCaseCmdletBase
    {
    }
}
