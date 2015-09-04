/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2012
 * Time: 10:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Commands
{
    using System.Management.Automation;
        
    /// <summary>
    /// Description of ReadESXiVMIdCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Read, "ESXiVMId")]
    public class ReadESXiVMIdCommand : ReadCmdletBase
    {
        public ReadESXiVMIdCommand()
        {
        }
    }
}
