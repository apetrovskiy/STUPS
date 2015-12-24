/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 4:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
//    using System.Collections.Generic;
    using Helpers.Commands;
    
    /// <summary>
    /// Description of GetUiaWindow.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaWindow", DefaultParameterSetName = "UIA")]
    [OutputType(typeof(IUiElement[]))] // [OutputType(typeof(object))]
    public class GetUiaWindowCommand : GetWindowCmdletBase
    {
        #region Parameters
        #endregion Parameters

        protected internal bool TestMode { get; set; }
        
        protected override void BeginProcessing()
        {
            StartDate = DateTime.Now;
            
            CurrentData.SetCurrentWindow(null);
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            CheckCmdletParameters();
            
            var command = AutomationFactory.GetCommand<GetWindowCommand>(this);
            command.Execute();
        }
        
        protected override void EndProcessing()
        {
            try {
                OddRootElement = null;
            }
            catch (Exception eEndProcessing) {
                WriteVerbose(
                    this,
                    eEndProcessing.Message);
            }
        }
        
        protected override void StopProcessing()
        {
            WriteVerbose(this, "User interrupted");
            Wait = false;
        }
        
    }
}
