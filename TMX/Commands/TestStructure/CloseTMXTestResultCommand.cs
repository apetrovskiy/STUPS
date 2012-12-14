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
    /// Description of CloseTMXTestResultCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Close, "TMXTestResult")]
    public class CloseTMXTestResultCommand : TestResultCmdletBase //CmdletBase
    {
        public CloseTMXTestResultCommand()
        {
            // 20120926
            //if (TestData.TestSuites.Count == 0) {
            if (null == TestData.TestSuites || 0 == TestData.TestSuites.Count) {
                TestData.InitTestData();
            }
            this.Id =
                TMX.TestData.GetTestResultId();
            this.TestLog = TMX.Preferences.TestLog;
            this.KnownIssue = false;
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public SwitchParameter TestPassed { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter KnownIssue { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Echo { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter TestLog { get; set; }
        
        [Parameter(Mandatory = false)]
        [AllowNull]
        [AllowEmptyString]
        public string Description { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckParameters();
            
            this.WriteVerbose(this, 
                              this.Name + ", Id = " +
                              this.Id + ", Status = " +
                              this.TestPassed.ToString());
            if (this.Echo) {
                //WriteCommandDetail(this.TestResultDetail);
                WriteObject(this, this.Name + "\t" + this.TestPassed.ToString());
            }
            string code = string.Empty;
//            if (this.TestLog){
//                code = TMXHelper.GetInvocationInfo(this.MyInvocation);
//            }
            TMXHelper.CloseTestResult(
                this.Name, 
                this.Id, 
                this.TestPassed, 
                this.KnownIssue,
                this.MyInvocation,
                null,
                this.Description,
                false);
        }
    }
}
