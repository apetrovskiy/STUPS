/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SeReadWebElementSelectedCommand.
    /// </summary>
    internal class SeReadWebElementSelectedCommand : SeWebElementCommand
    {
        internal SeReadWebElementSelectedCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
//            SeHelper.GetWebElementIsSelected(
//                ((ReadSeWebElementSelectedCommand)this.Cmdlet),
//                ((IWebElement[])((ReadSeWebElementSelectedCommand)this.Cmdlet).InputObject));
            SeHelper.GetWebElementIsSelected(
                Cmdlet,
                ((IWebElement[])((ReadSeWebElementSelectedCommand)Cmdlet).InputObject));
        }
    }
}
