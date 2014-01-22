/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 1/22/2014
 * Time: 6:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
    using System;
    using System.Collections;
    using System.Windows.Automation;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Extensions.NamedScope;
    using Castle.DynamicProxy;
    using WindowsInput;
    
    /// <summary>
    /// Description of ChildKernelModule.
    /// </summary>
    public class ChildKernelModule : NinjectModule
    {
        public override void Load()
        {
            #region IUiElement
            Bind<IUiElement>()
                .ToConstructor(
                    x =>
                    new UiElement(x.Inject<System.Windows.Automation.AutomationElement>()))
                .InCallScope()
                .Named("AutomationElement.NET");
            
            Bind<IUiElement>()
                .ToConstructor(
                    x =>
                    new UiElement(x.Inject<IUiElement>()))
                .InCallScope()
                .Named("UiElement");
            
            Bind<IUiElement>()
                .To<UiElement>()
                .InCallScope()
                .Named("Empty");
            
            Bind<IExtendedModelHolder>()
                .To<UiExtendedModelHolder>()
//                .InSingletonScope();
                .InCallScope();
            
            Bind<IControlInputHolder>()
                .To<UiControlInputHolder>()
                .InSingletonScope();
//                .InCallScope();
            
            Bind<IKeyboardInputHolder>()
                .To<UiKeyboardInputHolder>()
//                 .InCallScope();
                .InSingletonScope();
            
            Bind<IMouseInputHolder>()
                .To<UiMouseInputHolder>()
//                 .InCallScope();
                .InSingletonScope();
            
            Bind<ITouchInputHolder>()
                .To<UiTouchInputHolder>()
//                 .InCallScope();
                .InSingletonScope();
            
            Bind<IInputSimulator>()
                .To<InputSimulator>()
                .InSingletonScope();
            #endregion IUiElement
            
            #region IUiEltCollection
            Bind<IUiEltCollection>()
                .ToConstructor(
                    x => 
                    new UiEltCollection(x.Inject<AutomationElementCollection>()))
                .InCallScope()
                .Named("AutomationElementCollection.NET");
            
            Bind<IUiEltCollection>()
                .ToConstructor(
                    x =>
                    new UiEltCollection(x.Inject<IUiEltCollection>()))
                .InCallScope()
                .Named("UiEltCollection");
            
            Bind<IUiEltCollection>()
                .ToConstructor(
                    x =>
                    new UiEltCollection(x.Inject<IEnumerable>()))
                .InCallScope()
                .Named("AnyCollection");
            
            Bind<IUiEltCollection>()
                .ToConstructor(
                    x =>
                    new UiEltCollection(x.Inject<bool>()))
                .InCallScope()
                .Named("Empty");
            #endregion IUiEltCollection
            
            #region IUiElementInformation
            Bind<IUiElementInformation>().To<UiElementInformation>().InCallScope();
            #endregion IUiElementInformation
        }
    }
}
