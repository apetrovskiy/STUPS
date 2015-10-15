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
    /// Description of SeReadWebElementTextCommand.
    /// </summary>
    internal class SeReadWebElementTextCommand : SeWebElementCommand
    {
        internal SeReadWebElementTextCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
//            SeHelper.GetWebElementText(
//                ((ReadSeWebElementTextCommand)this.Cmdlet),
//                ((IWebElement[])((ReadSeWebElementTextCommand)this.Cmdlet).InputObject));
            SeHelper.GetWebElementText(
                Cmdlet,
                ((IWebElement[])((ReadSeWebElementTextCommand)Cmdlet).InputObject));
        }
    }
}
