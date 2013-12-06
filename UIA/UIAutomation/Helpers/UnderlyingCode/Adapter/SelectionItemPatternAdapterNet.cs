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
	//using Ninject;

	public class MySelectionItemPatternNet : IMySuperSelectionItemPattern
	{
	    private readonly System.Windows.Automation.SelectionItemPattern _selectionItemPattern;
		private IMySuperWrapper _element;
		
		public MySelectionItemPatternNet(IMySuperWrapper element, SelectionItemPattern selectionItemPattern)
		{
			this._selectionItemPattern = selectionItemPattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		internal MySelectionItemPatternNet(IMySuperWrapper element)
		{
		    this._element = element;
		}
		
		public struct SelectionItemPatternInformation : ISelectionItemPatternInformation
		{
			// private AutomationElement _el;
			private bool _useCache;
			private IMySuperSelectionItemPattern _selectionItemPattern;
			
			public SelectionItemPatternInformation(IMySuperSelectionItemPattern selectionItemPattern, bool useCache)
			{
			    this._selectionItemPattern = selectionItemPattern;
			    this._useCache = useCache;
			}
			
			public bool IsSelected {
				get {
			        // return (bool)this._el.GetPatternPropertyValue(SelectionItemPattern.IsSelectedProperty, this._useCache);
			        return (bool)this._selectionItemPattern.ParentElement.GetPatternPropertyValue(SelectionItemPattern.IsSelectedProperty, this._useCache);
			    }
			}
			// public AutomationElement SelectionContainer {
			public IMySuperWrapper SelectionContainer {
				get {
			        // return (AutomationElement)this._el.GetPatternPropertyValue(SelectionItemPattern.SelectionContainerProperty, this._useCache);
			        return (IMySuperWrapper)this._selectionItemPattern.ParentElement.GetPatternPropertyValue(SelectionItemPattern.SelectionContainerProperty, this._useCache);
			    }
			}
//			internal SelectionItemPatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
		}
		public static readonly AutomationPattern Pattern = SelectionItemPatternIdentifiers.Pattern;
		public static readonly AutomationProperty IsSelectedProperty = SelectionItemPatternIdentifiers.IsSelectedProperty;
		public static readonly AutomationProperty SelectionContainerProperty = SelectionItemPatternIdentifiers.SelectionContainerProperty;
		public static readonly AutomationEvent ElementAddedToSelectionEvent = SelectionItemPatternIdentifiers.ElementAddedToSelectionEvent;
		public static readonly AutomationEvent ElementRemovedFromSelectionEvent = SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEvent;
		public static readonly AutomationEvent ElementSelectedEvent = SelectionItemPatternIdentifiers.ElementSelectedEvent;
//		private SafePatternHandle _hPattern;
//		private bool _cached;
		// public SelectionItemPattern.SelectionItemPatternInformation Cached {
		// public MySelectionItemPatternNet.SelectionItemPatternInformation Cached {
		public ISelectionItemPatternInformation Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new SelectionItemPattern.SelectionItemPatternInformation(this._el, true);
				return new MySelectionItemPatternNet.SelectionItemPatternInformation(this, true);
			}
		}
		// public SelectionItemPattern.SelectionItemPatternInformation Current {
		// public SelectionItemPattern.SelectionItemPatternInformation Current {
		public ISelectionItemPatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new SelectionItemPattern.SelectionItemPatternInformation(this._el, false);
				return new MySelectionItemPatternNet.SelectionItemPatternInformation(this, false);
			}
		}
//		private SelectionItemPattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//			this._cached = cached;
//		}
		public void Select()
		{
			// UiaCoreApi.SelectionItemPattern_Select(this._hPattern);
			if (null == this._selectionItemPattern) return;
			this._selectionItemPattern.Select();
		}
		public void AddToSelection()
		{
			// UiaCoreApi.SelectionItemPattern_AddToSelection(this._hPattern);
			if (null == this._selectionItemPattern) return;
			this._selectionItemPattern.AddToSelection();
		}
		public void RemoveFromSelection()
		{
			// UiaCoreApi.SelectionItemPattern_RemoveFromSelection(this._hPattern);
			if (null == this._selectionItemPattern) return;
			this._selectionItemPattern.RemoveFromSelection();
		}
//		internal static object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new SelectionItemPattern(el, hPattern, cached);
//		}
		
		public IMySuperWrapper ParentElement
		{
		    get { return this._element; }
		    set { this._element = value; }
		}
	}
}

