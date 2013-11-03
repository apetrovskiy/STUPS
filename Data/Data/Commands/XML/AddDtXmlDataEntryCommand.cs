/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 8:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddDtXmlDataEntryCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "DtXmlDataEntry")]
    public class AddDtXmlDataEntryCommand : XMLCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string XPath { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string Value { get; set; }
        
        [Parameter(Mandatory = true,
                   ValueFromPipeline = true)]
        [ValidateNotNull()]
        public IXMLComparer InputObject { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            DtAddXmlDataEntryCommand command =
                new DtAddXmlDataEntryCommand(this);
            command.Execute();
        }
    }
}
