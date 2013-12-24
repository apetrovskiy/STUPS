/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 3:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System;
	using System.Windows.Automation;

	/// <summary>
	/// Description of ScrollItemPatternAdapter.
	/// </summary>
	public class MyScrollItemPatternNet : IMySuperScrollItemPattern
	{
		public static readonly AutomationPattern Pattern = ScrollItemPatternIdentifiers.Pattern;
		// private SafePatternHandle _hPattern;
		
		private System.Windows.Automation.ScrollItemPattern _scrollItemPattern;
		private IUiElement _element;
		
		public MyScrollItemPatternNet(IUiElement element, ScrollItemPattern scrollItemPattern)
		{
			this._scrollItemPattern = scrollItemPattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		public MyScrollItemPatternNet(IUiElement element)
		{
		    this._element = element;
		}
		
//		private MyScrollItemPatternNet(AutomationElement el, SafePatternHandle hPattern) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//		}
		public virtual void ScrollIntoView()
		{
			// UiaCoreApi.ScrollItemPattern_ScrollIntoView(this._hPattern);
			this._scrollItemPattern.ScrollIntoView();
		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new ScrollItemPattern(el, hPattern);
//		}
		
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
//		    get { return this._scrollItemPattern; }
//		    set { this._scrollItemPattern = value as ScrollItemPattern; }
//		}
		
		public void SetSourcePattern(object pattern)
		{
		    this._scrollItemPattern = pattern as ScrollItemPattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._scrollItemPattern;
		}
	}
}
