/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/25/2012
 * Time: 10:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ShowUIATaskManagerCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UIATaskManager")]
    public class ShowUIATaskManagerCommand : HotkeyCmdletBase
    {
        public ShowUIATaskManagerCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.keyCodes.Add(0x11);
            this.keyCodes.Add(0x10);
            this.keyCodes.Add(0x1B);
            this.processKeys();
        }
    }
}
