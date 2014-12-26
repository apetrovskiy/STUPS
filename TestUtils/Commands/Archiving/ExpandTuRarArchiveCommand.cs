/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2014
 * Time: 6:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ExpandTuRarArchiveCommand.
    /// </summary>
    [Cmdlet(VerbsData.Expand, "TuRarArchive")]
    public class ExpandTuRarArchiveCommand : ExtractCmdletBase
    {
        protected override void ProcessRecord()
        {
            var command = new ExpandTuRarArchiveCommand(this);
            command.Execute();
        }
    }
}
