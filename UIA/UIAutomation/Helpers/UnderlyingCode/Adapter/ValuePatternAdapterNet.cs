/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/24/2013
 * Time: 2:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
	using System;
	using System.Windows.Automation;
	//using Ninject;
    
	/// <summary>
	/// Description of ValuePatternAdapter.
	/// </summary>
	public class MyValuePatternNet :  IMySuperValuePattern //IValuePatternAdapter
	{
		private readonly System.Windows.Automation.ValuePattern _valuePattern;
		private IUiElement _element;
		
		//private bool _useCache; // mine
        
		public MyValuePatternNet(IUiElement element, ValuePattern valuePattern)
		{
			this._valuePattern = valuePattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		internal MyValuePatternNet(IUiElement element)
		{
		    // this._valuePattern = AutomationFactory.GetMySuperValuePattern(element, null);
		    this._element = element;
		}

		public struct ValuePatternInformation : IValuePatternInformation
		{
			//private AutomationElement _el;
			private readonly bool _useCache;
			//private IValuePatternAdapter valuePattern;
			private readonly IMySuperValuePattern _valuePattern;

			//public ValuePatternInformation(IValuePatternAdapter valuePattern)
			public ValuePatternInformation(IMySuperValuePattern valuePattern, bool useCache)
			{
				this._valuePattern = valuePattern;
				this._useCache = useCache;
			}

			public string Value {
//					object patternPropertyValue = this._el.GetPatternPropertyValue(ValuePattern.ValueProperty, this._useCache);
//					return patternPropertyValue.ToString();
			    get { 
//			        Console.WriteLine(this._valuePattern.GetType().Name);
//			        Console.WriteLine(this._valuePattern.ParentElement.GetType().Name);
//			        Console.WriteLine(this._useCache.ToString());
//			        Console.WriteLine(ValuePattern.ValueProperty.ProgrammaticName);
//			        try {
//			            var a1 = this._valuePattern;
//			            Console.WriteLine(a1.ToString());
//			            var a2 = this._valuePattern.ParentElement;
//			            Console.WriteLine(a2.ToString());
//			            var a3 = this._useCache;
//			            Console.WriteLine(a3.ToString());
//			            var aaa = this._valuePattern.ParentElement.GetPatternPropertyValue(ValuePattern.ValueProperty, this._useCache);
//			            Console.WriteLine(aaa);
//			            Console.WriteLine(aaa.GetType());
//			            Console.WriteLine(aaa.ToString());
//			        }
//			        catch (Exception eeee111) {
//			            Console.WriteLine("eeee111:");
//			            Console.WriteLine(eeee111.Message);
//			        }
			        if (null == this._valuePattern) return string.Empty;
			        return this._valuePattern.ParentElement.GetPatternPropertyValue(ValuePattern.ValueProperty, this._useCache).ToString(); }
			}
			public bool IsReadOnly {
				//get { return (bool)this._el.GetPatternPropertyValue(ValuePattern.IsReadOnlyProperty, this._useCache); }
				get {
				    if (null == this._valuePattern) return true;
				    return (bool)this._valuePattern.ParentElement.GetPatternPropertyValue(ValuePattern.IsReadOnlyProperty, this._useCache);
				}
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
				return new MyValuePatternNet.ValuePatternInformation(this, true);
			}
		}
		//public ValuePattern.ValuePatternInformation Current {
		public IValuePatternInformation Current {
			get {
				//Misc.ValidateCurrent(this._hPattern);
				//return new ValuePattern.ValuePatternInformation(this._el, false);
				return new MyValuePatternNet.ValuePatternInformation(this, false);
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
		    if (null == this._valuePattern) return;
			this._valuePattern.SetValue(value);
		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new ValuePattern(el, hPattern, cached);
//		}

		public IUiElement ParentElement
		{
		    get { return this._element; }
		    set { this._element = value; }
		}
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
