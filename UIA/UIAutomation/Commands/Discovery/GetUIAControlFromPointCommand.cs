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
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetUiaControlFromPoint.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaControlFromPoint")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUiaControlFromPointCommand : DiscoveryCmdletBase
    {
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            // 20131109
            //System.Windows.Automation.AutomationElement result = null;
            //result = 
            //    UiaHelper.GetAutomationElementFromPoint();
            IMySuperWrapper result =
                UiaHelper.GetAutomationElementFromPoint();
            
            this.WriteObject(this, result);
        }
    }
}
