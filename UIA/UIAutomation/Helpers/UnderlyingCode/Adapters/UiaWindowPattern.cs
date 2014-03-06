/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 3:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;// using System.Windows.Automation;
	using System;
	using classic = UIANET::System.Windows.Automation; // using System.Windows.Automation;

	/// <summary>
	/// Description of WindowPatternAdapter.
	/// </summary>
	public class UiaWindowPattern : IWindowPattern
	{
		private classic.WindowPattern _windowPattern;
		private IUiElement _element;

		public UiaWindowPattern(IUiElement element, classic.WindowPattern windowPattern)
		{
			this._windowPattern = windowPattern;
			this._element = element;
			//this._useCache = useCache;
		}

		public UiaWindowPattern(IUiElement element)
		{
			this._element = element;
		}

		public struct WindowPatternInformation : IWindowPatternInformation
		{
			// private AutomationElement _el;
			private bool _useCache;
			
			private IWindowPattern _windowPattern;
			
			public WindowPatternInformation(IWindowPattern windowPattern, bool useCache)
			{
			    this._windowPattern = windowPattern;
			    this._useCache = useCache;
			}
			
			public bool CanMaximize {
				// get { return (bool)this._el.GetPatternPropertyValue(WindowPattern.CanMaximizeProperty, this._useCache); }
				get { return (bool)this._windowPattern.GetParentElement().GetPatternPropertyValue(classic.WindowPattern.CanMaximizeProperty, this._useCache); }
			}
			public bool CanMinimize {
				// get { return (bool)this._el.GetPatternPropertyValue(WindowPattern.CanMinimizeProperty, this._useCache); }
				get { return (bool)this._windowPattern.GetParentElement().GetPatternPropertyValue(classic.WindowPattern.CanMinimizeProperty, this._useCache); }
			}
			public bool IsModal {
				// get { return (bool)this._el.GetPatternPropertyValue(WindowPattern.IsModalProperty, this._useCache); }
				get { return (bool)this._windowPattern.GetParentElement().GetPatternPropertyValue(classic.WindowPattern.IsModalProperty, this._useCache); }
			}
			public classic.WindowVisualState WindowVisualState {
				// get { return (WindowVisualState)this._el.GetPatternPropertyValue(WindowPattern.WindowVisualStateProperty, this._useCache); }
				get { return (classic.WindowVisualState)this._windowPattern.GetParentElement().GetPatternPropertyValue(classic.WindowPattern.WindowVisualStateProperty, this._useCache); }
			}
			public classic.WindowInteractionState WindowInteractionState {
				// get { return (WindowInteractionState)this._el.GetPatternPropertyValue(WindowPattern.WindowInteractionStateProperty, this._useCache); }
				get { return (classic.WindowInteractionState)this._windowPattern.GetParentElement().GetPatternPropertyValue(classic.WindowPattern.WindowInteractionStateProperty, this._useCache); }
			}
			public bool IsTopmost {
				// get { return (bool)this._el.GetPatternPropertyValue(WindowPattern.IsTopmostProperty, this._useCache); }
				get { return (bool)this._windowPattern.GetParentElement().GetPatternPropertyValue(classic.WindowPattern.IsTopmostProperty, this._useCache); }
			}
//			internal WindowPatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
		}
		public static readonly classic.AutomationPattern Pattern = classic.WindowPatternIdentifiers.Pattern;
		public static readonly classic.AutomationProperty CanMaximizeProperty = classic.WindowPatternIdentifiers.CanMaximizeProperty;
		public static readonly classic.AutomationProperty CanMinimizeProperty = classic.WindowPatternIdentifiers.CanMinimizeProperty;
		public static readonly classic.AutomationProperty IsModalProperty = classic.WindowPatternIdentifiers.IsModalProperty;
		public static readonly classic.AutomationProperty WindowVisualStateProperty = classic.WindowPatternIdentifiers.WindowVisualStateProperty;
		public static readonly classic.AutomationProperty WindowInteractionStateProperty = classic.WindowPatternIdentifiers.WindowInteractionStateProperty;
		public static readonly classic.AutomationProperty IsTopmostProperty = classic.WindowPatternIdentifiers.IsTopmostProperty;
		public static readonly classic.AutomationEvent WindowOpenedEvent = classic.WindowPatternIdentifiers.WindowOpenedEvent;
		public static readonly classic.AutomationEvent WindowClosedEvent = classic.WindowPatternIdentifiers.WindowClosedEvent;
		// private SafePatternHandle _hPattern;
		// private bool _cached;
		
		public virtual IWindowPatternInformation Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new WindowPattern.WindowPatternInformation(this._el, true);
				return new UiaWindowPattern.WindowPatternInformation(this, true);
			}
		}
		
		public virtual IWindowPatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new WindowPattern.WindowPatternInformation(this._el, false);
				return new UiaWindowPattern.WindowPatternInformation(this, false);
			}
		}
//		private UiaWindowPattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//			this._cached = cached;
//		}
		public virtual void SetWindowVisualState(classic.WindowVisualState state)
		{
			// UiaCoreApi.WindowPattern_SetWindowVisualState(this._hPattern, state);
			this._windowPattern.SetWindowVisualState(state);
		}
		public virtual void Close()
		{
			// UiaCoreApi.WindowPattern_Close(this._hPattern);
			this._windowPattern.Close();
		}
		public virtual bool WaitForInputIdle(int milliseconds)
		{
			// return UiaCoreApi.WindowPattern_WaitForInputIdle(this._hPattern, milliseconds);
			return this._windowPattern.WaitForInputIdle(milliseconds);
		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new WindowPattern(el, hPattern, cached);
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
		    this._windowPattern = pattern as classic.WindowPattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._windowPattern;
		}
	}
}
