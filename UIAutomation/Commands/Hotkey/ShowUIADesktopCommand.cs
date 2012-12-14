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
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ShowUIADesktopCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UIADesktop")]
    public class ShowUIADesktopCommand : HotkeyCmdletBase
    {
        public ShowUIADesktopCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.keyCodes.Add(0xE0);
            this.keyCodes.Add(0x5B);
            this.keyCodes.Add(0x44);
            this.processKeys();
        }
    }
}
