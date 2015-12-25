/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 26.07.2012
 * Time: 9:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests.CheckCmdletParameters
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
            @"Import-Module '.\Tmx.dll' -Force;" +
            @"Import-Module '.\TLAddin.dll' -Force;";
    }
}
