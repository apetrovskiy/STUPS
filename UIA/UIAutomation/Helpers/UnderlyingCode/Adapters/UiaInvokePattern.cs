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
    extern alias UIANET;using System.Windows.Automation;
	using System;
	using classic = UIANET::System.Windows.Automation; // using System.Windows.Automation;
    
	public class UiaInvokePattern : IInvokePattern
	{
	    private classic.InvokePattern _invokePattern;
		private IUiElement _element;
		
		public UiaInvokePattern(IUiElement element, classic.InvokePattern invokePattern)
		{
			this._invokePattern = invokePattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		public UiaInvokePattern(IUiElement element)
		{
		    this._element = element;
		}
		
		public UiaInvokePattern(classic.InvokePattern InvokePattern)
		{
		    this._invokePattern = InvokePattern;
		}
		
		public static readonly classic.AutomationPattern Pattern = InvokePatternIdentifiers.Pattern;
		public static readonly classic.AutomationEvent InvokedEvent = InvokePatternIdentifiers.InvokedEvent;
		
		public virtual void Invoke()
		{
			if (null == this._invokePattern) return;
			this._invokePattern.Invoke();
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
		    this._invokePattern = pattern as InvokePattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._invokePattern;
		}
	}
}
