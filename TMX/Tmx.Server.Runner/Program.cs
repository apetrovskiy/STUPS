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
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
    
    class Program
    {
        public static void Main(string[] args)
        {
            try {
                ServerControl.Port = 12340;
            ServerControl.Start(@"http://localhost:" + 12340);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException.Message);
            }
            Console.Write("Press any key to stop server . . . ");
            Console.ReadKey(true);
            ServerControl.Stop();
        }
    }
}