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
    using System.Management.Automation;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    //using OpenQA.Selenium.Safari;
    //using OpenQA.Selenium.Opera;
    //using OpenQA.Selenium.Android;
    //using OpenQA.Selenium.Remote;

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
        internal SwitchParameter Ch { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "IEDriver")]
        internal SwitchParameter Ie { get; set; }
        
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
        public OpenQA.Selenium.IE.InternetExplorerOptions IeOptions { get; set; }
        
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
        internal SwitchParameter Ff { get; set; }
        
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
            CheckCmdletParameters();
            
            switch (DriverName.ToUpper()) {
                case SeHelper.DriverNameChrome:
                case SeHelper.DriverNameChrome2:
                    Ch = true;
                    DriverType = Drivers.Chrome;
                    break;
                case SeHelper.DriverNameFirefox:
                case SeHelper.DriverNameFirefox2:
                    Ff = true;
                    DriverType = Drivers.Firefox;
                    break;
                case SeHelper.DriverNameInternetExplorer:
                case SeHelper.DriverNameInternetExplorer2:
                case SeHelper.DriverNameInternetExplorer3:
                case SeHelper.DriverNameInternetExplorer4:
                case SeHelper.DriverNameInternetExplorer5:
                case SeHelper.DriverNameInternetExplorer6:
                    Ie = true;
                    DriverType = Drivers.InternetExplorer;
                    break;
                default:
                    WriteError(
                        this,
                        "Could not determine the type of driver.",
                        "DriverType",
                        ErrorCategory.InvalidArgument,
                        true);
                    break;
            }
            
            var command =
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
            DriverName = SeHelper.DriverNameFirefox;
            Ff = true;
            DriverType = Drivers.Firefox;
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
            DriverName = SeHelper.DriverNameChrome;
            Ch = true;
            DriverType = Drivers.Chrome;
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
            DriverName = SeHelper.DriverNameInternetExplorer;
            Architecture = InternetExplorer.X86;
            Ie = true;
            DriverType = Drivers.InternetExplorer;
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
            DriverName = SeHelper.DriverNameInternetExplorer;
            Architecture = InternetExplorer.X64;
            Ie = true;
            DriverType = Drivers.InternetExplorer;
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
            DriverName = SeHelper.DriverNameSafari;
            DriverType = Drivers.Safari;
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
            DriverName = SeHelper.DriverNameOpera;
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
            DriverName = SeHelper.DriverNameAndroid;
            //this.DriverType = Drivers.Android;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeHTMLUnit")]
    public class StartSeHtmlUnitCommand : StartSeWebDriverCommand
    {
        public StartSeHtmlUnitCommand()
        {
            DriverName = SeHelper.DriverNameHtmlUnit;
            //this.DriverType = Drivers.HTML;
        }
    }
}
