/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 7:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
	using System;
	//using Data.Commands;

	using Autofac;
	using Autofac.Builder;
	using Autofac.Core;

	using System.Reflection;
	using Autofac.Core.Activators.Reflection;
	
	using System.Management.Automation;
	
	using System.Linq;
	
    /// <summary>
    /// Description of DataFactory.
    /// </summary>
    public static class DataFactory
    {
        static DataFactory()
        {
            try {
                DataFactory.AutofacModule = new DataModule();
            }
            catch (Exception eLoadingModule) {
                Console.WriteLine("Loading of module failed; " + eLoadingModule.Message);
            }
        }
        
		private static Autofac.Module autofacModule;
		internal static Autofac.Module AutofacModule
		{ 
		    get { return autofacModule; }
		    set{ autofacModule = value; initFlag = false; }
		}
		
		private static ContainerBuilder builder;
		internal static IContainer Container;
		private static bool initFlag = false;
		
		internal static void Init()
		{
		    if (!initFlag) {
    		    try {

                    builder = new ContainerBuilder();

                    builder.RegisterModule(DataFactory.AutofacModule);

                    DataFactory.Container = null;

                    var container = builder.Build(ContainerBuildOptions.Default);

                    DataFactory.Container = container;

    		    }
    		    catch (Exception efgh) {

    		        Console.WriteLine(efgh.Message);
    		    }

		        initFlag = true;
		    }
		}
    }
}
