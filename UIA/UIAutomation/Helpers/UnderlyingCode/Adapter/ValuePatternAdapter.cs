/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/24/2013
 * Time: 2:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	using System;
	using System.Windows.Automation;

	/// <summary>
	/// Description of ValuePatternAdapter.
	/// </summary>
	public class MyValuePattern : IValuePatternAdapter
	{
		private System.Windows.Automation.ValuePattern valuePattern;
		private IMySuperWrapper element;

		public MyValuePattern(IMySuperWrapper element, ValuePattern valuePattern)
		{
			this.valuePattern = valuePattern;
			this.element = element;
		}

		//: BasePattern
		public struct ValuePatternInformation : IValuePatternInformation
		{
			//private AutomationElement _el;
			//private bool _useCache;
			private IValuePatternAdapter valuePattern;

			public ValuePatternInformation(IValuePatternAdapter valuePattern)
			{
				this.valuePattern = valuePattern;
			}

			public string Value {
//					object patternPropertyValue = this._el.GetPatternPropertyValue(ValuePattern.ValueProperty, this._useCache);
//					return patternPropertyValue.ToString();
				//get { return this.valuePattern.ParentElement.GetPatternPropertyValue(ValuePattern.ValueProperty, false); }
				get { return ""; }
			}
			public bool IsReadOnly {
				//get { return (bool)this._el.GetPatternPropertyValue(ValuePattern.IsReadOnlyProperty, this._useCache); }
				//get { return (bool)this._el.GetPatternPropertyValue(ValuePattern.IsReadOnlyProperty, this._useCache); }
				get { return false; }
			}
//			internal ValuePatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
		}
		public static readonly AutomationPattern Pattern = ValuePatternIdentifiers.Pattern;
		public static readonly AutomationProperty ValueProperty = ValuePatternIdentifiers.ValueProperty;
		public static readonly AutomationProperty IsReadOnlyProperty = ValuePatternIdentifiers.IsReadOnlyProperty;
//		private SafePatternHandle _hPattern;
//		private bool _cached;
		//public ValuePattern.ValuePatternInformation Cached {
		public IValuePatternInformation Cached {
			get {
				//Misc.ValidateCached(this._cached);
				//return new ValuePattern.ValuePatternInformation(this._el, true);
				return null;
			}
		}
		//public ValuePattern.ValuePatternInformation Current {
		public IValuePatternInformation Current {
			get {
				//Misc.ValidateCurrent(this._hPattern);
				//return new ValuePattern.ValuePatternInformation(this._el, false);
				return null;
			}
		}
//		internal ValuePattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//			this._cached = cached;
//		}
		public void SetValue(string value)
		{
//			Misc.ValidateArgumentNonNull(value, "value");
//			object currentPropertyValue = this._el.GetCurrentPropertyValue(AutomationElementIdentifiers.IsEnabledProperty);
//			if (currentPropertyValue is bool && !(bool)currentPropertyValue) {
//				throw new ElementNotEnabledException();
//			}
//			object currentPropertyValue2 = this._el.GetCurrentPropertyValue(ValuePattern.IsReadOnlyProperty);
//			if (currentPropertyValue2 is bool && (bool)currentPropertyValue2) {
//				throw new InvalidOperationException(SR.Get("ValueReadonly"));
//			}
//			UiaCoreApi.ValuePattern_SetValue(this._hPattern, value);
			this.valuePattern.SetValue(value);
		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new ValuePattern(el, hPattern, cached);
//		}

		public IMySuperWrapper ParentElement { get; set; }
	}

	/*
	public class ValuePattern : IValuePatternAdapter
	{
		//: BasePattern
		public struct ValuePatternInformation
		{
			private AutomationElement _el;
			private bool _useCache;
			public string Value {
				get {
					object patternPropertyValue = this._el.GetPatternPropertyValue(ValuePattern.ValueProperty, this._useCache);
					return patternPropertyValue.ToString();
				}
			}
			public bool IsReadOnly {
				get { return (bool)this._el.GetPatternPropertyValue(ValuePattern.IsReadOnlyProperty, this._useCache); }
			}
			internal ValuePatternInformation(AutomationElement el, bool useCache)
			{
				this._el = el;
				this._useCache = useCache;
			}
		}
		public static readonly AutomationPattern Pattern = ValuePatternIdentifiers.Pattern;
		public static readonly AutomationProperty ValueProperty = ValuePatternIdentifiers.ValueProperty;
		public static readonly AutomationProperty IsReadOnlyProperty = ValuePatternIdentifiers.IsReadOnlyProperty;
		private SafePatternHandle _hPattern;
		private bool _cached;
		public ValuePattern.ValuePatternInformation Cached {
			get {
				Misc.ValidateCached(this._cached);
				return new ValuePattern.ValuePatternInformation(this._el, true);
			}
		}
		public ValuePattern.ValuePatternInformation Current {
			get {
				Misc.ValidateCurrent(this._hPattern);
				return new ValuePattern.ValuePatternInformation(this._el, false);
			}
		}
		internal ValuePattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
		{
			this._hPattern = hPattern;
			this._cached = cached;
		}
		public void SetValue(string value)
		{
			Misc.ValidateArgumentNonNull(value, "value");
			object currentPropertyValue = this._el.GetCurrentPropertyValue(AutomationElementIdentifiers.IsEnabledProperty);
			if (currentPropertyValue is bool && !(bool)currentPropertyValue) {
				throw new ElementNotEnabledException();
			}
			object currentPropertyValue2 = this._el.GetCurrentPropertyValue(ValuePattern.IsReadOnlyProperty);
			if (currentPropertyValue2 is bool && (bool)currentPropertyValue2) {
				throw new InvalidOperationException(SR.Get("ValueReadonly"));
			}
			UiaCoreApi.ValuePattern_SetValue(this._hPattern, value);
		}
		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
		{
			return new ValuePattern(el, hPattern, cached);
		}
	}
	*/
}
