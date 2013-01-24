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
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUIACurrentPatternFromPointCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACurrentPatternFromPoint")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACurrentPatternFromPointCommand : DiscoveryCmdletBase
    {
        #region Constructor
        public GetUIACurrentPatternFromPointCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            object result = null;
            result = UIAHelper.GetCurrentPatternFromPoint();
            WriteObject(this, result);
        }
    }
}
