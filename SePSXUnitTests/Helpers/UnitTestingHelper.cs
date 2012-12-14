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
    
    /// <summary>
    /// Description of UnitTestingHelper.
    /// </summary>
    public static class UnitTestingHelper
    {
        static UnitTestingHelper()
        {
            //moduleAlreadyLoaded = false;
        }
        
        public static void PrepareUnitTestDataStore()
        {
            CommonCmdletBase.UnitTest = true;
            
//Console.WriteLine("the fake module");
//Console.WriteLine("CommonCmdletBase.ModuleAlreadyLoaded = " + CommonCmdletBase.ModuleAlreadyLoaded.ToString());

try {
    WebDriverFactory.Container.Resolve<StartSeChromeCommand>();
}
catch {
    CommonCmdletBase.ModuleAlreadyLoaded = false;
}

            if (!CommonCmdletBase.ModuleAlreadyLoaded) {
//Console.WriteLine("loading the fake module");
                WebDriverFactory.AutofacModule = new FakeWebDriverModule();
//Console.WriteLine("init the factory");
                WebDriverFactory.Init();
//Console.WriteLine("setting the flag in unit tests");
                CommonCmdletBase.ModuleAlreadyLoaded = true;
            }
//Console.WriteLine("init CurrentData");
            CurrentData.InitUnconditional();
            
            if (null != SePSX.CommonCmdletBase.UnitTestOutput && 0 < SePSX.CommonCmdletBase.UnitTestOutput.Count) {
//Console.WriteLine("clena up the output collection");
                SePSX.CommonCmdletBase.UnitTestOutput.Clear();
            }
            
            
//            //if (!UnitTest && !Module/Already/Loaded) {
//Console.WriteLine("the unit testing module");
//                UnitTestFactory.AutofacModule = new UnitTestModule();
//                UnitTestFactory.Init();
//            //    Module/Already/Loaded = true;
//            //}
        }
        
        //internal static bool ModuleAlreadyLoaded;
        //internal static bool ModuleAlreadyLoaded { get; set; }
//        private static bool moduleAlreadyLoaded;
//        internal static bool ModuleAlreadyLoaded { get { return moduleAlreadyLoaded; } set{ Console.WriteLine("flag was set"); moduleAlreadyLoaded = value; } }
    }
}
