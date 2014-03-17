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
    /// Description of SeReadWebElementSizeCommand.
    /// </summary>
    internal class SeReadWebElementSizeCommand : SeWebElementCommand
    {
        internal SeReadWebElementSizeCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
//            SeHelper.GetWebElementSize(
//                ((ReadSeWebElementSizeCommand)this.Cmdlet),
//                ((IWebElement[])((ReadSeWebElementSizeCommand)this.Cmdlet).InputObject));
            SeHelper.GetWebElementSize(
                this.Cmdlet,
                ((IWebElement[])((ReadSeWebElementSizeCommand)this.Cmdlet).InputObject));
        }
    }
}
