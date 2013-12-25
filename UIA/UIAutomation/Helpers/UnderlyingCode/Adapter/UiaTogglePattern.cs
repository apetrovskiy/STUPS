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
	extern alias UIANET;
	using System;
	using System.Windows.Automation;

	public class UiaTogglePattern : ITogglePattern
	{
		private System.Windows.Automation.TogglePattern _togglePattern;
		private IUiElement _element;
		
		public UiaTogglePattern(IUiElement element, TogglePattern togglePattern)
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
		    
			public ToggleState ToggleState {
				get { return (ToggleState)this._togglePattern.GetParentElement().GetPatternPropertyValue(TogglePattern.ToggleStateProperty, this._useCache); }
			}
		}
		public static readonly AutomationPattern Pattern = TogglePatternIdentifiers.Pattern;
		public static readonly AutomationProperty ToggleStateProperty = TogglePatternIdentifiers.ToggleStateProperty;
		
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
		    this._togglePattern = pattern as TogglePattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._togglePattern;
		}
	}
}
