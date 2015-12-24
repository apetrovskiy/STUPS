/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    using Meyn.TestLink;
    
    /// <summary>
    /// Description of TLSrvGetTestSuiteCommand.
    /// </summary>
    internal class TLSrvGetTestSuiteCommand : TLSrvCommand
    {
        internal TLSrvGetTestSuiteCommand(TLSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (TLTestSuiteCmdletBase)Cmdlet;
            
            if (null != cmdlet.InputObjectTestProject) {
                cmdlet.WriteVerbose(cmdlet, "getting test projects from the pipeline");
                TLHelper.GetTestSuiteFromProject(cmdlet, cmdlet.InputObjectTestProject);
                return;
            }
            if (null != cmdlet.InputObjectTestPlan) {
                cmdlet.WriteVerbose(cmdlet, "getting test plans from the pipeline");
                TLHelper.GetTestSuiteFromTestPlan(cmdlet, cmdlet.InputObjectTestPlan);
                return;
            }
            if (null != cmdlet.InputObjectTestSuite) {
                cmdlet.WriteVerbose(cmdlet, "getting test suites from the pipeline");
                TLHelper.GetTestSuiteFromTestSuite(cmdlet, cmdlet.InputObjectTestSuite);
                return;
            }
            // 20130215
            //if (null != ((TLTestSuiteCmdletBase)this.Cmdlet).TestSuiteName &&
            if (null != cmdlet.TestSuiteName && 0 < cmdlet.TestSuiteName.Length) {
                // 20130215
                //0 < ((TLTestSuiteCmdletBase)this.Cmdlet).TestSuiteName.Length) {
                cmdlet.WriteVerbose(cmdlet, "getting test suites by name");
                // 20130215
                //TLHelper.GetTestSuite(cmdlet, ((TLTestSuiteCmdletBase)this.Cmdlet).TestSuiteName);
                TLHelper.GetTestSuite(cmdlet, cmdlet.TestSuiteName);
                return;
            }
            if (null != TLAddinData.CurrentTestProject) {
                cmdlet.WriteVerbose(cmdlet, "getting test suites from the test project in the store");
                Meyn.TestLink.TestProject[] testProjects = { TLAddinData.CurrentTestProject };
                TLHelper.GetTestSuiteFromProject(cmdlet, testProjects);
                return;
            }
            if (null != TLAddinData.CurrentTestPlan) {
                cmdlet.WriteVerbose(cmdlet, "getting test suites from the test plan in the store");
                Meyn.TestLink.TestPlan[] testPlans = { TLAddinData.CurrentTestPlan };
                TLHelper.GetTestSuiteFromTestPlan(cmdlet, testPlans);
                return;
            }
            if (null != TLAddinData.CurrentTestSuite) {
                cmdlet.WriteVerbose(cmdlet, "getting test suites from the test suite in the store");
                Meyn.TestLink.TestSuite[] testSuites = { TLAddinData.CurrentTestSuite };
                TLHelper.GetTestSuiteFromTestSuite(cmdlet, testSuites);
                return;
            }
//            if (null = cmdlet.TestProjectName) {
//                
//            }
//            TLHelper.GetTestSuite(this.Cmdlet, this.Cmdlet.Name);
        }
    }
}
