/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2012
 * Time: 10:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace MoqCmdlets
{
    /// <summary>
    /// Description of MoqCommand.
    /// </summary>
    internal abstract class MoqCommand
    {
        internal MoqCommand()
        {
        }
        
        internal MoqCommand(CommonCmdletBase cmdlet)
        {
        }
        
        internal CommonCmdletBase Cmdlet { get; set; }
        internal abstract void Execute();
    }
}
