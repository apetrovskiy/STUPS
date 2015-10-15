/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using Commands;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SeReadWebElementCssValueCommand.
    /// </summary>
    internal class SeReadWebElementCssValueCommand : SeWebElementCommand
    {
        internal SeReadWebElementCssValueCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
//            SeHelper.GetWebElementCSSValue(
//                ((ReadSeWebElementCssValueCommand)this.Cmdlet),
//                ((IWebElement[])((ReadSeWebElementCssValueCommand)this.Cmdlet).InputObject),
//                ((ReadSeWebElementCssValueCommand)this.Cmdlet).PropertyName);
            SeHelper.GetWebElementCssValue(
                Cmdlet,
                ((IWebElement[])((ReadSeWebElementCssValueCommand)Cmdlet).InputObject),
                ((ReadSeWebElementCssValueCommand)Cmdlet).PropertyName);
        }
    }
}
