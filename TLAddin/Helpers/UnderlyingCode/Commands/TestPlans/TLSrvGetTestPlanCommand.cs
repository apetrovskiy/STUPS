/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 7:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
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
            Meyn.TestLink.TestProject[] testProjects = null;
            
            //if (null == ((TLTestPlanCmdletBase)this.Cmdlet).TestPlanName) { // || string.Empty == this.Cmdlet.Name) {
            if (null == ((TLTestPlanCmdletBase)this.Cmdlet).InputObject) {
//Console.WriteLine("null == ((TLTestPlanCmdletBase)this.Cmdlet).InputObject");
                this.Cmdlet.WriteVerbose(this.Cmdlet, "there is no TestProject in the pipeline");
                if (null == ((TLTestPlanCmdletBase)this.Cmdlet).TestProjectName) {
//Console.WriteLine("null == ((TLTestPlanCmdletBase)this.Cmdlet).TestProjectName");
                    if (null != TLAddinData.CurrentTestProject) {
//Console.WriteLine("null != TLAddinData.CurrentTestProject");
                        this.Cmdlet.WriteVerbose(this.Cmdlet, "using the current project");
                        testProjects =
                            new Meyn.TestLink.TestProject[1]; //(){ TLAddinData.CurrentTestProject };
                        testProjects[0] = TLAddinData.CurrentTestProject;
                    } else {
                        //error
                    }
                    
                } else {
                    this.Cmdlet.WriteVerbose(this.Cmdlet, "getting projects via the -TestProjectName parameter value");
                    testProjects =
                        TLHelper.GetProjectsByName(this.Cmdlet, ((TLTestPlanCmdletBase)this.Cmdlet).TestProjectName);
                }
            } else {
                testProjects = ((TLTestPlanCmdletBase)this.Cmdlet).InputObject;
                
            }
            if (null == ((TLTestPlanCmdletBase)this.Cmdlet).TestPlanName) {
                TLHelper.GetTestPlans(this.Cmdlet, testProjects);
            } else {
                //TLHelper.GetTestPlan(this.Cmdlet, testProjects, ((TLTestPlanCmdletBase)this.Cmdlet).TestPlanName);
                TLHelper.GetTestPlan(
                    this.Cmdlet,
                    testProjects,
                    ((GetTLTestPlanCommand)this.Cmdlet).TestPlanName);
            }
        }
    }
}
