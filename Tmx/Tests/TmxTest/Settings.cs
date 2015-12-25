/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2012
 * Time: 10:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest
{
    /// <summary>
    /// Description of Settings.
    /// </summary>
    public static class Settings
    {
        static Settings()
        {
        }
        
        public static string RunspaceCommand = 
                        @"Import-Module '.\UIAutomation.dll' -Force;" + 
                        @"Import-Module '.\Tmx.dll' -Force;";
        
        public static string FileName { get { return @".\1.db3"; } }
        public static string DatabaseName { get { return @"001"; } }
    }
}
