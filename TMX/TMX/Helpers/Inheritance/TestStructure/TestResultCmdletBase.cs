/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 08:55 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TestResultCmdletBase.
    /// </summary>
    public class TestResultCmdletBase : CommonCmdletBase
    {
        public TestResultCmdletBase()
        {
            // 20130330
            this.TestResultStatus = TestResultStatuses.NotTested;
        }
        
        #region Parameters
        // 20130325
        //[Parameter(Mandatory = true,
        //           Position = 0)]
        // 20130330
        // 20130401
        //[Parameter(Mandatory = false)]
        [Parameter(Mandatory = false,
                   Position = 0)]
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "DualLogic")]
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "EnumLogic")]
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "DefaultLogicName")]
        // 20130325
        //[ValidateNotNullOrEmpty]
        [Alias("Name")]
        // 20130325
        //public override string TestResultName { get; set; }
        public new string TestResultName { get; set; }
        
        // 20130330
        [Parameter(Mandatory = false,
                   ParameterSetName = "EnumLogic")]
        public TestResultStatuses TestResultStatus { get; set; }
        // 20130325
        //[Parameter(Mandatory = false)]
        // 20130330
        //[Parameter(Mandatory = false,
        //           Position = 0)]
        [Parameter(Mandatory = false,
                   ParameterSetName = "DualLogic")]
        public new SwitchParameter TestPassed { get; set; }
        
        // 20130330
        //[Parameter(Mandatory = false)]
        [Parameter(Mandatory = false,
                   ParameterSetName = "DualLogic")]
        public new SwitchParameter KnownIssue { get; set; }
        
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Echo { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        public new SwitchParameter TestLog { get; set; }
        
        [Parameter(Mandatory = false)]
        [AllowNull]
        [AllowEmptyString]
        public string Description { get; set; }
        
        // 20130626
        // 20130627
        //[Parameter(Mandatory = false)]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "DualLogic")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "EnumLogic")]
        [Parameter(Mandatory = false)]
        public TestResultOrigins TestOrigin { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        
//        [Parameter(Mandatory = false)]
//        public new string TestResultId { get; set; }
        #endregion Parameters
        
        public void ConvertTestResultStatusToTraditionalTestResult()
        {
            if (TestResultStatuses.NotTested != this.TestResultStatus) {
                
                switch (this.TestResultStatus) {
                    case TestResultStatuses.Passed:
                        this.TestPassed = true;
                        break;
                    case TestResultStatuses.Failed:
                        this.TestPassed = false;
                        break;
                    case TestResultStatuses.NotTested:
                        // nothing to do
                        // the impossible combination
                        break;
                    case TestResultStatuses.KnownIssue:
                        this.KnownIssue = true;
                        break;
                    default:
                        //throw new Exception("Invalid value for TestResultStatuses");
                        break;
                }
            }
        }
    }
}
