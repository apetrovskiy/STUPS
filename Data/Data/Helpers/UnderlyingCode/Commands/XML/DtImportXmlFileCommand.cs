/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 8:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using System;
    using System.Management.Automation;
	using PSTestLib;
    using Data.Commands;
    
    /// <summary>
    /// Description of DtImportXmlFileCommand.
    /// </summary>
    internal class DtImportXmlFileCommand : AbstractCommand
    {
        internal DtImportXmlFileCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (ImportDtXmlFileCommand)this.Cmdlet;
            
            XMLHelper.LoadXMLFile(cmdlet, cmdlet.InputObject, cmdlet.Path);
        }
    }
}
