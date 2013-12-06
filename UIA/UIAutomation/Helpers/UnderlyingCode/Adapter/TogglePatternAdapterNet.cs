/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/6/2013
 * Time: 10:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System;
	using System.Windows.Automation;
	//using Ninject;

	public class MyTogglePatternNet : IMySuperTogglePattern
	{
		private readonly System.Windows.Automation.TogglePattern _togglePattern;
		private IMySuperWrapper _element;
		
		public MyTogglePatternNet(IMySuperWrapper element, TogglePattern togglePattern)
		{
			this._togglePattern = togglePattern;
			this._element = element;
			//this._useCache = useCache;
		}

		//: BasePattern
		public struct TogglePatternInformation : ITogglePatternInformation
		{
			private readonly bool _useCache;
			private readonly IMySuperTogglePattern _togglePattern;
			
			public TogglePatternInformation(IMySuperTogglePattern tooglePattern, bool useCache)
			{
			    this._togglePattern = tooglePattern;
			    this._useCache = useCache;
			}
		    
			// private AutomationElement _el;
			// private bool _useCache;
			public ToggleState ToggleState {
				// get { return (ToggleState)this._el.GetPatternPropertyValue(TogglePattern.ToggleStateProperty, this._useCache); }
				get { return (ToggleState)this._togglePattern.ParentElement.GetPatternPropertyValue(TogglePattern.ToggleStateProperty, this._useCache); }
			}
//			internal TogglePatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
		}
		public static readonly AutomationPattern Pattern = TogglePatternIdentifiers.Pattern;
		public static readonly AutomationProperty ToggleStateProperty = TogglePatternIdentifiers.ToggleStateProperty;
		// private SafePatternHandle _hPattern;
		// private bool _cached;
		// public TogglePattern.TogglePatternInformation Cached {
		public ITogglePatternInformation Cached {
			get {
//				Misc.ValidateCached(this._cached);
//				return new TogglePattern.TogglePatternInformation(this._el, true);
		        return new MyTogglePatternNet.TogglePatternInformation(this, true);
			}
		}
		// public TogglePattern.TogglePatternInformation Current {
		public ITogglePatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new TogglePattern.TogglePatternInformation(this._el, false);
				return new MyTogglePatternNet.TogglePatternInformation(this, false);
			}
		}
//		private MyTogglePatternNet(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//			this._cached = cached;
//		}
		public void Toggle()
		{
			// UiaCoreApi.TogglePattern_Toggle(this._hPattern);
			this._togglePattern.Toggle();
		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new TogglePattern(el, hPattern, cached);
//		}
		
		public IMySuperWrapper ParentElement
		{
		    get { return this._element; }
		    set { this._element = value; }
		}
	}
}
