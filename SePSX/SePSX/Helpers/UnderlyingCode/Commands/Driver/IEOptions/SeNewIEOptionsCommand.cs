/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 12:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    /// <summary>
    /// Description of SeNewIEOptionsCommand.
    /// </summary>
    internal class SeNewIeOptionsCommand : SeCommand
    {
        internal SeNewIeOptionsCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.GetNewIeOptions(Cmdlet);
        }
    }
}
