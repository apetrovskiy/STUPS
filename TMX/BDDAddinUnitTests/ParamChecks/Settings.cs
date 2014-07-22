/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/28/2012
 * Time: 1:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace BDDAddinUnitTests
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
//#if DEBUG
//                        @"Import-Module '..\..\..\TMX\bin\Debug\Tmx.dll' -Force;" + //);
//#else
//                        @"Import-Module '..\..\..\TMX\bin\Release35\Tmx.dll' -Force;" + //);
//#endif
//                        @"";
        
                        @"Import-Module '.\Tmx.dll' -Force;" +
                        @"Import-Module '.\BDDAddin.dll' -Force;";
    }
}
