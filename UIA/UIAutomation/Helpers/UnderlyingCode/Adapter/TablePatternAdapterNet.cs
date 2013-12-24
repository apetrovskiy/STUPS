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
	using System.Windows.Automation;
	using System.Linq;

	/// <summary>
	/// Description of TablePatternAdapterNet.
	/// </summary>
	public class MyTablePatternNet : IMySuperTablePattern
	{
		private System.Windows.Automation.TablePattern _tablePattern;
		private IUiElement _element;

		public MyTablePatternNet(IUiElement element, TablePattern tablePattern)
		{
			this._tablePattern = tablePattern;
			this._element = element;
			//this._useCache = useCache;
		}

		public MyTablePatternNet(IUiElement element)
		{
			this._element = element;
		}

		public struct TablePatternInformation : ITablePatternInformation
		{
			// private AutomationElement _el;
			// private bool _useCache;
			
			private readonly bool _useCache;
			private readonly IMySuperTablePattern _tablePattern;

			public TablePatternInformation(IMySuperTablePattern tablePattern, bool useCache)
			{
				this._tablePattern = tablePattern;
				this._useCache = useCache;
			}
			
			public int RowCount {
				// get { return (int)this._el.GetPatternPropertyValue(GridPattern.RowCountProperty, this._useCache); }
				// 20131224
				// get { return (int)this._tablePattern.ParentElement.GetPatternPropertyValue(GridPattern.RowCountProperty, this._useCache); }
				get { return (int)this._tablePattern.GetParentElement().GetPatternPropertyValue(GridPattern.RowCountProperty, this._useCache); }
			}
			public int ColumnCount {
				// get { return (int)this._el.GetPatternPropertyValue(GridPattern.ColumnCountProperty, this._useCache); }
				// 20131224
				// get { return (int)this._tablePattern.ParentElement.GetPatternPropertyValue(GridPattern.ColumnCountProperty, this._useCache); }
				get { return (int)this._tablePattern.GetParentElement().GetPatternPropertyValue(GridPattern.ColumnCountProperty, this._useCache); }
			}
			public RowOrColumnMajor RowOrColumnMajor {
				// get { return (RowOrColumnMajor)this._el.GetPatternPropertyValue(TablePattern.RowOrColumnMajorProperty, this._useCache); }
				// 20131224
				// get { return (RowOrColumnMajor)this._tablePattern.ParentElement.GetPatternPropertyValue(TablePattern.RowOrColumnMajorProperty, this._useCache); }
				get { return (RowOrColumnMajor)this._tablePattern.GetParentElement().GetPatternPropertyValue(TablePattern.RowOrColumnMajorProperty, this._useCache); }
			}
//			internal TablePatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
			// public AutomationElement[] GetRowHeaders()
			public IUiElement[] GetRowHeaders()
			{
				// return (AutomationElement[])this._el.GetPatternPropertyValue(TablePattern.RowHeadersProperty, this._useCache);
				// 20131224
				// return AutomationFactory.GetUiEltCollection((AutomationElement[])this._tablePattern.ParentElement.GetPatternPropertyValue(TablePattern.RowHeadersProperty, this._useCache)).ToArray();
				// return AutomationFactory.GetUiEltCollection((AutomationElement[])this._tablePattern.GetParentElement().GetPatternPropertyValue(TablePattern.RowHeadersProperty, this._useCache)).ToArray();
				AutomationElement[] nativeElements = (AutomationElement[])this._tablePattern.GetParentElement().GetPatternPropertyValue(TablePattern.RowHeadersProperty, this._useCache);
                IUiEltCollection tempCollection = AutomationFactory.GetUiEltCollection(nativeElements);
				// return AutomationFactory.GetUiEltCollection(nativeElements).ToArray();
				if (null == tempCollection || 0 == tempCollection.Count) {
				    return new UiElement[] {};
				} else {
				    return tempCollection.Cast<IUiElement>().ToArray<IUiElement>();
				}
			}
			// public AutomationElement[] GetColumnHeaders()
			public IUiElement[] GetColumnHeaders()
			{
				// return (AutomationElement[])this._el.GetPatternPropertyValue(TablePattern.ColumnHeadersProperty, this._useCache);
				// 20131224
				// return AutomationFactory.GetUiEltCollection((AutomationElement[])this._tablePattern.ParentElement.GetPatternPropertyValue(TablePattern.ColumnHeadersProperty, this._useCache)).ToArray();
				// return AutomationFactory.GetUiEltCollection((AutomationElement[])this._tablePattern.GetParentElement().GetPatternPropertyValue(TablePattern.ColumnHeadersProperty, this._useCache)).ToArray();
                AutomationElement[] nativeElements = (AutomationElement[])this._tablePattern.GetParentElement().GetPatternPropertyValue(TablePattern.ColumnHeadersProperty, this._useCache);
				// return AutomationFactory.GetUiEltCollection(nativeElements).ToArray();
				IUiEltCollection tempCollection = AutomationFactory.GetUiEltCollection(nativeElements);
                // return tempCollection.ToArray();
                if (null == tempCollection || 0 == tempCollection.Count) {
				    return new UiElement[] {};
				} else {
                    return tempCollection.Cast<IUiElement>().ToArray<IUiElement>();
				}
			}
		}
		public static new readonly AutomationPattern Pattern = TablePatternIdentifiers.Pattern;
		public static readonly AutomationProperty RowHeadersProperty = TablePatternIdentifiers.RowHeadersProperty;
		public static readonly AutomationProperty ColumnHeadersProperty = TablePatternIdentifiers.ColumnHeadersProperty;
		public static readonly AutomationProperty RowOrColumnMajorProperty = TablePatternIdentifiers.RowOrColumnMajorProperty;
		// public new TablePattern.TablePatternInformation Cached {
		public new ITablePatternInformation Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new TablePattern.TablePatternInformation(this._el, true);
				return new MyTablePatternNet.TablePatternInformation(this, true);
			}
		}
		// public new TablePattern.TablePatternInformation Current {
		public new ITablePatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new TablePattern.TablePatternInformation(this._el, false);
				return new MyTablePatternNet.TablePatternInformation(this, false);
			}
		}
//		private MyTablePatternNet(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern, cached)
//		{
//		}
//		static internal new object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new TablePattern(el, hPattern, cached);
//		}
		
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

//		public object SourcePattern {
//			get { return this._tablePattern; }
//			set { this._tablePattern = value as TablePattern; }
//		}
		
		public void SetSourcePattern(object pattern)
		{
		    this._tablePattern = pattern as TablePattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._tablePattern;
		}
	}
}

