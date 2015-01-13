/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/26/2014
 * Time: 3:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils
{
    using System;
    using TestUtils.Commands;
    
    /// <summary>
    /// Description of NewScheduledTaskCommand.
    /// </summary>
    internal class NewScheduledTaskCommand : Win32Command
    {
        internal NewScheduledTaskCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (NewTuScheduledTaskCommand)Cmdlet;
            
            // ArchivingHelper.ExtractFromRarArchive(cmdlet);
        }
    }
}
