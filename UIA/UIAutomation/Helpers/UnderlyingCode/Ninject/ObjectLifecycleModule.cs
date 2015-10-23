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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Collections;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
//    using Ninject;
    using Ninject.Modules;
//    using Ninject.Extensions.NamedScope;
    using Ninject.Extensions.ChildKernel;
    // 20140217
    using Ninject.Extensions.Conventions;
//    using Ninject.Extensions.Conventions.BindingBuilder;
//    using Ninject.Extensions.Conventions.BindingGenerators;
//    using Ninject.Extensions.Conventions.Syntax;
    using Castle.DynamicProxy;
    using WindowsInput;
    
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
            
            Bind<IChildKernel>().ToSelf().InSingletonScope();
            
            Bind<WindowSearcher>().ToSelf().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            Bind<ControlSearcher>().ToSelf().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            Bind<ContextMenuSearcher>().ToSelf().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            
            Bind<ControlFromWin32Provider>().ToSelf().InSingletonScope();
            
            Bind<IAutomation>().To<UiaAutomation>().InSingletonScope();
            
            Bind<UiaCommand>().ToSelf().InSingletonScope();
            
            Bind<LogHelper>()
                .ToSelf()
                .InSingletonScope();
            
            Kernel.Bind(r =>
                        r.FromThisAssembly()
                        .SelectAllClasses()
                        .WithoutAttribute<UiaSpecialBindingAttribute>()
                        .BindToSelf());
            #endregion common objects
            
//            #region IUiElement
//            Bind<IUiElement>()
//                .ToConstructor(
//                    x =>
//                    new UiElement(x.Inject<System.Windows.Automation.AutomationElement>()))
////                .InSingletonScope()
////                .InTransientScope()
////                .InThreadScope()
//                .InCallScope()
//                .Named("AutomationElement.NET");
//            
//            Bind<IUiElement>()
//                .ToConstructor(
//                    x =>
//                    new UiElement(x.Inject<IUiElement>()))
////                .InSingletonScope()
////                .InTransientScope()
////                .InThreadScope()
//                .InCallScope()
//                .Named("UiElement");
//            
//            Bind<IUiElement>()
//                .To<UiElement>()
////                .InSingletonScope()
////                .InTransientScope()
////                .InThreadScope()
//                .InCallScope()
//                .Named("Empty");
//            
//            Bind<IExtendedModelHolder>()
//                .To<UiExtendedModelHolder>()
////                .InSingletonScope();
//                .InCallScope();
//            
//            Bind<IControlInputHolder>()
//                .To<UiControlInputHolder>()
//                .InSingletonScope();
////                .InCallScope();
//            
//            Bind<IKeyboardInputHolder>()
//                .To<UiKeyboardInputHolder>()
////                 .InCallScope();
//                .InSingletonScope();
//            
//            Bind<IMouseInputHolder>()
//                .To<UiMouseInputHolder>()
////                 .InCallScope();
//                .InSingletonScope();
//            
//            Bind<ITouchInputHolder>()
//                .To<UiTouchInputHolder>()
////                 .InCallScope();
//                .InSingletonScope();
//            
//            Bind<IInputSimulator>()
//                .To<InputSimulator>()
//                .InSingletonScope();
//            #endregion IUiElement
//            
//            #region IUiEltCollection
//            Bind<IUiEltCollection>()
//                .ToConstructor(
//                    x => 
//                    new UiEltCollection(x.Inject<AutomationElementCollection>()))
////                .InSingletonScope()
////                .InTransientScope()
////                .InThreadScope()
//                .InCallScope()
//                .Named("AutomationElementCollection.NET");
//            
//            Bind<IUiEltCollection>()
//                .ToConstructor(
//                    x =>
//                    new UiEltCollection(x.Inject<IUiEltCollection>()))
////                .InSingletonScope()
////                .InTransientScope()
////                .InThreadScope()
//                .InCallScope()
//                .Named("UiEltCollection");
//            
//            Bind<IUiEltCollection>()
//                .ToConstructor(
//                    x =>
//                    new UiEltCollection(x.Inject<IEnumerable>()))
////                .InSingletonScope()
////                .InTransientScope()
////                .InThreadScope()
//                .InCallScope()
//                .Named("AnyCollection");
//            
//            Bind<IUiEltCollection>()
//                .ToConstructor(
//                    x =>
//                    new UiEltCollection(x.Inject<bool>()))
////                .InSingletonScope()
////                .InTransientScope()
////                .InThreadScope()
//                .InCallScope()
//                .Named("Empty");
//            #endregion IUiEltCollection
//            
//            #region IUiElementInformation
//            Bind<IUiElementInformation>().To<UiElementInformation>().InCallScope();
//            #endregion IUiElementInformation
            
//            #region IDockPattern
//            Bind<IDockPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaDockPattern(x.Inject<IUiElement>(), x.Inject<DockPattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<IDockPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaDockPattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<IDockPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaDockPattern(x.Inject<DockPattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutElement);
//            
//            Bind<IDockPatternInformation>().To<UiaDockPattern.DockPatternInformation>().InCallScope();
//            #endregion IDockPattern
//            
//            #region IExpandCollapsePattern
//            Bind<IExpandCollapsePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaExpandCollapsePattern(x.Inject<IUiElement>(), x.Inject<ExpandCollapsePattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<IExpandCollapsePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaExpandCollapsePattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<IExpandCollapsePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaExpandCollapsePattern(x.Inject<ExpandCollapsePattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutElement);
//            
//            Bind<IExpandCollapsePatternInformation>().To<UiaExpandCollapsePattern.ExpandCollapsePatternInformation>().InCallScope();
//            #endregion IExpandCollapsePattern
//            
//            #region IGridItemPattern
//            Bind<IGridItemPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaGridItemPattern(x.Inject<IUiElement>(), x.Inject<GridItemPattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<IGridItemPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaGridItemPattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<IGridItemPatternInformation>().To<UiaGridItemPattern.GridItemPatternInformation>().InCallScope();
//            #endregion IGridItemPattern
//            
//            #region IGridPattern
//            Bind<IGridPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaGridPattern(x.Inject<IUiElement>(), x.Inject<GridPattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<IGridPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaGridPattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<IGridPatternInformation>().To<UiaGridPattern.GridPatternInformation>().InCallScope();
//            #endregion IGridPattern
//            
//            #region IInvokePattern
//            Bind<IInvokePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaInvokePattern(x.Inject<IUiElement>(), x.Inject<InvokePattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<IInvokePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaInvokePattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<IInvokePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaInvokePattern(x.Inject<InvokePattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutElement);
//            #endregion IInvokePattern
//            
//            #region IRangeValuePattern
//            Bind<IRangeValuePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaRangeValuePattern(x.Inject<IUiElement>(), x.Inject<RangeValuePattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<IRangeValuePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaRangeValuePattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<IRangeValuePatternInformation>().To<UiaRangeValuePattern.RangeValuePatternInformation>().InCallScope();
//            #endregion IRangeValuePattern
//            
//            #region IScrollItemPattern
//            Bind<IScrollItemPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaScrollItemPattern(x.Inject<IUiElement>(), x.Inject<ScrollItemPattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<IScrollItemPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaScrollItemPattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            // Bind<IScrollItemPatternInformation>().To<UiaScrollItemPattern.ScrollItemPatternInformation>().InCallScope();
//            #endregion IScrollItemPattern
//            
//            #region IScrollPattern
//            Bind<IScrollPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaScrollPattern(x.Inject<IUiElement>(), x.Inject<ScrollPattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<IScrollPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaScrollPattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<IScrollPatternInformation>().To<UiaScrollPattern.ScrollPatternInformation>().InCallScope();
//            #endregion IScrollPattern
//            
//            #region ISelectionItemPattern
//            Bind<ISelectionItemPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaSelectionItemPattern(x.Inject<IUiElement>(), x.Inject<SelectionItemPattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<ISelectionItemPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaSelectionItemPattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            // Bind<ISelectionItemPatternInformation>().To<UiaSelectionItemPattern.SelectionItemPatternInformation>().InCallScope();
//            #endregion ISelectionItemPattern
//            
//            #region ISelectionPattern
//            Bind<ISelectionPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaSelectionPattern(x.Inject<IUiElement>(), x.Inject<SelectionPattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<ISelectionPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaSelectionPattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<ISelectionPatternInformation>().To<UiaSelectionPattern.SelectionPatternInformation>().InCallScope();
//            #endregion ISelectionPattern
//            
//            #region ITableItemPattern
//            Bind<ITableItemPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaTableItemPattern(x.Inject<IUiElement>(), x.Inject<TableItemPattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<ITableItemPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaTableItemPattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<ITableItemPatternInformation>().To<UiaTableItemPattern.TableItemPatternInformation>().InCallScope();
//            #endregion ITableItemPattern
//            
//            #region ITablePattern
//            Bind<ITablePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaTablePattern(x.Inject<IUiElement>(), x.Inject<TablePattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<ITablePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaTablePattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<ITablePatternInformation>().To<UiaTablePattern.TablePatternInformation>().InCallScope();
//            #endregion ITablePattern
//            
//            #region ITextPattern
//            Bind<ITextPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaTextPattern(x.Inject<IUiElement>(), x.Inject<TextPattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<ITextPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaTextPattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            #endregion ITextPattern
//            
//            #region ITogglePattern
//            Bind<ITogglePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaTogglePattern(x.Inject<IUiElement>(), x.Inject<TogglePattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<ITogglePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaTogglePattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<ITogglePatternInformation>().To<UiaTogglePattern.TogglePatternInformation>().InCallScope();
//            #endregion ITogglePattern
//            
//            #region ITransformPattern
//            Bind<ITransformPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaTransformPattern(x.Inject<IUiElement>(), x.Inject<TransformPattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<ITransformPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaTransformPattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<ITransformPatternInformation>().To<UiaTransformPattern.TransformPatternInformation>().InCallScope();
//            #endregion ITransformPattern
//            
//            #region IValuePattern
//            Bind<IValuePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaValuePattern(x.Inject<IUiElement>(), x.Inject<ValuePattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<IValuePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaValuePattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<IValuePattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaValuePattern(x.Inject<ValuePattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutElement);
//            
//            Bind<IValuePatternInformation>().To<UiaValuePattern.ValuePatternInformation>().InCallScope();
//            #endregion IValuePattern
//            
//            #region IWindowPattern
//            Bind<IWindowPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaWindowPattern(x.Inject<IUiElement>(), x.Inject<WindowPattern>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithPattern);
//            
//            Bind<IWindowPattern>()
//                .ToConstructor(
//                    x =>
//                    new UiaWindowPattern(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named(AutomationFactory.NamedParameter_WithoutPattern);
//            
//            Bind<IWindowPatternInformation>().To<UiaWindowPattern.WindowPatternInformation>().InCallScope();
//            #endregion IWindowPattern

// =============================================================================================================================
            #region IUiElement
            Bind<IUiElement>()
                .ToConstructor(
                    x =>
                    new UiElement(x.Inject<classic.AutomationElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named("AutomationElement.NET");
            
            Bind<IUiElement>()
                .ToConstructor(
                    x =>
                    new UiElement(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named("UiElement");
            
            Bind<IUiElement>()
                .To<UiElement>()
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named("Empty");
            
            Bind<IExtendedModelHolder>()
                .To<UiExtendedModelHolder>()
//                .InSingletonScope();
                .InScope(ctx => AutomationFactory.ScopeChangeFlag);
            
            Bind<IControlInputHolder>()
                .To<UiControlInputHolder>()
//                .InSingletonScope();
                .InScope(ctx => AutomationFactory.ScopeChangeFlag);
            
            Bind<IKeyboardInputHolder>()
                .To<UiKeyboardInputHolder>()
//                 .InScope(ctx => AutomationFactory.ScopeChangeFlag);
                .InSingletonScope();
            
            Bind<IMouseInputHolder>()
                .To<UiMouseInputHolder>()
//                 .InScope(ctx => AutomationFactory.ScopeChangeFlag);
                .InSingletonScope();
            
            Bind<ITouchInputHolder>()
                .To<UiTouchInputHolder>()
//                 .InScope(ctx => AutomationFactory.ScopeChangeFlag);
                .InSingletonScope();
            
            Bind<IInputSimulator>()
                .To<InputSimulator>()
//                .InScope(ctx => AutomationFactory.ScopeChangeFlag);
                .InSingletonScope();
            #endregion IUiElement
            
            #region IUiEltCollection
            Bind<IUiEltCollection>()
                .ToConstructor(
                    x => 
                    new UiEltCollection(x.Inject<classic.AutomationElementCollection>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named("AutomationElementCollection.NET");
            
            Bind<IUiEltCollection>()
                .ToConstructor(
                    x =>
                    new UiEltCollection(x.Inject<IUiEltCollection>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named("UiEltCollection");
            
            Bind<IUiEltCollection>()
                .ToConstructor(
                    x =>
                    new UiEltCollection(x.Inject<IEnumerable>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named("AnyCollection");
            
            Bind<IUiEltCollection>()
                .ToConstructor(
                    x =>
                    new UiEltCollection(x.Inject<bool>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named("Empty");
            #endregion IUiEltCollection
            
            #region IUiElementInformation
            Bind<IUiElementInformation>().To<UiElementInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion IUiElementInformation
            
            #region IDockPattern
            Bind<IDockPattern>()
                .ToConstructor(
                    x =>
                    new UiaDockPattern(x.Inject<IUiElement>(), x.Inject<classic.DockPattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IDockPattern>()
                .ToConstructor(
                    x =>
                    new UiaDockPattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IDockPattern>()
                .ToConstructor(
                    x =>
                    new UiaDockPattern(x.Inject<classic.DockPattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutElement);
            
            Bind<IDockPatternInformation>().To<UiaDockPattern.DockPatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion IDockPattern
            
            #region IExpandCollapsePattern
            Bind<IExpandCollapsePattern>()
                .ToConstructor(
                    x =>
                    new UiaExpandCollapsePattern(x.Inject<IUiElement>(), x.Inject<classic.ExpandCollapsePattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IExpandCollapsePattern>()
                .ToConstructor(
                    x =>
                    new UiaExpandCollapsePattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IExpandCollapsePattern>()
                .ToConstructor(
                    x =>
                    new UiaExpandCollapsePattern(x.Inject<classic.ExpandCollapsePattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutElement);
            
            Bind<IExpandCollapsePatternInformation>().To<UiaExpandCollapsePattern.ExpandCollapsePatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion IExpandCollapsePattern
            
            #region IGridItemPattern
            Bind<IGridItemPattern>()
                .ToConstructor(
                    x =>
                    new UiaGridItemPattern(x.Inject<IUiElement>(), x.Inject<classic.GridItemPattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IGridItemPattern>()
                .ToConstructor(
                    x =>
                    new UiaGridItemPattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IGridItemPatternInformation>().To<UiaGridItemPattern.GridItemPatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion IGridItemPattern
            
            #region IGridPattern
            Bind<IGridPattern>()
                .ToConstructor(
                    x =>
                    new UiaGridPattern(x.Inject<IUiElement>(), x.Inject<classic.GridPattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IGridPattern>()
                .ToConstructor(
                    x =>
                    new UiaGridPattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IGridPatternInformation>().To<UiaGridPattern.GridPatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion IGridPattern
            
            #region IInvokePattern
            Bind<IInvokePattern>()
                .ToConstructor(
                    x =>
                    new UiaInvokePattern(x.Inject<IUiElement>(), x.Inject<classic.InvokePattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IInvokePattern>()
                .ToConstructor(
                    x =>
                    new UiaInvokePattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IInvokePattern>()
                .ToConstructor(
                    x =>
                    new UiaInvokePattern(x.Inject<classic.InvokePattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutElement);
            #endregion IInvokePattern
            
            #region IRangeValuePattern
            Bind<IRangeValuePattern>()
                .ToConstructor(
                    x =>
                    new UiaRangeValuePattern(x.Inject<IUiElement>(), x.Inject<classic.RangeValuePattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IRangeValuePattern>()
                .ToConstructor(
                    x =>
                    new UiaRangeValuePattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IRangeValuePatternInformation>().To<UiaRangeValuePattern.RangeValuePatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion IRangeValuePattern
            
            #region IScrollItemPattern
            Bind<IScrollItemPattern>()
                .ToConstructor(
                    x =>
                    new UiaScrollItemPattern(x.Inject<IUiElement>(), x.Inject<classic.ScrollItemPattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IScrollItemPattern>()
                .ToConstructor(
                    x =>
                    new UiaScrollItemPattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            // Bind<IScrollItemPatternInformation>().To<UiaScrollItemPattern.ScrollItemPatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion IScrollItemPattern
            
            #region IScrollPattern
            Bind<IScrollPattern>()
                .ToConstructor(
                    x =>
                    new UiaScrollPattern(x.Inject<IUiElement>(), x.Inject<classic.ScrollPattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IScrollPattern>()
                .ToConstructor(
                    x =>
                    new UiaScrollPattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IScrollPatternInformation>().To<UiaScrollPattern.ScrollPatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion IScrollPattern
            
            #region ISelectionItemPattern
            Bind<ISelectionItemPattern>()
                .ToConstructor(
                    x =>
                    new UiaSelectionItemPattern(x.Inject<IUiElement>(), x.Inject<classic.SelectionItemPattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<ISelectionItemPattern>()
                .ToConstructor(
                    x =>
                    new UiaSelectionItemPattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            // Bind<ISelectionItemPatternInformation>().To<UiaSelectionItemPattern.SelectionItemPatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion ISelectionItemPattern
            
            #region ISelectionPattern
            Bind<ISelectionPattern>()
                .ToConstructor(
                    x =>
                    new UiaSelectionPattern(x.Inject<IUiElement>(), x.Inject<classic.SelectionPattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<ISelectionPattern>()
                .ToConstructor(
                    x =>
                    new UiaSelectionPattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<ISelectionPatternInformation>().To<UiaSelectionPattern.SelectionPatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion ISelectionPattern
            
            #region ITableItemPattern
            Bind<ITableItemPattern>()
                .ToConstructor(
                    x =>
                    new UiaTableItemPattern(x.Inject<IUiElement>(), x.Inject<classic.TableItemPattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<ITableItemPattern>()
                .ToConstructor(
                    x =>
                    new UiaTableItemPattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<ITableItemPatternInformation>().To<UiaTableItemPattern.TableItemPatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion ITableItemPattern
            
            #region ITablePattern
            Bind<ITablePattern>()
                .ToConstructor(
                    x =>
                    new UiaTablePattern(x.Inject<IUiElement>(), x.Inject<classic.TablePattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<ITablePattern>()
                .ToConstructor(
                    x =>
                    new UiaTablePattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<ITablePatternInformation>().To<UiaTablePattern.TablePatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion ITablePattern
            
            #region ITextPattern
            Bind<ITextPattern>()
                .ToConstructor(
                    x =>
                    new UiaTextPattern(x.Inject<IUiElement>(), x.Inject<classic.TextPattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<ITextPattern>()
                .ToConstructor(
                    x =>
                    new UiaTextPattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            #endregion ITextPattern
            
            #region ITogglePattern
            Bind<ITogglePattern>()
                .ToConstructor(
                    x =>
                    new UiaTogglePattern(x.Inject<IUiElement>(), x.Inject<classic.TogglePattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<ITogglePattern>()
                .ToConstructor(
                    x =>
                    new UiaTogglePattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<ITogglePatternInformation>().To<UiaTogglePattern.TogglePatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion ITogglePattern
            
            #region ITransformPattern
            Bind<ITransformPattern>()
                .ToConstructor(
                    x =>
                    new UiaTransformPattern(x.Inject<IUiElement>(), x.Inject<classic.TransformPattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<ITransformPattern>()
                .ToConstructor(
                    x =>
                    new UiaTransformPattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<ITransformPatternInformation>().To<UiaTransformPattern.TransformPatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion ITransformPattern
            
            #region IValuePattern
            Bind<IValuePattern>()
                .ToConstructor(
                    x =>
                    new UiaValuePattern(x.Inject<IUiElement>(), x.Inject<classic.ValuePattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IValuePattern>()
                .ToConstructor(
                    x =>
                    new UiaValuePattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IValuePattern>()
                .ToConstructor(
                    x =>
                    new UiaValuePattern(x.Inject<classic.ValuePattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutElement);
            
            Bind<IValuePatternInformation>().To<UiaValuePattern.ValuePatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion IValuePattern
            
            #region IWindowPattern
            Bind<IWindowPattern>()
                .ToConstructor(
                    x =>
                    new UiaWindowPattern(x.Inject<IUiElement>(), x.Inject<classic.WindowPattern>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithPattern);
            
            Bind<IWindowPattern>()
                .ToConstructor(
                    x =>
                    new UiaWindowPattern(x.Inject<IUiElement>()))
                .InScope(ctx => AutomationFactory.ScopeChangeFlag)
                .Named(AutomationFactory.NamedParameter_WithoutPattern);
            
            Bind<IWindowPatternInformation>().To<UiaWindowPattern.WindowPatternInformation>().InScope(ctx => AutomationFactory.ScopeChangeFlag);
            #endregion IWindowPattern

        }
    }
}
