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
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUIAifUltraGridSelectionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAifUltraGridSelection")]
    public class GetUIAifUltraGridSelectionCommand : ULtraGridCmdletBase
    {
        #region Constructor
        public GetUIAifUltraGridSelectionCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = true)]
        internal new string[] ItemName { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            ifUltraGridProcessing(ifUltraGridOperations.getSelection);
        }
    }
}
