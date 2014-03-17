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
    /// Description of CloseTmxTestResultCommand.
    /// </summary>
    //V20130330
    //[Cmdlet(VerbsCommon.Close, "TmxTestResult")]
    [Cmdlet(VerbsCommon.Close, "TmxTestResult", DefaultParameterSetName = "DefaultLogicId")]
    public class CloseTmxTestResultCommand : TestResultCmdletBase
    {
        public CloseTmxTestResultCommand()
        {
            // 20130605
//            if (null == TestData.TestSuites || 0 == TestData.TestSuites.Count) {
//                TestData.InitTestData();
//            }
            this.Id =
                TMX.TestData.GetTestResultId();
            this.TestLog = TMX.Preferences.TestLog;
            this.KnownIssue = false;
            
            // 20130429
            if (TMX.Preferences.AutoEcho) {
                this.Echo = true;
            }
            
            // 20130626
            //this.TestOrigin = TestResultOrigins.Logical;
        }
        
        #region Parameters
//        [Parameter(Mandatory = false)]
//        public new SwitchParameter TestPassed { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        public new SwitchParameter KnownIssue { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Echo { get; set; }
        
        [Parameter(Mandatory = false)]
        public new SwitchParameter TestLog { get; set; }
        
//        [Parameter(Mandatory = false)]
//        [AllowNull]
//        [AllowEmptyString]
//        public string Description { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        internal new string Name { get; set; }
//        
//        [Parameter(Mandatory = true,
//                   Position = 0)]
//        [ValidateNotNullOrEmpty]
//        [Alias("Name")]
//        public override string TestResultName { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
                
            TmxCloseTestResultCommand command =
                new TmxCloseTestResultCommand(this);
                // new TmxCloseTestResultCommand() { Cmdlet = this };
            command.Execute();
        }
    }
}
