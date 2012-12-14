/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 06/02/2012
 * Time: 11:36 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    // using System.Runtime.InteropServices;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of GetUIAActiveWindowCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAActiveWindow")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAActiveWindowCommand : HasScriptBlockCmdletBase
    {
        #region constructor
        public GetUIAActiveWindowCommand()
        {
        }
        #endregion constructor
        
        protected override void BeginProcessing()
        {
            AutomationElement element = 
                GetActiveWindow();
            UIAutomation.CurrentData.CurrentWindow = element;
            this.WriteObject(this, element);
        }
    }
}
