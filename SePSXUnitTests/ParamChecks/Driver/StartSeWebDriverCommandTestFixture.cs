/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 8:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    //using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.IE;
    //using OpenQA.Selenium.Safari;
    //using OpenQA.Selenium.Opera;
    //using OpenQA.Selenium.Android;
    //using OpenQA.Selenium.Remote;
    
    
    //using System.Management.Automation.Runspaces;
    
    
    /// <summary>
    /// Description of StartSeWebDriverCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeWebDriver", DefaultParameterSetName = "Independent")]
    [OutputType(typeof(IWebDriver))]
    public class StartSeWebDriverCommandTestFixture // StartDriverCmdletBase //DriverCmdletBase
    {
        public StartSeWebDriverCommandTestFixture()
        {
        }
        
        #region Parameters
#region commented
//        [Parameter(Mandatory = false)]
//        [ValidateNotNullOrEmpty()]
//        public string DriverName { get; set; }
//        
////        [Parameter(Mandatory = false)]
////        public string[] InstanceName { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        public int Count { get; set; }
#endregion commented
        #endregion Parameters
        
        #region Parameters
        [Parameter(Mandatory = false,
                   ParameterSetName = "ChromeDriver")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "IEDriver")]
        public string DriverDirectoryPath { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "ChromeDriver")]
        public OpenQA.Selenium.Chrome.ChromeOptions ChromeOptions { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "IEDriver")]
        //public InternetExplorerOptions IEOptions { get; set; }
        public OpenQA.Selenium.IE.InternetExplorerOptions IEOptions { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "ChromeDriver")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "IEDriver")]
        public int Timeout { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "ChromeDriver")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "IEDriver")]
        public SwitchParameter AsService { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            SeStartWebDriverCommand command =
                new SeStartWebDriverCommand(this);
            command.Execute();
        }
    }
    
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeFirefox")]
    public class StartSeFirefoxCommandTestFixture // StartSeWebDriverCommand
    {
        public StartSeFirefoxCommandTestFixture(){this.DriverName = SeHelper.driverNameFirefox; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Start, "SeChrome")]
    public class StartSeDriverServerCommandTestFixture // StartSeWebDriverCommand
    {
        public StartSeDriverServerCommandTestFixture(){this.DriverName = SeHelper.driverNameChrome; this.AsService = true; }
        
//        #region Parameters
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "ChromeDriver")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "IEDriver")]
//        public string DriverDirectoryPath { get; set; }
//        
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "ChromeDriver")]
//        public OpenQA.Selenium.Chrome.ChromeOptions ChromeOptions { get; set; }
//        
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "IEDriver")]
//        //public InternetExplorerOptions IEOptions { get; set; }
//        public OpenQA.Selenium.IE.InternetExplorerOptions IEOptions { get; set; }
//        
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "ChromeDriver")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "IEDriver")]
//        public int Timeout { get; set; }
//        
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "ChromeDriver")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "IEDriver")]
//        public SwitchParameter AsService { get; set; }
//        #endregion Parameters
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeChrome", DefaultParameterSetName = "ChromeDriver")]
    public class StartSeChromeCommandTestFixture // StartSeDriverServerCommand //StartSeWebDriverCommand
    {
        public StartSeChromeCommandTestFixture(){this.DriverName = SeHelper.driverNameChrome; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeInternetExplorer32", DefaultParameterSetName = "IEDriver")]
    public class StartSeInternetExplorer32CommandTestFixture // StartSeDriverServerCommand //StartSeWebDriverCommand
    {
        public StartSeInternetExplorer32CommandTestFixture()
        {
            this.DriverName = SeHelper.driverNameInternetExplorer;
            this.Architecture = InternetExplorer.x86;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeInternetExplorer64", DefaultParameterSetName = "IEDriver")]
    public class StartSeInternetExplorer64CommandTestFixture // StartSeDriverServerCommand //StartSeWebDriverCommand
    {
        public StartSeInternetExplorer64CommandTestFixture()
        {
            this.DriverName = SeHelper.driverNameInternetExplorer;
            this.Architecture = InternetExplorer.x64;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeSafari")]
    public class StartSeSafariCommandTestFixture // StartSeWebDriverCommand
    {
        public StartSeSafariCommandTestFixture(){this.DriverName = SeHelper.driverNameSafari; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeOpera")]
    internal class StartSeOperaCommandTestFixture // StartSeWebDriverCommand
    {
        public StartSeOperaCommandTestFixture(){this.DriverName = SeHelper.driverNameOpera; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeAndroid")]
    internal class StartSeAndroidCommandTestFixture // StartSeWebDriverCommand
    {
        public StartSeAndroidCommandTestFixture(){this.DriverName = SeHelper.driverNameAndroid; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeHTMLUnit")]
    public class StartSeHTMLUnitCommandTestFixture // StartSeWebDriverCommand
    {
        public StartSeHTMLUnitCommandTestFixture(){this.DriverName = SeHelper.driverNameHTMLUnit; }
    }
}
