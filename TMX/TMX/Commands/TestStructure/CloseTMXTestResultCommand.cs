/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    using Tmx;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of CloseTmxTestResultCommand.
    /// </summary>
    //V20130330
    [Cmdlet(VerbsCommon.Close, "TmxTestResult", DefaultParameterSetName = "DefaultLogicId")]
    public class CloseTmxTestResultCommand : TestResultCmdletBase
    {
        public CloseTmxTestResultCommand()
        {
            // 20130605
//            if (null == TestData.TestSuites || 0 == TestData.TestSuites.Count) {
//                TestData.InitTestData();
//            }
            this.Id = TestData.GetTestResultId();
            this.TestLog = Preferences.TestLog;
            this.KnownIssue = false;
            this.Echo |= Preferences.AutoEcho;
            
            // 20130626
            //this.TestOrigin = TestResultOrigins.Logical;
            
            // 20140902
            TestOrigin = TestResultOrigins.Logical;
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public SwitchParameter Echo { get; set; }
        
        [Parameter(Mandatory = false)]
        public new SwitchParameter TestLog { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
                
            var command = new TmxCloseTestResultCommand(this);
            command.Execute();
        }
    }
}
