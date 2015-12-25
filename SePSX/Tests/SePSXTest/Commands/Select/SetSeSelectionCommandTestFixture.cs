/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-03
 * Time: 21:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Select
{
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SetSeSelectionCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class SetSeSelectionCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="Select all options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_SelectAllOptions()
        {
            Select_SelectAllOptions(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Select all options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_SelectAllOptions()
        {
            Select_SelectAllOptions(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Select all options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_SelectAllOptions()
        {
            Select_SelectAllOptions(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_SelectAllOptions(string driverName)
        {
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                new System.Collections.ObjectModel.Collection<PSObject>();
            
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value01Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value02Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value03Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value04Name)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -All; " +
                @"Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                //@"' | Get-SeSelection -Selected | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -Selected | Read-SeWebElementText;",
                coll);
        }
        
        
        [Test] //[Test(Description="Select all options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_SelectAllOptions_WrongInput()
        {
            Select_SelectAllOptions_WrongInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Select all options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_SelectAllOptions_WrongInput()
        {
            Select_SelectAllOptions_WrongInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Select all options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_SelectAllOptions_WrongInput()
        {
            Select_SelectAllOptions_WrongInput(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_SelectAllOptions_WrongInput(string driverName)
        {
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                new System.Collections.ObjectModel.Collection<PSObject>();
            
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value01Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value02Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value03Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value04Name)));
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -All; " +
                @"Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementButton01XPath +
                //@"' | Get-SeSelection -Selected | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -Selected | Read-SeWebElementText;",
                "ParameterBindingException",
                "A positional parameter cannot be found that accepts argument 'button'.");
        }
        
        
        [Test] //[Test(Description="Deselect all options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_DeselectAllOptions()
        {
            Select_DeselectAllOptions(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Deselect all options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_DeselectAllOptions()
        {
            Select_DeselectAllOptions(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Deselect all options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_DeselectAllOptions()
        {
            Select_DeselectAllOptions(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_DeselectAllOptions(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -Index 2,3; " +
                @"$null = Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -All -Deselect; " +
                @"if ((Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                "' | Get-SeSelection -Selected) -ne $null) { \"1\"; } else { \"0\"; }",
                "0");
        }
        
        
        [Test] //[Test(Description="Deselect all options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_DeselectAllOptions_WrongInput()
        {
            Select_DeselectAllOptions_WrongInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Deselect all options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_DeselectAllOptions_WrongInput()
        {
            Select_DeselectAllOptions_WrongInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Deselect all options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_DeselectAllOptions_WrongInput()
        {
            Select_DeselectAllOptions_WrongInput(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_DeselectAllOptions_WrongInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -Index 2,3; " +
                @"$null = Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -All -Deselect; " +
                @"if ((Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                "' | Get-SeSelection -Selected) -ne $null) { \"1\"; } else { \"0\"; }",
                "ParameterBindingException",
                "A positional parameter cannot be found that accepts argument 'button'.");
        }
        
        
        
        [Test] //[Test(Description="Select by index")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_SelectByIndex()
        {
            Select_SelectByIndex(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Select by index")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_SelectByIndex()
        {
            Select_SelectByIndex(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Select by index")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_SelectByIndex()
        {
            Select_SelectByIndex(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_SelectByIndex(string driverName)
        {
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                new System.Collections.ObjectModel.Collection<PSObject>();
            
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value01Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value02Name)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value03Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value04Name)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -Index 1,3; " +
                @"Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                //@"' | Get-SeSelection -Selected | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -Selected | Read-SeWebElementText;",
                coll);
        }
        
        
        [Test] //[Test(Description="Deselect by index")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_DeselectByIndex()
        {
            Select_DeselectByIndex(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Deselect by index")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_DeselectByIndex()
        {
            Select_DeselectByIndex(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Deselect by index")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_DeselecttByIndex()
        {
            Select_DeselectByIndex(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_DeselectByIndex(string driverName)
        {
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                new System.Collections.ObjectModel.Collection<PSObject>();
            
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value01Name)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value02Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value03Name)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value04Name)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -All; " +
                @"$null = Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -Index 1,3 -Deselect; " +
                @"Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                //@"' | Get-SeSelection -Selected | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -Selected | Read-SeWebElementText;",
                coll);
        }
        
        
        
        
        [Test] //[Test(Description="Select by value")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_SelectByValue()
        {
            Select_SelectByValue(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Select by value")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_SelectByValue()
        {
            Select_SelectByValue(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Select by value")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_SelectByValue()
        {
            Select_SelectByValue(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_SelectByValue(string driverName)
        {
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                new System.Collections.ObjectModel.Collection<PSObject>();
            
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value01Name)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value02Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value03Name)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value04Name)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -Value '" + 
                Settings.TestFile05Controls1ElementSelect04Value01 +
                @"','" +
                Settings.TestFile05Controls1ElementSelect04Value03 +
                @"'; " +
                @"Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                //@"' | Get-SeSelection -Selected | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -Selected | Read-SeWebElementText;",
                coll);
        }
        
        
        [Test] //[Test(Description="Deselect by value")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_DeselectByValue()
        {
            Select_DeselectByValue(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Deselect by value")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_DeselectByValue()
        {
            Select_DeselectByValue(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Deselect by value")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_DeselectByValue()
        {
            Select_DeselectByValue(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_DeselectByValue(string driverName)
        {
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                new System.Collections.ObjectModel.Collection<PSObject>();
            
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value01Name)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value02Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value03Name)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value04Name)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -All; " +
                @"$null = Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -Value '" + 
                Settings.TestFile05Controls1ElementSelect04Value02 +
                @"','" +
                Settings.TestFile05Controls1ElementSelect04Value04 +
                @"' -Deselect; " +
                @"Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                //@"' | Get-SeSelection -Selected | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -Selected | Read-SeWebElementText;",
                coll);
        }
        
        
        
        [Test] //[Test(Description="Select by visible text")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_SelectByVisibleText()
        {
            Select_SelectByVisibleText(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Select by visible text")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_SelectByVisibleText()
        {
            Select_SelectByVisibleText(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Select by visible text")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_SelectByVisibleText()
        {
            Select_SelectByVisibleText(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_SelectByVisibleText(string driverName)
        {
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                new System.Collections.ObjectModel.Collection<PSObject>();
            
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value01Name)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04VisibleText02Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value03Name)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04VisibleText04Name)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -VisibleText '" + 
                Settings.TestFile05Controls1ElementSelect04Value01Name +
                @"','" +
                Settings.TestFile05Controls1ElementSelect04Value03Name +
                @"'; " +
                @"Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                //@"' | Get-SeSelection -Selected | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -Selected | Read-SeWebElementText;",
                coll);
        }
        
        
        [Test] //[Test(Description="Deselect by visible text")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_DeselectByVisibleText()
        {
            Select_DeselectByVisibleText(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Deselect by visible text")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_DeselectByVisibleText()
        {
            Select_DeselectByVisibleText(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Deselect by visible text")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Set_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_DeselectByVisibleText()
        {
            Select_DeselectByVisibleText(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_DeselectByVisibleText(string driverName)
        {
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                new System.Collections.ObjectModel.Collection<PSObject>();
            
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value01Name)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04VisibleText02Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value03Name)));
            //coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04VisibleText04Name)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -All; " +
                @"$null = Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -VisibleText '" + 
                Settings.TestFile05Controls1ElementSelect04Value02Name +
                @"','" +
                Settings.TestFile05Controls1ElementSelect04Value04Name +
                @"' -Deselect; " +
                @"Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                //@"' | Get-SeSelection -Selected | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -Selected | Read-SeWebElementText;",
                coll);
        }
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
