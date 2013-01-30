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
    /// Description of NewTMXTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TMXTestSuite")]
    public class NewTMXTestSuiteCommand : NewSuiteCmdletBase
    {
        public NewTMXTestSuiteCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TMXNewTestSuiteCommand command =
                new TMXNewTestSuiteCommand(this);
            command.Execute();
        }
    }
}
