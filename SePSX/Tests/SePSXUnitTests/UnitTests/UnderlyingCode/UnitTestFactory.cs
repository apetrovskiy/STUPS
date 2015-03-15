///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 12/4/2012
// * Time: 3:48 PM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace SePSXUnitTests
//{
//    using System;
////    using OpenQA.Selenium;
////    //using OpenQA.Selenium.Android;
////    using OpenQA.Selenium.Chrome;
////    using OpenQA.Selenium.Firefox;
////    using OpenQA.Selenium.IE;
////    //using OpenQA.Selenium.PhantomJS;
////    using OpenQA.Selenium.Safari;
////
////    using OpenQA.Selenium.Remote;
//
//    using SePSX.Commands;
//
//    //using Ninject;
//
//
//    using Autofac;
//    using Autofac.Builder;
//    using Autofac.Core;
//
//
//
//    using System.Reflection;
//    using Autofac.Core.Activators.Reflection;
//    
//    using SePSX;
//
////    using Autofac.Core.Registration;
////    using Autofac.Core.Resolving;
//
//
////    using Ninject;
////    using Ninject.Activation;
////    using Ninject.Components;
////    using Ninject.Infrastructure;
////    using Ninject.Injection;
//
//    /// <summary>
//    /// Description of UnitTestFactory.
//    /// </summary>
//    public static class UnitTestFactory
//    {
//        //[STAThread]
//        static UnitTestFactory()
//        {
//            Console.WriteLine("UnitTestFactory constructor");
//            initFlag = false;
//        }
//        
//        private static Autofac.Module autofacModule;
//        internal static Autofac.Module AutofacModule
//        { 
//            get { return autofacModule; }
//            set{ autofacModule = value; initFlag = false; }
//        }
//        
//        private static ContainerBuilder builder;
//        //internal static IContainer Container;
//        //[ThreadStati
//        public static IContainer Container;
//        
//        //[ThreadStatic]
//        private static bool initFlag; // = false;
//        
//        private static int initCounter = 0;
//        
//        //[ThreadStatic]
//        internal static void Init()
//        {
//            if (!initFlag) {
//                try {
//                    
//                  builder = new ContainerBuilder();
//
//                  builder.RegisterModule(AutofacModule);
//                  
//                  Container = null;
//                  
//                  Container = builder.Build(ContainerBuildOptions.None);
//                  
//                }
//                catch (Exception efgh) {
//                    Console.WriteLine(efgh.Message);
//                }
//                Console.WriteLine(
//                    "UnitTestFActory has been initialized: " +
//                    System.DateTime.Now.Millisecond.ToString());
//                initCounter++;
//                Console.WriteLine("initCounter = " + initCounter.ToString());
//                Console.WriteLine(initFlag.ToString());
//                initFlag = true;
//            }
//        }
//    }
//}
