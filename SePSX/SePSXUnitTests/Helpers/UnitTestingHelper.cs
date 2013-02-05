/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2012
 * Time: 4:13 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using SePSX;
    using SePSX.Commands;
    using Autofac;
    using OpenQA.Selenium;
    using PSTestLib;
    
    /// <summary>
    /// Description of UnitTestingHelper.
    /// </summary>
    public static class UnitTestingHelper
    {
        static UnitTestingHelper()
        {
        }
        
        public static void PrepareUnitTestDataStore()
        {

try {
    WebDriverFactory.Container.Resolve<StartSeChromeCommand>();
}
catch {
    CommonCmdletBase.ModuleAlreadyLoaded = false;
}

            if (!CommonCmdletBase.ModuleAlreadyLoaded) {

                WebDriverFactory.AutofacModule = new FakeWebDriverModule();

                WebDriverFactory.Init();

                CommonCmdletBase.ModuleAlreadyLoaded = true;
            }

            CurrentData.InitUnconditional();
            
            PSCmdletBase.UnitTestMode = true;
            
            if (0 < PSTestLib.UnitTestOutput.Count) {

                PSTestLib.UnitTestOutput.Clear();
            }
            
            IWebDriver webDriver = new FakeWebDriver();

            CurrentData.CurrentWebDriver = webDriver;
        }
    }
}
