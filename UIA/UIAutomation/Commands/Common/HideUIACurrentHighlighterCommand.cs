/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/5/2013
 * Time: 2:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of HideUiaCurrentHighlighterCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Hide, "UiaCurrentHighlighter")]
    public class HideUiaCurrentHighlighterCommand : CommonCmdletBase
    {
        protected override void BeginProcessing()
        {
            UiaHelper.HideHighlighters();
        }
    }
}
