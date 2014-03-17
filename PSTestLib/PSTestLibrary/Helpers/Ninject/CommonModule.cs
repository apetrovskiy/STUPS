/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2014
 * Time: 11:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    using Ninject.Modules;
    using Ninject.Extensions.ChildKernel;
    using Ninject.Extensions.Conventions;
    using Castle.DynamicProxy;
    
    /// <summary>
    /// Description of CommonModule.
    /// </summary>
    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ProxyGenerator>()
                .ToSelf()
                .InSingletonScope();
            
            Bind<IChildKernel>().ToSelf().InSingletonScope();
            
//            Kernel.Bind(r =>
//                r.FromAssembliesMatching("UIAutomation", "TMX", "SePSX", "Hap", "Data")
//                .SelectAllClasses()
//                .WithAttribute<InSingletonScopeAttribute>()
//                .BindToSelf())
            
            // Bind<AbstractCommand>().ToSelf(); //.InSingletonScope();
//            Bind<AbstractCommand>().ToConstructor(
//                x => 
//                new AbstractCommand(x.Inject<PSCmdletBase>()));
            
            Bind<LogHelper>()
                .ToSelf()
                .InSingletonScope();
        }
    }
}
