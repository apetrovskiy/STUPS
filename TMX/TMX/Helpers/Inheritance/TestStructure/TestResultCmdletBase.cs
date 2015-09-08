/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 08:55 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    using Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultCmdletBase.
    /// </summary>
    public class TestResultCmdletBase : CommonCmdletBase
    {
        public TestResultCmdletBase()
        {
            // 20130330
            // 20150805
            // this.TestResultStatus = TestResultStatuses.NotTested;
            TestResultStatus = TestStatuses.NotRun;
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   Position = 0)]
        [Alias("Name")]
        public new string TestResultName { get; set; }

        [Parameter(Mandatory = false,
                   ParameterSetName = "EnumLogic")]
        // 20150805
        // public TestResultStatuses TestResultStatus { get; set; }
        public TestStatuses TestResultStatus { get; set; }
        [Parameter(Mandatory = false,
                   ParameterSetName = "DualLogic")]
        public new SwitchParameter TestPassed { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "DualLogic")]
        public new SwitchParameter KnownIssue { get; set; }
        
        [Parameter(Mandatory = false)]
        [AllowNull]
        [AllowEmptyString]
        public string Description { get; set; }
        
        [Parameter(Mandatory = false)]
        public TestResultOrigins TestOrigin { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        #endregion Parameters
        
        public void ConvertTestResultStatusToTraditionalTestResult()
        {
            // 20150805
            // if (TestResultStatuses.NotTested == TestResultStatus) return;
            if (TestStatuses.NotRun == TestResultStatus) return;
            switch (TestResultStatus) {
                // 20150805
                // case TestResultStatuses.Passed:
                case TestStatuses.Passed:
                    TestPassed = true;
                    break;
                // 20150805
                // case TestResultStatuses.Failed:
                case TestStatuses.Failed:
                    TestPassed = false;
                    break;
                // 20150805
                // case TestResultStatuses.NotTested:
                case TestStatuses.NotRun:
                    // nothing to do
                    // the impossible combination
                    break;
                // 20150805
                // case TestResultStatuses.KnownIssue:
                case TestStatuses.KnownIssue:
                    KnownIssue = true;
                    break;
                default:
                    //throw new Exception("Invalid value for TestResultStatuses");
                    break;
            }
        }
    }
}
