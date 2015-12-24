/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2012
 * Time: 3:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    
    /// <summary>
    /// Description of SeStartSafariCommand.
    /// </summary>
    internal class SeStartSafariCommand : SeWebDriverCommand
    {
        internal SeStartSafariCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.StartWebDriver((StartSeWebDriverCommand)Cmdlet);
        }
    }
}
