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
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ShowUiaMetroCharmCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UiaMetroCharm")]
    public class ShowUiaMetroCharmCommand : HotkeyCmdletBase
    {
        protected override void BeginProcessing()
        {
            keyCodes.Add(0xE0);
            keyCodes.Add(0x5B);
            keyCodes.Add(0x43);
            processKeys();
        }
    }
}
