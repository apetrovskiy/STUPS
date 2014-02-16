/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/02/2012
 * Time: 07:56 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUiaIfUltraGridSelectionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaIfUltraGridSelection")]
    public class GetUiaIfUltraGridSelectionCommand : ULtraGridCmdletBase
    {
        #region Constructor
        public GetUiaIfUltraGridSelectionCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true)]
        internal new string[] ItemName { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            ifUltraGridProcessing(ifUltraGridOperations.GetSelection);
        }
    }
}
