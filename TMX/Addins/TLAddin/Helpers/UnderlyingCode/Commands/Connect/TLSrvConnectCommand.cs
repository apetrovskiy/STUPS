/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    /// <summary>
    /// Description of TLSrvConnectCommand.
    /// </summary>
    internal class TLSrvConnectCommand : TLSrvCommand
    {
        internal TLSrvConnectCommand(TLSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TLHelper.ConnectTLServer(
                (TLSConnectCmdletBase)Cmdlet);
        }
    }
}
