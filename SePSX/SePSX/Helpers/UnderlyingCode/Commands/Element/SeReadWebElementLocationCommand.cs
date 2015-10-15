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
    /// Description of SeReadWebElementLocationCommand.
    /// </summary>
    internal class SeReadWebElementLocationCommand : SeWebElementCommand
    {
        internal SeReadWebElementLocationCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
//            SeHelper.GetWebElementLocation(
//                ((ReadSeWebElementLocationCommand)this.Cmdlet),
//                ((IWebElement[])((ReadSeWebElementLocationCommand)this.Cmdlet).InputObject));
            SeHelper.GetWebElementLocation(
                Cmdlet,
                ((IWebElement[])((ReadSeWebElementLocationCommand)Cmdlet).InputObject));
        }
    }
}
