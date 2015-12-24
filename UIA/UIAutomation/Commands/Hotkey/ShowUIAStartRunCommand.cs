/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/25/2012
 * Time: 10:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ShowUiaStartRunCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UiaStartRun")]
    public class ShowUiaStartRunCommand : HotkeyCmdletBase
    {
        protected override void BeginProcessing()
        {
            keyCodes.Add(0xE0);
            keyCodes.Add(0x5B);
            keyCodes.Add(0x52);
            processKeys();
        }
    }
}
