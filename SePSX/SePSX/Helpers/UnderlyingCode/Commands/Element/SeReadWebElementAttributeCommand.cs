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
    /// Description of SeReadWebElementAttributeCommand.
    /// </summary>
    internal class SeReadWebElementAttributeCommand : SeWebElementCommand
    {
        internal SeReadWebElementAttributeCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
//            SeHelper.GetWebElementAttribute(
//                ((ReadSeWebElementAttributeCommand)this.Cmdlet),
//                ((IWebElement[])((ReadSeWebElementAttributeCommand)this.Cmdlet).InputObject),
//                ((ReadSeWebElementAttributeCommand)this.Cmdlet).AttributeName);
            SeHelper.GetWebElementAttribute(
                this.Cmdlet,
                ((IWebElement[])((ReadSeWebElementAttributeCommand)this.Cmdlet).InputObject),
                ((ReadSeWebElementAttributeCommand)this.Cmdlet).AttributeName);
        }
    }
}
