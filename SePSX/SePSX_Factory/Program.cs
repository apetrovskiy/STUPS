/*
 * Created by SharpDevelop.
 * User: shuran
 * Date: 12/14/2012
 * Time: 4:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
//    using SePSX;
    using SePSXUnitTests;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Interactions.Internal;
    using OpenQA.Selenium.Internal;
    using OpenQA.Selenium.Remote;
    using Autofac;
    using Autofac.Builder;
    using Autofac.Features.ResolveAnything;
    
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    class Program
    {
        public static void Main(string[] args)
        {
//            var builderWhite = new ContainerBuilder();
//            Console.WriteLine("0001");
//            builderWhite.RegisterModule(new WebDriverModule());
//            Console.WriteLine("0002");
//            try {
//                builderWhite.Build(ContainerBuildOptions.Default);
//                Console.WriteLine("0003");
//            }
//            catch (Exception e1) {
//                Console.WriteLine(e1.Message);
//                Console.WriteLine(e1.GetType().Name);
//            }
            
            var builderBlack = new ContainerBuilder();
            Console.WriteLine("0001");
            builderBlack.RegisterModule(new FakeWebDriverModule());
            Console.WriteLine("0002");
            try {
                builderBlack.Build(ContainerBuildOptions.Default);
                Console.WriteLine("0003");
            }
            catch (Exception e2) {
                Console.WriteLine(e2.Message);
                Console.WriteLine(e2.GetType().Name);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}