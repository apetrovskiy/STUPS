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
    
    /// <summary>
    /// Description of ObjectsFactory.
    /// </summary>
    public static class ObjectsFactory
    {
        static ObjectsFactory()
        {
            if (CommonCmdletBase.UnitTestMode || CommonCmdletBase.ModuleAlreadyLoaded) return;
            ninjectModule = new ObjectLifecycleModule();
            CommonCmdletBase.ModuleAlreadyLoaded = true;

            /*
            if (!CommonCmdletBase.UnitTestMode && !CommonCmdletBase.ModuleAlreadyLoaded) {

                ninjectModule = new ObjectLifecycleModule();
                CommonCmdletBase.ModuleAlreadyLoaded = true;
            }
            */
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
		
		// 20131114
		//internal static void Init()
		public static void Init()
		{
		    if (initFlag) return;
		    try {
		        kernel = new StandardKernel(ninjectModule);
		    }
		    catch (Exception eInitFailure) {
		        // TODO
		        // write error to error object!!!
		        //Console.WriteLine("Init Kernel");
		        //Console.WriteLine(eInitFailure.Message);
		    }

		    initFlag = true;

		    /*
		    if (!initFlag) {
    		    try {
                    kernel = new StandardKernel(ninjectModule);
    		    }
    		    catch (Exception eInitFailure) {
		            // TODO
			        // write error to error object!!!
			        //Console.WriteLine("Init Kernel");
    		        //Console.WriteLine(eInitFailure.Message);
    		    }

		        initFlag = true;
		    }
            */
        }
		
		internal static IMySuperWrapper GetMySuperWrapper(AutomationElement element)
		{
	        if (null == element) {
	            return null;
	        }
			try {
    			var singleElement = new Ninject.Parameters.ConstructorArgument("element", element);
    			IMySuperWrapper adapterElement = ObjectsFactory.Kernel.Get<IMySuperWrapper>(singleElement);
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
		
		internal static IMySuperCollection GetMySuperCollection(AutomationElementCollection elements)
		{
	        if (null == elements) {
	            return null;
	        }
			try {
    			var manyElements = new Ninject.Parameters.ConstructorArgument("elements", elements);
	      		IMySuperCollection adapterCollection = ObjectsFactory.Kernel.Get<IMySuperCollection>(manyElements);
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
    }
}
