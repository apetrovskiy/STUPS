/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 5:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    /// <summary>
    /// Description of SeNewFirefoxProfileCommand.
    /// </summary>
    internal class SeNewFirefoxProfileCommand : SeCommand
    {
        internal SeNewFirefoxProfileCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.GetNewFirefoxProfile(Cmdlet);
        }
    }
}
