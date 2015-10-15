/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2012
 * Time: 3:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    
    /// <summary>
    /// Description of SeStartInternetExplorer32Command.
    /// </summary>
    internal class SeStartInternetExplorer32Command : SeWebDriverCommand
    {
        internal SeStartInternetExplorer32Command(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
            //SeHelper.StartWebDriver((StartSeDriverServerCommand)this.Cmdlet);
            SeHelper.StartWebDriver((StartSeWebDriverCommand)Cmdlet);
        }
    }
}
