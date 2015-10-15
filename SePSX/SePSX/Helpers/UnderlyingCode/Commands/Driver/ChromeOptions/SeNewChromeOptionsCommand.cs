/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/26/2012
 * Time: 8:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    /// <summary>
    /// Description of SeNewChromeOptionsCommand.
    /// </summary>
    internal class SeNewChromeOptionsCommand : SeCommand
    {
        internal SeNewChromeOptionsCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.GetNewChromeOptions(Cmdlet);
        }
    }
}
