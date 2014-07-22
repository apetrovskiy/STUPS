/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/19/2014
 * Time: 1:15 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Parameters;
    
    /// <summary>
    /// Description of TmxFactory.
    /// </summary>
    public static class TmxFactory
    {
        #region Initialization
        static TmxFactory()
        {
//            if (PSCmdletBase.UnitTestMode || CommonCmdletBase.ModuleAlreadyLoaded) return;
//            _ninjectModule = new ObjectLifecycleModule();
//            CommonCmdletBase.ModuleAlreadyLoaded = true;
            Init();
            
//		    InitCommonObjects();
        }
        
		private static INinjectModule _ninjectModule;
		internal static INinjectModule NinjectModule
		{ 
		    get { return _ninjectModule; }
		    set { _ninjectModule = value; _initFlag = false; }
		}
		
		private static bool _initFlag = false;

        internal static StandardKernel Kernel { get; private set; }
        
        public static void Init()
		{
		    if (_initFlag) return;
		    try {
		        Kernel = new StandardKernel(_ninjectModule);
		    }
		    catch (Exception eInitFailure) {
		        // TODO
		        // write error to error object!!!
		        // Console.WriteLine("Init Kernel");
		        // Console.WriteLine(eInitFailure.Message);
		    }

		    _initFlag = true;
        }
        
		public static void Reset()
		{
//		    _generator = null;
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
		    // _initFlag = true;
		}
        #endregion Initialization
    }
}
