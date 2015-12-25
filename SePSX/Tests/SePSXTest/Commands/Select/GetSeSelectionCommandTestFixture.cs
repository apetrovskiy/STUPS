/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-02
 * Time: 00:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Select
{
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetSeSelectionCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class GetSeSelectionCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="Getting all the options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_AllOptions()
        {
            Select_AllOptions(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Getting all the options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_AllOptions()
        {
            Select_AllOptions(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Getting all the options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_AllOptions()
        {
            Select_AllOptions(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_AllOptions(string driverName)
        {
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                new System.Collections.ObjectModel.Collection<PSObject>();
            
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect01Value01Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect01Value02Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect01Value03Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect01Value04Name)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                //Settings.TestFile05Controls1ElementSelect01XPath +
                Settings.TestFile05Controls1ElementSelect04XPath +
                //@"' | Get-SeSelection -All | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -All | Read-SeWebElementText;",
                coll);
        }
        
        
        [Test] //[Test(Description="Getting all the options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_AllOptions_WrongInput()
        {
            Select_AllOptions_WrongInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Getting all the options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_AllOptions_WrongInput()
        {
            Select_AllOptions_WrongInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Getting all the options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_AllOptions_WrongInput()
        {
            Select_AllOptions_WrongInput(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_AllOptions_WrongInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementButton01XPath +
                //@"' | Get-SeSelection -All | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -All | Read-SeWebElementText;",
                "ParameterBindingException",
                "A positional parameter cannot be found that accepts argument 'button'.");
        }
        

        
        [Test] //[Test(Description="Getting selected options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_SelectedOptions()
        {
            Select_SelectedOptions(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Getting selected options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_SelectedOptions()
        {
            Select_SelectedOptions(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Getting selected options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_SelectedOptions()
        {
            Select_SelectedOptions(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_SelectedOptions(string driverName)
        {
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                new System.Collections.ObjectModel.Collection<PSObject>();
            
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value01Name)));
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value03Name)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -Index 0,2; " +
                @"Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                //@"' | Get-SeSelection -Selected | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -Selected | Read-SeWebElementText;",
                coll);
        }
        
        [Test] //[Test(Description="Getting selected options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_SelectedOptions_WrongInput()
        {
            Select_SelectedOptions_WrongInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Getting selected options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_SelectedOptions_WrongInput()
        {
            Select_SelectedOptions_WrongInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Getting selected options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_SelectedOptions_WrongInput()
        {
            Select_SelectedOptions_WrongInput(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_SelectedOptions_WrongInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -Index 0,2; " +
                @"Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementButton01XPath +
                //@"' | Get-SeSelection -Selected | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -Selected | Read-SeWebElementText;",
                "ParameterBindingException",
                "A positional parameter cannot be found that accepts argument 'button'.");
        }
        
        
        
        [Test] //[Test(Description="Getting the first selected options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_FirstSelectedOptions()
        {
            Select_FirstSelectedOptions(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Getting the first selected options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_FirstSelectedOptions()
        {
            Select_FirstSelectedOptions(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Getting the first selected options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_FirstSelectedOptions()
        {
            Select_FirstSelectedOptions(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_FirstSelectedOptions(string driverName)
        {
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                new System.Collections.ObjectModel.Collection<PSObject>();
            
            coll.Add((new PSObject(Settings.TestFile05Controls1ElementSelect04Value02Name)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -Index 1,2,3; " +
                @"Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                //@"' | Get-SeSelection -FirstSelected | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -FirstSelected | Read-SeWebElementText;",
                coll);
        }
        
        [Test] //[Test(Description="Getting the first selected options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Select_FirstSelectedOptions_WrongInput()
        {
            Select_FirstSelectedOptions_WrongInput(Settings.DriverNameFirefox);
        }
        
        [Test] //[Test(Description="Getting the first selected options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Select_FirstSelectedOptions_WrongInput()
        {
            Select_FirstSelectedOptions_WrongInput(Settings.DriverNameChrome);
        }
        
        [Test] //[Test(Description="Getting the first selected options")]
        [Category("Slow")][Category("WebElement")]
        [Category("Slow")][Category("Get_SeSelection")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Select_FirstSelectedOptions_WrongInput()
        {
            Select_FirstSelectedOptions_WrongInput(Settings.DriverNameInternetExplorer);
        }
        
        private void Select_FirstSelectedOptions_WrongInput(string driverName)
        {
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile05Controls1)) +
                @"' | Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementSelect04XPath +
                @"' | Set-SeSelection -Index 1,2,3; " +
                @"Get-SeWebElement -XPath '" +
                Settings.TestFile05Controls1ElementButton01XPath +
                //@"' | Get-SeSelection -FirstSelected | %{ $_ | Read-SeWebElementText; };",
                @"' | Get-SeSelection -FirstSelected | Read-SeWebElementText;",
                "ParameterBindingException",
                "A positional parameter cannot be found that accepts argument 'button'.");
        }

        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
