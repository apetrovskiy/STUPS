/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TLSrvGetProjectCommand.
    /// </summary>
    internal class TLSrvGetProjectCommand : TLSrvCommand
    {
        internal TLSrvGetProjectCommand(TLSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TLProjectCmdletBase cmdlet =
                (TLProjectCmdletBase)this.Cmdlet;
            
            if (null == cmdlet.Name) {

                if (null == cmdlet.Id) {

                    cmdlet.WriteVerbose(cmdlet, "getting all projects");
                    TLHelper.GetProjectCollection(cmdlet);
                } else {

                    cmdlet.WriteVerbose(cmdlet, "getting specific projects by id");
                    TLHelper.GetProjectById(
                        cmdlet,
                        cmdlet.Id);
                }
            } else {

                cmdlet.WriteVerbose(cmdlet, "getting specific projects by name");

                TLHelper.GetProjectByName(
                    cmdlet,
                    cmdlet.Name);
            }
        }
    }
}
