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
    using System;
    using Tmx.Client;
    using Tmx.Commands;
    
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
            var testResultsLoader = new TestResultsLoader(new RestRequestCreator());
            cmdlet.WriteObject(testResultsLoader.LoadTestResults());
        }
    }
}
