/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 12:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    using SePSX.Commands;
    
    /// <summary>
    /// Description of SeReadWebDriverTitleCommand.
    /// </summary>
    internal class SeReadWebDriverTitleCommand : SeWebDriverCommand
    {
        internal SeReadWebDriverTitleCommand(CommonCmdletBase cmdlet) : base(cmdlet)
        {
        }
        
        internal override void Execute()
        {
//            SeHelper.GetTitle(
//                ((SeReadWebDriverTitleCommand)this.Cmdlet),
//                ((SeReadWebDriverTitleCommand)this.Cmdlet).InputObject);
            SeHelper.GetTitle(
                this.Cmdlet,
                ((HasWebDriverInputCmdletBase)this.Cmdlet).InputObject);
        }
    }
}
