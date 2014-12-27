/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2014
 * Time: 6:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils
{
    using System;
    using System.Management.Automation;
    using TestUtils.Commands;
    
    /// <summary>
    /// Description of ExpandTuRarArchiveCommand.
    /// </summary>
    internal class ExpandTuRarArchiveCommand : Win32Command
    {
        internal ExpandTuRarArchiveCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (ExpandTuRarArchiveCommand)Cmdlet;
            
            ArchivingHelper.ExtractFromRarArchive(cmdlet);
        }
    }
}
