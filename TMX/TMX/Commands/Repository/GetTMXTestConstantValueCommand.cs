/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTMXTestConstantValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TMXTestConstantValue")]
    [OutputType(typeof(ITestConstant))]
    public class GetTMXTestConstantValueCommand: TestConstantCmdletBase
    {
        public GetTMXTestConstantValueCommand()
        {
        }
    }
}
