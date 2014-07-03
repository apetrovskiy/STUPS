/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 1:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Linq;

namespace TMX
{
    using System;
    using System.Management.Automation;
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of TestExecCmdletBase.
    /// </summary>
    public class TestExecCmdletBase : CommonCmdletBase
    {
        public TestExecCmdletBase()
        {
        }
        
        public void RunTestSuite(
        	TestSuiteExecCmdletBase cmdlet,
        	ITestSuite testSuite)
        {
            foreach (ITestScenario testScenario in testSuite.TestScenarios.Where(testScenario => null != testScenario.TestCases && 0 < testScenario.TestCases.Count))
            {
                cmdlet.runTwoScriptBlockCollections(
                    testSuite.BeforeScenario,
                    null, // alternate scriptblocks
                    cmdlet,
                    testSuite.BeforeScenarioParameters);
                //}
	        	
                //if (null != testScenario.TestCases && 0 < testScenario.TestCases.Count) {
	        	    
                foreach (ITestCase testCase in testScenario.TestCases) {
	        	        
                    cmdlet.runTwoScriptBlockCollections(
                        testScenario.BeforeTest,
                        null, // alternate scriptblocks
                        cmdlet,
                        testScenario.BeforeTestParameters);
		        		
                    cmdlet.runTwoScriptBlockCollections(
                        testCase.TestCode,
                        null,
                        cmdlet,
                        testCase.TestCodeParameters);
		        		
                    cmdlet.runTwoScriptBlockCollections(
                        testScenario.AfterTest,
                        null, // alternate scriptblocks
                        cmdlet,
                        testScenario.AfterTestParameters);
		        		
                }
                //}
	        	
                // run AfterScenario scriptblocks
                //if (null != testScenario) {
                cmdlet.runTwoScriptBlockCollections(
                    testSuite.AfterScenario,
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
                testSuite.BeforeScenario,
                null, // alternate scriptblocks
                cmdlet,
                testSuite.BeforeScenarioParameters);
            //}
        	
            foreach (ITestCase testCase in testScenario.TestCases) {
                cmdlet.runTwoScriptBlockCollections(
                    testScenario.BeforeTest,
                    null, // alternate scriptblocks
                    cmdlet,
                    testScenario.BeforeTestParameters);
        		
                cmdlet.runTwoScriptBlockCollections(
                    testCase.TestCode,
                    null,
                    cmdlet,
                    testCase.TestCodeParameters);
        		
                cmdlet.runTwoScriptBlockCollections(
                    testScenario.AfterTest,
                    null, // alternate scriptblocks
                    cmdlet,
                    testScenario.AfterTestParameters);
            }
			
            // run AfterScenario scriptblocks
            //if (null != testSuite) {
            //if (null != testSuite && null != testScenario && 0 < testScenario.TestCases.Count) {
            cmdlet.runTwoScriptBlockCollections(
                testSuite.AfterScenario,
                null, // alternate scriptblocks
                cmdlet,
                testSuite.AfterScenarioParameters);
        }
        
        public void RunTestCase(
			TestCaseExecCmdletBase cmdlet,
			TestSuite testSuite,
			TestScenario testScenario)
		{
            
			ITestCase testCase =
			    TMX.TestData.GetTestCase(
			        testSuite,
			        string.Empty, //cmdlet.Name
			        cmdlet.Id,
			        testScenario.Name,
			        testScenario.Id,
			        testSuite.Name,
			        testSuite.Id,
			        testScenario.PlatformId);
			if (null == testCase) {
			    return;
			}
			
			// run BeforeScenario scriptblocks
			//if (null != testSuite) {
			if (null != testSuite && null != testScenario) {
				cmdlet.runTwoScriptBlockCollections(
					testSuite.BeforeScenario,
					null, // alternate scriptblocks
					cmdlet,
					testSuite.BeforeScenarioParameters);
			}
			
			// run BeforeTest scriptblocks
			if (null != testScenario) {
				cmdlet.runTwoScriptBlockCollections(
					testScenario.BeforeTest,
					null, // alternate scriptblocks
					cmdlet,
					testScenario.BeforeTestParameters);
			}
			
			// run TestCode scriptblocks
			cmdlet.runTwoScriptBlockCollections(
				//cmdlet.TestCode,
				testCase.TestCode,
				null,
				cmdlet,
				cmdlet.TestCodeParameters);
			
			// run AfterTest scriptblocks
			if (null != testScenario) {
				cmdlet.runTwoScriptBlockCollections(
					testScenario.AfterTest,
					null, // alternate scriptblocks
					cmdlet,
					testScenario.AfterTestParameters);
			}
			
			// run AfterScenario scriptblocks
			//if (null != testSuite) {
			if (null != testSuite && null != testScenario) {
				cmdlet.runTwoScriptBlockCollections(
					testSuite.AfterScenario,
					null, // alternate scriptblocks
					cmdlet,
					testSuite.AfterScenarioParameters);
			}
			
		}
    }
}
