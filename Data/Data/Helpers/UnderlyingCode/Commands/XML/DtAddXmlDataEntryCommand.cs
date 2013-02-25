/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 2/25/2013
 * Time: 8:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using System;
    using System.Management.Automation;
    using Data.Commands;
    
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
            AddDtXmlDataEntryCommand cmdlet =
                (AddDtXmlDataEntryCommand)this.Cmdlet;
            
            XMLHelper.AddDataToXMLComparer(cmdlet, cmdlet.InputObject, cmdlet.XPath, cmdlet.Value);
        }
    }
}
