/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 8:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of CompareDtXmlDataCommand.
    /// </summary>
    [Cmdlet(VerbsData.Compare, "DtXmlData")]
    public class CompareDtXmlDataCommand : XMLCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true,
                   ValueFromPipeline = true)]
        [ValidateNotNull()]
        public IXMLComparer InputObject { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            DtCompareXmlDataCommand command =
                new DtCompareXmlDataCommand(this);
            command.Execute();
        }
    }
}
