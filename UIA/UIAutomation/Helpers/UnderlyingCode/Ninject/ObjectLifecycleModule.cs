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
            #region IUiElement
            Bind<IUiElement>()
                .ToConstructor(
                    x =>
                    // new UiElement(x.Inject<AutomationElement>()))
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
            
            #region IMySuperExpandCollapsePattern
            Bind<IMySuperExpandCollapsePattern>()
                .ToConstructor(
                    x =>
                    new MyExpandCollapsePatternNet(x.Inject<IUiElement>(), x.Inject<ExpandCollapsePattern>()))
                .InCallScope();
            
            Bind<IExpandCollapsePatternInformationAdapter>().To<MyExpandCollapsePatternNet.ExpandCollapsePatternInformation>().InCallScope();
            #endregion IMySuperExpandCollapsePattern
            
            #region IMySuperInvokePattern
            Bind<IMySuperInvokePattern>()
                .ToConstructor(
                    x =>
                    new MyInvokePatternNet(x.Inject<IUiElement>(), x.Inject<InvokePattern>()))
                .InCallScope();
            #endregion IMySuperInvokePattern
            
            #region IMySuperScrollItemPattern
            Bind<IMySuperScrollItemPattern>()
                .ToConstructor(
                    x =>
                    new MyScrollItemPatternNet(x.Inject<IUiElement>(), x.Inject<ScrollItemPattern>()))
                .InCallScope();
            
            // Bind<IScrollItemPatternInformation>().To<MyScrollItemPatternNet.ScrollItemPatternInformation>().InCallScope();
            #endregion IMySuperScrollItemPattern
            
            #region IMySuperScrollPattern
            Bind<IMySuperScrollPattern>()
                .ToConstructor(
                    x =>
                    new MyScrollPatternNet(x.Inject<IUiElement>(), x.Inject<ScrollPattern>()))
                .InCallScope();
            
            Bind<IScrollPatternInformation>().To<MyScrollPatternNet.ScrollPatternInformation>().InCallScope();
            #endregion IMySuperScrollPattern
            
            #region IMySuperSelectionItemPattern
            Bind<IMySuperSelectionItemPattern>()
                .ToConstructor(
                    x =>
                    new MySelectionItemPatternNet(x.Inject<IUiElement>(), x.Inject<SelectionItemPattern>()))
                .InCallScope();
            
            // Bind<ISelectionItemPatternInformation>().To<MySelectionItemPatternNet.SelectionItemPatternInformation>().InCallScope();
            #endregion IMySuperSelectionItemPattern
            
            #region IMySuperSelectionPattern
            Bind<IMySuperSelectionPattern>()
                .ToConstructor(
                    x =>
                    new MySelectionPatternNet(x.Inject<IUiElement>(), x.Inject<SelectionPattern>()))
                .InCallScope();
            
            Bind<ISelectionPatternInformation>().To<MySelectionPatternNet.SelectionPatternInformation>().InCallScope();
            #endregion IMySuperSelectionPattern
            
            #region IMySuperTogglePattern
            Bind<IMySuperTogglePattern>()
                .ToConstructor(
                    x =>
                    new MyTogglePatternNet(x.Inject<IUiElement>(), x.Inject<TogglePattern>()))
                .InCallScope();
            
            Bind<ITogglePatternInformation>().To<MyTogglePatternNet.TogglePatternInformation>().InCallScope();
            #endregion IMySuperTogglePattern
            
            #region IMySuperValuePattern
            Bind<IMySuperValuePattern>()
                .ToConstructor(
                    x =>
                    new MyValuePatternNet(x.Inject<IUiElement>(), x.Inject<ValuePattern>()))
                .InCallScope();
            
            Bind<IValuePatternInformation>().To<MyValuePatternNet.ValuePatternInformation>().InCallScope();
            #endregion IMySuperValuePattern
            
            #region IMySuperWindowPattern
            Bind<IMySuperWindowPattern>()
                .ToConstructor(
                    x =>
                    new MyWindowPatternNet(x.Inject<IUiElement>(), x.Inject<WindowPattern>()))
                .InCallScope();
            
            Bind<IWindowPatternInformation>().To<MyWindowPatternNet.WindowPatternInformation>().InCallScope();
            #endregion IMySuperWindowPattern
        }
    }
}
