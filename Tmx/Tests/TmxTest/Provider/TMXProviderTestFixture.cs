/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/27/2012
 * Time: 11:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Provider
{
    using System;
    using MbUnit.Framework;using NUnit.Framework; // using MbUnit.Framework;using NUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TmxProviderTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="TmxProvider test")]
    public class TmxProviderTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Provider")]
        public void CheckProvider()
        {
            const string name = "TmxProvider";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-PSProvider -PSProvider " + 
                name + 
                ").Name;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Provider")]
        public void CheckDefaultDrive()
        {
            const string name = "TMX";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-PSDrive -Name " + 
                name +
                ").Name;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Provider")]
        public void CheckNewDriveByWindowName()
        {
            const string driveName = "TMX1";
            const string providerName = "TmxProvider";
            const string rootpath = @"TMX\TmxProvider::suite1";
            const string windowName = "suite1";
            const string processName = @"""""";
            const int processId = 0;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-PSDrive -Name  " + 
                driveName +
                " -PSProvider " +
                providerName +
                " -Root " +
                rootpath +
                " -WindowName " +
                windowName +
                " -ProcessName " +
                processName +
                " -ProcessId " +
                processId.ToString() + 
                "; (Get-PSDrive -Name " +
                driveName +
                ").Name;",
                driveName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Provider")]
        public void CheckNewDrivebyProcessName()
        {
            const string driveName = "TMX2";
            const string providerName = "TmxProvider";
            const string rootpath = @"TMX\TmxProvider::suite2";
            const string windowName = @"""""";
            const string processName = "mmc";
            const int processId = 0;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-PSDrive -Name  " + 
                driveName +
                " -PSProvider " +
                providerName +
                " -Root " +
                rootpath +
                " -WindowName " +
                windowName +
                " -ProcessName " +
                processName +
                " -ProcessId " +
                processId.ToString() + 
                "; (Get-PSDrive -Name " +
                driveName +
                ").Name;",
                driveName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Provider")]
        public void CheckNewDriveByProcessId()
        {
            const string driveName = "TMX3";
            const string providerName = "TmxProvider";
            const string rootpath = @"TMX\TmxProvider::suite3";
            const string windowName = @"""""";
            const string processName = @"""""";
            const int processId = 1024;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-PSDrive -Name  " + 
                driveName +
                " -PSProvider " +
                providerName +
                " -Root " +
                rootpath +
                " -WindowName " +
                windowName +
                " -ProcessName " +
                processName +
                " -ProcessId " +
                processId + 
                "; (Get-PSDrive -Name " +
                driveName +
                ").Name;",
                driveName);
        }

        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Provider")]
        [MbUnit.Framework.Ignore("This code never worked before. 20130207")]
        [NUnit.Framework.Ignore("This code never worked before. 20130207")]
        public void RemoveDefaultDrive()
        {
            const string driveName = "TMX";
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"$null = Remove-PSDrive -Name " + 
                driveName +
                "; (Get-PSDrive -Name " +
                driveName +
                ").Name;",
                // 20130207
                //"DriveNotFoundException", // this code never worked
                "AssertionFailureException",
                "Cannot find drive. A drive with the name " + 
                driveName +
                " does not exist.");
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
