/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/22/2014
 * Time: 6:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using Ninject.Modules;

    /// <summary>
    /// Description of ChildKernelModule.
    /// </summary>
    public class ChildKernelModule : NinjectModule
    {
        public override void Load()
        {
//            #region IUiElement
//            Bind<IUiElement>()
//                .ToConstructor(
//                    x =>
//                    new UiElement(x.Inject<System.Windows.Automation.AutomationElement>()))
//                .InCallScope()
//                .Named("AutomationElement.NET");
//            
//            Bind<IUiElement>()
//                .ToConstructor(
//                    x =>
//                    new UiElement(x.Inject<IUiElement>()))
//                .InCallScope()
//                .Named("UiElement");
//            
//            Bind<IUiElement>()
//                .To<UiElement>()
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
////                .InSingletonScope();
//                .InCallScope();
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
////                .InCallScope();
//                .InSingletonScope();
//            #endregion IUiElement
//            
//            #region IUiEltCollection
//            Bind<IUiEltCollection>()
//                .ToConstructor(
//                    x => 
//                    new UiEltCollection(x.Inject<AutomationElementCollection>()))
//                .InCallScope()
//                .Named("AutomationElementCollection.NET");
//            
//            Bind<IUiEltCollection>()
//                .ToConstructor(
//                    x =>
//                    new UiEltCollection(x.Inject<IUiEltCollection>()))
//                .InCallScope()
//                .Named("UiEltCollection");
//            
//            Bind<IUiEltCollection>()
//                .ToConstructor(
//                    x =>
//                    new UiEltCollection(x.Inject<IEnumerable>()))
//                .InCallScope()
//                .Named("AnyCollection");
//            
//            Bind<IUiEltCollection>()
//                .ToConstructor(
//                    x =>
//                    new UiEltCollection(x.Inject<bool>()))
//                .InCallScope()
//                .Named("Empty");
//            #endregion IUiEltCollection
//            
//            #region IUiElementInformation
//            Bind<IUiElementInformation>().To<UiElementInformation>().InCallScope();
//            #endregion IUiElementInformation
//            
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
        }
    }
}
