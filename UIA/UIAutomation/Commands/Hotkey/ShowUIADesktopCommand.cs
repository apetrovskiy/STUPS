/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/25/2012
 * Time: 10:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ShowUiaDesktopCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UiaDesktop")]
    public class ShowUiaDesktopCommand : HotkeyCmdletBase
    {
        protected override void BeginProcessing()
        {
            keyCodes.Add(0xE0);
            keyCodes.Add(0x5B);
            keyCodes.Add(0x44);
            processKeys();
        }
    }
}
