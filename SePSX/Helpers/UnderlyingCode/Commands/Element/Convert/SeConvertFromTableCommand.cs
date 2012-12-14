/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 7:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SeConvertFromTableCommand.
    /// </summary>
    internal class SeConvertFromTableCommand : SeCommand
    {
        internal SeConvertFromTableCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.ConvertFromTable(this.Cmdlet);
        }
    }
}
