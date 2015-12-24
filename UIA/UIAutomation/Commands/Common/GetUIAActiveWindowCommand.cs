/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 06/02/2012
 * Time: 11:36 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    using Helpers.Commands;
    
    /// <summary>
    /// Description of GetUiaActiveWindowCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaActiveWindow")]
    public class GetUiaActiveWindowCommand : HasScriptBlockCmdletBase
    {
        protected override void BeginProcessing()
        {
//            IUiElement element =
//                GetActiveWindow();
//            
//            CurrentData.CurrentWindow = element;
//            WriteObject(this, element);
            
            var command =
                AutomationFactory.GetCommand<GetActiveWindowCommand>(this);
            command.Execute();
        }
    }
}
