/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 5:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    /// <summary>
    /// Description of SeSetIEOptionCommand.
    /// </summary>
    internal class SeSetIeOptionCommand : SeCommand
    {
        internal SeSetIeOptionCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.SetIeOption(Cmdlet);
        }
    }
}
