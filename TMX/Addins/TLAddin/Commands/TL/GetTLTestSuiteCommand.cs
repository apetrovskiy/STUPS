/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTLTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TLTestSuite", DefaultParameterSetName = "TestProjectInput")]
    public class GetTLTestSuiteCommand : TLTestSuiteCmdletBase
    {
        protected override void ProcessRecord()
        {
            var command = new TLSrvGetTestSuiteCommand(this);
            command.Execute();
        }
    }
}
