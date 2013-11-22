/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 30.11.2011
 * Time: 10:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUiaCurrentPatternFromPointCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCurrentPatternFromPoint")]
    [OutputType(typeof(object))]
    
    public class GetUiaCurrentPatternFromPointCommand : DiscoveryCmdletBase
    {
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            object result = null;
            result = UiaHelper.GetCurrentPatternFromPoint();
            WriteObject(this, result);
        }
    }
}
