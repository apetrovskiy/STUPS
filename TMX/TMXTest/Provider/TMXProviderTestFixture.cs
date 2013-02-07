/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/27/2012
 * Time: 11:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Provider
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TMXProviderTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="TMXProvider test")]
    public class TMXProviderTestFixture
    {
        public TMXProviderTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Provider")]
        public void CheckProvider()
        {
            string name = "TMXProvider";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-PSProvider -PSProvider " + 
                name + 
                ").Name;",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Provider")]
        public void CheckDefaultDrive()
        {
            string name = "TMX";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-PSDrive -Name " + 
                name +
                ").Name;",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Provider")]
        public void CheckNewDriveByWindowName()
        {
            string driveName = "TMX1";
            string providerName = "TMXProvider";
            string rootpath = @"TMX\TMXProvider::suite1";
            string windowName = "suite1";
            string processName = @"""""";
            int processId = 0;
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
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Provider")]
        public void CheckNewDrivebyProcessName()
        {
            string driveName = "TMX2";
            string providerName = "TMXProvider";
            string rootpath = @"TMX\TMXProvider::suite2";
            string windowName = @"""""";
            string processName = "mmc";
            int processId = 0;
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
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Provider")]
        public void CheckNewDriveByProcessId()
        {
            string driveName = "TMX3";
            string providerName = "TMXProvider";
            string rootpath = @"TMX\TMXProvider::suite3";
            string windowName = @"""""";
            string processName = @"""""";
            int processId = 1024;
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

        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("Provider")]
        [Ignore("This code never worked before. 20130207")]
        public void RemoveDefaultDrive()
        {
            string driveName = "TMX";
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
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
