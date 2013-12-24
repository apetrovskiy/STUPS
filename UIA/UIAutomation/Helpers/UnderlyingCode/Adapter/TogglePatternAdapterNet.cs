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

	public class MyTogglePatternNet : IMySuperTogglePattern
	{
		private System.Windows.Automation.TogglePattern _togglePattern;
		private IUiElement _element;
		
		public MyTogglePatternNet(IUiElement element, TogglePattern togglePattern)
		{
			this._togglePattern = togglePattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		public MyTogglePatternNet(IUiElement element)
		{
		    this._element = element;
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
		    
			public ToggleState ToggleState {
			    // 20131224
				// get { return (ToggleState)this._togglePattern.ParentElement.GetPatternPropertyValue(TogglePattern.ToggleStateProperty, this._useCache); }
				get { return (ToggleState)this._togglePattern.GetParentElement().GetPatternPropertyValue(TogglePattern.ToggleStateProperty, this._useCache); }
			}
		}
		public static readonly AutomationPattern Pattern = TogglePatternIdentifiers.Pattern;
		public static readonly AutomationProperty ToggleStateProperty = TogglePatternIdentifiers.ToggleStateProperty;
		
		public virtual ITogglePatternInformation Cached {
			get {
		        return new MyTogglePatternNet.TogglePatternInformation(this, true);
			}
		}
		
		public virtual ITogglePatternInformation Current {
			get {
				return new MyTogglePatternNet.TogglePatternInformation(this, false);
			}
		}
        
		public virtual void Toggle()
		{
			if (null == this._togglePattern) return;
			this._togglePattern.Toggle();
		}
		
		// public virtual IUiElement ParentElement
//		internal virtual IUiElement ParentElement
//		{
//		    get { return this._element; }
//		    set { this._element = value; }
//		}
		
		public void SetParentElement(IUiElement element)
		{
		    this._element = element;
		}
		
		public IUiElement GetParentElement()
		{
		    return this._element;
		}
		
//		public object SourcePattern
//		{
//		    get { return this._togglePattern; }
//		    set { this._togglePattern = value as TogglePattern; }
//		}
		
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
