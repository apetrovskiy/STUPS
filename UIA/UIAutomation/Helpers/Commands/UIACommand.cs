/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2013
 * Time: 12:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    /// <summary>
    /// Description of UiaCommand.
    /// </summary>
    [UiaSpecialBinding]
    public abstract class UiaCommand
    {
        // 20140211
        // internal UiaCommand(CommonCmdletBase cmdlet)
        public UiaCommand(CommonCmdletBase cmdlet)
        {
            Cmdlet = cmdlet;
        }
        
        internal CommonCmdletBase Cmdlet { get; set; }
        public abstract void Execute();
    }
}
