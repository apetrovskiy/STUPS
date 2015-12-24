/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/29/2012
 * Time: 9:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLibraryTest
{
    //using System;
    
    /// <summary>
    /// Description of Settings.
    /// </summary>
    public static class Settings
    {
        public const string RunspaceCommand = 
            @"Import-Module '.\UIAutomation.dll' -Force;" + @"Import-Module '.\Tmx.dll' -Force;";
    }
}
