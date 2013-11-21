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
    /// Description of NewTmxTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TmxTestSuite")]
    public class NewTmxTestSuiteCommand : NewSuiteCmdletBase
    {
        public NewTmxTestSuiteCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TmxNewTestSuiteCommand command =
                new TmxNewTestSuiteCommand(this);
            command.Execute();
        }
    }
}
