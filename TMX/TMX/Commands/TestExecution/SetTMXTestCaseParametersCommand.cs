/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/16/2013
 * Time: 2:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SetTMXTestCaseParametersCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "TMXTestCaseParameters")]
    public class SetTMXTestCaseParametersCommand : InvokeTMXTestCaseCommand
    {
        public SetTMXTestCaseParametersCommand()
        {
            this.OnlySetParameters = true;
        }
    }
}
