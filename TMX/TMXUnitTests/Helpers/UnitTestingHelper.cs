/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 9:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxUnitTests
{
    using System;
    using TMX;
    using TMX.Commands;
    using PSTestLib;
    
    /// <summary>
    /// Description of UnitTestingHelper.
    /// </summary>
    public static class UnitTestingHelper
    {
        static UnitTestingHelper()
        {
        }
        
        public static void PrepareUnitTestDataStore()
        {
            PSCmdletBase.UnitTestMode = true;
            
            if (0 < PSTestLib.UnitTestOutput.Count) {

                PSTestLib.UnitTestOutput.Clear();
            }
            
            TMX.TestData.ResetData();
            
        }
        
        #region TestSuite
        internal static ITestSuite GetNewTestSuite(
            string name,
            string id,
            string description)
        {

            NewSuiteCmdletBase cmdlet =
                new NewSuiteCmdletBase();

            if (null != name && string.Empty != name) {
                cmdlet.Name = name;
            }
            if (null != id && string.Empty != id) {
                cmdlet.Id = id;
            }
            if (null != description && string.Empty != description) {
                cmdlet.Description = description;
            }
            
            TmxNewTestSuiteCommand command =
                new TmxNewTestSuiteCommand(cmdlet);
            command.Execute();
            
            return (ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0];
        }
        
        internal static ITestSuite GetExistingTestSuite(
            string name,
            string id)
        {

            OpenSuiteCmdletBase cmdlet =
                new OpenSuiteCmdletBase();

            if (null != name && string.Empty != name) {
                cmdlet.Name = name;
            }
            if (null != id && string.Empty != id) {
                cmdlet.Id = id;
            }
            
            TmxOpenTestSuiteCommand command =
                new TmxOpenTestSuiteCommand(cmdlet);
            command.Execute();
            
            return (ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0];
        }
        
        internal static string GetTestScenarioStatus(bool skipAutomatic)
        {
            TestData.SetScenarioStatus(skipAutomatic);

            return TestData.CurrentTestScenario.Status;
        }
        
        internal static string GetTestSuiteStatus(bool skipAutomatic)
        {
            TestData.SetSuiteStatus(skipAutomatic);

            return TestData.CurrentTestSuite.Status;
        }
        #endregion TestSuite
        
        internal static ITestScenario AddTestScenario(
            ITestSuite testSuite,
            string name,
            string id,
            string description,
            string testSuiteName,
            string testSuiteId)
        {
            AddTmxTestScenarioCommand cmdlet =
                new AddTmxTestScenarioCommand();

            if (null != name && string.Empty != name) {
                cmdlet.Name = name;
            }
            if (null != id && string.Empty != id) {
                cmdlet.Id = id;
            }
            if (null != description && string.Empty != description) {
                cmdlet.Description = description;
            }
            if (null == testSuite) {

                if (null != testSuiteName && string.Empty != testSuiteName) {

                    cmdlet.TestSuiteName = testSuiteName;
                }
                if (null != testSuiteId && string.Empty != testSuiteId) {

                    cmdlet.TestSuiteId = testSuiteId;
                }
                
                if ((null == testSuiteName || string.Empty == testSuiteName) && 
                    (null == testSuiteId || string.Empty == testSuiteId)) {

                    cmdlet.InputObject =
                        TestData.CurrentTestSuite;
                }
                
            } else {

                cmdlet.InputObject =
                    (TestSuite)testSuite;
            }
            
            TmxAddTestScenarioCommand command =
                new TmxAddTestScenarioCommand(cmdlet);
            command.Execute();
            
            return (ITestScenario)TMX.TestData.CurrentTestScenario;
        }
        
        internal static ITestScenario GetNewTestScenario(
            string name,
            string id,
            string description)
        {

            AddScenarioCmdletBase cmdlet =
                new AddScenarioCmdletBase();

            if (null != name && string.Empty != name) {
                cmdlet.Name = name;
            }
            if (null != id && string.Empty != id) {
                cmdlet.Id = id;
            }
            if (null != description && string.Empty != description) {
                cmdlet.Description = description;
            }
            
            TmxAddTestScenarioCommand command =
                new TmxAddTestScenarioCommand(cmdlet);
            command.Execute();
            
            return (ITestScenario)(object)PSTestLib.UnitTestOutput.LastOutput[0];
        }
        
        // more parameters!
        internal static ITestResult CloseTestResult(TestResultStatuses codeStatus, bool logicStatus)
        {
            GetNewTestSuite("name", "id", "description");

            CloseTmxTestResultCommand cmdlet =
                new CloseTmxTestResultCommand();

            cmdlet.TestResultName = "test result";

            switch (codeStatus) {
                case TestResultStatuses.Passed:
                    cmdlet.TestPassed = true;
                    break;
                case TestResultStatuses.Failed:
                    cmdlet.TestPassed = false;
                    break;
                case TestResultStatuses.NotTested:
                    // nothing to do
                    break;
//                case TestResultStatuses.KnownIssue:
//                    cmdlet.KnownIssue = true;
//                    break;
                default:
                    //nothing to do
                    break;
            }

            cmdlet.KnownIssue = logicStatus;
            
            TmxCloseTestResultCommand command =
                new TmxCloseTestResultCommand(cmdlet);
            command.Execute();

            return TMX.TestData.CurrentTestResult;
        }
        
        internal static ITestResult SetTestResult(string testResultName, string testResultId)
        {
            GetNewTestSuite("name", "id", "description");

            SetTmxCurrentTestResultCommand cmdlet =
                new SetTmxCurrentTestResultCommand();

            if (null != testResultName &&
                string.Empty != testResultName &&
                0 < testResultName.Length) {
                
                cmdlet.TestResultName = testResultName;
            }
            
            if (null != testResultId &&
                string.Empty != testResultId &&
                0 < testResultId.Length) {
                
                cmdlet.Id = testResultId;
            }

            TmxSetCurrentTestResultCommand command =
                new TmxSetCurrentTestResultCommand(cmdlet);
            command.Execute();

            return TMX.TestData.CurrentTestResult;
        }
    }
}
