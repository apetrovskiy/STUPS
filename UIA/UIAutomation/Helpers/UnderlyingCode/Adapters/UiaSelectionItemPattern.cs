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
	extern alias UIANET;// using System.Windows.Automation;
	using System;
	using classic = UIANET::System.Windows.Automation; // using System.Windows.Automation;

	public class UiaSelectionItemPattern : ISelectionItemPattern
	{
	    private classic.SelectionItemPattern _selectionItemPattern;
		private IUiElement _element;
		
		public UiaSelectionItemPattern(IUiElement element, classic.SelectionItemPattern selectionItemPattern)
		{
			this._selectionItemPattern = selectionItemPattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		public UiaSelectionItemPattern(IUiElement element)
		{
		    this._element = element;
		}
		
		public struct SelectionItemPatternInformation : ISelectionItemPatternInformation
		{
			private bool _useCache;
			private ISelectionItemPattern _selectionItemPattern;
			
			public SelectionItemPatternInformation(ISelectionItemPattern selectionItemPattern, bool useCache)
			{
			    this._selectionItemPattern = selectionItemPattern;
			    this._useCache = useCache;
			}
			
			public bool IsSelected {
				get {
			        return (bool)this._selectionItemPattern.GetParentElement().GetPatternPropertyValue(classic.SelectionItemPattern.IsSelectedProperty, this._useCache);
			    }
			}
			
			public IUiElement SelectionContainer {
				get {
			        return AutomationFactory.GetUiElement(this._selectionItemPattern.GetParentElement().GetPatternPropertyValue(classic.SelectionItemPattern.SelectionContainerProperty, this._useCache));
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
				return new UiaSelectionItemPattern.SelectionItemPatternInformation(this, true);
			}
		}
		
		public virtual ISelectionItemPatternInformation Current {
			get {
				return new UiaSelectionItemPattern.SelectionItemPatternInformation(this, false);
			}
		}
        
		public virtual void Select()
		{
			if (null == this._selectionItemPattern) return;
			this._selectionItemPattern.Select();
		}
		public virtual void AddToSelection()
		{
			if (null == this._selectionItemPattern) return;
			this._selectionItemPattern.AddToSelection();
		}
		public virtual void RemoveFromSelection()
		{
			if (null == this._selectionItemPattern) return;
			this._selectionItemPattern.RemoveFromSelection();
		}
		
		public void SetParentElement(IUiElement element)
		{
		    this._element = element;
		}
		
		public IUiElement GetParentElement()
		{
		    return this._element;
		}
		
		public void SetSourcePattern(object pattern)
		{
		    this._selectionItemPattern = pattern as classic.SelectionItemPattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._selectionItemPattern;
		}
	}
}

