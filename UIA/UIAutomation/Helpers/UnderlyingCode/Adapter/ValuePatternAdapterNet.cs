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
    
	/// <summary>
	/// Description of ValuePatternAdapter.
	/// </summary>
	public class MyValuePatternNet :  IMySuperValuePattern //IValuePatternAdapter
	{
		private readonly System.Windows.Automation.ValuePattern _valuePattern;
		private IUiElement _element;
		
		public MyValuePatternNet(IUiElement element, ValuePattern valuePattern)
		{
			this._valuePattern = valuePattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		internal MyValuePatternNet(IUiElement element)
		{
		    this._element = element;
		}

		public struct ValuePatternInformation : IValuePatternInformation
		{
			private readonly bool _useCache;
			private readonly IMySuperValuePattern _valuePattern;

			public ValuePatternInformation(IMySuperValuePattern valuePattern, bool useCache)
			{
				this._valuePattern = valuePattern;
				this._useCache = useCache;
			}

			public string Value {
			    get { 
			        if (null == this._valuePattern) return string.Empty;
			        return this._valuePattern.ParentElement.GetPatternPropertyValue(ValuePattern.ValueProperty, this._useCache).ToString(); }
			}
			public bool IsReadOnly {
				get {
				    if (null == this._valuePattern) return true;
				    return (bool)this._valuePattern.ParentElement.GetPatternPropertyValue(ValuePattern.IsReadOnlyProperty, this._useCache);
				}
			}
		}
		public static readonly AutomationPattern Pattern = ValuePatternIdentifiers.Pattern;
		public static readonly AutomationProperty ValueProperty = ValuePatternIdentifiers.ValueProperty;
		public static readonly AutomationProperty IsReadOnlyProperty = ValuePatternIdentifiers.IsReadOnlyProperty;
		
		public virtual IValuePatternInformation Cached {
			get {
				return new MyValuePatternNet.ValuePatternInformation(this, true);
			}
		}
		
		public virtual IValuePatternInformation Current {
			get {
				return new MyValuePatternNet.ValuePatternInformation(this, false);
			}
		}
		
		public virtual void SetValue(string value)
		{
		    if (null == this._valuePattern) return;
			this._valuePattern.SetValue(value);
		}

		public virtual IUiElement ParentElement
		{
		    get { return this._element; }
		    set { this._element = value; }
		}
	}
}
