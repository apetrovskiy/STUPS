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
            //GetTLProjectCommand cmdlet =
            //    (GetTLProjectCommand)this.Cmdlet;
            TLProjectCmdletBase cmdlet =
                (TLProjectCmdletBase)this.Cmdlet;
            
            //if (null == this.Cmdlet.Name) { // || string.Empty == this.Cmdlet.Name) {
            if (null == cmdlet.Name) {
//Console.WriteLine("null == cmdlet.Name");
                //if (null == this.Cmdlet.Id) {
                if (null == cmdlet.Id) {
//Console.WriteLine("null == cmdlet.Id");
                    //this.Cmdlet.WriteVerbose(this.Cmdlet, "getting all projects");
                    cmdlet.WriteVerbose(cmdlet, "getting all projects");
                    //TLHelper.GetProjectCollection(this.Cmdlet);
                    TLHelper.GetProjectCollection(cmdlet);
                } else {
//Console.WriteLine("else 01");
                    //this.Cmdlet.WriteVerbose(this.Cmdlet, "getting specific projects by id");
                    cmdlet.WriteVerbose(cmdlet, "getting specific projects by id");
                    TLHelper.GetProjectById(
                        //this.Cmdlet,
                        cmdlet,
                        //this.Cmdlet.Name);
                        //((GetTLProjectCommand)this.Cmdlet).Id);
                        cmdlet.Id);
                }
            } else {
//Console.WriteLine("else 02 main");
                //this.Cmdlet.WriteVerbose(this.Cmdlet, "getting specific projects by name");
                cmdlet.WriteVerbose(cmdlet, "getting specific projects by name");
//Console.WriteLine(cmdlet.Name);
//Console.WriteLine(cmdlet.Name[0]);
                TLHelper.GetProjectByName(
                    //this.Cmdlet,
                    cmdlet,
                    //this.Cmdlet.Name);
                    //((GetTLProjectCommand)this.Cmdlet).Name);
                    cmdlet.Name);
            }
        }
    }
}
