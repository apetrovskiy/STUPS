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
    extern alias UIANET;
    using System;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Extensions.NamedScope;
    
    using System.Collections;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of ObjectLifecycleModule.
    /// </summary>
    public class ObjectLifecycleModule : NinjectModule
    {
        public override void Load()
        {
            // IMySuperWrapper
            Bind<IMySuperWrapper>()
                .ToConstructor(
                    x =>
                    new MySuperWrapper(x.Inject<AutomationElement>()))
                .InCallScope()
                .Named("AutomationElement.NET");
            
            Bind<IMySuperWrapper>()
                .ToConstructor(
                    x =>
                    new MySuperWrapper(x.Inject<IMySuperWrapper>()))
                .InCallScope()
                .Named("MySuperWrapper");
            
            Bind<IMySuperWrapper>()
                .To<MySuperWrapper>()
                .InCallScope()
                .Named("Empty");
            
            // IMySuperCollection
            Bind<IMySuperCollection>()
                .ToConstructor(
                    x => 
                    new MySuperCollection(x.Inject<AutomationElementCollection>()))
                .InCallScope()
                .Named("AutomationElementCollection.NET");
            
            Bind<IMySuperCollection>()
                .ToConstructor(
                    x =>
                    new MySuperCollection(x.Inject<IMySuperCollection>()))
                .InCallScope()
                .Named("MySuperCollection");
            
            Bind<IMySuperCollection>()
                .ToConstructor(
                    x =>
                    new MySuperCollection(x.Inject<IEnumerable>()))
                .InCallScope()
                .Named("AnyCollection");
            
            Bind<IMySuperCollection>()
                .ToConstructor(
                    x =>
                    new MySuperCollection(x.Inject<bool>()))
                .InCallScope()
                .Named("Empty");
            
            // IMySuperWrapperInformation
            Bind<IMySuperWrapperInformation>().To<MySuperWrapperInformation>().InCallScope();
            
            // IMySuperValuePattern
            //Bind<IMySuperValuePattern>().To<MyValuePatternNet>().InCallScope();
            Bind<IMySuperValuePattern>()
                .ToConstructor(
                    x =>
                    new MyValuePatternNet(x.Inject<IMySuperWrapper>(), x.Inject<ValuePattern>()))
                .InCallScope();
            
            Bind<IValuePatternInformation>().To<MyValuePatternNet.ValuePatternInformation>().InCallScope();
            
            // IMySuperInvokePattern
            Bind<IMySuperInvokePattern>()
                .ToConstructor(
                    x =>
                    new MyInvokePatternNet(x.Inject<IMySuperWrapper>(), x.Inject<InvokePattern>()))
                .InCallScope();
        }
    }
}
