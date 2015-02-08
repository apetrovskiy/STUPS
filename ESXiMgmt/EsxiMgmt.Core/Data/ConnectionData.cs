/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 7:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Core.Data
{
    using System;
    using System.Collections.Generic;
    using Renci.SshNet;
    
    /// <summary>
    /// Description of ConnectionData.
    /// </summary>
    public class ConnectionData
    {
        public static List<ConnectionInfo> Entries = new List<ConnectionInfo>();
        
        public static void Add(string hostname, string username, string password, string keyFilePath)
        {
            var connInfo = new ConnectionInfo(
                               hostname,
                               username,
                               new AuthenticationMethod[] {
                    new PasswordAuthenticationMethod(username, password),
                    new PrivateKeyAuthenticationMethod(
                        username,
                        new [] { new PrivateKeyFile(keyFilePath, password) }),
                });
            
            // TODO: refactoring in SD?
            // ConnectionData.Entries.Add(connInfo);
            Entries.Add(connInfo);
        }
    }
}
