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
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ShowUiaContextMenuCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UiaContextMenu")]
    public class ShowUiaContextMenuCommand : HotkeyCmdletBase
    {
        protected override void BeginProcessing()
        {
            keyCodes.Add(0x10);
            keyCodes.Add(0x79);
            processKeys();
        }
    }
}
