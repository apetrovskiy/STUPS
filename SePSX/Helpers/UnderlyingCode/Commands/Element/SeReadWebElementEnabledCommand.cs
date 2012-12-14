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
    using System;
    using System.Management.Automation;
    using SePSX.Commands;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SeReadWebElementEnabledCommand.
    /// </summary>
    internal class SeReadWebElementEnabledCommand : SeWebElementCommand
    {
        internal SeReadWebElementEnabledCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
//            SeHelper.GetWebElementIsEnabled(
//                ((ReadSeWebElementEnabledCommand)this.Cmdlet),
//                ((IWebElement[])((ReadSeWebElementEnabledCommand)this.Cmdlet).InputObject));
            SeHelper.GetWebElementIsEnabled(
                this.Cmdlet,
                ((IWebElement[])((ReadSeWebElementEnabledCommand)this.Cmdlet).InputObject));
        }
    }
}
