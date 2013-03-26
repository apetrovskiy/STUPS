/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/25/2013
 * Time: 1:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TMXSetCurrentTestResultCommand.
    /// </summary>
    internal class TMXSetCurrentTestResultCommand : TMXCommand
    {
        internal TMXSetCurrentTestResultCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TestResultCmdletBase cmdlet =
                (TestResultCmdletBase)this.Cmdlet;
                
            cmdlet.WriteVerbose(
                cmdlet,
                "Checking the current test structure, creating the first test suite and scenario if needed");
            TestData.InitCurrentTestScenario();
            
            cmdlet.WriteVerbose(
                cmdlet,
                "Checking whether the current test result is fulfilled and must be added to the current test scenairo' results");
//Console.WriteLine("name in the Set-TMXCurrentTestResult = " + cmdlet.TestResultName);
//Console.WriteLine("name of the current = " + TestData.CurrentTestResult.Name);
            if (null != TestData.CurrentTestResult) {
//Console.WriteLine("null != TestData.CurrentTestResult");
                cmdlet.WriteVerbose(
                    cmdlet,
                    "The current test result is not null");

                if ((null != TestData.CurrentTestResult.Name &&
                     string.Empty != TestData.CurrentTestResult.Name) || // &&
                    //(null != TestData.CurrentTestResult.Id &&
                    //string.Empty != TestData.CurrentTestResult.Id) ||
                    (0 < TestData.CurrentTestResult.Details.Count)) {
                    
                    cmdlet.WriteVerbose(
                        cmdlet,
                        "Adding the current test result to the current test scenario' results");
                    
                    //TestData.CurrentTestScenario.TestResults.Add(TestData.CurrentTestResult);
                    // 20130326
                    TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1] = 
                        TestData.CurrentTestResult;
                } else {
                    
//Console.WriteLine("not adding the current test result to the collection");
                    
                }
                
                
                
            } else {
                
//Console.WriteLine(" current result is null");
            }
            
            cmdlet.WriteVerbose(
                cmdlet,
                "Creating the current test result for putting new data into it");
            
//Console.WriteLine("before setting a new current test result: TestData.CurrentTestResult.Name = " + TestData.CurrentTestResult.Name);
//Console.WriteLine("before setting a new current test result: TestData.CurrentTestResult.Id = " + TestData.CurrentTestResult.Id);
//Console.WriteLine("before setting a new current test result: TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Name = " + TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Name);
//Console.WriteLine("before setting a new current test result: TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Id = " + TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Id);
            TestData.CurrentTestResult =
                new TestResult(
                    TestData.CurrentTestScenario.Id,
                    TestData.CurrentTestSuite.Id);
//Console.WriteLine("after setting a new current test result: TestData.CurrentTestResult.Name = " + TestData.CurrentTestResult.Name);
//Console.WriteLine("after setting a new current test result: TestData.CurrentTestResult.Id = " + TestData.CurrentTestResult.Id);
//Console.WriteLine("after setting a new current test result: TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Name = " + TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Name);
//Console.WriteLine("after setting a new current test result: TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Id = " + TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Id);
            cmdlet.WriteVerbose(
                cmdlet,
                "Writing data to the current test result");
//Console.WriteLine("cmdlet.Id = " + cmdlet.Id);
            TMXHelper.SetCurrentTestResult(cmdlet);
            
        }
    }
}
