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
    using Data.Commands;
    
    /// <summary>
    /// Description of DtImportXmlFileCommand.
    /// </summary>
    internal class DtImportXmlFileCommand : DataCommand
    {
        internal DtImportXmlFileCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (ImportDtXmlFileCommand)Cmdlet;
            
            XMLHelper.LoadXMLFile(cmdlet, cmdlet.InputObject, cmdlet.Path);
        }
    }
}
