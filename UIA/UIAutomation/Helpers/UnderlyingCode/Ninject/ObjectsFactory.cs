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
    using System;
    using Ninject;
    using Ninject.Modules;
    using System.Windows.Automation;
    using System.Collections;
    using PSTestLib;
    
    /// <summary>
    /// Description of ObjectsFactory.
    /// </summary>
    public static class ObjectsFactory
    {
        #region Initialization
        static ObjectsFactory()
        {
            if (PSCmdletBase.UnitTestMode || CommonCmdletBase.ModuleAlreadyLoaded) return;
            ninjectModule = new ObjectLifecycleModule();
            CommonCmdletBase.ModuleAlreadyLoaded = true;
        }
        
		private static INinjectModule ninjectModule;
		internal static INinjectModule NinjectModule
		{ 
		    get { return ninjectModule; }
		    set { ninjectModule = value; initFlag = false; }
		}
		
		private static bool initFlag = false;
		
		private static StandardKernel kernel;
		internal static StandardKernel Kernel
		{
		    get { return kernel; }
		}
		
		public static void Init()
		{
		    if (initFlag) return;
		    try {
		        kernel = new StandardKernel(ninjectModule);
		    }
		    catch (Exception eInitFailure) {
		        // TODO
		        // write error to error object!!!
//		        Console.WriteLine("Init Kernel");
//		        Console.WriteLine(eInitFailure.Message);
		    }

		    initFlag = true;
        }
		
		internal static void InitUnitTests()
		{
		    try {
		        ninjectModule = new ObjectLifecycleModule();
		        kernel = new StandardKernel(ninjectModule);
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
    			var singleElement = new Ninject.Parameters.ConstructorArgument("element", element);
    			IMySuperWrapper adapterElement = ObjectsFactory.Kernel.Get<IMySuperWrapper>("AutomationElement.NET", singleElement);
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
    			var singleElement = new Ninject.Parameters.ConstructorArgument("element", element);
    			IMySuperWrapper adapterElement = ObjectsFactory.Kernel.Get<IMySuperWrapper>("MySuperWrapper", singleElement);
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
    			IMySuperWrapper adapterElement = ObjectsFactory.Kernel.Get<IMySuperWrapper>("Empty", null);
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
    			var singleInfo = new Ninject.Parameters.ConstructorArgument("information", information);
    			IMySuperWrapperInformation adapterInformation = ObjectsFactory.Kernel.Get<IMySuperWrapperInformation>(singleInfo);
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
    			var manyElements = new Ninject.Parameters.ConstructorArgument("elements", elements);
	      		IMySuperCollection adapterCollection = ObjectsFactory.Kernel.Get<IMySuperCollection>("AutomationElementCollection.NET", manyElements);
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
    			var manyElements = new Ninject.Parameters.ConstructorArgument("elements", elements);
	      		IMySuperCollection adapterCollection = ObjectsFactory.Kernel.Get<IMySuperCollection>("MySuperCollection", manyElements);
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
    			var manyElements = new Ninject.Parameters.ConstructorArgument("elements", elements);
	      		IMySuperCollection adapterCollection = ObjectsFactory.Kernel.Get<IMySuperCollection>("AnyCollection", manyElements);
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
		        var boolArgument = new Ninject.Parameters.ConstructorArgument("fake", true);
	      		IMySuperCollection adapterCollection = ObjectsFactory.Kernel.Get<IMySuperCollection>("Empty", boolArgument);
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
		
		#region IMySuperValuePattern
		internal static IMySuperValuePattern GetMySuperValuePattern(IMySuperWrapper element, System.Windows.Automation.ValuePattern valuePattern)
		{
			try {
                var argElement = new Ninject.Parameters.ConstructorArgument("element", element);
		        var argPattern = new Ninject.Parameters.ConstructorArgument("valuePattern", valuePattern);
		        IMySuperValuePattern adapterPattern = ObjectsFactory.Kernel.Get<IMySuperValuePattern>(new[] { argElement, argPattern });
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
		#endregion IMySuperValuePattern
    }
}
