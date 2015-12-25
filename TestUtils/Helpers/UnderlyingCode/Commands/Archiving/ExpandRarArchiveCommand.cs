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
    using Commands;
    
    /// <summary>
    /// Description of ExpandTuRarArchiveCommand.
    /// </summary>
    internal class ExpandRarArchiveCommand : Win32Command
    {
        internal ExpandRarArchiveCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (ExpandTuRarArchiveCommand)Cmdlet;
            
            ArchivingHelper.ExtractFromRarArchive(cmdlet);
        }
    }
}
