/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2014
 * Time: 12:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
//	using System.Windows.Documents;
//    using Ninject;
//    using Ninject.Modules;
    using Ninject.Parameters;
//    using Ninject.Extensions.ChildKernel;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
//    using System.Management.Automation;
    using System.Collections;
//    using System.Collections.Generic;
    using PSTestLib;
    using Castle.DynamicProxy;
    using System.Linq;
    using WindowsInput;
    
//    using NLog;
    
    /// <summary>
    /// Description of AutomationFactory.
    /// </summary>
    // public class AutomationFactory
    public static class AutomationFactory
    {
//        internal const string NamedParameter_WithPattern = "WithPattern";
        internal const string NamedParameter_WithoutPattern = "WithoutPattern";
        internal const string NamedParameter_WithoutElement = "WithoutElement";
        
        private static bool _alreadyInitialized;
        
        //
        static AutomationFactory()
        {
            if (_alreadyInitialized) return;
            if (PSCmdletBase.UnitTestMode) return;
            // ObjectFactory.Init(new ObjectLifecycleModule());
            Init();
            _alreadyInitialized = true;
        }
        //
        
        public static void Init()
        {
            if (PSCmdletBase.UnitTestMode) return;
            ObjectFactory.Init(new ObjectLifecycleModule());
        }
        
        internal static void InitUnitTests()
        {
//            InitCommonObjects();
        }
        
//		internal static void InitCommonObjects() // ?
//		{
//		    var argument = new ConstructorArgument("builder", new PersistentProxyBuilder());
//		    _generator = Kernel.Get<ProxyGenerator>(argument);
//		    
//            var logger = GetLogHelper(string.Empty);
//		}
        
//        public static IUiElement GetUiElement<T>(T element, string from)
//        {
//            Console.WriteLine(from);
//            return GetUiElement<T>(element);
//        }
        
        
        // public static IUiElement GetUiElement(classic.AutomationElement element)
        public static IUiElement GetUiElement<T>(T element)
		{
//Console.WriteLine("GetUIElement 00000");
	        if (null == element) {
Console.WriteLine("GetUiElement: null == element");
	            //return null;
	        }
		    
			try {
                var adapterElement = ObjectFactory.Resolve<IUiElement>(); // singleElement); // ChildKernel.Get<IUiElement>("AutomationElement.NET", singleElement);
                adapterElement.SetSourceElement<T>(element);
                
				return Preferences.UseProxy ? (IUiElement)ConvertToProxiedElement(adapterElement) : (IUiElement)adapterElement;
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    Console.WriteLine("Element 01");
			    Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
        
        internal static IUiElement ConvertToProxiedElement<T>(T element)
        {
            Type[] supportedAdditionalInterfaces =
                UiaHelper.GetSupportedInterfaces(element);
            
//if (null != supportedAdditionalInterfaces && 0 < supportedAdditionalInterfaces.Length) {
//    foreach (Type iface in supportedAdditionalInterfaces) {
//        Console.WriteLine(iface.Name);
//    }
//}
            // 20140317
            // UiElement proxiedElement = null;
            try {
                
//Console.WriteLine("ConvertToProxiedElement: 000003");
                if (null != supportedAdditionalInterfaces && 0 < supportedAdditionalInterfaces.Length) {
//            		proxiedElement =
//            		    (UiElement)_generator.CreateClassProxy(
//            		        typeof(UiElement),
//            		        supportedAdditionalInterfaces,
//                            new MethodSelectorAspect(), new ErrorHandlingAspect());
                    
                    // 20140317
                    // proxiedElement =
                    return
                        (UiElement)ObjectFactory.ConvertToProxiedObject<UiElement>(
                            // 20140317
                            //proxiedElement,
                            typeof(UiElement),
                            new IInterceptor[] { new MethodSelectorAspect(), new ErrorHandlingAspect() },
                            // new IInterceptor[] {},
                            supportedAdditionalInterfaces);
                    
//Console.WriteLine("ConvertToProxiedElement: 000005");
                } else {
//            		proxiedElement =
//            		    (UiElement)_generator.CreateClassProxy(
//            		        typeof(UiElement),
//                            new MethodSelectorAspect(), new ErrorHandlingAspect());
                    
Console.WriteLine("ConvertToProxiedElement: 000006");
                    // 20140317
                    // proxiedElement =
                    return
                        (UiElement)ObjectFactory.ConvertToProxiedObject<UiElement>(
                            // 20140317
                            // proxiedElement,
                            typeof(UiElement),
                            new IInterceptor[] { new MethodSelectorAspect(), new ErrorHandlingAspect() });
//Console.WriteLine("ConvertToProxiedElement: 000007");
                }
            }
            catch (Exception eConvertation) {
//Console.WriteLine("ConvertToProxiedElement: 000008");
Console.WriteLine("ConvertToProxiedElement<T>(T element): 0005");
                Console.WriteLine(eConvertation.Message);
                // 20140317
                return null;
            }
        }
        
		internal static IUiElementInformation GetUiElementInformation(classic.AutomationElement.AutomationElementInformation information)
		{
			try {
    			var singleInfo = new ConstructorArgument("information", information);
                return ObjectFactory.Resolve<IUiElementInformation>(singleInfo);
			}
			catch (Exception eFailedToIssueInformation) {
			    // TODO
			    // write error to error object!!!
                Console.WriteLine("Information");
			    Console.WriteLine(eFailedToIssueInformation.Message);
			    return null;
			}
		}
        
		internal static IExtendedModelHolder GetUiExtendedModelHolder(IUiElement parentElement, classic.TreeScope scope)
		{
	        if (null == parentElement) {
	            return null;
	        }
		    
			try {
                
                var holder = ObjectFactory.Resolve<IExtendedModelHolder>();
                
//    			var proxiedHolder =
//    			    (IExtendedModelHolder)_generator.CreateClassProxy(
//    			        typeof(UiExtendedModelHolder),
//    			        new Type[] { typeof(IExtendedModel) },
//    			        new MethodSelectorAspect());
                
                var proxiedHolder =
                    (IExtendedModelHolder)ObjectFactory.ConvertToProxiedObject<UiExtendedModelHolder>(
                        (UiExtendedModelHolder)holder,
                        new IInterceptor[] { new MethodSelectorAspect() },
                        new Type[] { typeof(IExtendedModel) });
    			
    			proxiedHolder.SetScope(scope);
    			
    			proxiedHolder.SetParentElement(parentElement);
    			
    			return proxiedHolder;
			}
			catch (Exception eFailedToIssueHolder) {
			    // TODO
			    // write error to error object!!!
			    Console.WriteLine("Holder 001");
			    Console.WriteLine(eFailedToIssueHolder.Message);
			    return null;
			}
		}
        
        internal static T GetHolder<T>(IUiElement parentElement)
        {
	        if (null == parentElement) {
                return default(T);
	        }
            
            try {
                
                T holder = ObjectFactory.Resolve<T>();
                Type typeOfClass = null;
                Type wearedInterface = null;
                
                // var proxiedHolder = detaul
                var proxiedHolder = default(T);
                
                switch (typeof(T).Name) {
                    case "IControlInputHolder":
                        typeOfClass = typeof(UiControlInputHolder);
                        wearedInterface = typeof(IControlInput);
                        proxiedHolder =
                            (T)ObjectFactory.ConvertToProxiedObject<T>(
                                // holder,
                                typeof(UiControlInputHolder),
                                // typeOfClass,
                                new IInterceptor[] { new MethodSelectorAspect() },
                                // new Type[] { wearedInterface });
                                new[] { wearedInterface });
                        break;
                    case "IKeyboardInputHolder":
                        typeOfClass = typeof(UiKeyboardInputHolder);
                        wearedInterface = typeof(IKeyboardInput);
                        proxiedHolder =
                            (T)ObjectFactory.ConvertToProxiedObject<T>(
                                // holder,
                                typeof(UiKeyboardInputHolder),
                                new IInterceptor[] { new MethodSelectorAspect() },
                                // new Type[] { wearedInterface });
                                new[] { wearedInterface });
                        break;
                    case "IMouseInputHolder":
                        typeOfClass = typeof(UiMouseInputHolder);
                        wearedInterface = typeof(IMouseInput);
                        proxiedHolder =
                            (T)ObjectFactory.ConvertToProxiedObject<T>(
                                // holder,
                                typeof(UiMouseInputHolder),
                                // typeof(typeOfClass),
                                new IInterceptor[] { new MethodSelectorAspect() },
                                // new Type[] { wearedInterface });
                                new[] { wearedInterface });
                        break;
                    case "ITouchInputHolder":
                        typeOfClass = typeof(UiTouchInputHolder);
                        wearedInterface = typeof(ITouchInput);
                        proxiedHolder =
                            (T)ObjectFactory.ConvertToProxiedObject<T>(
                                // holder,
                                typeof(UiTouchInputHolder),
                                new IInterceptor[] { new MethodSelectorAspect() },
                                // new Type[] { wearedInterface });
                                new[] { wearedInterface });
                        break;
                }
                
//    			var proxiedHolder =
//    			    (T)_generator.CreateClassProxy(
//    			        typeOfClass,
//    			        new Type[] { wearedInterface },
//    			        new MethodSelectorAspect());
                
//                var proxiedHolder =
//                    (T)ObjectFactory.ConvertToProxiedObject<T,typeof(typeOfClass)>(
//                        // holder,
//                        typeOfClass,
//                        new IInterceptor[] { new MethodSelectorAspect() },
//                        new Type[] { wearedInterface });
    			
    			(proxiedHolder as IHolder).SetParentElement(parentElement);
    			
    			return proxiedHolder;
    			
            } catch (Exception eFailedToIssueHolder) {
                // TODO
			    // write error to error object!!!
			    Console.WriteLine("Holder 002");
			    Console.WriteLine(eFailedToIssueHolder.Message);
			    return default(T);
            }
        }
        
        internal static IInputSimulator GetInputSimulator()
        {
            try {
                return ObjectFactory.Resolve<InputSimulator>();
                
            } catch (Exception eFailedToIssueInputSimulator) {
                // TODO
			    // write error to error object!!!
			    Console.WriteLine("InputSimulator");
			    Console.WriteLine(eFailedToIssueInputSimulator.Message);
                return null;
            }
        }
        
        // internal static IUiEltCollection GetUiEltCollection<T>(T elements)
        // internal static IUiEltCollection GetUiEltCollection<T>(params T[] elements)
        // 20140316
        // internal static IUiEltCollection GetUiEltCollection(params IEnumerable[] elements)
        internal static IUiEltCollection GetUiEltCollection(params object[] elements)
		{
            /*
	        if (null == elements) {
	            return null;
	        }
            */
			try {
                if (null != elements) {
                    
        			var manyElements = new ConstructorArgument("elements", elements);
                    // var adapterCollection = ObjectFactory.Resolve<IUiEltCollection>(manyElements);
    	       		// return adapterCollection;
                    return ObjectFactory.Resolve<IUiEltCollection>(manyElements);
                } else {
                    return ObjectFactory.Resolve<IUiEltCollection>();
                }
			}
			catch (Exception eFailedToIssueCollection) {
			    // TODO
			    // write error to error object!!!
			    Console.WriteLine("Collection 01");
			    Console.WriteLine(eFailedToIssueCollection.Message);
			    return null;
			}
		}
        
        // internal static T GetCommand<T>(CommonCmdletBase cmdlet)
        // internal static AbstractCommand GetCommand<T>(CommonCmdletBase cmdlet)
        internal static T GetCommand<T>(CommonCmdletBase cmdlet)
        {
            try {
                T newCommand = default(T);
                var cmdletParam = new ConstructorArgument("cmdlet", cmdlet);
                newCommand = ObjectFactory.Resolve<T>(cmdletParam);
                
                var proxiedCommand = (T)ObjectFactory.ConvertToProxiedObject<T>(
                    newCommand,
                    cmdlet,
                    // new IInterceptor[] { new LoggingAspect(), new InputValidationAspect(), new ErrorHandlingAspect(), new HighlighterAspect(), new TestResultAspect(), new FaultInjectionAspect() }) as AbstractCommand;
                    // new IInterceptor[] { new LoggingAspect() }) as AbstractCommand;
                    // new IInterceptor[] { new HighlighterAspect() }); // as AbstractCommand;
                    new IInterceptor[] { new LoggingAspect(), new InputValidationAspect(), new ErrorHandlingAspect(), new TestResultAspect(), new FaultInjectionAspect() }); // as AbstractCommand;
                
                return proxiedCommand;
                
            } catch (Exception eCommand) {
			    // TODO
			    // write error to error object!!!
			    Console.WriteLine("Command 01");
			    Console.WriteLine(eCommand.Message);
			    return default(T);
			    // return null;
            }
        }
        
        internal static T GetObject<T>()
        {
            return ObjectFactory.Resolve<T>(new IParameter[] {});
        }
        
        internal static IAutomation GetMyAutomation()
        {
            return ObjectFactory.Resolve<IAutomation>();
        }
        
        internal static SearcherTemplate GetSearcherImpl<T>()
        {
            // var newObject = Kernel.Get<T>(new IParameter[] {});
            // return ConvertToProxiedObject<T>(newObject) as SearcherTemplate;
            var newObject = GetObject<T>();
            return ObjectFactory.ConvertToProxiedObject<T>(
                newObject,
                // 20140316
                // new IInterceptor[] { new LoggingAspect(), new ErrorHandlingAspect(), new FaultInjectionAspect(), new MethodSelectorAspect() }) as SearcherTemplate;
                // new IInterceptor[] { new LoggingAspect(), new ErrorHandlingAspect(), new FaultInjectionAspect() }) as SearcherTemplate;
                new IInterceptor[] { new EmptyAspect() }) as SearcherTemplate;
        }
        
        #region patterns
		internal static N GetPatternAdapter<N>(IUiElement element, object pattern)
		    where N : IBasePattern
		{
			try {
                
                N adapterPattern = default(N);
                var argElement = new ConstructorArgument("element", element);
                // adapterPattern = Kernel.Get<N>(NamedParameter_WithoutPattern, new[] { argElement });
                // 20140315
                // adapterPattern = ChildKernel.Get<N>(NamedParameter_WithoutPattern, new[] { argElement });
                adapterPattern = ObjectFactory.Resolve<N>(argElement);
		        adapterPattern.SetSourcePattern(pattern);
	       		return adapterPattern;
			}
			catch (Exception eFailedToIssuePattern) {
			    // TODO
			    // write error to error object!!!
			    Console.WriteLine("Pattern 01");
			    Console.WriteLine(eFailedToIssuePattern.Message);
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
                // 20140315
                // adapterPattern = ChildKernel.Get<N>(NamedParameter_WithoutElement, null);
                adapterPattern = ObjectFactory.Resolve<N>();
		        adapterPattern.SetSourcePattern(pattern);
	       		return adapterPattern;
			}
			catch (Exception eFailedToIssuePattern) {
			    // TODO
			    // write error to error object!!!
			    Console.WriteLine("Pattern 02");
			    Console.WriteLine(eFailedToIssuePattern.Message);
			    // return null;
			    return default(N);
			}
		}
		#endregion patterns
    }
}
