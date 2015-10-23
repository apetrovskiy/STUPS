/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/2/2012
 * Time: 2:15 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands.Common
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of ShowUiaDesktopCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UiaDesktop")]
    internal class ShowUiaDesktopCommand : HasScriptBlockCmdletBase
    {
        protected override void BeginProcessing()
        {
            try{
                var showDesktopButton =
                    UiElement.RootElement.FindFirst(
                        classic.TreeScope.Children,
                        new classic.PropertyCondition(
                            classic.AutomationElement.ClassNameProperty,
                            "TrayShowDesktopButtonWClass"));
                
                showDesktopButton.PerformInvoke();
                
                WriteObject(this, true);
            }
            catch (Exception ee) {
                WriteObject(this, ee.Message);
                WriteObject(this, false);
            }
        }
    }
}
