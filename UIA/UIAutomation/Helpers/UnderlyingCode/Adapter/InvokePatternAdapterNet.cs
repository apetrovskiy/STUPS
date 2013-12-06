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
	//using Ninject;
    
	public class MyInvokePatternNet : IMySuperInvokePattern
	{
	    private readonly System.Windows.Automation.InvokePattern _invokePattern;
		private IMySuperWrapper _element;
		
		public MyInvokePatternNet(IMySuperWrapper element, InvokePattern invokePattern)
		{
			this._invokePattern = invokePattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		internal MyInvokePatternNet(IMySuperWrapper element)
		{
		    // this._invokePattern = AutomationFactory.GetMySuperInvokePattern(element, null);
		    this._element = element;
		}
		
		//: BasePattern
		public static readonly AutomationPattern Pattern = InvokePatternIdentifiers.Pattern;
		public static readonly AutomationEvent InvokedEvent = InvokePatternIdentifiers.InvokedEvent;
		// private SafePatternHandle _hPattern;
		
//		private readonly System.Windows.Automation.InvokePattern _invokePattern;
//		private IMySuperWrapper _element;
//		
//		public MyInvokePatternNet(IMySuperWrapper element, InvokePattern invokePattern)
//		{
//			this._invokePattern = invokePattern;
//			this._element = element;
//			//this._useCache = useCache;
//		}
		
//		private InvokePattern(AutomationElement el, SafePatternHandle hPattern) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//		}
		public void Invoke()
		{
			// UiaCoreApi.InvokePattern_Invoke(this._hPattern);
			if (null == this._invokePattern) return;
			this._invokePattern.Invoke();
		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new InvokePattern(el, hPattern);
//		}
		
		public IMySuperWrapper ParentElement
		{
		    get { return this._element; }
		    set { this._element = value; }
		}
	}
}
