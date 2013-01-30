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

            // 20121223
            string testResultName = string.Empty;
            if ((null == cmdlet.Name || string.Empty == cmdlet.Name) &&
                (null != cmdlet.TestResultName && string.Empty != cmdlet.TestResultName)) {
                
                testResultName = cmdlet.TestResultName;
            }
            if ((null != cmdlet.Name && string.Empty != cmdlet.Name) &&
                (null == cmdlet.TestResultName || string.Empty == cmdlet.TestResultName)) {
                
                testResultName = cmdlet.Name;
            }
            if ((null != cmdlet.TestResultName && string.Empty != cmdlet.TestResultName) &&
                (null != cmdlet.Name && string.Empty != cmdlet.Name)) {
                
                testResultName = cmdlet.TestResultName;
            }
            
            TMXHelper.CloseTestResult(
                // 20121223
                testResultName,
                cmdlet.Id, 
                cmdlet.TestPassed, 
                cmdlet.KnownIssue,
                cmdlet.MyInvocation,
                null,
                cmdlet.Description,
                false);
            
        }
    }
}
