/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/1/2013
 * Time: 1:17 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    /// <summary>
    /// Description of RMSrvCommand.
    /// </summary>
    public abstract class RMSrvCommand
    {
        public RMSrvCommand(RMCmdletBase cmdlet)
        {
            Cmdlet = cmdlet;
        }
        
        internal RMCmdletBase Cmdlet { get; set; }
        internal abstract void Execute();
    }
}
