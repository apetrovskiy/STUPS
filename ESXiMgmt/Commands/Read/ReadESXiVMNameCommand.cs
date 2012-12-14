/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2012
 * Time: 10:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ESXiMgmt.Commands
{
    using System;
    using System.Management.Automation;
        
    /// <summary>
    /// Description of ReadESXiVMNameCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "ESXiVMName")]
    public class ReadESXiVMNameCommand : ReadCmdletBase
    {
        public ReadESXiVMNameCommand()
        {
        }
        
        
    }
}
