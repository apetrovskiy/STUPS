/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 30.01.2012
 * Time: 11:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUIAifUltraGridSelectItemByNameCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAifUltraGridSelectItemByName")]
    public class InvokeUIAifUltraGridSelectItemByNameCommand : ULtraGridCmdletBase
    {
        #region Constructor
        public InvokeUIAifUltraGridSelectItemByNameCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public int First { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            ifUltraGridProcessing(ifUltraGridOperations.selectItems);
        }
    }
}
