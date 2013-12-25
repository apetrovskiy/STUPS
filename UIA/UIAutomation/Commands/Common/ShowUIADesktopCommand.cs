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
    extern alias UIANET;
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of ShowUiaDesktopCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UiaDesktop")]
    internal class ShowUiaDesktopCommand : HasScriptBlockCmdletBase
    {
        protected override void BeginProcessing()
        {
            try{
                // 20131109
                //AutomationElement showDesktopButton =
                // 20131209
                /*
                IUiElement showDesktopButton =
                    // 20131109
                    //AutomationElement.RootElement.FindFirst(
                    UiElement.RootElement.FindFirst(
                        TreeScope.Children,
                        new PropertyCondition(
                            AutomationElement.NameProperty,
                            "Show desktop"));
                */
                IUiElement showDesktopButton =
                    UiElement.RootElement.FindFirst(
                        TreeScope.Children,
                        new PropertyCondition(
                            AutomationElement.ClassNameProperty,
                            "TrayShowDesktopButtonWClass"));
                
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                // 20131208
                // InvokePattern invPtrn =
                    // 20131208
                    // showDesktopButton.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                //    showDesktopButton.GetCurrentPattern<IInvokePattern, InvokePattern>(InvokePattern.Pattern) as InvokePattern;
                // invPtrn.Invoke();
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                IInvokePattern invPtrn =
                    showDesktopButton.GetCurrentPattern<IInvokePattern>(InvokePattern.Pattern);
                invPtrn.Invoke();
                /*
                InvokePattern invPtrn = 
                    showDesktopButton.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                invPtrn.Invoke();
                */
                WriteObject(this, true);
            }
            catch (Exception ee) {
                WriteObject(this, ee.Message);
                WriteObject(this, false);
            }
        }
    }
}
