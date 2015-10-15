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

    /// <summary>
    /// Description of SeStopWebDriverCommand.
    /// </summary>
    internal class SeStopWebDriverCommand : SeWebDriverCommand
    {
        internal SeStopWebDriverCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
            //SeHelper.StartWebDriver((StartSeDriverServerCommand)this.Cmdlet);
            throw new NotImplementedException();
        }
    }
}
