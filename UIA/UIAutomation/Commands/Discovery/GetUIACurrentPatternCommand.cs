/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 30/11/2011
 * Time: 10:12 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUIACurrentPatternCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACurrentPattern")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACurrentPatternCommand : DiscoveryCmdletBase
    {
        #region Constructor
        public GetUIACurrentPatternCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        //[ValidateNotNullOrEmpty()]
        //[Parameter(Mandatory = true, 
        //    ValueFromPipeline = true, 
        //    HelpMessage = "This is usually the output from Get-UIAControl" )] 
        //// 20131014
        ////public System.Windows.Automation.AutomationElement Control { get; set; }
        //public System.Windows.Automation.AutomationElement[] InputObject { get; set; }
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
        #endregion Parameters
        
        // 20131014
        System.Windows.Automation.AutomationElement _control = null;
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            
            object result = null; // ?
            
            if (!this.CheckControl(this)) { return; }
            
            // 20131014
            //this.WriteVerbose(this, _control.Current);
            
            // 20131014
            //this.WriteVerbose(this, 
            //             (_control.GetSupportedPatterns()).Length.ToString());
            
            // 20131014
            //foreach (System.Windows.Automation.AutomationPattern p in _control.GetSupportedPatterns())
            foreach (System.Windows.Automation.AutomationElement element in this.InputObject) {
                foreach (System.Windows.Automation.AutomationPattern p in element.GetSupportedPatterns())
                {
                    this.WriteVerbose(this, p.ProgrammaticName);
                }
            }
            
            System.Windows.Automation.AutomationPattern pattern = 
                UIAHelper.GetPatternByName(Name);
            
            result = 
                UIAHelper.GetCurrentPattern(ref _control,
                                            pattern);
            
            this.WriteVerbose(this, result);
            
            this.WriteObject(this, result);
        }
    }
}
