/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2012
 * Time: 3:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using SePSX.Commands;
    
    /// <summary>
    /// Description of SeStartFirefoxCommand.
    /// </summary>
    internal class SeStartFirefoxCommand : SeWebDriverCommand
    {
        internal SeStartFirefoxCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            SeHelper.StartWebDriver((StartSeWebDriverCommand)this.Cmdlet);
        }
    }
}
