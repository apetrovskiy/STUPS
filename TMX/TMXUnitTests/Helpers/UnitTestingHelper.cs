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
    using Tmx;
    using Tmx.Commands;
    using PSTestLib;
	// using Tmx.Core;
	using Tmx.Interfaces;
	using Tmx.Interfaces.TestStructure;
    
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
			// 20141117
			TestData.AlreadyInitialized = false;
			TestData.InitTestData();
        }
        
        #region TestSuite
        // internal static ITestSuite GetNewTestSuite(
        internal static object GetNewTestSuite(
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
            
            // 20140715
            // return (ITestSuite)(object)UnitTestOutput.LastOutput[0];
            var returnValue = (object)UnitTestOutput.LastOutput[0];
            if (returnValue is ITestSuite)
            	return returnValue as ITestSuite;
            if (returnValue is ErrorRecord)
            	return returnValue as ErrorRecord;
            return returnValue;
        }
        
        // internal static ITestSuite GetExistingTestSuite(
        internal static object GetExistingTestSuite(
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
            
            // 20140715
            // return (ITestSuite)(object)UnitTestOutput.LastOutput[0];
            var returnValue = (object)UnitTestOutput.LastOutput[0];
            if (returnValue is ITestSuite)
            	return returnValue as ITestSuite;
            if (returnValue is ErrorRecord)
            	return returnValue as ErrorRecord;
            return returnValue;
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
            
            return (ITestScenario)TestData.CurrentTestScenario;
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
                    // 20140715
                    // cmdlet.TestResultStatus = TestResultStatuses.Passed;
                    break;
                case TestResultStatuses.Failed:
                    cmdlet.TestPassed = false;
                    // 20140715
                    // cmdlet.TestResultStatus = TestResultStatuses.Failed;
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
            // 20140715
            // if (logicStatus)
            // 	cmdlet.TestResultStatus = TestResultStatuses.KnownIssue;
            
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
