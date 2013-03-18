/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 12:23 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of TestUIAControlStateCommand.
    /// </summary>
    // 20130130
    //[Cmdlet(VerbsDiagnostic.Test, "UIAControlState")]
    [Cmdlet(VerbsDiagnostic.Test, "UIAControlState", DefaultParameterSetName = "Search")]
    [OutputType(new[] { typeof(object) })]
    public class TestUIAControlStateCommand : GetControlStateCmdletBase
    {
        #region Constructor
        public TestUIAControlStateCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter]
        internal new int Timeout { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            bool result = 
                TestControlByPropertiesFromHashtable(
                    // 20130315
                    this.InputObject,
                    this.SearchCriteria,
                    Preferences.Timeout);
            if (result) {
                this.WriteObject(this, true);
            } else {
                this.WriteObject(this, false);
            }
        }
    }
}
