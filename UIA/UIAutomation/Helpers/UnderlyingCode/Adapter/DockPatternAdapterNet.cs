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
	/// Description of DockPatternAdapterNet.
	/// </summary>
	public class MyDockPatternNet : IMySuperDockPattern
	{
		private System.Windows.Automation.DockPattern _dockPattern;
		private IUiElement _element;

		public MyDockPatternNet(IUiElement element, DockPattern dockPattern)
		{
			this._dockPattern = dockPattern;
			this._element = element;
			//this._useCache = useCache;
		}

		public MyDockPatternNet(IUiElement element)
		{
			this._element = element;
		}
		
		public MyDockPatternNet(DockPattern DockPattern)
		{
		    this._dockPattern = DockPattern;
		}

		public struct DockPatternInformation : IDockPatternInformation
		{
			// private AutomationElement _el;
			// private bool _useCache;
			
			private readonly bool _useCache;
			private readonly IMySuperDockPattern _dockPattern;

			public DockPatternInformation(IMySuperDockPattern dockPattern, bool useCache)
			{
				this._dockPattern = dockPattern;
				this._useCache = useCache;
			}
			
			public DockPosition DockPosition {
				// get { return (DockPosition)this._el.GetPatternPropertyValue(DockPattern.DockPositionProperty, this._useCache); }
				get { return (DockPosition)this._dockPattern.ParentElement.GetPatternPropertyValue(DockPattern.DockPositionProperty, this._useCache); }
			}
//			internal DockPatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
		}
		public static readonly AutomationPattern Pattern = DockPatternIdentifiers.Pattern;
		public static readonly AutomationProperty DockPositionProperty = DockPatternIdentifiers.DockPositionProperty;
		// private SafePatternHandle _hPattern;
		// private bool _cached;
		// public DockPattern.DockPatternInformation Cached {
		public IDockPatternInformation Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new DockPattern.DockPatternInformation(this._el, true);
				return new MyDockPatternNet.DockPatternInformation(this, true);
			}
		}
		// public DockPattern.DockPatternInformation Current {
		public IDockPatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new DockPattern.DockPatternInformation(this._el, false);
				return new MyDockPatternNet.DockPatternInformation(this, false);
			}
		}
//		private MyDockPatternNet(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//			this._cached = cached;
//		}
		public void SetDockPosition(DockPosition dockPosition)
		{
			// UiaCoreApi.DockPattern_SetDockPosition(this._hPattern, dockPosition);
			this._dockPattern.SetDockPosition(dockPosition);
		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new DockPattern(el, hPattern, cached);
//		}
		
		public virtual IUiElement ParentElement
		{
		    get { return this._element; }
		    set { this._element = value; }
		}

		public object SourcePattern {
			get { return this._dockPattern; }
			set { this._dockPattern = value as DockPattern; }
		}
	}
}

