/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 8:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ImportDtXmlFileCommand.
    /// </summary>
    [Cmdlet(VerbsData.Import, "DtXmlFile")]
    public class ImportDtXmlFileCommand : XMLCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string Path { get; set; }

        [Parameter(Mandatory = true,
                   ValueFromPipeline = true)]
        [ValidateNotNull()]
        public IXMLComparer InputObject { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            DtImportXmlFileCommand command =
                new DtImportXmlFileCommand(this);
            command.Execute();
        }
    }
}
