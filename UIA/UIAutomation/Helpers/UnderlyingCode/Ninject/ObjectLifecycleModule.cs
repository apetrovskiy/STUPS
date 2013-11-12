/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/10/2013
 * Time: 10:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using Ninject;
    using Ninject.Modules;
    
    /// <summary>
    /// Description of ObjectLifecycleModule.
    /// </summary>
    public class ObjectLifecycleModule : NinjectModule
    {
        public ObjectLifecycleModule()
        {
        }
        
        public override void Load()
        {
            Bind<IMySuperWrapper>().To<MySuperWrapper>();
        }
        
        
    }
}
