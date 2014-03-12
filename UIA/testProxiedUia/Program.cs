/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/15/2013
 * Time: 11:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UIAutomation;
using Castle.DynamicProxy;

namespace testProxiedUia
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            IUiElement rootElement =
                UIAutomation.UiElement.RootElement;
            
            DateTime startDate = System.DateTime.Now;
            
            var proxyGenerator =
                new ProxyGenerator();
            
            var proxiedRootElement =
                proxyGenerator.CreateInterfaceProxyWithTargetInterface(
                    typeof(IUiElement),
                    rootElement,
                    new StandardInterceptor[]{});
            
            Console.WriteLine((System.DateTime.Now - startDate).Seconds.ToString() + "; " + (System.DateTime.Now - startDate).Ticks.ToString());
            
            Console.WriteLine(proxiedRootElement.GetType().Name);
            
            IUiElement proxiedtypedRootElement =
                proxiedRootElement as IUiElement;
            
            // 20140312
//            Console.WriteLine(proxiedtypedRootElement.Current.Name);
//            Console.WriteLine(proxiedtypedRootElement.Current.AutomationId);
//            Console.WriteLine(proxiedtypedRootElement.Current.ClassName);
            Console.WriteLine(proxiedtypedRootElement.GetCurrent().Name);
            Console.WriteLine(proxiedtypedRootElement.GetCurrent().AutomationId);
            Console.WriteLine(proxiedtypedRootElement.GetCurrent().ClassName);
            
            var originalElement =
                proxiedtypedRootElement.GetSourceElement();
//            Console.WriteLine(originalElement.Current.Name);
//            Console.WriteLine(originalElement.Current.AutomationId);
//            Console.WriteLine(originalElement.Current.ClassName);
            var arr = proxiedtypedRootElement.GetSupportedPatterns();
            foreach (var ptrn in arr) {
                Console.WriteLine(ptrn.ToString());
                // Console.WriteLine(ptrn.SourcePattern as automationpa
            }
            
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}