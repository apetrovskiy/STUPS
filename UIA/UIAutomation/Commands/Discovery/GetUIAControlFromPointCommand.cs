/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 30.11.2011
 * Time: 9:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    // test it
    //using System;
    using System.Management.Automation;
    // test it
    //using System.Runtime.CompilerServices;

    /// <summary>
    /// Description of GetUIAControlFromPoint.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlFromPoint")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlFromPointCommand : DiscoveryCmdletBase
    {
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            // 20131109
            //System.Windows.Automation.AutomationElement result = null;
            //result = 
            //    UIAHelper.GetAutomationElementFromPoint();
            IMySuperWrapper result =
                UIAHelper.GetAutomationElementFromPoint();
            
            this.WriteObject(this, result);
        }
    }
}
