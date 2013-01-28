/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/27/2013
 * Time: 12:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.CheckCmdletParameters
{
    using System;
    
    /// <summary>
    /// Description of Settings.
    /// </summary>
    public class Settings
    {
        public Settings()
        {
        }
        
        public static string RunspaceCommand =
            @"Import-Module '.\UIAutomation.dll' -Force;";

		
    }
}