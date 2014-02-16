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
    using System.Management.Automation;

    /// <summary>
    /// Description of InvokeUiaIfUltraGridSelectItemByNameCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiaIfUltraGridSelectItemByName")]
    public class InvokeUiaIfUltraGridSelectItemByNameCommand : ULtraGridCmdletBase
    {
        #region Constructor
        public InvokeUiaIfUltraGridSelectItemByNameCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        public int First { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            ifUltraGridProcessing(ifUltraGridOperations.SelectItems);
        }
    }
}
