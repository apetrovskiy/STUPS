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
        [ValidateNotNullOrEmpty()]
        [Parameter(Mandatory = true, 
            ValueFromPipeline = true, 
            HelpMessage = "This is usually the output from Get-UIAControl" )] 
        public System.Windows.Automation.AutomationElement Control { get; set; }
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
        #endregion Parameters
        
        System.Windows.Automation.AutomationElement _control = null;
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            object result = null; // ?

            if (!this.CheckControl(this)) { return; }
            
            this.WriteVerbose(this, _control.Current);
            this.WriteVerbose(this, 
                         (_control.GetSupportedPatterns()).Length.ToString());
            foreach (System.Windows.Automation.AutomationPattern p in _control.GetSupportedPatterns())
            {
                this.WriteVerbose(this, p.ProgrammaticName);
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
