/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08/02/2012
 * Time: 06:08 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUiaIfUltraGridRowCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaIfUltraGridRow")]
    public class GetUiaIfUltraGridRowCommand : ULtraGridCmdletBase
    {
        #region Constructor
        public GetUiaIfUltraGridRowCommand()
        {
        }
        #endregion Constructor
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            ifUltraGridProcessing(ifUltraGridOperations.GetItems);
        }
    }
}
