/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of OpenTmxTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Open, "TmxTestSuite")]
    public class OpenTmxTestSuiteCommand : OpenSuiteCmdletBase
    {
        public OpenTmxTestSuiteCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TmxOpenTestSuiteCommand command =
                new TmxOpenTestSuiteCommand(this);
            command.Execute();
        }
    }
}
