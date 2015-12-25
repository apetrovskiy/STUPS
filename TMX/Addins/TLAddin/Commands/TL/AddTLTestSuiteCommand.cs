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
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddTLTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TLTestSuite")]
    public class AddTLTestSuiteCommand : TLTestSuiteCmdletBase
    {
        protected override void ProcessRecord()
        {
            var command = new TLSrvAddTestSuiteCommand(this);
            command.Execute();
        }
    }
}
