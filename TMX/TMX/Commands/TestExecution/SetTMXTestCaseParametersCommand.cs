/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/16/2013
 * Time: 2:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SetTmxTestCaseParametersCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "TmxTestCaseParameters")]
    public class SetTmxTestCaseParametersCommand : InvokeTmxTestCaseCommand
    {
        public SetTmxTestCaseParametersCommand()
        {
            OnlySetParameters = true;
        }
    }
}
