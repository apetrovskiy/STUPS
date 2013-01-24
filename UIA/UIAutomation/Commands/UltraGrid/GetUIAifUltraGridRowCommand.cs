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
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUIAifUltraGridRowCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAifUltraGridRow")]
    public class GetUIAifUltraGridRowCommand : ULtraGridCmdletBase
    {
        #region Constructor
        public GetUIAifUltraGridRowCommand()
        {
        }
        #endregion Constructor
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            ifUltraGridProcessing(ifUltraGridOperations.getItems);
        }
    }
}
