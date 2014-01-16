/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2012
 * Time: 9:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of GetUiaDesktopCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDesktop")]
    [OutputType(typeof(UIAutomation.IUiElement[]))] // [OutputType(typeof(object))]
    public class GetUiaDesktopCommand : GetCmdletBase
    {
        protected override void BeginProcessing()
        {
            CurrentData.CurrentWindow =
                UiElement.RootElement;
            
            WriteObject(this, UiElement.RootElement);
        }
    }
}
