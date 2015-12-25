/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/23/2013
 * Time: 5:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewTuZipArchiveCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TuZipArchive")]
    public class NewTuZipArchiveCommand : ArchivingCmdletBase
    {
        public NewTuZipArchiveCommand()
        {
            PathInArchive = null;
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipeline = true)]
        //[ValidateNotNull()]
        [ValidateNotNullOrEmpty()]
        public string[] Filename { get; set; }
        
        [Parameter(Mandatory = false)]
        public string PathInArchive { get; set; }
        
        [Parameter(Mandatory = false)]
        public string ArchiveName { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Comment { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            var command = new NewZipArchiveCommand(this);
            command.Execute();
        }
    }
}
