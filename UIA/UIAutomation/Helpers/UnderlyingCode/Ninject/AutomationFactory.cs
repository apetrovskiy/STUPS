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
    using Ninject.Extensions.ChildKernel;
    using System.Windows.Automation;
    using System.Management.Automation;
    using System.Collections;
    using System.Collections.Generic;
    using PSTestLib;
    using Castle.DynamicProxy;
    using System.Linq;
    using WindowsInput;
    
    /// <summary>
    /// Description of AutomationFactory.
    /// </summary>
    public static class AutomationFactory
    {
        internal const string NamedParameter_WithPattern = "WithPattern";
        internal const string NamedParameter_WithoutPattern = "WithoutPattern";
        internal const string NamedParameter_WithoutElement = "WithoutElement";
        
        private static ProxyGenerator _generator;
        
        // 20140125
        internal static DateTime ScopeChangeFlag { get; set; }
        // internal static PlaceholderType ScopeChangeFlag { get; set; }
        internal static void InitNewCustomScope()
        {
            ScopeChangeFlag = DateTime.Now;
            // ScopeChangeFlag = new PlaceholderType();
        }
        
        #region Initialization
        static AutomationFactory()
        {
            if (PSCmdletBase.UnitTestMode || CommonCmdletBase.ModuleAlreadyLoaded) return;
            _ninjectModule = new ObjectLifecycleModule();
            CommonCmdletBase.ModuleAlreadyLoaded = true;
            Init();
            
		    InitCommonObjects();
		    
		    // ProxyGenerationOptions options;
		    // options.AdditionalAttributes
		    // options.AttributesToAddToGeneratedTypes
        }
        
		private static INinjectModule _ninjectModule;
		internal static INinjectModule NinjectModule
		{ 
		    get { return _ninjectModule; }
		    set { _ninjectModule = value; _initFlag = false; }
		}
		
		private static bool _initFlag = false;

        internal static StandardKernel Kernel { get; private set; }
        // 20140122
        internal static IChildKernel ChildKernel { get; private set; }
        
        public static void Init()
		{
		    if (_initFlag) return;
		    try {
		        Kernel = new StandardKernel(_ninjectModule);
		        
		        // 20140121
		        // 20140123
                // Kernel.Settings.ActivationCacheDisabled = true;
		        Kernel.Settings.ActivationCacheDisabled = false;
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
		    if (null != _ninjectModule && null != Kernel && _initFlag) return;
		    
		    try {
		        _ninjectModule = new ObjectLifecycleModule();
		        Kernel = new StandardKernel(_ninjectModule);
		        
		        // 20140121
		        // 20140123
                // Kernel.Settings.ActivationCacheDisabled = true;
		        Kernel.Settings.ActivationCacheDisabled = false;
		        
		        InitCommonObjects();
		        
		        // 20140122
		        // InitializeChildKernel();
		        
		        // 20140130
		        // HasScriptBlockCmdletBase.
		    }
		    catch (Exception eInitFailure) {
		        // TODO
		        // write error to error object!!!
		        // Console.WriteLine("Init Kernel for unit tests");
		        // Console.WriteLine(eInitFailure.Message);
		    }
		    
		    _initFlag = true;
		}
		
		internal static void InitCommonObjects()
		{
		    var argument = new ConstructorArgument("builder", new PersistentProxyBuilder());
		    _generator = Kernel.Get<ProxyGenerator>(argument);
		    
		    // 20140124
		    InitializeChildKernel();
		    
		    // 20140125
		    ScopeChangeFlag = DateTime.Now;
		    
		    // 20140130
		    // temporary?
		    
		}
		
		public static void Reset()
		{
		    _generator = null;
		    try {
                Kernel.Dispose();
		    }
		    catch {}
		    try {
                Kernel = null;
		    }
		    catch {}
		    _ninjectModule = null;
		    _initFlag = false;
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
        
        internal static T ConvertToProxiedObject<T>(T objectToConvert)
        {
            T proxiedObject = default(T);
            
            try {
                
                proxiedObject =
                    (T)_generator.CreateClassProxy(
                        typeof(T),
                        new LoggingAspect(), new ErrorHandlingAspect());
                
            } catch (Exception eProxying) {
                
                // Console.WriteLine("ProxiedObject");
                // Console.WriteLine(eProxying.Message);
                // throw;
            }
            
            return proxiedObject;
        }
        #endregion Castle DynamicProxy
        
        #region Common objects
        internal static IChildKernel GetChildKernel()
        {
            var childKernel = new ChildKernel(Kernel, new ChildKernelModule());
            // 20140123
            // childKernel.Settings.ActivationCacheDisabled = true;
            childKernel.Settings.ActivationCacheDisabled = false;
            return childKernel;
        }
        
        internal static int ChildKernelCreationCounter { get; set; }
        
        internal static void InitializeChildKernel()
        {
//            if (null != ChildKernel) {
//                ChildKernel.Dispose();
//                ChildKernel = null;
//            }
            
            // 20140129
            if (null != ChildKernel && 5 == ChildKernelCreationCounter) {
                ChildKernel.Dispose();
                ChildKernel = null;
                ChildKernelCreationCounter = 0;
            } // else {
            //     ChildKernelCreationCounter++;
            // }
            
            // 20140125
            if (null == ChildKernel) {
            
                ChildKernel = new ChildKernel(Kernel, new ChildKernelModule());
                // 20140123
                // ChildKernel.Settings.ActivationCacheDisabled = true;
                ChildKernel.Settings.ActivationCacheDisabled = false;
                
                // 20140129
                ChildKernelCreationCounter++;
            }
        }
        
        internal static void DisposeChildKernel()
        {
            ChildKernel.Dispose();
            ChildKernel = null;
        }
        
        // internal static 
        #endregion Common objects
		
		#region IUiElement
		internal static IExtendedModelHolder GetUiExtendedModelHolder(IUiElement parentElement, TreeScope scope)
		{
	        if (null == parentElement) {
	            return null;
	        }
		    
			try {
		        // 20140122
    			// IExtendedModelHolder holder = Kernel.Get<IExtendedModelHolder>(new IParameter[] {});
    			IExtendedModelHolder holder;
//    			if (null != ChildKernel) {
    			    // holder = ChildKernel.Get<IExtendedModelHolder>(new IParameter[] {});
    			    // var childKernel = GetChildKernel();
//    			    if (null == (parentElement as UiElement).ChildKernel) {
//    			        (parentElement as UiElement).ChildKernel = GetChildKernel();
//    			    }
    			    // holder = childKernel.Get<IExtendedModelHolder>(new IParameter[] {});
    			    // holder = (parentElement as UiElement).ChildKernel.Get<IExtendedModelHolder>(new IParameter[] {});
    			    // childKernel.Dispose();
    			    holder = ChildKernel.Get<IExtendedModelHolder>(new IParameter[] {});
    			    // (parentElement as UiElement).ChildKernel.Dispose();
//    			} else {
//    			    holder = Kernel.Get<IExtendedModelHolder>(new IParameter[] {});
//    			}
    			
    			IExtendedModelHolder proxiedHolder =
    			    (IExtendedModelHolder)_generator.CreateClassProxy(
    			        typeof(UiExtendedModelHolder),
    			        new Type[] { typeof(IExtendedModel) },
    			        new MethodSelectorAspect());
    			
    			proxiedHolder.SetScope(scope);
    			
    			proxiedHolder.SetParentElement(parentElement);
    			
    			return proxiedHolder;
			}
			catch (Exception eFailedToIssueHolder) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Holder");
			    // Console.WriteLine(eFailedToIssueHolder.Message);
			    return null;
			}
		}
		
        internal static T GetHolder<T>(IUiElement parentElement)
        {
	        if (null == parentElement) {
                return default(T);
	        }
            
            try {
                // 20140122
                // T holder = Kernel.Get<T>(new IParameter[] {});
                T holder;
//                if (null != ChildKernel) {
                    // holder = ChildKernel.Get<T>(new IParameter[] {});
                    // var childKernel = GetChildKernel();
//                    if (null == (parentElement as UiElement).ChildKernel) {
//    			        (parentElement as UiElement).ChildKernel = GetChildKernel();
//    			    }
                    // holder = childKernel.Get<T>(new IParameter[] {});
                    // holder = (parentElement as UiElement).ChildKernel.Get<T>(new IParameter[] {});
                    holder = ChildKernel.Get<T>(new IParameter[] {});
                    // childKernel.Dispose();
                    // (parentElement as UiElement).ChildKernel.Dispose();
                    // ChildKernel.Dispose();
//                } else {
//                    holder = Kernel.Get<T>(new IParameter[] {});
//                }
                
                Type typeOfClass = null;
                Type wearedInterface = null;
                switch (typeof(T).Name) {
                    case "IControlInputHolder":
                        typeOfClass = typeof(UiControlInputHolder);
                        wearedInterface = typeof(IControlInput);
                        break;
                    case "IKeyboardInputHolder":
                        typeOfClass = typeof(UiKeyboardInputHolder);
                        wearedInterface = typeof(IKeyboardInput);
                        break;
                    case "IMouseInputHolder":
                        typeOfClass = typeof(UiMouseInputHolder);
                        wearedInterface = typeof(IMouseInput);
                        break;
                    case "ITouchInputHolder":
                        typeOfClass = typeof(UiTouchInputHolder);
                        wearedInterface = typeof(ITouchInput);
                        break;
                }
                
    			T proxiedHolder =
    			    (T)_generator.CreateClassProxy(
    			        typeOfClass,
    			        new Type[] { wearedInterface },
    			        new MethodSelectorAspect());
    			
    			(proxiedHolder as IHolder).SetParentElement(parentElement);
    			
    			return proxiedHolder;
    			
            } catch (Exception eFailedToIssueHolder) {
                // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Holder");
			    // Console.WriteLine(eFailedToIssueHolder.Message);
			    return default(T);
            }
        }
        
        internal static IInputSimulator GetInputSimulator()
        {
            try {
                // 20140122
                // return Kernel.Get<InputSimulator>(new IParameter[] {});
//                if (null != ChildKernel) {
                    // return ChildKernel.Get<InputSimulator>(new IParameter[] {});
                    // var childKernel = GetChildKernel();
                    // return childKernel.Get<InputSimulator>(new IParameter[] {});
                    // childKernel.Dispose();
                    return ChildKernel.Get<InputSimulator>(new IParameter[] {});
//                } else {
//                    return Kernel.Get<InputSimulator>(new IParameter[] {});
//                }
                
            } catch (Exception eFailedToIssueInputSimulator) {
                // TODO
			    // write error to error object!!!
			    // Console.WriteLine("InputSimulator");
			    // Console.WriteLine(eFailedToIssueInputSimulator.Message);
                return null;
            }
        }
		
		public static IUiElement GetUiElement(object element)
		{
		    if (element is AutomationElement) {
		        return GetUiElement(element as AutomationElement);
		    } else if (element is IUiElement) {
		        return GetUiElement(element as IUiElement);
		    } else {
		        return GetUiElement();
		    }
		    
		}
		
//		public static IUiElement GetUiElementViaChildKernel(AutomationElement element, IChildKernel childKernel)
//		{
//	        if (null == element) {
//	            return null;
//	        }
//		    
//			try {
//    			var singleElement = new ConstructorArgument("element", element);
//    			IUiElement adapterElement = childKernel.Get<IUiElement>("AutomationElement.NET", singleElement);
//    			
//    			if (Preferences.UseElementsPatternObjectModel) {
//    			    
//        			IUiElement proxiedTypedUiElement =
//        			    ConvertToProxiedElement(
//        			        adapterElement);
//        			
//        			proxiedTypedUiElement.SetSourceElement<AutomationElement>(element);
//        			
//        			return (IUiElement)proxiedTypedUiElement; // as IUiElement;
//    			} else {
//    			    
//    			    adapterElement.SetSourceElement<AutomationElement>(element);
//    			    
//    			    return adapterElement;
//    			}
//    			
//			}
//			catch (Exception eFailedToIssueElement) {
//			    // TODO
//			    // write error to error object!!!
//			    // Console.WriteLine("Element 01 via ChildKernel");
//			    // Console.WriteLine(eFailedToIssueElement.Message);
//			    return null;
//			}
//		}
		
		public static IUiElement GetUiElement(AutomationElement element)
		{
	        if (null == element) {
	            return null;
	        }
		    
			try {
    			var singleElement = new ConstructorArgument("element", element);
    			// 20140122
    			IUiElement adapterElement; // = Kernel.Get<IUiElement>("AutomationElement.NET", singleElement);
    			
//    			if (null != ChildKernel) {
//Console.WriteLine("child elt");
    			    // adapterElement = ChildKernel.Get<IUiElement>("AutomationElement.NET", singleElement);
    			    // var childKernel = GetChildKernel();
    			    // adapterElement = childKernel.Get<IUiElement>("AutomationElement.NET", singleElement);
    			    adapterElement = ChildKernel.Get<IUiElement>("AutomationElement.NET", singleElement);
    			    // childKernel.Dispose();
    			    // (adapterElement as UiElement).ChildKernel = childKernel;
//    			} else {
//    			    adapterElement = Kernel.Get<IUiElement>("AutomationElement.NET", singleElement);
//    			}
    			
    			if (Preferences.UseElementsPatternObjectModel) {
    			    
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
			    // Console.WriteLine("Element 01");
			    // Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
		
		// to prevent from threading lock
		internal static IUiElement GetUiElement(IUiElement element)
		{
	        if (null == element) {
	            return null;
	        }
	        
			try {
                
    			var singleElement = new ConstructorArgument("element", element);
    			
    			// 20140122
    			IUiElement adapterElement; // = Kernel.Get<IUiElement>("UiElement", singleElement);
    			// var childKernel = GetChildKernel();
			    // adapterElement = childKernel.Get<IUiElement>("UiElement", singleElement);
			    adapterElement = ChildKernel.Get<IUiElement>("UiElement", singleElement);
			    // childKernel.Dispose();
			    // (adapterElement as UiElement).ChildKernel = childKernel;
    			
    			if (Preferences.UseElementsPatternObjectModel) {
    			    
        			IUiElement proxiedTypedUiElement =
        			    ConvertToProxiedElement(
        			        adapterElement);
        			
        			proxiedTypedUiElement.SetSourceElement<IUiElement>(element);
        			
        			return (IUiElement)proxiedTypedUiElement;
    			} else {
    			    
    			    adapterElement.SetSourceElement<IUiElement>(element);
    			    
    			    return adapterElement;
    			}
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Element 02");
			    // Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
		
		// to prevent from threading lock
		internal static IUiElement GetUiElement()
		{
			try {
		        // 20140122
    			IUiElement adapterElement; // = Kernel.Get<IUiElement>("Empty", null);
    			// var childKernel = GetChildKernel();
			    // adapterElement = childKernel.Get<IUiElement>("Empty", null);
			    adapterElement = ChildKernel.Get<IUiElement>("Empty", null);
			    // childKernel.Dispose();
			    // (adapterElement as UiElement).ChildKernel = childKernel;
    			
    			if (Preferences.UseElementsPatternObjectModel) {
    			    
        			IUiElement proxiedTypedUiElement =
        			    ConvertToProxiedElement(
        			        adapterElement);
        			
        			return (IUiElement)proxiedTypedUiElement;
    			} else {
    			    
    			    return adapterElement;
    			}
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Element 03");
			    // Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
		
		internal static IUiElementInformation GetUiElementInformation(AutomationElement.AutomationElementInformation information)
		{
			try {
    			var singleInfo = new ConstructorArgument("information", information);
    			// 20140122
    			// IUiElementInformation adapterInformation = Kernel.Get<IUiElementInformation>(singleInfo);
    			IUiElementInformation adapterInformation;
//    			if (null != ChildKernel) {
    			    // adapterInformation = ChildKernel.Get<IUiElementInformation>(singleInfo);
    			    // var childKernel = GetChildKernel();
    			    // adapterInformation = childKernel.Get<IUiElementInformation>(singleInfo);
    			    adapterInformation = ChildKernel.Get<IUiElementInformation>(singleInfo);
    			    // childKernel.Dispose();
//    			} else {
//    			    adapterInformation = Kernel.Get<IUiElementInformation>(singleInfo);
//    			}
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
//		internal static IUiEltCollection GetUiEltCollectionViaChildKerne(AutomationElementCollection elements, IChildKernel childKernel)
//		{
//	        if (null == elements) {
//	            return null;
//	        }
//			try {
//    			var manyElements = new ConstructorArgument("elements", elements);
//	      		IUiEltCollection adapterCollection = childKernel.Get<IUiEltCollection>("AutomationElementCollection.NET", manyElements);
//	       		return adapterCollection;
//			}
//			catch (Exception eFailedToIssueCollection) {
//			    // TODO
//			    // write error to error object!!!
//			    // Console.WriteLine("Collection 01 via ChildKernel");
//			    // Console.WriteLine(eFailedToIssueCollection.Message);
//			    return null;
//			}
//		}
		
		internal static IUiEltCollection GetUiEltCollection(AutomationElementCollection elements)
		{
	        if (null == elements) {
	            return null;
	        }
			try {
    			var manyElements = new ConstructorArgument("elements", elements);
    			// 20140122
	      		IUiEltCollection adapterCollection; // = Kernel.Get<IUiEltCollection>("AutomationElementCollection.NET", manyElements);
//	      		if (null != ChildKernel) {
//Console.WriteLine("child coll");
	      		    // adapterCollection = ChildKernel.Get<IUiEltCollection>("AutomationElementCollection.NET", manyElements);
	      		    // var childKernel = GetChildKernel();
	      		    // adapterCollection = childKernel.Get<IUiEltCollection>("AutomationElementCollection.NET", manyElements);
	      		    adapterCollection = ChildKernel.Get<IUiEltCollection>("AutomationElementCollection.NET", manyElements);
	      		    // childKernel.Dispose();
//	      		} else {
//	      		    adapterCollection = Kernel.Get<IUiEltCollection>("AutomationElementCollection.NET", manyElements);
//	      		}
	       		return adapterCollection;
			}
			catch (Exception eFailedToIssueCollection) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Collection 01");
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
	      		// IUiEltCollection adapterCollection = Kernel.Get<IUiEltCollection>("UiEltCollection", manyElements);
	      		IUiEltCollection adapterCollection = ChildKernel.Get<IUiEltCollection>("UiEltCollection", manyElements);
	       		return adapterCollection;
			}
			catch (Exception eFailedToIssueCollection) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Collection 02");
			    // Console.WriteLine(eFailedToIssueCollection.Message);
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
	      		// IUiEltCollection adapterCollection = Kernel.Get<IUiEltCollection>("AnyCollection", manyElements);
	      		IUiEltCollection adapterCollection = ChildKernel.Get<IUiEltCollection>("AnyCollection", manyElements);
	       		return adapterCollection;
			}
			catch (Exception eFailedToIssueCollection) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Collection 03");
			    // Console.WriteLine(eFailedToIssueCollection.Message);
			    return null;
			}
		}
		
		internal static IUiEltCollection GetUiEltCollection()
		{
			try {
		        var boolArgument = new ConstructorArgument("fake", true);
	      		// IUiEltCollection adapterCollection = Kernel.Get<IUiEltCollection>("Empty", boolArgument);
	      		IUiEltCollection adapterCollection = ChildKernel.Get<IUiEltCollection>("Empty", boolArgument);
	       		return adapterCollection;
			}
			catch (Exception eFailedToIssueCollection) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Collection 04");
			    // Console.WriteLine(eFailedToIssueCollection.Message);
			    return null;
			}
		}
		#endregion IUiEltCollection
		
		#region patterns
		internal static N GetPatternAdapter<N>(IUiElement element, object pattern)
		    where N : IBasePattern
		{
			try {
                
                N adapterPattern = default(N);
                var argElement = new ConstructorArgument("element", element);
                // adapterPattern = Kernel.Get<N>(NamedParameter_WithoutPattern, new[] { argElement });
                adapterPattern = ChildKernel.Get<N>(NamedParameter_WithoutPattern, new[] { argElement });
		        adapterPattern.SetSourcePattern(pattern);
	       		return adapterPattern;
			}
			catch (Exception eFailedToIssuePattern) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Pattern");
			    // Console.WriteLine(eFailedToIssuePattern.Message);
			    // return null;
			    return default(N);
			}
		}
		
		internal static N GetPatternAdapter<N>(object pattern)
		    where N : IBasePattern
		{
			try {
                
                N adapterPattern = default(N);
                // adapterPattern = Kernel.Get<N>(NamedParameter_WithoutElement, null);
                adapterPattern = ChildKernel.Get<N>(NamedParameter_WithoutElement, null);
		        adapterPattern.SetSourcePattern(pattern);
	       		return adapterPattern;
			}
			catch (Exception eFailedToIssuePattern) {
			    // TODO
			    // write error to error object!!!
			    // Console.WriteLine("Pattern");
			    // Console.WriteLine(eFailedToIssuePattern.Message);
			    // return null;
			    return default(N);
			}
		}
		#endregion patterns
        
        internal static SearcherTemplate GetSearchImpl<T>()
        {
            var newObject = Kernel.Get<T>(new IParameter[] {});
            return ConvertToProxiedObject<T>(newObject) as SearcherTemplate;
        }
        
        internal static IAutomation GetMyAutomation()
        {
            return Kernel.Get<IAutomation>();
        }
    }
}
