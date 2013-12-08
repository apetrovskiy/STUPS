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
		private readonly System.Windows.Automation.TogglePattern _togglePattern;
		private IUiElement _element;
		
		public MyTogglePatternNet(IUiElement element, TogglePattern togglePattern)
		{
			this._togglePattern = togglePattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		internal MyTogglePatternNet(IUiElement element)
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
				get { return (ToggleState)this._togglePattern.ParentElement.GetPatternPropertyValue(TogglePattern.ToggleStateProperty, this._useCache); }
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
		
		public virtual IUiElement ParentElement
		{
		    get { return this._element; }
		    set { this._element = value; }
		}
	}
}
