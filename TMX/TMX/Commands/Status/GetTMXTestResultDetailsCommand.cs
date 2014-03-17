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
    /// Description of GetTmxTestResultDetailsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TmxTestResultDetails")]
    public class GetTmxTestResultDetailsCommand : TestResultStatusCmdletBase //TestResultCmdletBase
    {
        public GetTmxTestResultDetailsCommand()
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
            TmxGetTestResultDetailsCommand command =
                // 20140315
                new TmxGetTestResultDetailsCommand(this);
                // new TmxGetTestResultDetailsCommand();
            command.Cmdlet = this;
            command.Execute();
        }
    }
}
