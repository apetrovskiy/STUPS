/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/15/2014
 * Time: 12:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
	using System.Windows.Documents;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Parameters;
    using Ninject.Extensions.ChildKernel;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
//    using System.Management.Automation;
    using System.Collections;
//    using System.Collections.Generic;
    using PSTestLib;
    using Castle.DynamicProxy;
    using System.Linq;
    using WindowsInput;
    
    using NLog;
    
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
//Console.WriteLine("AF.AF 01");
            if (PSCmdletBase.UnitTestMode) return;
//Console.WriteLine("AF.AF 02");
            // ObjectFactory.Init(new ObjectLifecycleModule());
            Init();
//Console.WriteLine("AF.AF 03");
            _alreadyInitialized = true;
        }
        //
        
        public static void Init()
        {
//Console.WriteLine("AF.Init 01");
            if (PSCmdletBase.UnitTestMode) return;
Console.WriteLine("AF.Init 02");
            ObjectFactory.Init(new ObjectLifecycleModule());
//Console.WriteLine("AF.Init 03");
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
        
        
        
        
        // public static IUiElement GetUiElement(classic.AutomationElement element)
        public static IUiElement GetUiElement<T>(T element)
		{
//Console.WriteLine("GetUIElement 00000");
	        if (null == element) {
	            return null;
	        }
		    
			try {
    			// var singleElement = new ConstructorArgument("element", element);
    			
    			// var adapterElement = ChildKernel.Get<IUiElement>("AutomationElement.NET", singleElement);
Console.WriteLine("GetUiElement: 0000000000000001");
                var adapterElement = ObjectFactory.Resolve<IUiElement>(); // singleElement); // ChildKernel.Get<IUiElement>("AutomationElement.NET", singleElement);
Console.WriteLine("GetUiElement: 0000000000000002");
                
                #region commented
//if (null == adapterElement) {
//    Console.WriteLine("null == adapterElement");
//} else {
//    Console.WriteLine("null != adapterElement");
//}
                #endregion commented
                
if (null == adapterElement) {
    Console.WriteLine("GetUiElement: null == adapterElement");
} else {
    Console.WriteLine("GetUiElement: null != adapterElement");
    Console.WriteLine("GetUiElement: type of element is {0}", UiElement._innerElementType.ToString());
}
                
                // 20140316
                adapterElement.SetSourceElement<T>(element);
                
var sourceElement = adapterElement.GetSourceElement() as classic.AutomationElement;
if (null == sourceElement) {
    Console.WriteLine("GetUiElement: null == sourceElement");
} else {
    Console.WriteLine("GetUiElement: null != sourceElement");
    Console.WriteLine(sourceElement.GetType().Name);
    Console.WriteLine("GetUiElement 02: type of element is {0}", UiElement._innerElementType.ToString());
}
                
				return Preferences.UseProxy ? (IUiElement)ConvertToProxiedElement(adapterElement) : (IUiElement)adapterElement;
                
                #region commented
                /*
    			if (Preferences.UseProxy) {
    			    
//Console.WriteLine("use proxy");
                    // 20140316
        			// IUiElement proxiedTypedUiElement =
        			//     ConvertToProxiedElement(
        			//         adapterElement);
        			
        			// proxiedTypedUiElement.SetSourceElement<classic.AutomationElement>(element);
                    // 20140316
                    // proxiedTypedUiElement.SetSourceElement<T>(element);
        			
//if (null == (IUiElement)proxiedTypedUiElement) {
//    Console.WriteLine("null == (IUiElement)proxiedTypedUiElement");
//} else {
//    Console.WriteLine("null != (IUiElement)proxiedTypedUiElement");
//}
                    // 20140316
        			// return (IUiElement)proxiedTypedUiElement; // as IUiElement;
                    
                    // 20140316
                    return (IUiElement)ConvertToProxiedElement(adapterElement);
                    
    			} else {
    			    
//Console.WriteLine("don't use proxy");
    			    // adapterElement.SetSourceElement<classic.AutomationElement>(element);
                    // 20140316
                    // adapterElement.SetSourceElement<T>(element);
    			    
//if (null == adapterElement) {
//    Console.WriteLine("null == adapterElement");
//} else {
//    Console.WriteLine("null != adapterElement");
//}
                    // 20140316
    			    // return adapterElement;
                    return (IUiElement)adapterElement;
    			}
                */
    			#endregion commented
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    Console.WriteLine("Element 01");
			    Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
        
        #region commented
//        public static IUiElement GetUiElement()
//		{
//			try {
//    			// var singleElement = new ConstructorArgument("element", element);
//    			
//    			// var adapterElement = ChildKernel.Get<IUiElement>("AutomationElement.NET", singleElement);
//                var adapterElement = ObjectFactory.Resolve<IUiElement>(); // singleElement); // ChildKernel.Get<IUiElement>("AutomationElement.NET", singleElement);
//    			
//    			if (Preferences.UseProxy) {
//    			    
//        			IUiElement proxiedTypedUiElement =
//        			    ConvertToProxiedElement(
//        			        adapterElement);
//        			
//        			return (IUiElement)proxiedTypedUiElement; // as IUiElement;
//    			} else {
//    			    
//    			    return adapterElement;
//    			}
//    			
//			}
//			catch (Exception eFailedToIssueElement) {
//			    // TODO
//			    // write error to error object!!!
//			    Console.WriteLine("Element 02");
//			    Console.WriteLine(eFailedToIssueElement.Message);
//			    return null;
//			}
//		}
        #endregion commented
        
        internal static IUiElement ConvertToProxiedElement<T>(T element)
        {
            #region commented
//if (null == element) {
//    Console.WriteLine("ConvertToProxiedElement: null == element");
//} else {
//    Console.WriteLine("ConvertToProxiedElement: null != element");
//}
            #endregion commented
            
            Type[] supportedAdditionalInterfaces =
                UiaHelper.GetSupportedInterfaces(element);
            
            #region commented
//Console.WriteLine("ConvertToProxiedElement: 000002");
//if (null != supportedAdditionalInterfaces && 0 < supportedAdditionalInterfaces.Length) {
//    Console.WriteLine("null != supportedAdditionalInterfaces && 0 < supportedAdditionalInterfaces.Length");
//    foreach (Type iface in supportedAdditionalInterfaces) {
//        Console.WriteLine(iface.Name);
//    }
//} else {
//    Console.WriteLine("null == supportedAdditionalInterfaces || 0 == supportedAdditionalInterfaces.Length");
//}
            #endregion commented
            
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
                    
Console.WriteLine("ConvertToProxiedElement: 000004");
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
            
            #region commented
//Console.WriteLine("ConvertToProxiedElement: 000009");
//if (null == proxiedElement) {
//    Console.WriteLine("ConvertToProxiedElement: null == proxiedElement");
//} else {
//    Console.WriteLine("ConvertToProxiedElement: null != proxiedElement");
//}
            #endregion commented
            
//if (null != proxiedElement) {
//    Console.WriteLine("ConvertToProxiedElement: null != proxiedElement");
//    Console.WriteLine(proxiedElement.GetType().Name);
//    var sourceElement = proxiedElement.GetSourceElement();
//    if (null != sourceElement) {
//        Console.WriteLine("ConvertToProxiedElement: null != sourceElement");
//        Console.WriteLine(sourceElement.GetType().Name);
//        Console.WriteLine((sourceElement as classic.AutomationElement).Current.Name);
//        Console.WriteLine((sourceElement as classic.AutomationElement).Current.AutomationId);
//        Console.WriteLine((sourceElement as classic.AutomationElement).Current.ClassName);
//    } else {
//        Console.WriteLine("ConvertToProxiedElement: null == sourceElement");
//    }
//} else {
//    Console.WriteLine("ConvertToProxiedElement: null == proxiedElement");
//}
//            
//    		return proxiedElement;
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
                
//if (null == holder) {
//    Console.WriteLine("null == holder");
//} else {
//    Console.WriteLine("null != holder");
//    Console.WriteLine(holder.GetType().Name);
//}
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
                                new Type[] { wearedInterface });
                        break;
                    case "IKeyboardInputHolder":
                        typeOfClass = typeof(UiKeyboardInputHolder);
                        wearedInterface = typeof(IKeyboardInput);
                        proxiedHolder =
                            (T)ObjectFactory.ConvertToProxiedObject<T>(
                                // holder,
                                typeof(UiKeyboardInputHolder),
                                new IInterceptor[] { new MethodSelectorAspect() },
                                new Type[] { wearedInterface });
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
                                new Type[] { wearedInterface });
                        break;
                    case "ITouchInputHolder":
                        typeOfClass = typeof(UiTouchInputHolder);
                        wearedInterface = typeof(ITouchInput);
                        proxiedHolder =
                            (T)ObjectFactory.ConvertToProxiedObject<T>(
                                // holder,
                                typeof(UiTouchInputHolder),
                                new IInterceptor[] { new MethodSelectorAspect() },
                                new Type[] { wearedInterface });
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
                    
                    #region commented
//Console.WriteLine("GetUiEltCollection: 00001");
//Console.WriteLine("elements.Length = {0}", elements.Length.ToString());
//foreach (classic.AutomationElementCollection elements2 in elements) {
//    Console.WriteLine(elements2.GetType().Name);
////    try {
////        Console.WriteLine((element as ISupportsCurrent).Current.GetType().Name);
////    } catch (Exception) {
////        
////        throw;
////    }
//    Console.WriteLine(elements2.Count.ToString());
//    foreach (classic.AutomationElement element in elements2) {
//        Console.WriteLine(element.Current.Name);
//    }
//}
//Console.WriteLine("GetUiEltCollection: 00002");
                    #endregion commented
                    
        			var manyElements = new ConstructorArgument("elements", elements);
        			
    	      		// IUiEltCollection adapterCollection; // = Kernel.Get<IUiEltCollection>("AutomationElementCollection.NET", manyElements);
    	      		//     adapterCollection = ChildKernel.Get<IUiEltCollection>("AutomationElementCollection.NET", manyElements);
                    
//Console.WriteLine("GetUiEltCollection: 00003");
                    var adapterCollection = ObjectFactory.Resolve<IUiEltCollection>(manyElements);
                    
                    #region commented
//Console.WriteLine("GetUiEltCollection: 00004");
//if (null == adapterCollection) {
//    Console.WriteLine("null == adapterCollection");
//} else {
//    Console.WriteLine("null != adapterCollection");
//    Console.WriteLine(adapterCollection.GetType().Name);
//    foreach(IUiElement elt in adapterCollection.ToArray()) {
//        Console.WriteLine(elt.GetType().Name);
//        try { Console.WriteLine(elt.GetCurrent().Name); } catch {}
//    }
//                        try {
//    foreach (IUiElement element in adapterCollection) {
//        Console.WriteLine(element.GetType().Name);
//        try { Console.WriteLine(element.GetCurrent().Name); } catch {}
//    }
//                        }
//                        catch (Exception eeeeeeee) {
//                            Console.WriteLine(eeeeeeee.Message);
//                        }
//}
//Console.WriteLine("GetUiEltCollection: 00005");
                    #endregion commented
                    
    	       		return adapterCollection;
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
                
                // newCommand = Kernel.Get<T>(cmdletParam);
                // return ConvertToProxiedCommand<T>(newCommand, cmdlet);
                
                newCommand = ObjectFactory.Resolve<T>(cmdletParam);
                
                #region commented
                // newCommand = ObjectFactory.Resolve<T>();
                // newCommand
                // (newCommand as AbstractCommand).Cmdlet = cmdlet;
                
//if (null == newCommand) {
//    Console.WriteLine("GetCommand: null == newCommand");
//} else {
//    Console.WriteLine("GetCommand: null != newCommand");
//    Console.WriteLine(newCommand.GetType().Name);
//}
                
//                return ObjectFactory.ConvertToProxiedObject<T>(
//                    newCommand,
//                    new IInterceptor[] { new LoggingAspect(), new InputValidationAspect(), new ErrorHandlingAspect(), new HighlighterAspect(), new TestResultAspect(), new FaultInjectionAspect() });
                #endregion commented
                
                var proxiedCommand = (T)ObjectFactory.ConvertToProxiedObject<T>(
                    newCommand,
                    cmdlet,
                    // new IInterceptor[] { new LoggingAspect(), new InputValidationAspect(), new ErrorHandlingAspect(), new HighlighterAspect(), new TestResultAspect(), new FaultInjectionAspect() }) as AbstractCommand;
                    // new IInterceptor[] { new LoggingAspect() }) as AbstractCommand;
                    // new IInterceptor[] { new HighlighterAspect() }); // as AbstractCommand;
                    new IInterceptor[] { new LoggingAspect(), new InputValidationAspect(), new ErrorHandlingAspect(), new TestResultAspect(), new FaultInjectionAspect() }); // as AbstractCommand;
                
                #region commented
//Console.WriteLine("GetCommand: proxified!");
                
                // (proxiedCommand as AbstractCommand).Cmdlet = cmdlet;
                // proxiedCommand.Cmdlet = cmdlet;
                
//if (null == proxiedCommand) {
//    Console.WriteLine("GetCommand: null == proxiedCommand");
//} else {
//    Console.WriteLine("GetCommand: null != proxiedCommand");
//}

                
//                var proxiedCommand = newCommand as AbstractCommand; // temp
                #endregion commented
                
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
        
        #region commented
//        internal static T ConvertToProxiedCommand<T>(T commandToConvert, CommonCmdletBase cmdlet)
//        {
//            T proxiedObject = default(T);
//            
//            try {
//                
//                proxiedObject =
//                    (T)_generator.CreateClassProxy(
//                        typeof(T),
//                        new CommonCmdletBase[]{ cmdlet },
//                        // 20140228
//                        // new LoggingAspect(), new InputValidationAspect(), new ErrorHandlingAspect(), new HighlighterAspect(), new TestResultAspect());
//                        new LoggingAspect(), new InputValidationAspect(), new ErrorHandlingAspect(), new HighlighterAspect(), new TestResultAspect(), new FaultInjectionAspect());
//                
//            } catch (Exception eProxying) {
//                // Console.WriteLine("ProxiedObject");
//                // Console.WriteLine(eProxying.Message);
//            }
//            
//            return proxiedObject;
//        }
        
        #endregion commented
        
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
