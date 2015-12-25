/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 8:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using Commands;
    
    /// <summary>
    /// Description of DtAddXmlDataEntryCommand.
    /// </summary>
    internal class DtAddXmlDataEntryCommand : DataCommand
    {
        internal DtAddXmlDataEntryCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (AddDtXmlDataEntryCommand)Cmdlet;
            
            XMLHelper.AddDataToXMLComparer(cmdlet, cmdlet.InputObject, cmdlet.XPath, cmdlet.Value);
        }
    }
}
