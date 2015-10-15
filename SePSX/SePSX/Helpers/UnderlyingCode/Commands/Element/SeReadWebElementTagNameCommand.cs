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
    /// Description of SeReadWebElementTagNameCommand.
    /// </summary>
    internal class SeReadWebElementTagNameCommand : SeWebElementCommand
    {
        internal SeReadWebElementTagNameCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
//            SeHelper.GetWebElementTagName(
//                ((ReadSeWebElementTagNameCommand)this.Cmdlet),
//                ((IWebElement[])((ReadSeWebElementTagNameCommand)this.Cmdlet).InputObject));
            SeHelper.GetWebElementTagName(
                Cmdlet,
                ((IWebElement[])((ReadSeWebElementTagNameCommand)Cmdlet).InputObject));
        }
    }
}
