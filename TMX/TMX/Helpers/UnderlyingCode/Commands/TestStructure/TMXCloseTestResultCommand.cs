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
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TMXCloseTestResultCommand.
    /// </summary>
    internal class TMXCloseTestResultCommand : TMXCommand
    {
        internal TMXCloseTestResultCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            TMX.Commands.CloseTMXTestResultCommand cmdlet =
                (TMX.Commands.CloseTMXTestResultCommand)this.Cmdlet;
            
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

            TMXHelper.CloseTestResult(
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
