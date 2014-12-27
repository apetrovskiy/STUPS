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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    /// <summary>
    /// Description of ValuePatternAdapter.
    /// </summary>
    public class UiaValuePattern :  IValuePattern //IValuePatternAdapter
    {
        private classic.ValuePattern _valuePattern;
        private IUiElement _element;
        private object _patternEmulator;
        
        public UiaValuePattern(IUiElement element, classic.ValuePattern valuePattern)
        {
            this._valuePattern = valuePattern;
            this._element = element;
            //this._useCache = useCache;
        }
        
        public UiaValuePattern(IUiElement element)
        {
            this._element = element;
            this._patternEmulator = new SourcePatternEmulator(new object());
        }
        
        public UiaValuePattern(classic.ValuePattern valuePattern)
        {
            this._valuePattern = valuePattern;
        }

        public struct ValuePatternInformation : IValuePatternInformation
        {
            private readonly bool _useCache;
            private readonly IValuePattern _valuePattern;

            public ValuePatternInformation(IValuePattern valuePattern, bool useCache)
            {
                this._valuePattern = valuePattern;
                this._useCache = useCache;
            }

            public string Value {
                get
                {
                    return null == this._valuePattern ? string.Empty : this._valuePattern.GetParentElement().GetPatternPropertyValue(classic.ValuePattern.ValueProperty, this._useCache).ToString();
                    /*
                    if (null == this._valuePattern) return string.Empty;
                    return this._valuePattern.GetParentElement().GetPatternPropertyValue(ValuePattern.ValueProperty, this._useCache).ToString(); }
                    */
                }
            }
            public bool IsReadOnly {
                get {
                    return null == this._valuePattern || (bool)this._valuePattern.GetParentElement().GetPatternPropertyValue(classic.ValuePattern.IsReadOnlyProperty, this._useCache);
                    /*
                    if (null == this._valuePattern) return true;
                    return (bool)this._valuePattern.GetParentElement().GetPatternPropertyValue(ValuePattern.IsReadOnlyProperty, this._useCache);
                    */
                }
            }
        }
        public static readonly classic.AutomationPattern Pattern = classic.ValuePatternIdentifiers.Pattern;
        public static readonly classic.AutomationProperty ValueProperty = classic.ValuePatternIdentifiers.ValueProperty;
        public static readonly classic.AutomationProperty IsReadOnlyProperty = classic.ValuePatternIdentifiers.IsReadOnlyProperty;
        
        public virtual IValuePatternInformation Cached {
            get {
                return new UiaValuePattern.ValuePatternInformation(this, true);
            }
        }
        
        public virtual IValuePatternInformation Current {
            get {
                return new UiaValuePattern.ValuePatternInformation(this, false);
            }
        }
        
        public virtual void SetValue(string value)
        {
            if (null == this._valuePattern) return;
            this._valuePattern.SetValue(value);
        }
        
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
            this._valuePattern = pattern as classic.ValuePattern;
        }
        
        public object GetSourcePattern()
        {
            return this._valuePattern;
        }
    }
}
