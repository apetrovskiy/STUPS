/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 01/12/2011
 * Time: 12:36 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of ConvertFromUiaListCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertFrom, "UiaList")]
    // disabled in the current release
    internal class ConvertFromUiaListCommand : ConvertCmdletBase
    {
        #region Parameters
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            //_control.SetFocus();
            
            // get headers
            
            // output headers
            
            // get rows
            
            // output rows
            
        }
        
// protected override void EndProcessing()
// {
//  //_control = null;
// }
    }
}
