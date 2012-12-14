/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 14:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Description of TMXPluginManager.
    /// </summary>
    public static class TMXPluginManager
    {
        //public TMXPluginManager()
        static TMXPluginManager()
        {
        }
        
        #region Properties
        internal static System.Collections.Generic.List<Assembly >  PluginsCollection = 
            new System.Collections.Generic.List<Assembly > ();
        #endregion Properties
        
        //TMXPluginManager
        
        public static bool SubscribeToPlugins()
        {
            //System.AppDomain.CurrentDomain.AssemblyResolve
            
            bool result = false;
            
            //System.AppDomain.CurrentDomain
            
            //runScriptBlock runner = new runScriptBlock(runSBEvent);
            //// WriteVerbose(this, "runScriptBlocks 5 fired");
            //runner(sb, cmdlet.EventSource, cmdlet.EventArgs);
            
            

            AppDomain currentDomain = AppDomain.CurrentDomain;
        
            // This call will fail to create an instance of MyType since the
            // assembly resolver is not set
            InstantiateMyTypeFail(currentDomain);
        
            currentDomain.AssemblyResolve += new ResolveEventHandler(AddInResolveEventHandler);
        
            // This call will succeed in creating an instance of MyType since the
            // assembly resolver is now set.
            InstantiateMyTypeFail(currentDomain);
        
            // This call will succeed in creating an instance of MyType since the
            // assembly name is valid.
            InstantiateMyTypeSucceed(currentDomain);

        

        

            
            
            return result;
        }
        
        private static Assembly AddInResolveEventHandler(object sender, ResolveEventArgs args)
        //private static void AddInResolveEventHandler(object sender, ResolveEventArgs args)
        {
            //Console.WriteLine("Resolving...");
            //args.Name
            //args.RequestingAssembly
            
            Assembly result = null;

// if (!notInRegisteredAddIns(args.Name)) {
// if (isAddInOfSupportedType(args.RequestingAssembly)) {
// addAdInToAddInCollection(args.RequestingAssembly);
// result = args.RequestingAssembly;
// }
// }
            
            //return typeof(MyType).Assembly;
            return result;
        }
        
        private static bool notInRegisteredAddIns(string assemblyName)
        {
            bool result = false;
            
            
            
            
            return result;
        }
        
        private static bool isAddInOfSupportedType(Assembly candidateAssembly)
        {
            bool result = false;
            
            
            
            return result;
        }
        
        private static void addAdInToAddInCollection(Assembly addInAssembly)
        {
            TMXPluginManager.PluginsCollection.Add(addInAssembly);
        }
        
        private static void InstantiateMyTypeFail(AppDomain domain)
        {
            // Calling InstantiateMyType will always fail since the assembly info
            // given to CreateInstance is invalid.
// try
// {
//  // You must supply a valid fully qualified assembly name here.
// domain.CreateInstance("Assembly text name, Version, Culture, PublicKeyToken", "MyType");
// }
// catch (Exception e)
// {
//  //Console.WriteLine();
//  //Console.WriteLine(e.Message);
// }
        }
        
        private static void InstantiateMyTypeSucceed(AppDomain domain)
        {
// try
// {
// string asmname = Assembly.GetCallingAssembly().FullName;
// domain.CreateInstance(asmname, "MyType");
// }
// catch (Exception e)
// {
//  //Console.WriteLine();
//  //Console.WriteLine(e.Message);
// }
        }
        
        internal static bool GatherTestResults()
        {
            bool result = false;
            
            
            
            
            return result;
        }
    }
}
