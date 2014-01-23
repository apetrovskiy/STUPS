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
    /// Description of TuExpandZipArchiveCommand.
    /// </summary>
    internal class TuExpandZipArchiveCommand : Win32Command
    {
        internal TuExpandZipArchiveCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            ExpandTuZipArchiveCommand cmdlet =
                (ExpandTuZipArchiveCommand)this.Cmdlet;
            
            ArchivingHelper.ExtractFromZipArchive(cmdlet);
        }
    }
}
