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
	/// Description of GridPatternAdapterNet.
	/// </summary>
	public class MyGridPatternNet : IMySuperGridPattern
	{
		private System.Windows.Automation.GridPattern _gridPattern;
		private IUiElement _element;

		public MyGridPatternNet(IUiElement element, GridPattern gridPattern)
		{
			this._gridPattern = gridPattern;
			this._element = element;
			//this._useCache = useCache;
		}

		public MyGridPatternNet(IUiElement element)
		{
			this._element = element;
		}

		public struct GridPatternInformation : IGridPatternInformation
		{
			// private AutomationElement _el;
			// private bool _useCache;
			
			private readonly bool _useCache;
			private readonly IMySuperGridPattern _gridPattern;

			public GridPatternInformation(IMySuperGridPattern gridPattern, bool useCache)
			{
				this._gridPattern = gridPattern;
				this._useCache = useCache;
			}
			
			public int RowCount {
				// get { return (int)this._el.GetPatternPropertyValue(GridPattern.RowCountProperty, this._useCache); }
				// 20131224
				// get { return (int)this._gridPattern.ParentElement.GetPatternPropertyValue(GridPattern.RowCountProperty, this._useCache); }
				get { return (int)this._gridPattern.GetParentElement().GetPatternPropertyValue(GridPattern.RowCountProperty, this._useCache); }
			}
			public int ColumnCount {
				// get { return (int)this._el.GetPatternPropertyValue(GridPattern.ColumnCountProperty, this._useCache); }
				// 20131224
				// get { return (int)this._gridPattern.ParentElement.GetPatternPropertyValue(GridPattern.ColumnCountProperty, this._useCache); }
				get { return (int)this._gridPattern.GetParentElement().GetPatternPropertyValue(GridPattern.ColumnCountProperty, this._useCache); }
			}
//			internal GridPatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
		}
		public static readonly AutomationPattern Pattern = GridPatternIdentifiers.Pattern;
		public static readonly AutomationProperty RowCountProperty = GridPatternIdentifiers.RowCountProperty;
		public static readonly AutomationProperty ColumnCountProperty = GridPatternIdentifiers.ColumnCountProperty;
		// internal SafePatternHandle _hPattern;
		// internal bool _cached;
		// public GridPattern.GridPatternInformation Cached {
		public IGridPatternInformation Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new GridPattern.GridPatternInformation(this._el, true);
				return new MyGridPatternNet.GridPatternInformation(this, true);
			}
		}
		// public GridPattern.GridPatternInformation Current {
		public IGridPatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new GridPattern.GridPatternInformation(this._el, false);
				return new MyGridPatternNet.GridPatternInformation(this, false);
			}
		}
//		internal MyGridPatternNet(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//			this._cached = cached;
//		}
		// public AutomationElement GetItem(int row, int column)
		public IUiElement GetItem(int row, int column)
		{
			// SafeNodeHandle hnode = UiaCoreApi.GridPattern_GetItem(this._hPattern, row, column);
			// return AutomationElement.Wrap(hnode);
			return AutomationFactory.GetUiElement(this._gridPattern.GetItem(row, column));
		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new GridPattern(el, hPattern, cached);
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
//			get { return this._gridPattern; }
//			set { this._gridPattern = value as GridPattern; }
//		}
		
		public void SetSourcePattern(object pattern)
		{
		    this._gridPattern = pattern as GridPattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._gridPattern;
		}
	}
}

