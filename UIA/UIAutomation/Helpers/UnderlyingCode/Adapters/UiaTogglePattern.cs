/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/6/2013
 * Time: 10:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
	using System;
	using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

	public class UiaTogglePattern : ITogglePattern
	{
		private classic.TogglePattern _togglePattern;
		private IUiElement _element;
		
		public UiaTogglePattern(IUiElement element, classic.TogglePattern togglePattern)
		{
			this._togglePattern = togglePattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		public UiaTogglePattern(IUiElement element)
		{
		    this._element = element;
		}

		public struct TogglePatternInformation : ITogglePatternInformation
		{
			private readonly bool _useCache;
			private readonly ITogglePattern _togglePattern;
			
			public TogglePatternInformation(ITogglePattern tooglePattern, bool useCache)
			{
			    this._togglePattern = tooglePattern;
			    this._useCache = useCache;
			}
		    
			public classic.ToggleState ToggleState {
				get { return (classic.ToggleState)this._togglePattern.GetParentElement().GetPatternPropertyValue(classic.TogglePattern.ToggleStateProperty, this._useCache); }
			}
		}
		public static readonly classic.AutomationPattern Pattern = classic.TogglePatternIdentifiers.Pattern;
		public static readonly classic.AutomationProperty ToggleStateProperty = classic.TogglePatternIdentifiers.ToggleStateProperty;
		
		public virtual ITogglePatternInformation Cached {
			get {
		        return new UiaTogglePattern.TogglePatternInformation(this, true);
			}
		}
		
		public virtual ITogglePatternInformation Current {
			get {
				return new UiaTogglePattern.TogglePatternInformation(this, false);
			}
		}
        
		public virtual void Toggle()
		{
			if (null == this._togglePattern) return;
			this._togglePattern.Toggle();
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
		    this._togglePattern = pattern as classic.TogglePattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._togglePattern;
		}
	}
}
