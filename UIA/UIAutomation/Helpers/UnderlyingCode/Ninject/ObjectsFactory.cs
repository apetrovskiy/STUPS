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

                    //builder = new ContainerBuilder();
                    // 20131111
                    var kernel = new StandardKernel(new ObjectLifecycleModule());
                    //Kernel = new StandardKernel(new ObjectLifecycleModule());
                    
                    
                    //builder.RegisterModule(WebDriverFactory.AutofacModule);

                    //WebDriverFactory.Container = null;

                    //var container = builder.Build(ContainerBuildOptions.Default);

                    //WebDriverFactory.Container = container;

    		    }
    		    catch (Exception efgh) {

    		        Console.WriteLine(efgh.Message);
    		    }

		        initFlag = true;
		    }
		}
    }
}
