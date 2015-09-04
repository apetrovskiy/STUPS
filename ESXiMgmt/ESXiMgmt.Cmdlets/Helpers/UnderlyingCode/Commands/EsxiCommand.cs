/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 8:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands
{
    /// <summary>
    /// Description of EsxiCommand.
    /// </summary>
    abstract class EsxiCommand
    {
        internal EsxiCommand(CommonCmdletBase cmdlet)
        {
            Cmdlet = cmdlet;
        }
        
        internal CommonCmdletBase Cmdlet { get; set; }
        internal abstract void Execute();
    }
}
