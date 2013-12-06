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
            #region IMySuperWrapper
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
            #endregion IMySuperWrapper
            
            #region IMySuperCollection
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
            #endregion IMySuperCollection
            
            #region IMySuperWrapperInformation
            Bind<IMySuperWrapperInformation>().To<MySuperWrapperInformation>().InCallScope();
            #endregion IMySuperWrapperInformation
            
            #region IMySuperExpandCollapsePattern
            Bind<IMySuperExpandCollapsePattern>()
                .ToConstructor(
                    x =>
                    new MyExpandCollapsePatternNet(x.Inject<IMySuperWrapper>(), x.Inject<ExpandCollapsePattern>()))
                .InCallScope();
            
            Bind<IExpandCollapsePatternInformationAdapter>().To<MyExpandCollapsePatternNet.ExpandCollapsePatternInformation>().InCallScope();
            #endregion IMySuperExpandCollapsePattern
            
            #region IMySuperInvokePattern
            Bind<IMySuperInvokePattern>()
                .ToConstructor(
                    x =>
                    new MyInvokePatternNet(x.Inject<IMySuperWrapper>(), x.Inject<InvokePattern>()))
                .InCallScope();
            #endregion IMySuperInvokePattern
            
            #region IMySuperSelectionItemPattern
            Bind<IMySuperSelectionItemPattern>()
                .ToConstructor(
                    x =>
                    new MySelectionItemPatternNet(x.Inject<IMySuperWrapper>(), x.Inject<SelectionItemPattern>()))
                .InCallScope();
            
            Bind<ISelectionItemPatternInformation>().To<MySelectionItemPatternNet.SelectionItemPatternInformation>().InCallScope();
            #endregion IMySuperSelectionItemPattern
            
            #region IMySuperSelectionPattern
            Bind<IMySuperSelectionPattern>()
                .ToConstructor(
                    x =>
                    new MySelectionPatternNet(x.Inject<IMySuperWrapper>(), x.Inject<SelectionPattern>()))
                .InCallScope();
            
            Bind<ISelectionPatternInformation>().To<MySelectionPatternNet.SelectionPatternInformation>().InCallScope();
            #endregion IMySuperSelectionPattern
            
            #region IMySuperTogglePattern
            Bind<IMySuperTogglePattern>()
                .ToConstructor(
                    x =>
                    new MyTogglePatternNet(x.Inject<IMySuperWrapper>(), x.Inject<TogglePattern>()))
                .InCallScope();
            
            Bind<ITogglePatternInformation>().To<MyTogglePatternNet.TogglePatternInformation>().InCallScope();
            #endregion IMySuperTogglePattern
            
            #region IMySuperValuePattern
            Bind<IMySuperValuePattern>()
                .ToConstructor(
                    x =>
                    new MyValuePatternNet(x.Inject<IMySuperWrapper>(), x.Inject<ValuePattern>()))
                .InCallScope();
            
            Bind<IValuePatternInformation>().To<MyValuePatternNet.ValuePatternInformation>().InCallScope();
            #endregion IMySuperValuePattern

        }
    }
}
