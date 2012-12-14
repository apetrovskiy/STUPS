/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 8:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System;
    using System.Management.Automation;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.IE;
    //using OpenQA.Selenium.Safari;
    //using OpenQA.Selenium.Opera;
    //using OpenQA.Selenium.Android;
    //using OpenQA.Selenium.Remote;
    
    using Autofac;
    
    /// <summary>
    /// Description of StartSeWebDriverCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeWebDriver", DefaultParameterSetName = "Independent")]
    [OutputType(typeof(IWebDriver))]
    public class StartSeWebDriverCommand : StartDriverCmdletBase
    {
        public StartSeWebDriverCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   ParameterSetName = "ChromeDriver")]
        internal SwitchParameter CH { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "IEDriver")]
        internal SwitchParameter IE { get; set; }
        
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
        
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "ChromeDriver")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "IEDriver")]
//        public SwitchParameter AsService { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "FirefoxDriver")]
        public FirefoxProfile Profile { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "FirefoxDriver")]
        public ICapabilities Capabilities { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "FirefoxDriver")]
        public FirefoxBinary Binary { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "FirefoxDriver")]
        internal SwitchParameter FF { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "ChromeDriver")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "IEDriver")]
        [Parameter(Mandatory = false,
                   ParameterSetName = "FirefoxDriver")]
        public int Timeout { get; set; }
        #endregion Parameters
        
        protected internal Drivers DriverType { get; set; }
        
        protected override void BeginProcessing()
        {
            this.CheckParameters();
            
            switch (this.DriverName.ToUpper()) {
                case SeHelper.driverNameChrome:
                case SeHelper.driverNameChrome2:
                    this.CH = true;
                    this.DriverType = Drivers.Chrome;
                    break;
                case SeHelper.driverNameFirefox:
                case SeHelper.driverNameFirefox2:
                    this.FF = true;
                    this.DriverType = Drivers.Firefox;
                    break;
                case SeHelper.driverNameInternetExplorer:
                case SeHelper.driverNameInternetExplorer2:
                case SeHelper.driverNameInternetExplorer3:
                case SeHelper.driverNameInternetExplorer4:
                case SeHelper.driverNameInternetExplorer5:
                case SeHelper.driverNameInternetExplorer6:
                    this.IE = true;
                    this.DriverType = Drivers.InternetExplorer;
                    break;
                default:
                    this.WriteError(
                        this,
                        "Could not determine the type of driver.",
                        "DriverType",
                        ErrorCategory.InvalidArgument,
                        true);
                	break;
            }
            
            SeStartWebDriverCommand command =
                new SeStartWebDriverCommand(this);
                //WebDriverFactory.Container.Resolve<SeStartWebDriverCommand>(new NamedParameter("cmdlet", this));
            command.Execute();
        }
    }
    
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeFirefox", DefaultParameterSetName = "FirefoxDriver")]
    public class StartSeFirefoxCommand : StartSeWebDriverCommand
    {
        public StartSeFirefoxCommand()
        {
            this.DriverName = SeHelper.driverNameFirefox;
            this.FF = true;
            this.DriverType = Drivers.Firefox;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Start, "SeChrome")]
    public class StartSeDriverServerCommand : StartSeWebDriverCommand
    {
        //public StartSeDriverServerCommand(){this.DriverName = SeHelper.driverNameChrome; this.AsService = true; }
        public StartSeDriverServerCommand(){}
        
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeChrome", DefaultParameterSetName = "ChromeDriver")]
    public class StartSeChromeCommand : StartSeDriverServerCommand
    {
        public StartSeChromeCommand()
        {
            this.DriverName = SeHelper.driverNameChrome;
            this.CH = true;
            this.DriverType = Drivers.Chrome;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeInternetExplorer32", DefaultParameterSetName = "IEDriver")]
    public class StartSeInternetExplorer32Command : StartSeDriverServerCommand
    {
        public StartSeInternetExplorer32Command()
        {
            this.DriverName = SeHelper.driverNameInternetExplorer;
            this.Architecture = InternetExplorer.x86;
            this.IE = true;
            this.DriverType = Drivers.InternetExplorer;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeInternetExplorer64", DefaultParameterSetName = "IEDriver")]
    public class StartSeInternetExplorer64Command : StartSeDriverServerCommand
    {
        public StartSeInternetExplorer64Command()
        {
            this.DriverName = SeHelper.driverNameInternetExplorer;
            this.Architecture = InternetExplorer.x64;
            this.IE = true;
            this.DriverType = Drivers.InternetExplorer;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeSafari")]
    public class StartSeSafariCommand : StartSeWebDriverCommand
    {
        public StartSeSafariCommand()
        {
            this.DriverName = SeHelper.driverNameSafari;
            this.DriverType = Drivers.Safari;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeOpera")]
    internal class StartSeOperaCommand : StartSeWebDriverCommand
    {
        public StartSeOperaCommand()
        {
            this.DriverName = SeHelper.driverNameOpera;
            //this.DriverType = Drivers.Opera;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeAndroid")]
    internal class StartSeAndroidCommand : StartSeWebDriverCommand
    {
        public StartSeAndroidCommand()
        {
            this.DriverName = SeHelper.driverNameAndroid;
            //this.DriverType = Drivers.Android;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeHTMLUnit")]
    public class StartSeHTMLUnitCommand : StartSeWebDriverCommand
    {
        public StartSeHTMLUnitCommand()
        {
            this.DriverName = SeHelper.driverNameHTMLUnit;
            //this.DriverType = Drivers.HTML;
        }
    }
}
