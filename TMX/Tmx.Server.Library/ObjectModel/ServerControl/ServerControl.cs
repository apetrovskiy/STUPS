/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 1:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.ObjectModel.ServerControl
{
    using Logic.ObjectModel.ServerControl;
    
    /// <summary>
    /// Description of ServerControl.
    /// </summary>
    public class ServerControl
    {
        public static int Port
        {
            get { return Settings.Port; }
            set { Settings.Port = value; }
        }
        
        public static void Start(string url)
        {
            InternalServerControl.Start(url);
        }
        
        public static void Start(string hostname, int port)
        {
            Port = port;
            InternalServerControl.Start(@"http://" + hostname + ":" + port);
        }
        
        public static void Stop()
        {
            InternalServerControl.Stop();
        }
        
        public static void Reset()
        {
            InternalServerControl.Reset();
        }
    }
}
