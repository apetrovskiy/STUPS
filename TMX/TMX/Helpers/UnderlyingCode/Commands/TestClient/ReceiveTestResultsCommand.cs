/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/22/2014
 * Time: 8:41 PM
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
    /// Description of ReceiveTestResultsCommand.
    /// </summary>
    class ReceiveTestResultsCommand : TmxCommand
    {
        internal ReceiveTestResultsCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (ReceiveTmxTestResultsCommand)Cmdlet;
            // 20150918
            // var testResultsLoader = new TestResultsLoader(new RestRequestCreator());
            // var testResultsLoader = new TestResultsLoader();
            var testResultsLoader = ProxyFactory.Get<TestResultsLoader>();
            cmdlet.WriteObject(testResultsLoader.LoadTestResults());
        }
    }
}
