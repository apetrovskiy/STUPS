/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 1:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeTMXTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TMXTestSuite")]
    public class InvokeTMXTestSuiteCommand : TestSuiteExecCmdletBase
    {
        public InvokeTMXTestSuiteCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TMXInvokeTestSuiteCommand command =
                new TMXInvokeTestSuiteCommand(this);
            command.Execute();
        }
        
//        protected override void BeginProcessing()
//        {
//            
//            ITestSuite testSuite =
//                TMX.TestData.GetTestSuite(this.Name, this.Id, this.TestPlatformId);
//            
//            Console.WriteLine("before scenario script: " + testSuite.BeforeScenario.ToString());
//            
//            if (null != this.BeforeScenarioParameters && 0 < this.BeforeScenarioParameters.Length) {
//                foreach (var beforeParam in this.BeforeScenarioParameters) {
//                    Console.WriteLine("before param: " + beforeParam);
//                }
//            }
//            
//            Console.WriteLine("after scenario script: " + testSuite.AfterScenario.ToString());
//            
//            if (null != this.AfterScenarioParameters && 0 < this.AfterScenarioParameters.Length) {
//                foreach (var afterParam in this.AfterScenarioParameters) {
//                    Console.WriteLine("before param: " + afterParam);
//                }
//            }
//        }
    }
}
