/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 10:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System;
	using System.Windows.Automation;

	/// <summary>
	/// Description of GridItemPatternAdapterNet.
	/// </summary>
	public class MyGridItemPatternNet : IMySuperGridItemPattern
	{
		private System.Windows.Automation.GridItemPattern _gridItemPattern;
		private IUiElement _element;

		public MyGridItemPatternNet(IUiElement element, GridItemPattern gridItemPattern)
		{
			this._gridItemPattern = gridItemPattern;
			this._element = element;
			//this._useCache = useCache;
		}

		public MyGridItemPatternNet(IUiElement element)
		{
			this._element = element;
		}

		public struct GridItemPatternInformation : IGridItemPatternInformation
		{
			// private AutomationElement _el;
			// private bool _useCache;
			
			private readonly bool _useCache;
			private readonly IMySuperGridItemPattern _gridItemPattern;

			public GridItemPatternInformation(IMySuperGridItemPattern gridItemPattern, bool useCache)
			{
				this._gridItemPattern = gridItemPattern;
				this._useCache = useCache;
			}
			
			public int Row {
				// get { return (int)this._el.GetPatternPropertyValue(GridItemPattern.RowProperty, this._useCache); }
				get { return (int)this._gridItemPattern.ParentElement.GetPatternPropertyValue(GridItemPattern.RowProperty, this._useCache); }
			}
			public int Column {
				// get { return (int)this._el.GetPatternPropertyValue(GridItemPattern.ColumnProperty, this._useCache); }
				get { return (int)this._gridItemPattern.ParentElement.GetPatternPropertyValue(GridItemPattern.ColumnProperty, this._useCache); }
			}
			public int RowSpan {
				// get { return (int)this._el.GetPatternPropertyValue(GridItemPattern.RowSpanProperty, this._useCache); }
				get { return (int)this._gridItemPattern.ParentElement.GetPatternPropertyValue(GridItemPattern.RowSpanProperty, this._useCache); }
			}
			public int ColumnSpan {
				// get { return (int)this._el.GetPatternPropertyValue(GridItemPattern.ColumnSpanProperty, this._useCache); }
				get { return (int)this._gridItemPattern.ParentElement.GetPatternPropertyValue(GridItemPattern.ColumnSpanProperty, this._useCache); }
			}
			// public AutomationElement ContainingGrid {
			public IUiElement ContainingGrid {
				// get { return (AutomationElement)this._el.GetPatternPropertyValue(GridItemPattern.ContainingGridProperty, this._useCache); }
				get { return AutomationFactory.GetUiElement((AutomationElement)this._gridItemPattern.ParentElement.GetPatternPropertyValue(GridItemPattern.ContainingGridProperty, this._useCache)); }
			}
//			internal GridItemPatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
		}
		public static readonly AutomationPattern Pattern = GridItemPatternIdentifiers.Pattern;
		public static readonly AutomationProperty RowProperty = GridItemPatternIdentifiers.RowProperty;
		public static readonly AutomationProperty ColumnProperty = GridItemPatternIdentifiers.ColumnProperty;
		public static readonly AutomationProperty RowSpanProperty = GridItemPatternIdentifiers.RowSpanProperty;
		public static readonly AutomationProperty ColumnSpanProperty = GridItemPatternIdentifiers.ColumnSpanProperty;
		public static readonly AutomationProperty ContainingGridProperty = GridItemPatternIdentifiers.ContainingGridProperty;
		// private SafePatternHandle _hPattern;
		// internal bool _cached;
		// public GridItemPattern.GridItemPatternInformation Cached {
		public IGridItemPatternInformation Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new GridItemPattern.GridItemPatternInformation(this._el, true);
				return new MyGridItemPatternNet.GridItemPatternInformation(this, true);
			}
		}
		// public GridItemPattern.GridItemPatternInformation Current {
		public IGridItemPatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new GridItemPattern.GridItemPatternInformation(this._el, false);
				return new MyGridItemPatternNet.GridItemPatternInformation(this, false);
			}
		}
//		internal MyGridItemPatternNet(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//			this._cached = cached;
//		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new GridItemPattern(el, hPattern, cached);
//		}
		
		public virtual IUiElement ParentElement
		{
		    get { return this._element; }
		    set { this._element = value; }
		}

		public object SourcePattern {
			get { return this._gridItemPattern; }
			set { this._gridItemPattern = value as GridItemPattern; }
		}
	}
}

