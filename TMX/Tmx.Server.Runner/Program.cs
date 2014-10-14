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
//    using Tmx.Client;
//    using Spring.Rest.Client;
    
    class Program
    {
        public static void Main(string[] args)
        {
            ServerControl.Start(@"http://localhost:" + 12340);
            
            Console.Write("Press any key to stop server . . . ");
            Console.ReadKey(true);
            ServerControl.Stop();
        }
    }
}