/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/23/2013
 * Time: 3:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ExpandTuZipArchiveCommand.
    /// </summary>
    [Cmdlet(VerbsData.Expand, "TuZipArchive")]
    public class ExpandTuZipArchiveCommand : ExtractCmdletBase
    {
//        #region Parameters
//        [Parameter(Mandatory = true,
//                   Position = 0,
//                   ValueFromPipeline = true)]
//        public string[] ArchiveName { get; set; }
//        
//        [Parameter(Mandatory = true)]
//        public string TargetFolder { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Overwrite { get; set; }
//        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            var command = new ExpandZipArchiveCommand(this);
            command.Execute();
        }
    }
}
