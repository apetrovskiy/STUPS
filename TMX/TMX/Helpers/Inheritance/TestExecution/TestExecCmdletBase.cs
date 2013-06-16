/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 1:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
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
        	
        	foreach (ITestScenario testScenario in testSuite.TestScenarios) {
        		
	        	// run BeforeScenario scriptblocks
				//if (null != testScenario) {
				if (null != testScenario.TestCases && 0 < testScenario.TestCases.Count) {
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
        }
        
        public void RunTestScenario(
        	TestScenarioExecCmdletBase cmdlet,
        	ITestSuite testSuite,
        	ITestScenario testScenario)
        {
        	// run BeforeScenario scriptblocks
			//if (null != testSuite) {
			if (null != testSuite && null != testScenario && 0 < testScenario.TestCases.Count) {
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
        }
        
        public void RunTestCase(
			TestCaseExecCmdletBase cmdlet,
			TestSuite testSuite,
			TestScenario testScenario)
		{
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
				cmdlet.TestCode,
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
