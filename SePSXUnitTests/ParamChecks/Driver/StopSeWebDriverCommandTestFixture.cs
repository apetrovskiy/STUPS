/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 9:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of StopSeWebDriverCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "SeWebDriver", DefaultParameterSetName = "ByName")]
    [OutputType(typeof(bool))]
    public class StopSeWebDriverCommandTestFixture // DriverCmdletBase
    {
        public StopSeWebDriverCommandTestFixture()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal string DriverName { get; set; }
        
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "ByName")]
//        public string[] InstanceName { get; set; }
        
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true,
                   ParameterSetName = "ByInput")]
        public IWebDriver[] InputObject { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            if (this.InstanceName != null &&
                //this.InstanceName != string.Empty &&
                this.InstanceName.Length > 0) {
                
                try {
                    for (int i = 0; i < this.InstanceName.Length; i++) {
                        if (this.InstanceName[i] != string.Empty) {
                            IWebDriver driver = 
                                CurrentData.Drivers[this.InstanceName[i]];
                            
                            if (driver.Equals(CurrentData.CurrentWebDriver)) {
                                CurrentData.CurrentWebDriver = null;
                            }
                            
                            CurrentData.Drivers.Remove(this.InstanceName[i]);
                            
                            driver.Quit();
                            //CurrentData.CurrentWebDriver = null;
                            WriteObject(this, true);
                        }
                    }
                }
                catch (Exception eFailed) {
                    CurrentData.CurrentWebDriver = null;
                    //WriteObject(this, false);
//                    string errorDescription = 
//                        "Failed to stop the driver. " +
//                        eFailed.Message;
//                    ErrorRecord err = 
//                        new ErrorRecord(
//                            new Exception(errorDescription),
//                            "FailedStopDriver",
//                            ErrorCategory.InvalidOperation,
//                            this.InputObject);
//                    err.ErrorDetails = 
//                        new ErrorDetails(errorDescription);
//                    WriteError(this, err, true);
                    this.WriteError(
                        this,
                        "Failed to stop the driver. " +
                        eFailed.Message,
                        "FailedStopDriver",
                        ErrorCategory.InvalidOperation,
                        true);
                }
            }
        }
        
        protected override void ProcessRecord()
        {
            if (this.InputObject != null &&
                this.InputObject is IWebDriver[]) {
                
                foreach (IWebDriver driver in this.InputObject) {
                    
                    try {
                        foreach (KeyValuePair<string, IWebDriver> driverPair in CurrentData.Drivers) {
                            if (driverPair.Value == driver) {
                                CurrentData.Drivers.Remove(driverPair.Key);
                                break;
                            }
                        }
                        
                        //this.InputObject.Quit();
                        driver.Quit();
                        
                        WriteObject(this, true);
                    }
                    catch (Exception eFailed) {
                        //WriteObject(this, false);
                        
//                        string errorDescription = 
//                            "Failed to stop the driver. " +
//                            eFailed.Message;
//                        ErrorRecord err = 
//                            new ErrorRecord(
//                                new Exception(errorDescription),
//                                "FailedStopDriver",
//                                ErrorCategory.InvalidOperation,
//                                //this.InputObject);
//                                driver); // ?
//                        err.ErrorDetails = 
//                            new ErrorDetails(errorDescription);
//                        WriteError(this, err, true);
                        this.WriteError(
                            this,
                            "Failed to stop the driver. " +
                            eFailed.Message,
                            "FailedStopDriver",
                            ErrorCategory.InvalidOperation,
                            true);
                    }
                }
            }
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "SeFirefox")]
    public class StopSeFirefoxCommandTestFixture // StopSeWebDriverCommand
    {
        public StopSeFirefoxCommandTestFixture(){}
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "SeChrome")]
    public class StopSeChromeCommandTestFixture // StopSeWebDriverCommand
    {
        public StopSeChromeCommandTestFixture(){}
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "SeInternetExplorer")]
    public class StopSeInternetExplorerCommandTestFixture // StopSeWebDriverCommand
    {
        public StopSeInternetExplorerCommandTestFixture(){}
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "SeSafari")]
    internal class StopSeSafariCommandTestFixture // StopSeWebDriverCommand
    {
        public StopSeSafariCommandTestFixture(){}
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "SeOpera")]
    internal class StopSeOperaCommandTestFixture // StopSeWebDriverCommand
    {
        public StopSeOperaCommandTestFixture(){}
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "SeAndroid")]
    internal class StopSeAndroidCommandTestFixture // StopSeWebDriverCommand
    {
        public StopSeAndroidCommandTestFixture(){}
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "SeHTMLUnit")]
    public class StopSeHTMLUnitCommandTestFixture // StopSeWebDriverCommand
    {
        public StopSeHTMLUnitCommandTestFixture(){}
    }
}
