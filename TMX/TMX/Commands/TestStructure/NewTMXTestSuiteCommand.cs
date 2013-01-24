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
            
//            bool result = 
//                TMX.TMXHelper.NewTestSuite(this.Name, this.Id, this.Description);
//            if (result) {
//                WriteObject(TestData.CurrentTestSuite);
//            } else {
//                ErrorRecord err = 
//                    new ErrorRecord(new Exception("Couldn't create a test suite"),
//                                    "CreatingTestSuite",
//                                    ErrorCategory.InvalidOperation,
//                                    this.Name);
//                err.ErrorDetails = 
//                    new ErrorDetails(
//                        "Failed to create a test suite");
//                ThrowTerminatingError(err);
//            }
            
            
            TMXNewTestSuiteCommand command =
                new TMXNewTestSuiteCommand(this);
            command.Execute();
        }
    }
}
