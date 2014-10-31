/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/12/2014
 * Time: 6:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Linq;
    using Tmx.Client;
    using Tmx.Core;
//    using Tmx.Server;
    using Tmx.Commands;
    
    /// <summary>
    /// Description of GetTestCommonDataCommand.
    /// </summary>
    // TODO: fix it 20141030
    class GetCommonDataItemCommand : TmxCommand
    {
        internal GetCommonDataItemCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (GetTmxCommonDataItemCommand)Cmdlet;
            try {
                // cmdlet.WriteObject(CommonData.Data[cmdlet.Key]);
                // var commonData = TestRunQueue.TestRuns.First(testRun => testRun.Id == ClientsCollection
                cmdlet.WriteObject(ClientSettings.Instance.CommonData.Data[cmdlet.Key]);
            }
            catch (Exception e) {
                throw new Exception("Failed to get value with key '" + cmdlet.Key + "'. " + e.Message);
            }
        }
    }
}
