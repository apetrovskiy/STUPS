/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2013
 * Time: 3:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTMXTestResultDetailsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TMXTestResultDetails")]
    public class GetTMXTestResultDetailsCommand : TestResultStatusCmdletBase //TestResultCmdletBase
    {
        public GetTMXTestResultDetailsCommand()
        {
        }
        
        #region Parameters
//        [Parameter(Mandatory = false)]
//        internal new string TestResultName { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        internal new TestResultStatuses TestResultStatus { get; set; }
//
//        [Parameter(Mandatory = false)]
//        internal new SwitchParameter TestPassed { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        internal new SwitchParameter KnownIssue { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        internal new string Description { get; set; }
        
        //[Parameter(Mandatory = false)]
        //public TestResultStatuses[] TestResultStatus { get; set; }
        
        //[Parameter(Mandatory = false)]
        //public string Id { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            TMXGetTestResultDetailsCommand command =
                new TMXGetTestResultDetailsCommand(this);
            command.Execute();
        }
    }
}
