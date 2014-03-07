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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
    
    using System.Linq;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of GetUiaCurrentPatternCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCurrentPattern")]
    [OutputType(typeof(object))]
    
    public class GetUiaCurrentPatternCommand : DiscoveryCmdletBase
    {
        #region Parameters
        //[ValidateNotNullOrEmpty()]
        //[UiaParameterNotUsed][Parameter(Mandatory = true, 
        //    ValueFromPipeline = true, 
        //    HelpMessage = "This is usually the output from Get-UiaControl" )] 
        //// 20131014
        ////public System.Windows.Automation.AutomationElement Control { get; set; }
        //public System.Windows.Automation.AutomationElement[] InputObject { get; set; }
        [UiaParameter][Parameter(Mandatory = true)]
        public string Name { get; set; }
        #endregion Parameters
        
        // 20131014
        // 20131109
        //System.Windows.Automation.AutomationElement _control = null;
        IUiElement _control = null;
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            
            object result = null; // ?
            
            if (!CheckAndPrepareInput(this)) { return; }
            
            // 20131014
            //this.WriteVerbose(this, _control.Current);
            
            // 20131014
            //this.WriteVerbose(this, 
            //             (_control.GetSupportedPatterns()).Length.ToString());
            
            // 20131109
            //foreach (System.Windows.Automation.AutomationElement element in this.InputObject) {
            // 20131113
            foreach (classic.AutomationPattern p in InputObject.SelectMany(element => element.GetSupportedPatterns()))
            {
                WriteVerbose(this, p.ProgrammaticName);
            }

            /*
            foreach (IUiElement element in this.InputObject) {
                foreach (System.Windows.Automation.AutomationPattern p in element.GetSupportedPatterns())
                {
                    this.WriteVerbose(this, p.ProgrammaticName);
                }
            }
            */

            // 20131014
            //foreach (System.Windows.Automation.AutomationPattern p in _control.GetSupportedPatterns())
            /*
            foreach (AutomationPattern p in this.InputObject.SelectMany(element => element.GetSupportedPatterns()))
            {
                this.WriteVerbose(this, p.ProgrammaticName);
            }
            */

            /*
            foreach (System.Windows.Automation.AutomationElement element in this.InputObject) {
                foreach (System.Windows.Automation.AutomationPattern p in element.GetSupportedPatterns())
                {
                    this.WriteVerbose(this, p.ProgrammaticName);
                }
            }
            */

            classic.AutomationPattern pattern = 
                UiaHelper.GetPatternByName(Name);
            // 20131209
            result =
                UiaHelper.GetCurrentPattern(ref _control,
                                            pattern);
            // result =
            //     _control.GetCurrentPattern(pattern);
            
            WriteVerbose(this, result);
            
            WriteObject(this, result);
        }
    }
}
