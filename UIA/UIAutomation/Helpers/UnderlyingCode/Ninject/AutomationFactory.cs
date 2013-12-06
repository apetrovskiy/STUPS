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
    using PSTestLib;
    
    /// <summary>
    /// Description of AutomationFactory.
    /// </summary>
    public static class AutomationFactory
    {
        #region Initialization
        static AutomationFactory()
        {
            if (PSCmdletBase.UnitTestMode || CommonCmdletBase.ModuleAlreadyLoaded) return;
            _ninjectModule = new ObjectLifecycleModule();
            CommonCmdletBase.ModuleAlreadyLoaded = true;
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
//		        Console.WriteLine("Init Kernel");
//		        Console.WriteLine(eInitFailure.Message);
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
		
		#region IMySuperWrapper
		internal static IMySuperWrapper GetMySuperWrapper(AutomationElement element)
		{
	        if (null == element) {
	            return null;
	        }
			try {
    			var singleElement = new ConstructorArgument("element", element);
    			IMySuperWrapper adapterElement = Kernel.Get<IMySuperWrapper>("AutomationElement.NET", singleElement);
    			return adapterElement;
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
//			    Console.WriteLine("Element");
//			    Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
		
		internal static IMySuperWrapper GetMySuperWrapper(IMySuperWrapper element)
		{
	        if (null == element) {
	            return null;
	        }
			try {
    			var singleElement = new ConstructorArgument("element", element);
    			IMySuperWrapper adapterElement = Kernel.Get<IMySuperWrapper>("MySuperWrapper", singleElement);
    			return adapterElement;
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    //Console.WriteLine("Element");
			    //Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
		
		internal static IMySuperWrapper GetMySuperWrapper()
		{
//	        if (null == element) {
//	            return null;
//	        }
			try {
    			//IMySuperWrapper adapterElement = ObjectsFactory.Kernel.Get<IMySuperWrapper>();
    			IMySuperWrapper adapterElement = Kernel.Get<IMySuperWrapper>("Empty", null);
    			return adapterElement;
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    //Console.WriteLine("Element");
			    //Console.WriteLine(eFailedToIssueElement.Message);
			    return null;
			}
		}
		
		internal static IMySuperWrapperInformation GetMySuperWrapperInformation(AutomationElement.AutomationElementInformation information)
		{
//	        if (null == information) {
//	            return null;
//	        }
			try {
    			var singleInfo = new ConstructorArgument("information", information);
    			IMySuperWrapperInformation adapterInformation = Kernel.Get<IMySuperWrapperInformation>(singleInfo);
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
		#endregion IMySuperWrapper
		
		#region IMySuperCollection
		internal static IMySuperCollection GetMySuperCollection(AutomationElementCollection elements)
		{
	        if (null == elements) {
	            return null;
	        }
			try {
    			var manyElements = new ConstructorArgument("elements", elements);
	      		IMySuperCollection adapterCollection = Kernel.Get<IMySuperCollection>("AutomationElementCollection.NET", manyElements);
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
		
		internal static IMySuperCollection GetMySuperCollection(IMySuperCollection elements)
		{
	        if (null == elements) {
	            return null;
	        }
			try {
    			var manyElements = new ConstructorArgument("elements", elements);
	      		IMySuperCollection adapterCollection = Kernel.Get<IMySuperCollection>("MySuperCollection", manyElements);
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
		
		internal static IMySuperCollection GetMySuperCollection(IEnumerable elements)
		{
	        if (null == elements) {
	            return null;
	        }
			try {
    			var manyElements = new ConstructorArgument("elements", elements);
	      		IMySuperCollection adapterCollection = Kernel.Get<IMySuperCollection>("AnyCollection", manyElements);
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
		
		internal static IMySuperCollection GetMySuperCollection()
		{
			try {
		        var boolArgument = new ConstructorArgument("fake", true);
	      		IMySuperCollection adapterCollection = Kernel.Get<IMySuperCollection>("Empty", boolArgument);
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
		#endregion IMySuperCollection
		
		#region IMySuperExpandCollapsePattern
		internal static IMySuperExpandCollapsePattern GetMySuperExpandCollapsePattern(IMySuperWrapper element, ExpandCollapsePattern expandCollapsePattern)
		{
		    try {
                var argElement = new ConstructorArgument("element", element);
		        var argPattern = new ConstructorArgument("expandCollapsePattern", expandCollapsePattern);
		        IMySuperExpandCollapsePattern adapterPattern = Kernel.Get<IMySuperExpandCollapsePattern>(new[] { argElement, argPattern });
	       		return adapterPattern;
			}
			catch (Exception eFailedToIssueExpandCollapsePattern) {
			    // TODO
			    // write error to error object!!!
//			    Console.WriteLine("ExpandCollapsePattern");
//			    Console.WriteLine(eFailedToIssueExpandCollapsePattern.Message);
			    return null;
			}
		}
		#endregion IMySuperExpandCollapsePattern
		
		#region IMySuperInvokePattern
		internal static IMySuperInvokePattern GetMySuperInvokePattern(IMySuperWrapper element, InvokePattern invokePattern)
		{
			try {
                var argElement = new ConstructorArgument("element", element);
		        var argPattern = new ConstructorArgument("invokePattern", invokePattern);
		        IMySuperInvokePattern adapterPattern = Kernel.Get<IMySuperInvokePattern>(new[] { argElement, argPattern });
	       		return adapterPattern;
			}
			catch (Exception eFailedToIssueInvokePattern) {
			    // TODO
			    // write error to error object!!!
//			    Console.WriteLine("InvokePattern");
//			    Console.WriteLine(eFailedToIssueInvokePattern.Message);
			    return null;
			}
		}
		#endregion IMySuperInvokePattern
		
		#region IMySuperSelectionItemPattern
		internal static IMySuperSelectionItemPattern GetMySuperSelectionItemPattern(IMySuperWrapper element, SelectionItemPattern selectionItemPattern)
		{
		    try {
                var argElement = new ConstructorArgument("element", element);
		        var argPattern = new ConstructorArgument("selectionItemPattern", selectionItemPattern);
		        IMySuperSelectionItemPattern adapterPattern = Kernel.Get<IMySuperSelectionItemPattern>(new[] { argElement, argPattern });
	       		return adapterPattern;
			}
			catch (Exception eFailedToIssueIMySuperSelectionItemPattern) {
			    // TODO
			    // write error to error object!!!
//			    Console.WriteLine("IMySuperSelectionItemPattern");
//			    Console.WriteLine(eFailedToIssueIMySuperSelectionItemPattern.Message);
			    return null;
			}
		}
		#endregion IMySuperSelectionItemPattern
		
		#region IMySuperSelectionPattern
		internal static IMySuperSelectionPattern GetMySuperSelectionPattern(IMySuperWrapper element, SelectionPattern selectionPattern)
		{
		    try {
                var argElement = new ConstructorArgument("element", element);
		        var argPattern = new ConstructorArgument("selectionPattern", selectionPattern);
		        IMySuperSelectionPattern adapterPattern = Kernel.Get<IMySuperSelectionPattern>(new[] { argElement, argPattern });
	       		return adapterPattern;
			}
			catch (Exception eFailedToIssueSelectionPattern) {
			    // TODO
			    // write error to error object!!!
//			    Console.WriteLine("SelectionPattern");
//			    Console.WriteLine(eFailedToIssueSelectionPattern.Message);
			    return null;
			}
		}
		#endregion IMySuperSelectionPattern
		
		#region IMySuperTogglePattern
		internal static IMySuperTogglePattern GetMySuperTogglePattern(IMySuperWrapper element, TogglePattern togglePattern)
		{
		    try {
                var argElement = new ConstructorArgument("element", element);
		        var argPattern = new ConstructorArgument("togglePattern", togglePattern);
		        IMySuperTogglePattern adapterPattern = Kernel.Get<IMySuperTogglePattern>(new[] { argElement, argPattern });
	       		return adapterPattern;
			}
			catch (Exception eFailedToIssueTogglePattern) {
			    // TODO
			    // write error to error object!!!
//			    Console.WriteLine("TogglePattern");
//			    Console.WriteLine(eFailedToIssueTogglePattern.Message);
			    return null;
			}
		}
		#endregion IMySuperTogglePattern
		
		#region IMySuperValuePattern
		internal static IMySuperValuePattern GetMySuperValuePattern(IMySuperWrapper element, ValuePattern valuePattern)
		{
			try {
                var argElement = new ConstructorArgument("element", element);
		        var argPattern = new ConstructorArgument("valuePattern", valuePattern);
		        IMySuperValuePattern adapterPattern = Kernel.Get<IMySuperValuePattern>(new[] { argElement, argPattern });
	       		return adapterPattern;
			}
			catch (Exception eFailedToIssueValuePattern) {
			    // TODO
			    // write error to error object!!!
//			    Console.WriteLine("ValuePattern");
//			    Console.WriteLine(eFailedToIssueValuePattern.Message);
			    return null;
			}
		}
		#endregion IMySuperInvokePattern
    }
}
