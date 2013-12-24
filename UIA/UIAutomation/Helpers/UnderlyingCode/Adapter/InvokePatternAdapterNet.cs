/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2013
 * Time: 1:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
	using System;
	using System.Windows.Automation;
    
	public class MyInvokePatternNet : IMySuperInvokePattern
	{
	    private System.Windows.Automation.InvokePattern _invokePattern;
		private IUiElement _element;
		
		public MyInvokePatternNet(IUiElement element, InvokePattern invokePattern)
		{
			this._invokePattern = invokePattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		public MyInvokePatternNet(IUiElement element)
		{
		    this._element = element;
		}
		
		public MyInvokePatternNet(InvokePattern InvokePattern)
		{
		    this._invokePattern = InvokePattern;
		}
		
		//: BasePattern
		public static readonly AutomationPattern Pattern = InvokePatternIdentifiers.Pattern;
		public static readonly AutomationEvent InvokedEvent = InvokePatternIdentifiers.InvokedEvent;
		
		public virtual void Invoke()
		{
			if (null == this._invokePattern) return;
			this._invokePattern.Invoke();
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
//		    get { return this._invokePattern; }
//		    set { this._invokePattern = value as InvokePattern; }
//		}
		
		public void SetSourcePattern(object pattern)
		{
		    this._invokePattern = pattern as InvokePattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._invokePattern;
		}
	}
}
