/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/21/2014
 * Time: 1:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
    /// <summary>
    /// Description of ServerControl.
    /// </summary>
    public class ServerControl
    {
        public static void Start(string url)
        {
            InternalServerControl.Start(url);
        }
        
        public static void Stop()
        {
            InternalServerControl.Stop();
        }
    }
}
