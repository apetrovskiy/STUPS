/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2014
 * Time: 12:11 AM
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
    /// Description of ReceiveTestResportCommand.
    /// </summary>
    class ReceiveTestResportCommand : TmxCommand
    {
        internal ReceiveTestResportCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (ReceiveTmxTestReportCommand)Cmdlet;
            // 20150918
            // var testReportLoader = new TestReportLoader(new RestRequestCreator());
            // var testReportLoader = new TestReportLoader();
            var testReportLoader = ProxyFactory.Get<TestReportLoader>();
            cmdlet.WriteObject(testReportLoader.LoadTestReport());
        }
    }
}

