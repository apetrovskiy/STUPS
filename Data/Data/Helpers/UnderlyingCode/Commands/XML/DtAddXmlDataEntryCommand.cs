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
    using System;
    using System.Management.Automation;
	using PSTestLib;
    using Data.Commands;
    
    /// <summary>
    /// Description of DtAddXmlDataEntryCommand.
    /// </summary>
    internal class DtAddXmlDataEntryCommand : AbstractCommand
    {
        internal DtAddXmlDataEntryCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (AddDtXmlDataEntryCommand)this.Cmdlet;
            
            XMLHelper.AddDataToXMLComparer(cmdlet, cmdlet.InputObject, cmdlet.XPath, cmdlet.Value);
        }
    }
}
