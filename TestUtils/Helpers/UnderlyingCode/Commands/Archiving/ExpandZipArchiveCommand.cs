/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/23/2013
 * Time: 3:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils
{
    using System;
    using System.Management.Automation;
    using TestUtils.Commands;
    
    /// <summary>
    /// Description of ExpandTuZipArchiveCommand.
    /// </summary>
    internal class ExpandZipArchiveCommand : Win32Command
    {
        internal ExpandZipArchiveCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (ExpandTuZipArchiveCommand)Cmdlet;
            
            ArchivingHelper.ExtractFromZipArchive(cmdlet);
        }
    }
}
