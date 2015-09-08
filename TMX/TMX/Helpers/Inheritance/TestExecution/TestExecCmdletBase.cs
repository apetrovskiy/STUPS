/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 1:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Linq;

namespace Tmx
{
    using System.Management.Automation;
    using Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestExecCmdletBase.
    /// </summary>
    public class TestExecCmdletBase : CommonCmdletBase
    {
        public void RunTestSuite(
            TestSuiteExecCmdletBase cmdlet,
            ITestSuite testSuite)
        {
            foreach (var testScenario in testSuite.TestScenarios.Where(testScenario => null != testScenario.TestCases && 0 < testScenario.TestCases.Count))
            {
                cmdlet.runTwoScriptBlockCollections(
                    // 20141211
                    // testSuite.BeforeScenario,
                    testSuite.BeforeScenario.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                    null, // alternate scriptblocks
                    cmdlet,
                    testSuite.BeforeScenarioParameters);
                //}
                
                //if (null != testScenario.TestCases && 0 < testScenario.TestCases.Count) {
                    
                foreach (ITestCase testCase in testScenario.TestCases) {
                        
                    cmdlet.runTwoScriptBlockCollections(
                        // 20141211
                        // testScenario.BeforeTest,
                        testScenario.BeforeTest.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                        null, // alternate scriptblocks
                        cmdlet,
                        testScenario.BeforeTestParameters);
                        
                    cmdlet.runTwoScriptBlockCollections(
                        // 20141211
                        // testCase.TestCode,
                        testCase.TestCode.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                        null,
                        cmdlet,
                        testCase.TestCodeParameters);
                        
                    cmdlet.runTwoScriptBlockCollections(
                        // 20141211
                        // testScenario.AfterTest,
                        testScenario.AfterTest.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                        null, // alternate scriptblocks
                        cmdlet,
                        testScenario.AfterTestParameters);
                        
                }
                //}
                
                // run AfterScenario scriptblocks
                //if (null != testScenario) {
                cmdlet.runTwoScriptBlockCollections(
                    // 20141211
                    // testSuite.AfterScenario,
                    testSuite.AfterScenario.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                    null, // alternate scriptblocks
                    cmdlet,
                    testSuite.AfterScenarioParameters);
            }
        }

        public void RunTestScenario(
            TestScenarioExecCmdletBase cmdlet,
            ITestSuite testSuite,
            ITestScenario testScenario)
        {
            // run BeforeScenario scriptblocks
            //if (null != testSuite) {
            // 20140208
            // if (null == testSuite || null == testScenario || 0 >= testScenario.TestCases.Count) return;
            if (null == testSuite || null == testScenario || 0 == testScenario.TestCases.Count) return;
            // if (null != testSuite && null != testScenario && 0 < testScenario.TestCases.Count) {

            cmdlet.runTwoScriptBlockCollections(
                // 20141211
                // testSuite.BeforeScenario,
                testSuite.BeforeScenario.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                null, // alternate scriptblocks
                cmdlet,
                testSuite.BeforeScenarioParameters);
            //}
            
            foreach (ITestCase testCase in testScenario.TestCases) {
                cmdlet.runTwoScriptBlockCollections(
                    // 20141211
                    // testScenario.BeforeTest,
                    testScenario.BeforeTest.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                    null, // alternate scriptblocks
                    cmdlet,
                    testScenario.BeforeTestParameters);
                
                cmdlet.runTwoScriptBlockCollections(
                    // 20141211
                    // testCase.TestCode,
                    testCase.TestCode.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                    null,
                    cmdlet,
                    testCase.TestCodeParameters);
                
                cmdlet.runTwoScriptBlockCollections(
                    // 20141211
                    // testScenario.AfterTest,
                    testScenario.AfterTest.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                    null, // alternate scriptblocks
                    cmdlet,
                    testScenario.AfterTestParameters);
            }
            
            // run AfterScenario scriptblocks
            //if (null != testSuite) {
            //if (null != testSuite && null != testScenario && 0 < testScenario.TestCases.Count) {
            cmdlet.runTwoScriptBlockCollections(
                // 20141211
                // testSuite.AfterScenario,
                testSuite.AfterScenario.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                null, // alternate scriptblocks
                cmdlet,
                testSuite.AfterScenarioParameters);
        }
        
        // 20140720
        public void RunTestCase(
            TestCaseExecCmdletBase cmdlet,
            // 20140720
//            TestSuite testSuite,
//            TestScenario testScenario)
            ITestSuite testSuite,
            ITestScenario testScenario)
        {
            
            var testCase =
                TestData.GetTestCase(
                    testSuite,
                    string.Empty, //cmdlet.Name
                    cmdlet.Id,
                    testScenario.Name,
                    testScenario.Id,
                    testSuite.Name,
                    testSuite.Id,
                    // 20141119
                    // testScenario.PlatformId);
                    testScenario.PlatformUniqueId);
            if (null == testCase) {
                return;
            }
            
            // run BeforeScenario scriptblocks
            //if (null != testSuite) {
            if (null != testSuite && null != testScenario) {
                cmdlet.runTwoScriptBlockCollections(
                    // 20141211
                    // testSuite.BeforeScenario,
                    testSuite.BeforeScenario.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                    null, // alternate scriptblocks
                    cmdlet,
                    testSuite.BeforeScenarioParameters);
            }
            
            // run BeforeTest scriptblocks
            if (null != testScenario) {
                cmdlet.runTwoScriptBlockCollections(
                    // 20141211
                    // testScenario.BeforeTest,
                    testScenario.BeforeTest.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                    null, // alternate scriptblocks
                    cmdlet,
                    testScenario.BeforeTestParameters);
            }
            
            // run TestCode scriptblocks
            cmdlet.runTwoScriptBlockCollections(
                //cmdlet.TestCode,
                // 20141211
                // testCase.TestCode,
                testCase.TestCode.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                null,
                cmdlet,
                cmdlet.TestCodeParameters);
            
            // run AfterTest scriptblocks
            if (null != testScenario) {
                cmdlet.runTwoScriptBlockCollections(
                    // 20141211
                    // testScenario.AfterTest,
                    testScenario.AfterTest.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                    null, // alternate scriptblocks
                    cmdlet,
                    testScenario.AfterTestParameters);
            }
            
            // run AfterScenario scriptblocks
            //if (null != testSuite) {
            if (null != testSuite && null != testScenario) {
                cmdlet.runTwoScriptBlockCollections(
                    // 20141211
                    // testSuite.AfterScenario,
                    testSuite.AfterScenario.Select(codeblock => ScriptBlock.Create(codeblock.Code)).ToArray(),
                    null, // alternate scriptblocks
                    cmdlet,
                    testSuite.AfterScenarioParameters);
            }
            
        }
    }
}
