/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/6/2013
 * Time: 10:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System;
	using System.Windows.Automation;
	//using Ninject;

	public class MyExpandCollapsePatternNet : IMySuperExpandCollapsePattern
	{
		private readonly System.Windows.Automation.ExpandCollapsePattern _expandCollapsePattern;
		private IUiElement _element;
		
		public MyExpandCollapsePatternNet(IUiElement element, ExpandCollapsePattern expandCollapsePattern)
		{
			this._expandCollapsePattern = expandCollapsePattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		internal MyExpandCollapsePatternNet(IUiElement element)
		{
		    // this._expandCollapsePattern = AutomationFactory.GetMySuperExpandCollapsePattern(element, null);
		    // this._expandCollapsePattern = new MyExpandCollapsePatternNet(ele
		    this._element = element;
		}

		public struct ExpandCollapsePatternInformation : IExpandCollapsePatternInformationAdapter
		{
			// private AutomationElement _el;
			private bool _useCache;
			private IMySuperExpandCollapsePattern _expandCollapsePattern;
			
			public ExpandCollapsePatternInformation(IMySuperExpandCollapsePattern expandCollapsePattern, bool useCache)
			{
			    this._expandCollapsePattern = expandCollapsePattern;
			    this._useCache = useCache;
			}
			
			public ExpandCollapseState ExpandCollapseState {
				// get { return (ExpandCollapseState)this._el.GetPatternPropertyValue(ExpandCollapsePattern.ExpandCollapseStateProperty, this._useCache); }
				get { return (ExpandCollapseState)this._expandCollapsePattern.ParentElement.GetPatternPropertyValue(ExpandCollapsePattern.ExpandCollapseStateProperty, this._useCache); }
			}
//			internal ExpandCollapsePatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
		}
		public static readonly AutomationPattern Pattern = ExpandCollapsePatternIdentifiers.Pattern;
		public static readonly AutomationProperty ExpandCollapseStateProperty = ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty;
		// private SafePatternHandle _hPattern;
		// private bool _cached;
		// public ExpandCollapsePattern.ExpandCollapsePatternInformation Cached {
		public virtual IExpandCollapsePatternInformationAdapter Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new ExpandCollapsePattern.ExpandCollapsePatternInformation(this._el, true);
				return new MyExpandCollapsePatternNet.ExpandCollapsePatternInformation(this, true);
			}
		}
		// public ExpandCollapsePattern.ExpandCollapsePatternInformation Current {
		public virtual IExpandCollapsePatternInformationAdapter Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new ExpandCollapsePattern.ExpandCollapsePatternInformation(this._el, false);
				return new MyExpandCollapsePatternNet.ExpandCollapsePatternInformation(this, false);
			}
		}
//		private ExpandCollapsePattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//			this._cached = cached;
//		}
		public virtual void Expand()
		{
			// UiaCoreApi.ExpandCollapsePattern_Expand(this._hPattern);
			if (null == this._expandCollapsePattern) return;
			this._expandCollapsePattern.Expand();
		}
		public virtual void Collapse()
		{
			// UiaCoreApi.ExpandCollapsePattern_Collapse(this._hPattern);
			if (null == this._expandCollapsePattern) return;
			this._expandCollapsePattern.Collapse();
		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new ExpandCollapsePattern(el, hPattern, cached);
//		}
		
		public virtual IUiElement ParentElement
		{
		    get { return this._element; }
		    set { this._element = value; }
		}
	}
}
