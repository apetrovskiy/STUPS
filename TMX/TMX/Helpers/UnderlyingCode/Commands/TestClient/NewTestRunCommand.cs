/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/29/2014
 * Time: 8:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using Client.Library.Helpers;
    using Client.Library.ObjectModel;
    using Commands;
    using Core.Proxy;

    /// <summary>
    /// Description of NewTestRunCommand.
    /// </summary>
    class NewTestRunCommand : TmxCommand
    {
        internal NewTestRunCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (NewTmxTestRunCommand)Cmdlet;
            // 20150918
            // var testRunCreator = new TestRunCreator(new RestRequestCreator());
            // var testRunCreator = new TestRunCreator();
            // var testRunCreator = new TestRunCreator();
            var testRunCreator = ProxyFactory.Get<TestRunCreator>();
            var result = testRunCreator.CreateTestRun(cmdlet.WorkflowName, cmdlet.Status, cmdlet.Name);
            cmdlet.WriteObject(cmdlet, result);
        }
    }
}
