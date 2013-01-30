/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddTMXTestResultDetailCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TMXTestResultDetail")]
    public class AddTMXTestResultDetailCommand : CommonCmdletBase
    {
        public AddTMXTestResultDetailCommand()
        {
            if (null == TestData.TestSuites || 0 == TestData.TestSuites.Count) {
                TestData.InitTestData();
            }
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Id { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string TestResultDetail { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Echo { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            this.WriteVerbose(this, this.TestResultDetail);
            if (this.Echo) {

                WriteObject(this.TestResultDetail);
            }
            TMX.TestData.AddTestResultTextDetail(this.TestResultDetail);
        }
    }
}
