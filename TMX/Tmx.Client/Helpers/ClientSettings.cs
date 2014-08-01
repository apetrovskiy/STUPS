/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2014
 * Time: 11:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of ClientSettings.
    /// </summary>
    // public static class ClientSettings
    public class ClientSettings
    {
        public static string ServerUrl { get; set; }
        public static int ClientId { get; set; }
        public static ITestTask CurrentTask { get; set; }
        public static bool StopImmediately { get; set; }
        
        public static void ResetData()
        {
			ClientId = 0;
			CurrentTask = null;
			ServerUrl = string.Empty;
			StopImmediately = false;
        }
    }
}
