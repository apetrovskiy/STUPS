/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/31/2013
 * Time: 8:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
	using Tmx.Interfaces;
    using Tmx.Commands;
    
    /// <summary>
    /// Description of TmxGetTestResultStatusCommand.
    /// </summary>
    class TmxGetTestResultStatusCommand : TmxCommand
    {
        internal TmxGetTestResultStatusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (GetTmxTestResultStatusCommand)Cmdlet;
            
            // 20140721
            var dataObject = new TestResultCmdletBaseDataObject {
                Description = cmdlet.Description,
                Id = cmdlet.Id,
                KnownIssue = cmdlet.KnownIssue,
                TestOrigin = cmdlet.TestOrigin,
                TestResultName = cmdlet.TestResultName
            };
            
            // TmxHelper.GetCurrentTestResultStatus(cmdlet);
            // 20140722
            // TmxHelper.GetCurrentTestResultStatus(dataObject);
            cmdlet.WriteObject(TmxHelper.GetCurrentTestResultStatus(dataObject));
        }
    }
}
