/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/10/2013
 * Time: 10:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
    using System;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Parameters;
    using System.Windows.Automation;
    using System.Collections;
    using System.Collections.Generic;
    using PSTestLib;
    
    using Castle.DynamicProxy;
    using System.Linq;
    
    /// <summary>
    /// Description of AutomationFactory.
    /// </summary>
    public static class AutomationFactory
    {
        internal const string NamedParameter_WithPattern = "WithPattern";
        internal const string NamedParameter_WithoutPattern = "WithoutPattern";
        internal const string NamedParameter_WithoutElement = "WithoutElement";
        
        #region Initialization
        static AutomationFactory()
        {
            if (PSCmdletBase.UnitTestMode || CommonCmdletBase.ModuleAlreadyLoaded) return;
            _ninjectModule = new ObjectLifecycleModule();
            CommonCmdletBase.ModuleAlreadyLoaded = true;
            Init();
        }
        
		private static INinjectModule _ninjectModule;
		internal static INinjectModule NinjectModule
		{ 
		    get { return _ninjectModule; }
		    set { _ninjectModule = value; _initFlag = false; }
		}
		
		private static bool _initFlag = false;
		
		private static StandardKernel _kernel;
		internal static StandardKernel Kernel
		{
		    get { return _kernel; }
		}
		
		public static void Init()
		{
		    if (_initFlag) return;
		    try {
		        _kernel = new StandardKernel(_ninjectModule);
		    }
		    catch (Exception eInitFailure) {
		        // TODO
		        // write error to error object!!!
		        // Console.WriteLine("Init Kernel");
		        // Console.WriteLine(eInitFailure.Message);
		    }

		    _initFlag = true;
        }
		
		internal static void InitUnitTests()
		{
		    try {
		        _ninjectModule = new ObjectLifecycleModule();
		        _kernel = new StandardKernel(_ninjectModule);
		    }
		    catch (Exception eInitFailure) {
		        // TODO
		        // write error to error object!!!
//		         Console.WriteLine("Init Kernel");
//		         Console.WriteLine(eInitFailure.Message);
		    }
		}
		#endregion Initialization
        
        // original
        // works
//        private static IUiElement convertToProxy(IUiElement element) //, IInterceptor[] interceptors)
//        {
//    		var proxyGenerator =
//                    new ProxyGenerator();
//    		
//    		var proxiedElement =
//    		    proxyGenerator.CreateInterfaceProxyWithTargetInterface(
//    		        typeof(IUiElement),
//    		        element,
//    		        // interceptors);
//    		        // new LoggingAspect(), new ErrorHandlingAspect());
//    		        // new LoggingAspect(), new ErrorHandlingAspect(), new InputValidationAspect(), new ParameterValidationAspect());
//    		        new LoggingAspect());
//    		
//    		return proxiedElement as IUiElement;
//        }
        
        // also works
//        private static T convertToProxy<T>(T element)
//        {
//    		var proxyGenerator =
//                    new ProxyGenerator();
//    		
//    		T proxiedElement =
//    		    (T)proxyGenerator.CreateInterfaceProxyWithTargetInterface(
//    		        typeof(IUiElement),
//    		        element,
//    		        new LoggingAspect());
//    		
//    		return proxiedElement;
//        }
		
		#region IUiElement
		// internal static IUiElement GetUiElement(AutomationElement element)
		public static IUiElement GetUiElement(AutomationElement element)
		{
	        if (null == element) {
	            return null;
	        }
	        
			try {
                
    			var singleElement = new ConstructorArgument("element", element);
    			IUiElement adapterElement = Kernel.Get<IUiElement>("AutomationElement.NET", singleElement);
    			return adapterElement;
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Element");
			    // Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
		
		// this works
//		public static IUiElement GetUiElement(AutomationElement element)
//		{
////DateTime startDate = System.DateTime.Now;
//		    
//	        if (null == element) {
//	            return null;
//	        }
//	        
//			try {
//                
//    			var singleElement = new ConstructorArgument("element", element);
//    			IUiElement adapterElement = Kernel.Get<IUiElement>("AutomationElement.NET", singleElement);
//    			
//    			// return adapterElement;
//    			
//    			IUiElement proxiedTypedUiElement =
//    			    convertToProxy(
//    			        adapterElement);
//                
////Console.WriteLine((System.DateTime.Now - startDate).Seconds.ToString() + "; " + (System.DateTime.Now - startDate).Ticks.ToString());
//                
//    			return (IUiElement)proxiedTypedUiElement; // as IUiElement;
//    			
//			}
//			catch (Exception eFailedToIssueElement) {
//			    // TODO
//			    // write error to error object!!!
//			    // Console.WriteLine("Element");
//			    // Console.WriteLine(eFailedToIssueElement.Message);
//			    return null;
//			}
//		}
		
		internal static IUiElement GetUiElement(IUiElement element)
		{
	        if (null == element) {
	            return null;
	        }
			try {
    			var singleElement = new ConstructorArgument("element", element);
    			IUiElement adapterElement = Kernel.Get<IUiElement>("UiElement", singleElement);
    			return adapterElement;
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Element");
			    // Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
		
		// internal static IUiElement GetUiElement()
		public static IUiElement GetUiElement()
		{
			try {
    			IUiElement adapterElement = Kernel.Get<IUiElement>("Empty", null);
    			return adapterElement;
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Element");
			    // Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
		
		internal static IUiElementInformation GetUiElementInformation(AutomationElement.AutomationElementInformation information)
		{
			try {
    			var singleInfo = new ConstructorArgument("information", information);
    			IUiElementInformation adapterInformation = Kernel.Get<IUiElementInformation>(singleInfo);
    			return adapterInformation;
			}
			catch (Exception eFailedToIssueInformation) {
			    // TODO
			    // write error to error object!!!
                // Console.WriteLine("Information");
			    // Console.WriteLine(eFailedToIssueInformation.Message);
			    return null;
			}
		}
		#endregion IUiElement
		
		#region IUiEltCollection
		internal static IUiEltCollection GetUiEltCollection(AutomationElementCollection elements)
		{
	        if (null == elements) {
	            return null;
	        }
			try {
    			var manyElements = new ConstructorArgument("elements", elements);
	      		IUiEltCollection adapterCollection = Kernel.Get<IUiEltCollection>("AutomationElementCollection.NET", manyElements);
	       		return adapterCollection;
			}
			catch (Exception eFailedToIssueCollection) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Collection");
			    // Console.WriteLine(eFailedToIssueCollection.Message);
			    return null;
			}
		}
		
		internal static IUiEltCollection GetUiEltCollection(IUiEltCollection elements)
		{
	        if (null == elements) {
	            return null;
	        }
			try {
    			var manyElements = new ConstructorArgument("elements", elements);
	      		IUiEltCollection adapterCollection = Kernel.Get<IUiEltCollection>("UiEltCollection", manyElements);
	       		return adapterCollection;
			}
			catch (Exception eFailedToIssueCollection) {
			    // TODO
			    // write error to error object!!!
//			    Console.WriteLine("Collection");
//			    Console.WriteLine(eFailedToIssueCollection.Message);
			    return null;
			}
		}
		
		internal static IUiEltCollection GetUiEltCollection(IEnumerable elements)
		{
	        if (null == elements) {
	            return null;
	        }
			try {
    			var manyElements = new ConstructorArgument("elements", elements);
	      		IUiEltCollection adapterCollection = Kernel.Get<IUiEltCollection>("AnyCollection", manyElements);
	       		return adapterCollection;
			}
			catch (Exception eFailedToIssueCollection) {
			    // TODO
			    // write error to error object!!!
//			    Console.WriteLine("Collection");
//			    Console.WriteLine(eFailedToIssueCollection.Message);
			    return null;
			}
		}
		
		internal static IUiEltCollection GetUiEltCollection()
		{
			try {
		        var boolArgument = new ConstructorArgument("fake", true);
	      		IUiEltCollection adapterCollection = Kernel.Get<IUiEltCollection>("Empty", boolArgument);
	       		return adapterCollection;
			}
			catch (Exception eFailedToIssueCollection) {
			    // TODO
			    // write error to error object!!!
//			    Console.WriteLine("Collection");
//			    Console.WriteLine(eFailedToIssueCollection.Message);
			    return null;
			}
		}
		#endregion IUiEltCollection
		
		#region patterns
		// internal static N GetMySuperPattern<N>(IUiElement element, object pattern)
		public static N GetMySuperPattern<N>(IUiElement element, object pattern)
		    where N : IBasePattern
		{
			try {
                
                N adapterPattern = default(N);
                var argElement = new ConstructorArgument("element", element);
//                if (null != pattern) {
//                    // var pt = element.GetCurrentPattern<N, O>(pattern as AutomationPattern);
//                    var argPattern = new ConstructorArgument("pattern", pattern);
//                    // N adapterPattern = Kernel.Get<N>(new[] { argElement, argPattern });
//                    adapterPattern = Kernel.Get<N>(NamedParameter_WithPattern, new[] { argElement, argPattern });
//                } else {
		        // var argPattern = new ConstructorArgument("pattern", pattern);
                // var argPattern = new ConstructorArgument("pattern", pt);
		        // N adapterPattern = Kernel.Get<N>(new[] { argElement, argPattern });
                    // N adapterPattern = Kernel.Get<N>(new[] { argElement });
                    adapterPattern = Kernel.Get<N>(NamedParameter_WithoutPattern, new[] { argElement });
                // }
		        adapterPattern.SourcePattern = pattern;
//		        }
	       		return adapterPattern;
			}
			catch (Exception eFailedToIssuePattern) {
			    // TODO
			    // write error to error object!!!
//			    Console.WriteLine("Pattern");
//			    Console.WriteLine(eFailedToIssuePattern.Message);
			    // return null;
			    return default(N);
			}
		}
		
		public static N GetMySuperPattern<N>(object pattern)
		    where N : IBasePattern
		{
			try {
                
                N adapterPattern = default(N);
                // var argElement = new ConstructorArgument("element", element);
                adapterPattern = Kernel.Get<N>(NamedParameter_WithoutElement, null);
		        adapterPattern.SourcePattern = pattern;
	       		return adapterPattern;
			}
			catch (Exception eFailedToIssuePattern) {
			    // TODO
			    // write error to error object!!!
//			    Console.WriteLine("Pattern");
//			    Console.WriteLine(eFailedToIssuePattern.Message);
			    // return null;
			    return default(N);
			}
		}
		#endregion patterns
    }
}
