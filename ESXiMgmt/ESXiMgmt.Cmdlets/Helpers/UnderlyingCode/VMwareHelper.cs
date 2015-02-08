/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/30/2012
 * Time: 5:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

//namespace EsxiMgmt.Cmdlets
//{
//    using System;
//    //using Renci.SshNet;
//    using Tamir.SharpSsh;
//    
//    /// <summary>
//    /// Description of VMwareHelper.
//    /// </summary>
//    public static class VMwareHelper
//    {
//        static VMwareHelper()
//        {
//        }
//        
//        internal static ESXiConnection ConnectToServer(
//            ESXiConnection connection,
//            string serverName,
//            int port,
//            string username,
//            string password,
//            string datastoreName)
//        {
//            ESXiConnection result = null;
//            
////            using (var client =
////                   new SshClient(
////                       serverName, 
////                       port,
////                       username, 
////                       password))
////            {
////                client.Connect();
////                //client.Disconnect();
////                
////                result = client.IsConnected;
////            }
//////            result = client.IsConnected;
//            
//            if (connection != null ) {
//                serverName = connection.Server;
//                port = connection.Port;
//                username = connection.Username;
//                password = connection.Password;
//            }
//            //ESXiConnection connection = null;
//            connection = null;
//            if ((connection =  Connections.GetConnection(
//                    serverName,
//                    port,
//                    username,
//                    password)) == null) {
//            
//                SshExec exec = 
//                    new SshExec(
//                        serverName, 
//                        username, 
//                        password);
//    
//                System.IO.TextWriter standardWriter = 
//                    Console.Out;
//                System.IO.Stream stream = 
//                    new System.IO.MemoryStream();
//                System.IO.TextWriter writer = 
//                    new System.IO.StreamWriter(stream);
//                Console.SetOut(writer);
//                exec.Connect();
//                Console.SetOut(standardWriter);
//                
//                if (exec.Connected) {
//                    connection = 
//                        new ESXiConnection(
//                            serverName,
//                            port,
//                            username,
//                            password);
//                    result = Connections.Add(connection, exec);
//                    //result = true;
//                    
//                    //exec.Close();
//                }
//            }
//
////            while(true)
////            {
////                Console.Write("Enter a command to execute ['Enter' to cancel]: ");
////                string command = Console.ReadLine();
////                if(command=="")break;
////                string output = exec.RunCommand("ls");
////                //string output = shell..RunCommand("ls");
////                Console.WriteLine(output);
////            }
////            Console.Write("Disconnecting...");
////            exec.Close();
//            //shell.Close();
////            Console.WriteLine("Closed: OK");
//            
//            return result;
//        }
//        
//        
//    }
//}
