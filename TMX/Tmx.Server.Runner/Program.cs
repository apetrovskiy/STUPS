/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/26/2014
 * Time: 6:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Runner
{
    using System;
    using System.Net;
    using System.Net.NetworkInformation;
    
    class Program
    {
        public static void Main(string[] args)
        {
            ServerControl.Start(@"http://localhost:" + 12340);
            
//            if (null != args && 0 < args.Length) {
//                if (null != args[0])
//                    Console.WriteLine("Starting {0}", args[0]);
//                    ServerControl.Start(args[0]);
//            } else {
//                var hostname = Dns.GetHostName();
//                if (string.Empty != IPGlobalProperties.GetIPGlobalProperties().DomainName) {
//                    hostname += ".";
//                    hostname += IPGlobalProperties.GetIPGlobalProperties().DomainName;
//                }
//                // ServerControl.Start(hostname, 12340);
//                Console.WriteLine("Starting http://{0}:{1}/", hostname, 12340);
//                ServerControl.Start(@"http://" + hostname + ":" + 12340);
//            }
            
//Console.WriteLine(hostname);
//            
//            ServerControl.Start(hostname, 12340);
            
            Console.Write("Press any key to stop server . . . ");
            Console.ReadKey(true);
            ServerControl.Stop();
        }
    }
}