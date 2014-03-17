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
    using System;
    using System.Management.Automation;
    using SePSX.Commands;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SeReadWebElementDisplayedCommand.
    /// </summary>
    internal class SeReadWebElementDisplayedCommand : SeWebElementCommand
    {
        internal SeReadWebElementDisplayedCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
//            SeHelper.GetWebElementIsDisplayed(
//                ((ReadSeWebElementDisplayedCommand)this.Cmdlet),
//                ((IWebElement[])((ReadSeWebElementDisplayedCommand)this.Cmdlet).InputObject));
            SeHelper.GetWebElementIsDisplayed(
                this.Cmdlet,
                ((IWebElement[])((ReadSeWebElementDisplayedCommand)this.Cmdlet).InputObject));
        }
    }
}
