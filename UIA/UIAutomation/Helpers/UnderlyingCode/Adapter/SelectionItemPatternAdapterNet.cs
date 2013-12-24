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
	extern alias UIANET;
	using System;
	using System.Windows.Automation;

	public class MySelectionItemPatternNet : IMySuperSelectionItemPattern
	{
	    private System.Windows.Automation.SelectionItemPattern _selectionItemPattern;
		private IUiElement _element;
		
		public MySelectionItemPatternNet(IUiElement element, SelectionItemPattern selectionItemPattern)
		{
			this._selectionItemPattern = selectionItemPattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		public MySelectionItemPatternNet(IUiElement element)
		{
		    this._element = element;
		}
		
		public struct SelectionItemPatternInformation : ISelectionItemPatternInformation
		{
			private bool _useCache;
			private IMySuperSelectionItemPattern _selectionItemPattern;
			
			public SelectionItemPatternInformation(IMySuperSelectionItemPattern selectionItemPattern, bool useCache)
			{
			    this._selectionItemPattern = selectionItemPattern;
			    this._useCache = useCache;
			}
			
			public bool IsSelected {
				get {
			        // 20131224
			        // return (bool)this._selectionItemPattern.ParentElement.GetPatternPropertyValue(SelectionItemPattern.IsSelectedProperty, this._useCache);
			        return (bool)this._selectionItemPattern.GetParentElement().GetPatternPropertyValue(SelectionItemPattern.IsSelectedProperty, this._useCache);
			    }
			}
			
			public IUiElement SelectionContainer {
				get {
			        // 20131224
			        // return (IUiElement)this._selectionItemPattern.ParentElement.GetPatternPropertyValue(SelectionItemPattern.SelectionContainerProperty, this._useCache);
			        return (IUiElement)this._selectionItemPattern.GetParentElement().GetPatternPropertyValue(SelectionItemPattern.SelectionContainerProperty, this._useCache);
			    }
			}
		}
		public static readonly AutomationPattern Pattern = SelectionItemPatternIdentifiers.Pattern;
		public static readonly AutomationProperty IsSelectedProperty = SelectionItemPatternIdentifiers.IsSelectedProperty;
		public static readonly AutomationProperty SelectionContainerProperty = SelectionItemPatternIdentifiers.SelectionContainerProperty;
		public static readonly AutomationEvent ElementAddedToSelectionEvent = SelectionItemPatternIdentifiers.ElementAddedToSelectionEvent;
		public static readonly AutomationEvent ElementRemovedFromSelectionEvent = SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEvent;
		public static readonly AutomationEvent ElementSelectedEvent = SelectionItemPatternIdentifiers.ElementSelectedEvent;
        
		public virtual ISelectionItemPatternInformation Cached {
			get {
				return new MySelectionItemPatternNet.SelectionItemPatternInformation(this, true);
			}
		}
		
		public virtual ISelectionItemPatternInformation Current {
			get {
				return new MySelectionItemPatternNet.SelectionItemPatternInformation(this, false);
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
		
		// public virtual IUiElement ParentElement
//		internal virtual IUiElement ParentElement
//		{
//		    get { return this._element; }
//		    set { this._element = value; }
//		}
		
		public void SetParentElement(IUiElement element)
		{
		    this._element = element;
		}
		
		public IUiElement GetParentElement()
		{
		    return this._element;
		}
		
//		public object SourcePattern
//		{
//		    get { return this._selectionItemPattern; }
//		    set { this._selectionItemPattern = value as SelectionItemPattern; }
//		}
		
		public void SetSourcePattern(object pattern)
		{
		    this._selectionItemPattern = pattern as SelectionItemPattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._selectionItemPattern;
		}
	}
}

