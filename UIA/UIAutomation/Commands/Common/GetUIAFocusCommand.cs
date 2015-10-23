/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/16/2012
 * Time: 11:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUiaFocusCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaFocus")]
    public class GetUiaFocusCommand : HasControlInputCmdletBase
    {
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        // 20131109
        //internal new AutomationElement InputObject { get; set; }
        // 20131130
        internal new IUiElement InputObject { get; set; }
        /*
        internal new IUiElement InputObject { get; set; }
        */
        #endregion Parameters

        protected override void BeginProcessing()
        {
            // 20131109
            //this.WriteObject(this, AutomationElement.FocusedElement);
            // 20131111
            //this.WriteObject(this, new UiElement(AutomationElement.FocusedElement));
            // 20131112
            //this.WriteObject(this, ObjectsFactory.Kernel.Get<IUiElement>( new UiElement[] { UiElement.FocusedElement } ));
            WriteObject(this, UiElement.FocusedElement);
        }
    }
}
