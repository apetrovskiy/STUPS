/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 10:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Windows.Automation;

	/// <summary>
	/// Description of TableItemPatternAdapterNet.
	/// </summary>
	public class UiaTableItemPattern : ITableItemPattern
	{
		private System.Windows.Automation.TableItemPattern _tableItemPattern;
		private IUiElement _element;

		public UiaTableItemPattern(IUiElement element, TableItemPattern tableItemPattern)
		{
			this._tableItemPattern = tableItemPattern;
			this._element = element;
			//this._useCache = useCache;
		}

		public UiaTableItemPattern(IUiElement element)
		{
			this._element = element;
		}

		public struct TableItemPatternInformation : ITableItemPatternInformation
		{
			// private AutomationElement _el;
			// private bool _useCache;
			
			private readonly bool _useCache;
			private readonly ITableItemPattern _tableItemPattern;

			public TableItemPatternInformation(ITableItemPattern tableItemPattern, bool useCache)
			{
				this._tableItemPattern = tableItemPattern;
				this._useCache = useCache;
			}
			
			public int Row {
				// get { return (int)this._el.GetPatternPropertyValue(GridItemPattern.RowProperty, this._useCache); }
				get { return (int)this._tableItemPattern.GetParentElement().GetPatternPropertyValue(GridItemPattern.RowProperty, this._useCache); }
			}
			public int Column {
				// get { return (int)this._el.GetPatternPropertyValue(GridItemPattern.ColumnProperty, this._useCache); }
				get { return (int)this._tableItemPattern.GetParentElement().GetPatternPropertyValue(GridItemPattern.ColumnProperty, this._useCache); }
			}
			public int RowSpan {
				// get { return (int)this._el.GetPatternPropertyValue(GridItemPattern.RowSpanProperty, this._useCache); }
				get { return (int)this._tableItemPattern.GetParentElement().GetPatternPropertyValue(GridItemPattern.RowSpanProperty, this._useCache); }
			}
			public int ColumnSpan {
				// get { return (int)this._el.GetPatternPropertyValue(GridItemPattern.ColumnSpanProperty, this._useCache); }
				get { return (int)this._tableItemPattern.GetParentElement().GetPatternPropertyValue(GridItemPattern.ColumnSpanProperty, this._useCache); }
			}
			
			public IUiElement ContainingGrid {
				// get { return (AutomationElement)this._el.GetPatternPropertyValue(GridItemPattern.ContainingGridProperty, this._useCache); }
				get { return AutomationFactory.GetUiElement((AutomationElement)this._tableItemPattern.GetParentElement().GetPatternPropertyValue(GridItemPattern.ContainingGridProperty, this._useCache)); }
			}
//			internal TableItemPatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
			// public AutomationElement[] GetRowHeaderItems()
			
			public IUiElement[] GetRowHeaderItems()
			{
				// return (AutomationElement[])this._el.GetPatternPropertyValue(TableItemPattern.RowHeaderItemsProperty, this._useCache);
                AutomationElement[] nativeElements = (AutomationElement[])this._tableItemPattern.GetParentElement().GetPatternPropertyValue(TableItemPattern.RowHeaderItemsProperty, this._useCache);
                IUiEltCollection tempCollection = AutomationFactory.GetUiEltCollection(nativeElements);
				if (null == tempCollection || 0 == tempCollection.Count) {
				    return new UiElement[] {};
				} else {
				    return tempCollection.Cast<IUiElement>().ToArray();
				}
			}
			
			public IUiElement[] GetColumnHeaderItems()
			{
				// return (AutomationElement[])this._el.GetPatternPropertyValue(TableItemPattern.ColumnHeaderItemsProperty, this._useCache);
				AutomationElement[] nativeElements = (AutomationElement[])this._tableItemPattern.GetParentElement().GetPatternPropertyValue(TableItemPattern.ColumnHeaderItemsProperty, this._useCache);
                IUiEltCollection tempCollection = AutomationFactory.GetUiEltCollection(nativeElements);
				if (null == tempCollection || 0 == tempCollection.Count) {
				    return new UiElement[] {};
				} else {
				    return tempCollection.Cast<IUiElement>().ToArray();
				}
			}
	        
		}
		
		public static new readonly AutomationPattern Pattern = TableItemPatternIdentifiers.Pattern;
		public static readonly AutomationProperty RowHeaderItemsProperty = TableItemPatternIdentifiers.RowHeaderItemsProperty;
		public static readonly AutomationProperty ColumnHeaderItemsProperty = TableItemPatternIdentifiers.ColumnHeaderItemsProperty;
		
		// private SafePatternHandle _hPattern;
		
		public virtual ITableItemPatternInformation Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new TableItemPattern.TableItemPatternInformation(this._el, true);
				return new UiaTableItemPattern.TableItemPatternInformation(this, true);
			}
		}
		
		public virtual ITableItemPatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new TableItemPattern.TableItemPatternInformation(this._el, false);
				return new UiaTableItemPattern.TableItemPatternInformation(this, false);
			}
		}
		
//		private UiaTableItemPattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern, cached)
//		{
//			this._hPattern = hPattern;
//		}
//		static internal new object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new TableItemPattern(el, hPattern, cached);
//		}
		
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
		    this._tableItemPattern = pattern as TableItemPattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._tableItemPattern;
		}
	}
}

