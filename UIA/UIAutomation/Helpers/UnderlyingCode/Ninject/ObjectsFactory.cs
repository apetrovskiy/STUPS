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
        }
        
		private static INinjectModule ninjectModule;
		internal static INinjectModule NinjecctModule
		{ 
		    get { return ninjectModule; }
		    set{ ninjectModule = value; initFlag = false; }
		}
		
		private static bool initFlag = false;
		
		private static StandardKernel kernel;
		internal static StandardKernel Kernel
		{
		    get { return kernel; }
		}
		
		internal static void Init()
		{
		    if (!initFlag) {
    		    try {
		            
                    //kernel = new StandardKernel(new ObjectLifecycleModule());
                    kernel = new StandardKernel(ninjectModule);
    		    }
    		    catch (Exception efgh) {
    		        Console.WriteLine(efgh.Message);
    		    }

		        initFlag = true;
		    }
		}
		
		internal static IMySuperWrapper GetMySuperWrapper(AutomationElement element)
		{
			try {
    			var singleElement = new Ninject.Parameters.ConstructorArgument("element", element);
    			IMySuperWrapper adapterElement = ObjectsFactory.Kernel.Get<IMySuperWrapper>(singleElement);
    			return adapterElement;
			}
			catch (Exception eFailedToIssueElement) {
			    // TODO
			    // write error to error object!!!
			    return null;
			}
		}
		
		internal static IMySuperCollection GetMySuperCollection(AutomationElementCollection elements)
		{
			try {
    			var manyElements = new Ninject.Parameters.ConstructorArgument("elements", elements);
	      		IMySuperCollection adapterCollection = ObjectsFactory.Kernel.Get<IMySuperCollection>(manyElements);
	       		return adapterCollection;
			}
			catch (Exception eFailedToIssueCollection) {
			    // TODO
			    // write error to error object!!!
			    return null;
			}
		}
    }
}
