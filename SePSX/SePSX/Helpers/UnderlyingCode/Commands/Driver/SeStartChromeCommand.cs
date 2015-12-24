/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2012
 * Time: 3:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    
    /// <summary>
    /// Description of SeStartChromeCommand.
    /// </summary>
    internal class SeStartChromeCommand : SeWebDriverCommand
    {
        internal SeStartChromeCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
            //SeHelper.StartWebDriver((StartSeDriverServerCommand)this.Cmdlet);
            SeHelper.StartWebDriver((StartSeWebDriverCommand)Cmdlet);
        }
    }
}
