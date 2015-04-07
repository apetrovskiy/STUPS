/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/26/2014
 * Time: 6:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Runner
{
    using System;
    using System.ServiceProcess;
    using System.Threading;

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
            /*
            try
            {
                ServerControl.Port = 12340;
                ServerControl.Start(@"http://localhost:" + 12340);

                if (!Environment.UserInteractive)
                {
                    var services = new ServiceBase[] { new ServiceControl() };
                    ServiceBase.Run(services);
                }
                else
                {
                    var service = new ServiceControl();
                    Thread.Sleep(Timeout.Infinite);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException.Message);
            }
            Console.Write(@"Press any key to stop server . . . ");
            Console.ReadKey(true);
            ServerControl.Stop();
            */
        }
    }
}