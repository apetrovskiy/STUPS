/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTmxTestSuiteStatusCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TmxTestSuiteStatus")]
    public class GetTmxTestSuiteStatusCommand : OpenSuiteCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        public SwitchParameter FilterOutAutomaticResults { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            var command = new TmxGetTestSuiteStatusCommand(this);
            command.Execute();
        }
    }
}
