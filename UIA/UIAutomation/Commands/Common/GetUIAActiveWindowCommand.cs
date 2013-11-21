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
    /// Description of GetUIAActiveWindowCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAActiveWindow")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAActiveWindowCommand : HasScriptBlockCmdletBase
    {
        protected override void BeginProcessing()
        {
            // 20131109
            //AutomationElement element = 
            IMySuperWrapper element =
                GetActiveWindow();
            //UIAutomation.CurrentData.CurrentWindow = element;
            CurrentData.CurrentWindow = element;
            this.WriteObject(this, element);
        }
    }
}
