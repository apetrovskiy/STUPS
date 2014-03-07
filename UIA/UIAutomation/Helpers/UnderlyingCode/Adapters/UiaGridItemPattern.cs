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
	extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
	using System;
	using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

	/// <summary>
	/// Description of GridItemPatternAdapterNet.
	/// </summary>
	public class UiaGridItemPattern : IGridItemPattern
	{
		private classic.GridItemPattern _gridItemPattern;
		private IUiElement _element;

		public UiaGridItemPattern(IUiElement element, classic.GridItemPattern gridItemPattern)
		{
			this._gridItemPattern = gridItemPattern;
			this._element = element;
			//this._useCache = useCache;
		}

		public UiaGridItemPattern(IUiElement element)
		{
			this._element = element;
		}

		public struct GridItemPatternInformation : IGridItemPatternInformation
		{
			// private AutomationElement _el;
			// private bool _useCache;
			
			private readonly bool _useCache;
			private readonly IGridItemPattern _gridItemPattern;

			public GridItemPatternInformation(IGridItemPattern gridItemPattern, bool useCache)
			{
				this._gridItemPattern = gridItemPattern;
				this._useCache = useCache;
			}
			
			public int Row {
				// get { return (int)this._el.GetPatternPropertyValue(GridItemPattern.RowProperty, this._useCache); }
				get { return (int)this._gridItemPattern.GetParentElement().GetPatternPropertyValue(classic.GridItemPattern.RowProperty, this._useCache); }
			}
			public int Column {
				// get { return (int)this._el.GetPatternPropertyValue(GridItemPattern.ColumnProperty, this._useCache); }
				get { return (int)this._gridItemPattern.GetParentElement().GetPatternPropertyValue(classic.GridItemPattern.ColumnProperty, this._useCache); }
			}
			public int RowSpan {
				// get { return (int)this._el.GetPatternPropertyValue(GridItemPattern.RowSpanProperty, this._useCache); }
				get { return (int)this._gridItemPattern.GetParentElement().GetPatternPropertyValue(classic.GridItemPattern.RowSpanProperty, this._useCache); }
			}
			public int ColumnSpan {
				// get { return (int)this._el.GetPatternPropertyValue(GridItemPattern.ColumnSpanProperty, this._useCache); }
				get { return (int)this._gridItemPattern.GetParentElement().GetPatternPropertyValue(classic.GridItemPattern.ColumnSpanProperty, this._useCache); }
			}
			
			public IUiElement ContainingGrid {
				// get { return (AutomationElement)this._el.GetPatternPropertyValue(GridItemPattern.ContainingGridProperty, this._useCache); }
				get { return AutomationFactory.GetUiElement((classic.AutomationElement)this._gridItemPattern.GetParentElement().GetPatternPropertyValue(classic.GridItemPattern.ContainingGridProperty, this._useCache)); }
			}
//			internal GridItemPatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
		}
		public static readonly classic.AutomationPattern Pattern = classic.GridItemPatternIdentifiers.Pattern;
		public static readonly classic.AutomationProperty RowProperty = classic.GridItemPatternIdentifiers.RowProperty;
		public static readonly classic.AutomationProperty ColumnProperty = classic.GridItemPatternIdentifiers.ColumnProperty;
		public static readonly classic.AutomationProperty RowSpanProperty = classic.GridItemPatternIdentifiers.RowSpanProperty;
		public static readonly classic.AutomationProperty ColumnSpanProperty = classic.GridItemPatternIdentifiers.ColumnSpanProperty;
		public static readonly classic.AutomationProperty ContainingGridProperty = classic.GridItemPatternIdentifiers.ContainingGridProperty;
		// private SafePatternHandle _hPattern;
		// internal bool _cached;
		
		public virtual IGridItemPatternInformation Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new GridItemPattern.GridItemPatternInformation(this._el, true);
				return new UiaGridItemPattern.GridItemPatternInformation(this, true);
			}
		}
		
		public virtual IGridItemPatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new GridItemPattern.GridItemPatternInformation(this._el, false);
				return new UiaGridItemPattern.GridItemPatternInformation(this, false);
			}
		}
//		internal UiaGridItemPattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//			this._cached = cached;
//		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new GridItemPattern(el, hPattern, cached);
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
		    this._gridItemPattern = pattern as classic.GridItemPattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._gridItemPattern;
		}
	}
}

