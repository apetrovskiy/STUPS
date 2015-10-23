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
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ShowUiaTaskManagerCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UiaTaskManager")]
    public class ShowUiaTaskManagerCommand : HotkeyCmdletBase
    {
        protected override void BeginProcessing()
        {
            keyCodes.Add(0x11);
            keyCodes.Add(0x10);
            keyCodes.Add(0x1B);
            processKeys();
        }
    }
}
