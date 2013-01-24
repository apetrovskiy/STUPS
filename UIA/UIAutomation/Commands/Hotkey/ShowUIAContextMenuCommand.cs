/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/25/2012
 * Time: 10:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ShowUIAContextMenuCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UIAContextMenu")]
    public class ShowUIAContextMenuCommand : HotkeyCmdletBase
    {
        public ShowUIAContextMenuCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.keyCodes.Add(0x10);
            this.keyCodes.Add(0x79);
            this.processKeys();
        }
    }
}
