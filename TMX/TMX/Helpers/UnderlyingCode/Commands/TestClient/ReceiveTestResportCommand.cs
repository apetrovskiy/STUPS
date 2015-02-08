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
    using System;
    using Tmx.Client;
    using Tmx.Commands;
    
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
            var testReportLoader = new TestReportLoader(new RestRequestCreator());
            cmdlet.WriteObject(testReportLoader.LoadTestReport());
        }
    }
}

