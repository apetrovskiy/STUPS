/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2012
 * Time: 12:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
//    using System.Management.Automation;
    using TMX.Commands;
    using PSTestLib;
    
    /// <summary>
    /// Description of TmxCloseTestResultCommand.
    /// </summary>
    internal class TmxCloseTestResultCommand : AbstractCommand // : TmxCommand
    {
        internal TmxCloseTestResultCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        // internal override void Execute()
        public override void Execute()
        {
            var cmdlet =
                (CloseTmxTestResultCommand)this.Cmdlet;
            /*
            TMX.Commands.CloseTmxTestResultCommand cmdlet =
                (TMX.Commands.CloseTmxTestResultCommand)this.Cmdlet;
            */
            
            cmdlet.ConvertTestResultStatusToTraditionalTestResult();
                
            cmdlet.WriteVerbose(cmdlet, 
                              cmdlet.Name + ", Id = " +
                              cmdlet.Id + ", Status = " +
                              cmdlet.TestPassed.ToString());
            if (cmdlet.Echo) {

                cmdlet.WriteObject(
                    cmdlet,
                    cmdlet.Name +
                    "\t" +
                    cmdlet.TestPassed.ToString());
            }
            string code = string.Empty;

            string testResultName = string.Empty;
            if (string.IsNullOrEmpty(cmdlet.Name) &&
                !string.IsNullOrEmpty(cmdlet.TestResultName)) {

                testResultName = cmdlet.TestResultName;

            }
            if (!string.IsNullOrEmpty(cmdlet.Name) &&
                string.IsNullOrEmpty(cmdlet.TestResultName)) {

                testResultName = cmdlet.Name;

            }
            if (!string.IsNullOrEmpty(cmdlet.TestResultName) &&
                !string.IsNullOrEmpty(cmdlet.Name)) {

                testResultName = cmdlet.TestResultName;

            }

            TmxHelper.CloseTestResult(
                testResultName,
                cmdlet.Id, 
                cmdlet.TestPassed, 
                cmdlet.KnownIssue,
                cmdlet.MyInvocation,
                null,
                cmdlet.Description,
                cmdlet.TestOrigin,
                true);
            
        }
    }
}
