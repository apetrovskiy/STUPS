/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 8:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Commands.Connect
{
    using System;
    using System.Management.Automation;
    using EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Connect;
    
    /// <summary>
    /// Description of NewEsxiHostConnectionDataCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "EsxiHostConnectionData")]
    public class NewEsxiHostConnectionDataCommand : CommonCmdletBase
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Server { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Username { get; set; }
        
        [Parameter(Mandatory = true)]
        public string Password { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string KeyFilePath { get; set; }
        
        protected override void BeginProcessing()
        {
            var command = new NewHostConnectionDataCommand(this);
            command.Execute();
        }
    }
}
