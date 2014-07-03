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
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of AddTmxTestConstantCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TmxTestConstant")]
    [OutputType(typeof(ITestConstant))]
    public class AddTmxTestConstantCommand : TestConstantCmdletBase
    {
        public AddTmxTestConstantCommand()
        {
        }
    }
}
