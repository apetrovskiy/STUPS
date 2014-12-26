/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/26/2014
 * Time: 1:30 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Collections;
    using System.Management.Automation;
    using Tmx;
    
    /// <summary>
    /// Description of AddTmxTestTaskResultCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TmxTestTaskResult")]
    public class AddTmxTestTaskResultCommand : ClientCmdletBase
    {
//        [Parameter(Mandatory = true,
//                   Position = 0,
//                   ValueFromPipeline = true)]
//        [ValidateNotNull]
//        // public string[] Result { get; set; }
//        public Hashtable Result { get; set; }
        
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }
        
        [Parameter(Mandatory = true,
                   Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }
        
        protected override void BeginProcessing()
        {
            var command = new AddTestTaskResultCommand(this);
            command.Execute();
        }
    }
}
