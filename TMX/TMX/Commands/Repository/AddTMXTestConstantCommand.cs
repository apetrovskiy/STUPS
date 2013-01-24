/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddTMXTestConstantCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TMXTestConstant")]
    [OutputType(typeof(ITestConstant))]
    public class AddTMXTestConstantCommand : TestConstantCmdletBase
    {
        public AddTMXTestConstantCommand()
        {
        }
    }
}
