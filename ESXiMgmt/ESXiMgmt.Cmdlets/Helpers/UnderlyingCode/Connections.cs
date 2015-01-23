/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/3/2012
 * Time: 4:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets
{
    using System;
    using Tamir.SharpSsh;
    
    /// <summary>
    /// Description of Connections.
    /// </summary>
    public static class Connections
    {
        static Connections()
        {
            connections = 
                new System.Collections.Generic.List<ESXiConnection>();
        }
        
        private static System.Collections.Generic.List<ESXiConnection> connections { get; set; }
        
//        public static void Add(ESXiConnection connection)
//        {
//            connections.Add(connection);
//        }

        public static ESXiConnection Add(
            ESXiConnection connection,
            SshExec ssh)
        {
            connection.Ssh = ssh;
            connections.Add(connection);
            return connection;
        }
        
        public static ESXiConnection GetConnection(
            string serverName,
            int port,
            string username,
            string password)
        {
            ESXiConnection result = null;
            
            
            
            
            return result;
        }
    }
}
