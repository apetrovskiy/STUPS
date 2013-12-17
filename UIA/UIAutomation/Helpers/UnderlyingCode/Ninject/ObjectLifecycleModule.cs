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
    using Castle.DynamicProxy;
    
    /// <summary>
    /// Description of ObjectLifecycleModule.
    /// </summary>
    public class ObjectLifecycleModule : NinjectModule
    {
        public override void Load()
        {
            #region common objects
            Bind<ProxyGenerator>()
                .ToSelf()
                .InSingletonScope();
            #endregion common objects
            
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
                // .ToConstructor(
                //     x =>
                //     new UiElement(x.Inject<bool>()))
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
            
            #region IMySuperDockPattern
            Bind<IMySuperDockPattern>()
                .ToConstructor(
                    x =>
                    new MyDockPatternNet(x.Inject<IUiElement>(), x.Inject<DockPattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperDockPattern>()
                .ToConstructor(
                    x =>
                    new MyDockPatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IMySuperDockPattern>()
                .ToConstructor(
                    x =>
                    new MyDockPatternNet(x.Inject<DockPattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutElement);
            
            Bind<IDockPatternInformation>().To<MyDockPatternNet.DockPatternInformation>().InCallScope();
            #endregion IMySuperDockPattern
            
            #region IMySuperExpandCollapsePattern
            Bind<IMySuperExpandCollapsePattern>()
                .ToConstructor(
                    x =>
                    new MyExpandCollapsePatternNet(x.Inject<IUiElement>(), x.Inject<ExpandCollapsePattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperExpandCollapsePattern>()
                .ToConstructor(
                    x =>
                    new MyExpandCollapsePatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IMySuperExpandCollapsePattern>()
                .ToConstructor(
                    x =>
                    new MyExpandCollapsePatternNet(x.Inject<ExpandCollapsePattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutElement);
            
            Bind<IExpandCollapsePatternInformation>().To<MyExpandCollapsePatternNet.ExpandCollapsePatternInformation>().InCallScope();
            #endregion IMySuperExpandCollapsePattern
            
            #region IMySuperGridItemPattern
            Bind<IMySuperGridItemPattern>()
                .ToConstructor(
                    x =>
                    new MyGridItemPatternNet(x.Inject<IUiElement>(), x.Inject<GridItemPattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperGridItemPattern>()
                .ToConstructor(
                    x =>
                    new MyGridItemPatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IGridItemPatternInformation>().To<MyGridItemPatternNet.GridItemPatternInformation>().InCallScope();
            #endregion IMySuperGridItemPattern
            
            #region IMySuperGridPattern
            Bind<IMySuperGridPattern>()
                .ToConstructor(
                    x =>
                    new MyGridPatternNet(x.Inject<IUiElement>(), x.Inject<GridPattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperGridPattern>()
                .ToConstructor(
                    x =>
                    new MyGridPatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IGridPatternInformation>().To<MyGridPatternNet.GridPatternInformation>().InCallScope();
            #endregion IMySuperGridPattern
            
            #region IMySuperInvokePattern
            Bind<IMySuperInvokePattern>()
                .ToConstructor(
                    x =>
                    new MyInvokePatternNet(x.Inject<IUiElement>(), x.Inject<InvokePattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperInvokePattern>()
                .ToConstructor(
                    x =>
                    new MyInvokePatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IMySuperInvokePattern>()
                .ToConstructor(
                    x =>
                    new MyInvokePatternNet(x.Inject<InvokePattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutElement);
            #endregion IMySuperInvokePattern
            
            #region IMySuperRangeValuePattern
            Bind<IMySuperRangeValuePattern>()
                .ToConstructor(
                    x =>
                    new MyRangeValuePatternNet(x.Inject<IUiElement>(), x.Inject<RangeValuePattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperRangeValuePattern>()
                .ToConstructor(
                    x =>
                    new MyRangeValuePatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IRangeValuePatternInformation>().To<MyRangeValuePatternNet.RangeValuePatternInformation>().InCallScope();
            #endregion IMySuperRangeValuePattern
            
            #region IMySuperScrollItemPattern
            Bind<IMySuperScrollItemPattern>()
                .ToConstructor(
                    x =>
                    new MyScrollItemPatternNet(x.Inject<IUiElement>(), x.Inject<ScrollItemPattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperScrollItemPattern>()
                .ToConstructor(
                    x =>
                    new MyScrollItemPatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            // Bind<IScrollItemPatternInformation>().To<MyScrollItemPatternNet.ScrollItemPatternInformation>().InCallScope();
            #endregion IMySuperScrollItemPattern
            
            #region IMySuperScrollPattern
            Bind<IMySuperScrollPattern>()
                .ToConstructor(
                    x =>
                    new MyScrollPatternNet(x.Inject<IUiElement>(), x.Inject<ScrollPattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperScrollPattern>()
                .ToConstructor(
                    x =>
                    new MyScrollPatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IScrollPatternInformation>().To<MyScrollPatternNet.ScrollPatternInformation>().InCallScope();
            #endregion IMySuperScrollPattern
            
            #region IMySuperSelectionItemPattern
            Bind<IMySuperSelectionItemPattern>()
                .ToConstructor(
                    x =>
                    new MySelectionItemPatternNet(x.Inject<IUiElement>(), x.Inject<SelectionItemPattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperSelectionItemPattern>()
                .ToConstructor(
                    x =>
                    new MySelectionItemPatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            // Bind<ISelectionItemPatternInformation>().To<MySelectionItemPatternNet.SelectionItemPatternInformation>().InCallScope();
            #endregion IMySuperSelectionItemPattern
            
            #region IMySuperSelectionPattern
            Bind<IMySuperSelectionPattern>()
                .ToConstructor(
                    x =>
                    new MySelectionPatternNet(x.Inject<IUiElement>(), x.Inject<SelectionPattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperSelectionPattern>()
                .ToConstructor(
                    x =>
                    new MySelectionPatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<ISelectionPatternInformation>().To<MySelectionPatternNet.SelectionPatternInformation>().InCallScope();
            #endregion IMySuperSelectionPattern
            
            #region IMySuperTableItemPattern
            Bind<IMySuperTableItemPattern>()
                .ToConstructor(
                    x =>
                    new MyTableItemPatternNet(x.Inject<IUiElement>(), x.Inject<TableItemPattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperTableItemPattern>()
                .ToConstructor(
                    x =>
                    new MyTableItemPatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<ITableItemPatternInformation>().To<MyTableItemPatternNet.TableItemPatternInformation>().InCallScope();
            #endregion IMySuperTableItemPattern
            
            #region IMySuperTablePattern
            Bind<IMySuperTablePattern>()
                .ToConstructor(
                    x =>
                    new MyTablePatternNet(x.Inject<IUiElement>(), x.Inject<TablePattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperTablePattern>()
                .ToConstructor(
                    x =>
                    new MyTablePatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<ITablePatternInformation>().To<MyTablePatternNet.TablePatternInformation>().InCallScope();
            #endregion IMySuperTablePattern
            
            #region IMySuperTextPattern
            Bind<IMySuperTextPattern>()
                .ToConstructor(
                    x =>
                    new MyTextPatternNet(x.Inject<IUiElement>(), x.Inject<TextPattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperTextPattern>()
                .ToConstructor(
                    x =>
                    new MyTextPatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            #endregion IMySuperTextPattern
            
            #region IMySuperTogglePattern
            Bind<IMySuperTogglePattern>()
                .ToConstructor(
                    x =>
                    new MyTogglePatternNet(x.Inject<IUiElement>(), x.Inject<TogglePattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperTogglePattern>()
                .ToConstructor(
                    x =>
                    new MyTogglePatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<ITogglePatternInformation>().To<MyTogglePatternNet.TogglePatternInformation>().InCallScope();
            #endregion IMySuperTogglePattern
            
            #region IMySuperTransformPattern
            Bind<IMySuperTransformPattern>()
                .ToConstructor(
                    x =>
                    new MyTransformPatternNet(x.Inject<IUiElement>(), x.Inject<TransformPattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperTransformPattern>()
                .ToConstructor(
                    x =>
                    new MyTransformPatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<ITransformPatternInformation>().To<MyTransformPatternNet.TransformPatternInformation>().InCallScope();
            #endregion IMySuperTransformPattern
            
            #region IMySuperValuePattern
            Bind<IMySuperValuePattern>()
                .ToConstructor(
                    x =>
                    new MyValuePatternNet(x.Inject<IUiElement>(), x.Inject<ValuePattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperValuePattern>()
                .ToConstructor(
                    x =>
                    new MyValuePatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IMySuperValuePattern>()
                .ToConstructor(
                    x =>
                    new MyValuePatternNet(x.Inject<ValuePattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutElement);
            
            Bind<IValuePatternInformation>().To<MyValuePatternNet.ValuePatternInformation>().InCallScope();
            #endregion IMySuperValuePattern
            
            #region IMySuperWindowPattern
            Bind<IMySuperWindowPattern>()
                .ToConstructor(
                    x =>
                    new MyWindowPatternNet(x.Inject<IUiElement>(), x.Inject<WindowPattern>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IMySuperWindowPattern>()
                .ToConstructor(
                    x =>
                    new MyWindowPatternNet(x.Inject<IUiElement>()))
                .InCallScope()
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IWindowPatternInformation>().To<MyWindowPatternNet.WindowPatternInformation>().InCallScope();
            #endregion IMySuperWindowPattern
            
//            Bind<ValuePattern>()
//                //.To<ValuePattern>()
//                //.ToSelf()
//                //.ToConstant<ValuePattern>(ValuePattern.Pattern)
//                //.ToProvider(typeof(ValuePattern))
//                .ToMethod(
//                .InSingletonScope();
        }
    }
}
