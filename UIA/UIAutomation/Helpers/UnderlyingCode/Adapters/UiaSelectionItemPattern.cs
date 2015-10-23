/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/6/2013
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    public class UiaSelectionItemPattern : ISelectionItemPattern
    {
        private classic.SelectionItemPattern _selectionItemPattern;
        private IUiElement _element;
        
        public UiaSelectionItemPattern(IUiElement element, classic.SelectionItemPattern selectionItemPattern)
        {
            _selectionItemPattern = selectionItemPattern;
            _element = element;
            //this._useCache = useCache;
        }
        
        public UiaSelectionItemPattern(IUiElement element)
        {
            _element = element;
        }
        
        public struct SelectionItemPatternInformation : ISelectionItemPatternInformation
        {
            private bool _useCache;
            private ISelectionItemPattern _selectionItemPattern;
            
            public SelectionItemPatternInformation(ISelectionItemPattern selectionItemPattern, bool useCache)
            {
                _selectionItemPattern = selectionItemPattern;
                _useCache = useCache;
            }
            
            public bool IsSelected {
                get {
                    return (bool)_selectionItemPattern.GetParentElement().GetPatternPropertyValue(classic.SelectionItemPattern.IsSelectedProperty, _useCache);
                }
            }
            
            public IUiElement SelectionContainer {
                get {
                    return AutomationFactory.GetUiElement(_selectionItemPattern.GetParentElement().GetPatternPropertyValue(classic.SelectionItemPattern.SelectionContainerProperty, _useCache));
                }
            }
        }
        public static readonly classic.AutomationPattern Pattern = classic.SelectionItemPatternIdentifiers.Pattern;
        public static readonly classic.AutomationProperty IsSelectedProperty = classic.SelectionItemPatternIdentifiers.IsSelectedProperty;
        public static readonly classic.AutomationProperty SelectionContainerProperty = classic.SelectionItemPatternIdentifiers.SelectionContainerProperty;
        public static readonly classic.AutomationEvent ElementAddedToSelectionEvent = classic.SelectionItemPatternIdentifiers.ElementAddedToSelectionEvent;
        public static readonly classic.AutomationEvent ElementRemovedFromSelectionEvent = classic.SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEvent;
        public static readonly classic.AutomationEvent ElementSelectedEvent = classic.SelectionItemPatternIdentifiers.ElementSelectedEvent;
        
        public virtual ISelectionItemPatternInformation Cached {
            get {
                return new SelectionItemPatternInformation(this, true);
            }
        }
        
        public virtual ISelectionItemPatternInformation Current {
            get {
                return new SelectionItemPatternInformation(this, false);
            }
        }
        
        public virtual void Select()
        {
            if (null == _selectionItemPattern) return;
            _selectionItemPattern.Select();
        }
        public virtual void AddToSelection()
        {
            if (null == _selectionItemPattern) return;
            _selectionItemPattern.AddToSelection();
        }
        public virtual void RemoveFromSelection()
        {
            if (null == _selectionItemPattern) return;
            _selectionItemPattern.RemoveFromSelection();
        }
        
        public void SetParentElement(IUiElement element)
        {
            _element = element;
        }
        
        public IUiElement GetParentElement()
        {
            return _element;
        }
        
        public void SetSourcePattern(object pattern)
        {
            _selectionItemPattern = pattern as classic.SelectionItemPattern;
        }
        
        public object GetSourcePattern()
        {
            return _selectionItemPattern;
        }
    }
}

