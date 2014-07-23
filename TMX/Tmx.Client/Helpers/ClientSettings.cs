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
    }
}
