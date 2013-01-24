/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/3/2012
 * Time: 4:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ESXiMgmt
{
    using System;
    using Tamir.SharpSsh;
    
    /// <summary>
    /// Description of ESXiConnection.
    /// </summary>
    public class ESXiConnection
    {
        public ESXiConnection()
        {
        }
        
        public ESXiConnection(
           string server,
           int port,
           string username,
           string password)
        {
            this.Server = server;
            this.Port = port;
            this.Username = username;
            this.Password = password;
        }
        
        public ESXiConnection(
           string server,
           string username,
           string password)
        {
            this.Server = server;
            this.Port = 22;
            this.Username = username;
            this.Password = password;
        }
        
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DatastoreName { get; set; }
        public SshExec Ssh { get; set; }
    }
}
