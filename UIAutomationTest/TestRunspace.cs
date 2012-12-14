///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 07/12/2011
// * Time: 09:09 p.m.
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//using System;
//using System.Diagnostics;
//using System.Management.Automation;
//using System.Management.Automation.Runspaces;
//
using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
//using UIAutomationTest;
//
//namespace UIAutomationTest
//{
//    /// <summary>
//    /// Description of CmdletUnitTest.TestRunspace.
//    /// </summary>
//    public static class TestRunspace
//    {
//        private static Runspace testRunSpace;
//        
//        public static string TestFormPath {
//            get {
//#if DEBUG
//                return @"..\..\..\UIAutomationTestForms\bin\Debug\UIAutomationTestForms.exe";
//#else
//                return @"..\..\..\UIAutomationTestForms\bin\Release\UIAutomationTestForms.exe";
//#endif
//            }
//        }
//        
//        public static string TestFormProcess { get { return @"UIAutomationTestForms"; } }
//        // public static string TestFormProcess { get { return @"nunit"; } }
//        public static System.Diagnostics.Process TestProcess { get; set; }
//        public static System.Diagnostics.ProcessStartInfo TestProcessStartInfo { get; set; }
//        public static string TestFormNameEmpty { get { return @"WinFormsEmpty"; } }
//        public static string TestFormNameAnonymous { get { return @""; } }
//        public static string TestFormNameMinimized { get { return @"WinFormsMinimized"; } }
//        public static string TestFormNameMaximized { get { return @"WinFormsMaximized"; } }
//        public static string TestFormNameNoTaskBar { get { return @"WinFormsNoTaskBar"; } }
//        public static string TestFormNameRich { get { return @"WinFormsRich"; } }
//        
//        public static string TestFormWPFNameEmpty { get { return @"WPFEmpty"; } }
//        public static string TestFormWPFNameAnonymous { get { return @""; } }
//        public static string TestFormWPFNameMinimized { get { return @"WPFMinimized"; } }
//        public static string TestFormWPFNameMaximized { get { return @"WPFMaximized"; } }
//        public static string TestFormWPFNameCollapsed { get { return @"WPFCollapsed"; } }
//        // public static string TestFormNameNoTaskBar { get { return @"WinFormsNoTaskBar"; } }
//        // public static string TestFormNameRich { get { return @"WinFormsRich"; } }
//        
////        public static string NUnitClass {
////            get {
////                if (System.Environment.OSVersion.Version.Major == 6) {
////                    return "WindowsForms10.Window.8.app.0.3e2f22e_r29_ad1";
////                }
////                if (System.Environment.OSVersion.Version.Major == 5) {
////                    return "WindowsForms10.Window.8.app.0.11c7a8c";
////                }
////                return "no class";
////            }
////        }
//        
////        public static string NUnitTitle {
////            get {
////                if (System.Environment.OSVersion.Version.Major == 6) {
////                    return @"UIAutomationTest.dll - NUnit";
////                }
////                if (System.Environment.OSVersion.Version.Major == 5) {
////                    // return @"UIAutomationTest - NUnit";
////                    return @"UIAutomationTest.dll - NUnit";
////                }
////                return "no title";
////            }
////        }
//        
////        public static string NUnitTreeSplitterAutomationId {
////            get {
////                if (System.Environment.OSVersion.Version.Major == 6) {
////                    return @"treeSplitter";
////                }
////                if (System.Environment.OSVersion.Version.Major == 5) {
////                    return @"treeSplitter";
////                }
////                return "no title";
////            }
////        }
//        
//        private static bool IitializeRunspace()
//        {
//            bool result = false;
//            try {
//                testRunSpace = RunspaceFactory.CreateRunspace();
//                CmdletUnitTest.TestRunspace.Open();
//                Pipeline cmd = 
//                    CmdletUnitTest.TestRunspace.CreatePipeline(
//#if DEBUG
//                        @"Import-Module '..\..\..\UIAutomation\bin\Debug\UIAutomation.dll' -Force;" + //);
//#else
//                        @"Import-Module '..\..\..\UIAutomation\bin\Release\UIAutomation.dll' -Force;" + //);
//#endif
//                        @"[UIAutomation.Preferences]::OnSuccessDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnErrorDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnClickDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnSleepDelay = 0;" +
//                        @"[UIAutomation.Preferences]::Timeout = 3000;" + 
//                        @"[UIAutomation.Preferences]::OnErrorScreenShot = $false;" + 
//                        @"[UIAutomation.Preferences]::Log = $false;");
//                //Console.WriteLine("init runspace");                
//                cmd.Invoke();
//                result = true;
//            } 
//            catch (Exception eInitRunspace) {
//                Console.WriteLine(eInitRunspace.Message);
//                result = false;
//            }
//            return result;
//        }
//        
//        // private static System.Collections.ObjectModel.Collection<PSObject >  RunPSCode(string codeSnippet)
//        public static System.Collections.ObjectModel.Collection<PSObject> RunPSCode(string codeSnippet)
//        {
//            System.Collections.ObjectModel.Collection<PSObject >  result = null;
//                try {
//                Pipeline cmd = 
//                    CmdletUnitTest.TestRunspace.CreatePipeline(codeSnippet);
//                System.Collections.ObjectModel.Collection<PSObject> resultObject = 
//                    cmd.Invoke();
//                return resultObject;
//            } 
//            catch (Exception eRunspace) {
//                Console.WriteLine(eRunspace.Message);
//                result = null;
//            }
//            return result;
//        }
//        
//        private static bool CloseRunspace()
//        {
//            bool result = false;
//            CmdletUnitTest.TestRunspace.Close();
//            
//            
//            return result;
//        }
//        
//        public static void PrepareRunspace()
//        {
//            CmdletUnitTest.TestRunspace.IitializeRunspace();
//// string codeSnippet = 
//// @"$ErrorPreference = [System.Management.Automation.ActionPreference]::SilentlyContinue;";
//            TestProcessStartInfo =
//                new ProcessStartInfo();
//            TestProcessStartInfo.FileName = 
//                CmdletUnitTest.TestRunspace.TestFormPath;
//        }
//        
//        public static void DisposeRunspace()
//        {
//            CmdletUnitTest.TestRunspace.CloseRunspace();
//            // TestProcess.CloseMainWindow();
//            if (TestProcess != null)
//            {
//                try { TestProcess.CloseMainWindow(); } 
//                catch { }
//            }
//            System.Diagnostics.Process[] processes = 
//                System.Diagnostics.Process.GetProcessesByName(
//                    MiddleLevelCode.TestFormProcess);
//            foreach (System.Diagnostics.Process p in processes)
//            {
//                p.CloseMainWindow();
//            }
//            TestProcessStartInfo = null;
//            TestProcess = null;
//        }
//        
//        public static void StartProcessWithForm(UIAutomationTestForms.Forms formCode,
//                                                int delay)
//        {
//            TestProcessStartInfo.Arguments = 
//                ((int)formCode).ToString();
//            if (delay > 0)
//            {
//                TestProcessStartInfo.Arguments += " ";
//                TestProcessStartInfo.Arguments +=
//                    delay.ToString();
//            }
//            TestProcess =
//                System.Diagnostics.Process.Start(TestProcessStartInfo);
//        }
//        
//        public static void StartProcessWithFormAndControl(
//            UIAutomationTestForms.Forms formCode,
//            TimeoutsAndDelays formDelayEn,
//            System.Windows.Automation.ControlType controlType,
//            string controlName,
//            string controlAutomationId,
//            TimeoutsAndDelays controlDelayEn)
//        {
//            int formDelay = (int)formDelayEn;
//            int controlDelay = (int)controlDelayEn;
//            
//            TestProcessStartInfo.Arguments = 
//                ((int)formCode).ToString();
//            // form delay
//            TestProcessStartInfo.Arguments += " ";
//            TestProcessStartInfo.Arguments +=
//                formDelay.ToString();
//            // control type
//            TestProcessStartInfo.Arguments += " ";
//            string _controlType = 
//                controlType.ProgrammaticName.Substring(
//                    controlType.ProgrammaticName.IndexOf(".") + 1);
//            TestProcessStartInfo.Arguments +=
//                _controlType;
//            // control delay
//            TestProcessStartInfo.Arguments += " ";
//            TestProcessStartInfo.Arguments +=
//                controlDelay.ToString();
//            TestProcessStartInfo.Arguments += " ";
//            TestProcessStartInfo.Arguments +=
//                controlName;
//            TestProcessStartInfo.Arguments += " ";
//            TestProcessStartInfo.Arguments +=
//                controlAutomationId;
//            Console.WriteLine(TestProcessStartInfo.Arguments);
//            TestProcess =
//                System.Diagnostics.Process.Start(TestProcessStartInfo);
//        }
//        
//        public static void RunAndGetTheException(
//            string codeSnippet, 
//            string exceptionType,
//            string message)
//        {
//            Console.WriteLine(" ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =");
//            Console.WriteLine(codeSnippet);
//            try{
//                System.Collections.ObjectModel.Collection<PSObject >  coll =
//                    CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
//            }
//            catch (Exception ee) {
////                if (typeof(e) != exceptionType) {
////                    Assert.AreNotEqual(typeof(e), exceptionType);
////                }
//                Assert.AreNotEqual(exceptionType, ee.GetType().Name);
//                Assert.AreNotEqual(message, ee.Message);
//            }
//            Console.WriteLine(" ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  == =");
//        }
//        
//        public static void RunAndEvaluateAreEqual1(string codeSnippet)
//        {
//            RunAndEvaluateAreEqual(codeSnippet, "1");
//        }
//        
//        public static void RunAndEvaluateIsNull(string codeSnippet)
//        {
//            Console.WriteLine(" ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =");
//            Console.WriteLine(codeSnippet);
//            System.Collections.ObjectModel.Collection<PSObject >  coll =
//                CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
//            // Assert.AreEqual("1", coll[0].ToString());
//            Assert.IsNull(coll);
//            Console.WriteLine(" ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  == =");
//        }
//        
//        public static void RunAndEvaluateIsTrue(string codeSnippet,
//                                                string strValue)
//        {
//            Console.WriteLine(" ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =");
//            Console.WriteLine(codeSnippet);
//            System.Collections.ObjectModel.Collection<PSObject >  coll =
//                CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
//            Assert.IsTrue(coll[0].ToString() == strValue);
//            Console.WriteLine(" ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  == =");
//        }
//        
//        public static void RunAndEvaluateAreEqual(string codeSnippet, 
//                                                  string strValue)
//        {
//            Console.WriteLine(" ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =");
//            Console.WriteLine(codeSnippet);
//            System.Collections.ObjectModel.Collection<PSObject >  coll =
//                CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
//            Assert.AreEqual(strValue, coll[0].ToString());
//            Console.WriteLine(" ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  ==  == =");
//        }
//    }
//}
//
//// namespace PSUnitTestLibrary.Test
////{
//// [TestFixture]
//// public class Program
//// {
//// private Runspace myRunSpace;
//// 
//// [SetUp]
//// public void PSSetup()
//// {
//// myRunSpace = RunspaceFactory.CreateRunspace();
//// myRunSpace.Open();
//// Pipeline cmd = myRunSpace.CreatePipeline(@"set-Location 'C:\dev\someproject");
//// cmd.Invoke();
//// } 
////
//// [Test] //[Test(Description="TBD")]
//// public void PSTest()
//// {
//// Pipeline cmd = myRunSpace.CreatePipeline("get-location");
//// Collection<PSObject >  resultObject = cmd.Invoke();
//// string currDir = resultObject[0].ToString();
//// Assert.IsTrue(currDir == @"'C:\dev\someproject");
////
//// cmd = myRunSpace.CreatePipeline(@".\new-securestring.ps1 password");
//// resultObject = cmd.Invoke();
//// SecureString ss = (SecureString)resultObject[0].ImmediateBaseObject;
//// Assert.IsTrue(ss.Length == 8);
////
//// myRunSpace.SessionStateProxy.SetVariable("ss", ss);
//// cmd = myRunSpace.CreatePipeline(@".\getfrom-securestring.ps1 $ss");
//// resultObject = cmd.Invoke();
//// string clearText = (string)resultObject[0].ImmediateBaseObject;
//// Assert.IsTrue(clearText == "password");
//// }
//// }
////} 