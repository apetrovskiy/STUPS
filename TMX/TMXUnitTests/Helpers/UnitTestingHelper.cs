using System.Management.Automation;
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
	using TMX.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of UnitTestingHelper.
    /// </summary>
    public static class UnitTestingHelper
    {
        public static void PrepareUnitTestDataStore()
        {
            PSCmdletBase.UnitTestMode = true;
            if (0 < UnitTestOutput.Count)
				UnitTestOutput.Clear();
			TestData.ResetData();
        }
        
        #region TestSuite
        internal static ITestSuite GetNewTestSuite(
            string name,
            string id,
            string description)
        {

            var cmdlet = new NewSuiteCmdletBase();

			if (!string.IsNullOrEmpty(name))
				cmdlet.Name = name;
			if (!string.IsNullOrEmpty(id))
				cmdlet.Id = id;
			if (!string.IsNullOrEmpty(description))
				cmdlet.Description = description;
            
            var command = new TmxNewTestSuiteCommand(cmdlet);
            command.Execute();
            
            return (ITestSuite)(object)UnitTestOutput.LastOutput[0];
        }
        
        internal static ITestSuite GetExistingTestSuite(
            string name,
            string id)
        {

            var cmdlet = new OpenSuiteCmdletBase();

			if (!string.IsNullOrEmpty(name))
				cmdlet.Name = name;
			if (!string.IsNullOrEmpty(id))
				cmdlet.Id = id;
            
            var command = new TmxOpenTestSuiteCommand(cmdlet);
            command.Execute();
            
            return (ITestSuite)(object)UnitTestOutput.LastOutput[0];
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
            var cmdlet = new AddTmxTestScenarioCommand();

			if (!string.IsNullOrEmpty(name))
				cmdlet.Name = name;
			if (!string.IsNullOrEmpty(id))
				cmdlet.Id = id;
			if (!string.IsNullOrEmpty(description))
				cmdlet.Description = description;
            if (null == testSuite) {

				if (!string.IsNullOrEmpty(testSuiteName))
					cmdlet.TestSuiteName = testSuiteName;
				if (!string.IsNullOrEmpty(testSuiteId))
					cmdlet.TestSuiteId = testSuiteId;
                if ((string.IsNullOrEmpty(testSuiteName)) && (string.IsNullOrEmpty(testSuiteId)))
                    cmdlet.InputObject = TestData.CurrentTestSuite;
                
            } else {

                cmdlet.InputObject = (TestSuite)testSuite;
            }
            
            var command = new TmxAddTestScenarioCommand(cmdlet);
            command.Execute();
            
            return (ITestScenario)TMX.TestData.CurrentTestScenario;
        }
        
        internal static ITestScenario GetNewTestScenario(
            string name,
            string id,
            string description)
        {

            var cmdlet = new AddScenarioCmdletBase();

			if (!string.IsNullOrEmpty(name))
				cmdlet.Name = name;
			if (!string.IsNullOrEmpty(id))
				cmdlet.Id = id;
			if (!string.IsNullOrEmpty(description))
				cmdlet.Description = description;
            
            var command = new TmxAddTestScenarioCommand(cmdlet);
            command.Execute();
            
            return (ITestScenario)(object)UnitTestOutput.LastOutput[0];
        }
        
        // more parameters!
        internal static ITestResult CloseTestResult(TestResultStatuses codeStatus, bool logicStatus)
        {
            GetNewTestSuite("name", "id", "description");
            var cmdlet = new CloseTmxTestResultCommand();
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
            
            var command = new TmxCloseTestResultCommand(cmdlet);
            command.Execute();

            return TestData.CurrentTestResult;
        }
        
        internal static ITestResult SetTestResult(string testResultName, string testResultId)
        {
            GetNewTestSuite("name", "id", "description");

            var cmdlet = new SetTmxCurrentTestResultCommand();

            if (!string.IsNullOrEmpty(testResultName) &&
			             0 < testResultName.Length) {
                
                cmdlet.TestResultName = testResultName;
            }
            
            if (!string.IsNullOrEmpty(testResultId) &&
			             0 < testResultId.Length) {
                
                cmdlet.Id = testResultId;
            }

            var command = new TmxSetCurrentTestResultCommand(cmdlet);
            command.Execute();

            return TestData.CurrentTestResult;
        }
    }
}
