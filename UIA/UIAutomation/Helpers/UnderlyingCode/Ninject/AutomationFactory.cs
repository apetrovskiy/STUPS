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
        
        private static ProxyGenerator _generator;
        
        private static bool _useDynamicProxy;
        
        #region Initialization
        static AutomationFactory()
        {
            if (PSCmdletBase.UnitTestMode || CommonCmdletBase.ModuleAlreadyLoaded) return;
            _ninjectModule = new ObjectLifecycleModule();
            CommonCmdletBase.ModuleAlreadyLoaded = true;
            Init();
            
		    InitCommonObjects();
		    
		    _useDynamicProxy = true;
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
		        
		        //
		        InitCommonObjects();
		        //
		        
		        // 20131221
		        _useDynamicProxy = true;
		    }
		    catch (Exception eInitFailure) {
		        // TODO
		        // write error to error object!!!
//		         Console.WriteLine("Init Kernel");
//		         Console.WriteLine(eInitFailure.Message);
		    }
		}
		
		internal static void InitCommonObjects()
		{
		    var argument = new ConstructorArgument("builder", new PersistentProxyBuilder());
		    _generator = Kernel.Get<ProxyGenerator>(argument);
		}
		#endregion Initialization
        
		#region Castle DynamicProxy
        internal static IUiElement ConvertToProxiedElement<T>(T element)
        {
            Type[] supportedAdditionalInterfaces =
                UiaHelper.GetSupportedInterfaces(element);
            
            UiElement proxiedElement = null;
            try {
                
                if (null != supportedAdditionalInterfaces && 0 < supportedAdditionalInterfaces.Length) {
            		proxiedElement =
            		    (UiElement)_generator.CreateClassProxy(
            		        typeof(UiElement),
            		        supportedAdditionalInterfaces,
                            new MethodSelectorAspect(), new LoggingAspect(), new ErrorHandlingAspect(), new InputValidationAspect(), new ParameterValidationAspect());
                } else {
            		proxiedElement =
            		    (UiElement)_generator.CreateClassProxy(
            		        typeof(UiElement),
                            new MethodSelectorAspect(), new LoggingAspect(), new ErrorHandlingAspect(), new InputValidationAspect(), new ParameterValidationAspect());
                }
            }
            catch (Exception eConvertation) {
                // Console.WriteLine(eConvertation.Message);
            }
    		return proxiedElement;
        }
        #endregion Castle DynamicProxy
		
		#region IUiElement
		public static IUiElement GetUiElement(AutomationElement element)
		{
	        if (null == element) {
	            return null;
	        }
	        
			try {
    			var singleElement = new ConstructorArgument("element", element);
    			IUiElement adapterElement = Kernel.Get<IUiElement>("AutomationElement.NET", singleElement);
    			
    			if (_useDynamicProxy) {
                    
        			IUiElement proxiedTypedUiElement =
        			    ConvertToProxiedElement(
        			        adapterElement);
        			
        			proxiedTypedUiElement.SetSourceElement<AutomationElement>(element);
        			
        			return (IUiElement)proxiedTypedUiElement; // as IUiElement;
    			} else {
                    
    			    adapterElement.SetSourceElement<AutomationElement>(element);
    			    
    			    return adapterElement;
    			}
    			
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    //Console.WriteLine("Element 01");
			    //Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
		
		public static IUiElement GetUiElement(IUiElement element)
		{
	        if (null == element) {
	            return null;
	        }
	        
			try {
                
    			var singleElement = new ConstructorArgument("element", element);
    			
    			IUiElement adapterElement = Kernel.Get<IUiElement>("UiElement", singleElement);
    			
    			if (_useDynamicProxy) {
                    
        			IUiElement proxiedTypedUiElement =
        			    ConvertToProxiedElement(
        			        adapterElement);
        			
        			proxiedTypedUiElement.SetSourceElement<IUiElement>(element);
        			
        			return (IUiElement)proxiedTypedUiElement; // as IUiElement;
    			} else {
                    
    			    adapterElement.SetSourceElement<IUiElement>(element);
    			    
    			    return adapterElement;
    			}
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    //Console.WriteLine("Element 02");
			    //Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
		
		public static IUiElement GetUiElement()
		{
			try {
    			IUiElement adapterElement = Kernel.Get<IUiElement>("Empty", null);
    			
    			if (_useDynamicProxy) {
        			IUiElement proxiedTypedUiElement =
        			    ConvertToProxiedElement(
        			        adapterElement);
        			
        			return (IUiElement)proxiedTypedUiElement; // as IUiElement;
    			} else {
    			    
    			    return adapterElement;
    			}
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    //Console.WriteLine("Element 03");
			    //Console.WriteLine(eFailedToIssueElement.Message);
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
                //Console.WriteLine("Information");
			    //Console.WriteLine(eFailedToIssueInformation.Message);
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
			    //Console.WriteLine("Collection 01");
			    //Console.WriteLine(eFailedToIssueCollection.Message);
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
			    //Console.WriteLine("Collection 02");
			    //Console.WriteLine(eFailedToIssueCollection.Message);
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
			    //Console.WriteLine("Collection 03");
			    //Console.WriteLine(eFailedToIssueCollection.Message);
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
			    //Console.WriteLine("Collection 04");
			    //Console.WriteLine(eFailedToIssueCollection.Message);
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
