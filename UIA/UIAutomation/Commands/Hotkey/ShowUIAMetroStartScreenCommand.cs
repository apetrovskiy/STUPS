/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/25/2012
 * Time: 9:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ShowUIAMetroStartScreenCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UIAMetroStartScreen")]
    public class ShowUIAMetroStartScreenCommand : HotkeyCmdletBase
    {
        public ShowUIAMetroStartScreenCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.keyCodes.Add(0xE0);
            this.keyCodes.Add(0x5B);
            this.processKeys();
        }
    }
}
