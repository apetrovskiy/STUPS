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
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of HideUIACurrentHighlighterCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Hide, "UIACurrentHighlighter")]
    public class HideUIACurrentHighlighterCommand : CommonCmdletBase
    {
        public HideUIACurrentHighlighterCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            UIAHelper.HideHighlighters();
        }
    }
}
