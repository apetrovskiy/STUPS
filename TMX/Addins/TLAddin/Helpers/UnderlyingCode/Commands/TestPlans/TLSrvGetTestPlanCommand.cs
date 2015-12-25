/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 7:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    /// <summary>
    /// Description of TLSrvGetTestPlanCommand.
    /// </summary>
    internal class TLSrvGetTestPlanCommand : TLSrvCommand
    {
        internal TLSrvGetTestPlanCommand(TLSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (TLGetTestPlanCmdletBase)Cmdlet;
            
            Meyn.TestLink.TestProject[] testProjects = null;
            
            if (null == ((TLGetTestPlanCmdletBase)Cmdlet).InputObject) {
cmdlet.WriteTrace(cmdlet, "null == ((TLTestPlanCmdletBase)this.Cmdlet).InputObject");
                Cmdlet.WriteVerbose(Cmdlet, "there is no TestProject in the pipeline");
                if (null == ((TLGetTestPlanCmdletBase)Cmdlet).TestProjectName) {
cmdlet.WriteTrace(cmdlet, "null == ((TLTestPlanCmdletBase)this.Cmdlet).TestProjectName");
                    if (null != TLAddinData.CurrentTestProject) {
cmdlet.WriteTrace(cmdlet, "null != TLAddinData.CurrentTestProject");
cmdlet.WriteTrace(cmdlet, "TLSrvGetTestPlanCommand: 0003");
                        Cmdlet.WriteVerbose(Cmdlet, "using the current project");
                        testProjects =
                            new Meyn.TestLink.TestProject[1]; //(){ TLAddinData.CurrentTestProject };
cmdlet.WriteTrace(cmdlet, "TLSrvGetTestPlanCommand: 0004");
                        testProjects[0] = TLAddinData.CurrentTestProject;
cmdlet.WriteTrace(cmdlet, "TLSrvGetTestPlanCommand: 0005a");
                    } else {
                        //error
cmdlet.WriteTrace(cmdlet, "TLSrvGetTestPlanCommand: 0005b");
                    }
                    
                } else {
cmdlet.WriteTrace(cmdlet, "TLSrvGetTestPlanCommand: 0010");
                    Cmdlet.WriteVerbose(Cmdlet, "getting projects via the -TestProjectName parameter value");
                    testProjects =
                        TLHelper.GetProjectsByName(Cmdlet, ((TLGetTestPlanCmdletBase)Cmdlet).TestProjectName);
cmdlet.WriteTrace(cmdlet, "TLSrvGetTestPlanCommand: 0011");
                }
            } else {
cmdlet.WriteTrace(cmdlet, "TLSrvGetTestPlanCommand: 0020");
                testProjects = ((TLGetTestPlanCmdletBase)Cmdlet).InputObject;
                
            }
cmdlet.WriteTrace(cmdlet, "TLSrvGetTestPlanCommand: 0031");
            if (null == ((TLGetTestPlanCmdletBase)Cmdlet).TestPlanName) {
cmdlet.WriteTrace(cmdlet, "TLSrvGetTestPlanCommand: 0032a");
                TLHelper.GetTestPlans(Cmdlet, testProjects);
                
                
                
                
                
                
cmdlet.WriteTrace(cmdlet, "TLSrvGetTestPlanCommand: 0033a");
            } else {
cmdlet.WriteTrace(cmdlet, "TLSrvGetTestPlanCommand: 0032b");
                TLHelper.GetTestPlan(
                    Cmdlet,
                    testProjects,
                    ((GetTLTestPlanCommand)Cmdlet).TestPlanName);
cmdlet.WriteTrace(cmdlet, "TLSrvGetTestPlanCommand: 0033b");
            }
        }
    }
}
