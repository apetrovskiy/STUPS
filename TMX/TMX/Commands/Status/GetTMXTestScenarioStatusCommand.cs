/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTmxTestScenarioStatusCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TmxTestScenarioStatus")]
    public class GetTmxTestScenarioStatusCommand : OpenScenarioCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        public SwitchParameter FilterOutAutomaticResults { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            var command = new TmxGetTestScenarioStatusCommand(this);
            command.Execute();
        }
    }
}
