/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 8:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Connect
{
    using Core.Data;
    using Cmdlets.Commands.Connect;
    
    /// <summary>
    /// Description of NewHostConnectionDataCommand.
    /// </summary>
    class NewHostConnectionDataCommand : EsxiCommand
    {
        internal NewHostConnectionDataCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            Cmdlet.WriteObject(AddConnectionInfo());
        }
        
        internal bool AddConnectionInfo()
        {
            var cmdlet = (NewEsxiHostConnectionDataCommand)Cmdlet;
            
            ConnectionData.Add(
                cmdlet.Server,
                cmdlet.Username,
                cmdlet.Password,
                cmdlet.KeyFilePath);
            
            return true;
        }
    }
}
