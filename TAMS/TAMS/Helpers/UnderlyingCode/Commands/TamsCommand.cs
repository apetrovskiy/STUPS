/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/22/2013
 * Time: 10:00 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TAMS
{
    /// <summary>
    /// Description of TamsCommand.
    /// </summary>
    internal abstract class TamsCommand
    {
        internal TamsCommand(CommonCmdletBase cmdlet)
        {
            Cmdlet = cmdlet;
        }
        
        internal CommonCmdletBase Cmdlet { get; set; }
        internal abstract void Execute();
    }
}
