/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2014
 * Time: 9:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PSTestLib
{
    /// <summary>
    /// Description of Preferences.
    /// </summary>
    public static class Preferences
    {
        static Preferences()
        {
//Console.WriteLine("PS.Preferences 00");
            LogPath = 
                Environment.GetEnvironmentVariable(
                    "TEMP",
                    EnvironmentVariableTarget.User) + 
                @"\PSTestLib.log";
        }
        
        /// <summary>
        /// Path to the log file
        /// </summary>
        public static string LogPath { get; set; }
        
        public static bool Log { get; set; }
    }
}
