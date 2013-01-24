/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using SePSX.Commands;
    
    /// <summary>
    /// Description of SeGetWebDriverCookiesCommand.
    /// </summary>
    internal class SeGetWebDriverCookiesCommand : SeWebDriverCommand
    {
        internal SeGetWebDriverCookiesCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
//            SeHelper.GetCookies(
//                ((SeGetWebDriverCookiesCommand)this.Cmdlet), 
//                ((SeGetWebDriverCookiesCommand)this.Cmdlet).InputObject);
            SeHelper.GetCookies(
                this.Cmdlet,
                ((HasWebDriverInputCmdletBase)this.Cmdlet).InputObject);
        }
    }
}
