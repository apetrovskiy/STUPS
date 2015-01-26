/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 8:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Core.ObjectModel
{
    using System;
    using Renci.SshNet;
    
    /// <summary>
    /// Description of CrossHostCodeRunner.
    /// </summary>
    public class CrossHostCodeRunner
    {
        public TResult Run<TRunner, TResult>(ConnectionInfo connectionInfo, string commandText, Func<TRunner, string, string, TResult> runnerFunc)
            where TRunner : new()
            where TResult : new()
        {
            var result = new TResult();
            
            using (var client = new SshClient(connectionInfo)) {
                client.Connect();
                
                using (var cmd = client.CreateCommand(commandText)) {
                    var executionResult = cmd.Execute();
                    result = runnerFunc.Invoke(new TRunner(), executionResult, connectionInfo.Host);
                }
                
               client.Disconnect();
            }
            
            return result;
        }
    }
}
