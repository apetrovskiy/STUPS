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
    /// <summary>
    /// Description of TLSrvGetTestCaseCommand.
    /// </summary>
    internal class TLSrvGetTestCaseCommand : TLSrvCommand
    {
        internal TLSrvGetTestCaseCommand(TLSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (GetTLTestCaseCommand)Cmdlet;
//------------------------------------ ??            
//            TLHelper.GetTestCase(
//                this.Cmdlet,
//                cmdlet.Name);
//=======

            if (null != cmdlet.InputObjectTestProject) {
                cmdlet.WriteVerbose(cmdlet, "getting test projects from the pipeline");
                TLHelper.GetTestCaseFromProject(cmdlet, cmdlet.InputObjectTestProject, cmdlet.TestCaseName);
                return;
            }
            if (null != cmdlet.InputObjectTestPlan) {
                cmdlet.WriteVerbose(cmdlet, "getting test plans from the pipeline");
                TLHelper.GetTestCaseFromTestPlan(cmdlet, cmdlet.InputObjectTestPlan, cmdlet.TestCaseName);
                return;
            }
            if (null != cmdlet.InputObjectTestSuite) {
                cmdlet.WriteVerbose(cmdlet, "getting test suites from the pipeline");
                TLHelper.GetTestCaseFromTestSuite(cmdlet, cmdlet.InputObjectTestSuite, cmdlet.TestCaseName, cmdlet.Recurse);
                return;
            }
            if (null != cmdlet.TestCaseName && 0 < cmdlet.TestCaseName.Length) {
                cmdlet.WriteVerbose(cmdlet, "getting test cases by name");
                TLHelper.GetTestCaseFromProject(cmdlet, cmdlet.InputObjectTestProject, cmdlet.TestCaseName);
                return;
            }
            if (null != TLAddinData.CurrentTestProject) {
                cmdlet.WriteVerbose(cmdlet, "getting test cases from the test project in the store");
                Meyn.TestLink.TestProject[] testProjects = { TLAddinData.CurrentTestProject };
                TLHelper.GetTestCaseFromProject(cmdlet, testProjects, cmdlet.TestCaseName);
                return;
            }
            if (null != TLAddinData.CurrentTestPlan) {
                cmdlet.WriteVerbose(cmdlet, "getting test cases from the test plan in the store");
                Meyn.TestLink.TestPlan[] testPlans = { TLAddinData.CurrentTestPlan };
                TLHelper.GetTestCaseFromTestPlan(cmdlet, testPlans, cmdlet.TestCaseName);
                return;
            }
            if (null != TLAddinData.CurrentTestSuite) {
                cmdlet.WriteVerbose(cmdlet, "getting test cases from the test suite in the store");
                Meyn.TestLink.TestSuite[] testSuites = { TLAddinData.CurrentTestSuite };
                TLHelper.GetTestCaseFromTestSuite(cmdlet, testSuites, cmdlet.TestCaseName, cmdlet.Recurse);
                return;
            }
        }
    }
}
