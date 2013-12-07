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
    
    /// <summary>
    /// Description of GetUiaActiveWindowCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaActiveWindow")]
    
    public class GetUiaActiveWindowCommand : HasScriptBlockCmdletBase
    {
        protected override void BeginProcessing()
        {
            // 20131109
            //AutomationElement element = 
            IUiElement element =
                GetActiveWindow();
            //UIAutomation.CurrentData.CurrentWindow = element;
            CurrentData.CurrentWindow = element;
            WriteObject(this, element);
        }
    }
}
