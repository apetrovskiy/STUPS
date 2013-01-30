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
    /// Description of OpenTMXTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Open, "TMXTestSuite")]
    public class OpenTMXTestSuiteCommand : OpenSuiteCmdletBase
    {
        public OpenTMXTestSuiteCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TMXOpenTestSuiteCommand command =
                new TMXOpenTestSuiteCommand(this);
            command.Execute();
        }
    }
}
