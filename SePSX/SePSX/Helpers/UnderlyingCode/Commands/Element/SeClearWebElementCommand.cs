/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:30 PM
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
    /// Description of SeClearWebElementCommand.
    /// </summary>
    internal class SeClearWebElementCommand : SeWebElementCommand
    {
        internal SeClearWebElementCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
//            SeHelper.ClearWebElement(
//                ((ClearSeWebElementCommand)this.Cmdlet),
//                ((IWebElement[])((ClearSeWebElementCommand)this.Cmdlet).InputObject));
            SeHelper.ClearWebElement(
                this.Cmdlet,
                ((IWebElement[])((WebElementCmdletBase)this.Cmdlet).InputObject));
        }
    }
}
