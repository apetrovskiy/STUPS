/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 10:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System;
	using System.Windows.Automation;
	using System.Windows.Automation.Text;
	using System.Windows;

	/// <summary>
	/// Description of TextPatternAdapterNet.
	/// </summary>
	public class UiaTextPattern : ITextPattern
	{
		private System.Windows.Automation.TextPattern _textPattern;
		private IUiElement _element;
		
		public UiaTextPattern(IUiElement element, TextPattern textPattern)
		{
			this._textPattern = textPattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		public UiaTextPattern(IUiElement element)
		{
		    this._element = element;
		}
		
		public UiaTextPattern(TextPattern textPattern)
		{
		    this._textPattern = textPattern;
		}
		
		public static readonly object MixedAttributeValue = TextPatternIdentifiers.MixedAttributeValue;
		public static readonly AutomationTextAttribute AnimationStyleAttribute = TextPatternIdentifiers.AnimationStyleAttribute;
		public static readonly AutomationTextAttribute BackgroundColorAttribute = TextPatternIdentifiers.BackgroundColorAttribute;
		public static readonly AutomationTextAttribute BulletStyleAttribute = TextPatternIdentifiers.BulletStyleAttribute;
		public static readonly AutomationTextAttribute CapStyleAttribute = TextPatternIdentifiers.CapStyleAttribute;
		public static readonly AutomationTextAttribute CultureAttribute = TextPatternIdentifiers.CultureAttribute;
		public static readonly AutomationTextAttribute FontNameAttribute = TextPatternIdentifiers.FontNameAttribute;
		public static readonly AutomationTextAttribute FontSizeAttribute = TextPatternIdentifiers.FontSizeAttribute;
		public static readonly AutomationTextAttribute FontWeightAttribute = TextPatternIdentifiers.FontWeightAttribute;
		public static readonly AutomationTextAttribute ForegroundColorAttribute = TextPatternIdentifiers.ForegroundColorAttribute;
		public static readonly AutomationTextAttribute HorizontalTextAlignmentAttribute = TextPatternIdentifiers.HorizontalTextAlignmentAttribute;
		public static readonly AutomationTextAttribute IndentationFirstLineAttribute = TextPatternIdentifiers.IndentationFirstLineAttribute;
		public static readonly AutomationTextAttribute IndentationLeadingAttribute = TextPatternIdentifiers.IndentationLeadingAttribute;
		public static readonly AutomationTextAttribute IndentationTrailingAttribute = TextPatternIdentifiers.IndentationTrailingAttribute;
		public static readonly AutomationTextAttribute IsHiddenAttribute = TextPatternIdentifiers.IsHiddenAttribute;
		public static readonly AutomationTextAttribute IsItalicAttribute = TextPatternIdentifiers.IsItalicAttribute;
		public static readonly AutomationTextAttribute IsReadOnlyAttribute = TextPatternIdentifiers.IsReadOnlyAttribute;
		public static readonly AutomationTextAttribute IsSubscriptAttribute = TextPatternIdentifiers.IsSubscriptAttribute;
		public static readonly AutomationTextAttribute IsSuperscriptAttribute = TextPatternIdentifiers.IsSuperscriptAttribute;
		public static readonly AutomationTextAttribute MarginBottomAttribute = TextPatternIdentifiers.MarginBottomAttribute;
		public static readonly AutomationTextAttribute MarginLeadingAttribute = TextPatternIdentifiers.MarginLeadingAttribute;
		public static readonly AutomationTextAttribute MarginTopAttribute = TextPatternIdentifiers.MarginTopAttribute;
		public static readonly AutomationTextAttribute MarginTrailingAttribute = TextPatternIdentifiers.MarginTrailingAttribute;
		public static readonly AutomationTextAttribute OutlineStylesAttribute = TextPatternIdentifiers.OutlineStylesAttribute;
		public static readonly AutomationTextAttribute OverlineColorAttribute = TextPatternIdentifiers.OverlineColorAttribute;
		public static readonly AutomationTextAttribute OverlineStyleAttribute = TextPatternIdentifiers.OverlineStyleAttribute;
		public static readonly AutomationTextAttribute StrikethroughColorAttribute = TextPatternIdentifiers.StrikethroughColorAttribute;
		public static readonly AutomationTextAttribute StrikethroughStyleAttribute = TextPatternIdentifiers.StrikethroughStyleAttribute;
		public static readonly AutomationTextAttribute TabsAttribute = TextPatternIdentifiers.TabsAttribute;
		public static readonly AutomationTextAttribute TextFlowDirectionsAttribute = TextPatternIdentifiers.TextFlowDirectionsAttribute;
		public static readonly AutomationTextAttribute UnderlineColorAttribute = TextPatternIdentifiers.UnderlineColorAttribute;
		public static readonly AutomationTextAttribute UnderlineStyleAttribute = TextPatternIdentifiers.UnderlineStyleAttribute;
		public static readonly AutomationPattern Pattern = TextPatternIdentifiers.Pattern;
		public static readonly AutomationEvent TextSelectionChangedEvent = TextPatternIdentifiers.TextSelectionChangedEvent;
		public static readonly AutomationEvent TextChangedEvent = TextPatternIdentifiers.TextChangedEvent;
		// private SafePatternHandle _hPattern;
		// private AutomationElement _element;
		public TextPatternRange DocumentRange {
			get {
				// SafeTextRangeHandle hTextRange = UiaCoreApi.TextPattern_get_DocumentRange(this._hPattern);
				// return TextPatternRange.Wrap(hTextRange, this);
				return this._textPattern.DocumentRange;
			}
		}
		public SupportedTextSelection SupportedTextSelection {
			// get { return UiaCoreApi.TextPattern_get_SupportedTextSelection(this._hPattern); }
			get { return this._textPattern.SupportedTextSelection; }
		}
//		internal UiaTextPattern(AutomationElement el, SafePatternHandle hPattern) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//			this._element = el;
//		}
		public virtual TextPatternRange[] GetSelection()
		{
			// SafeTextRangeHandle[] hTextRanges = UiaCoreApi.TextPattern_GetSelection(this._hPattern);
			// return TextPatternRange.Wrap(hTextRanges, this);
			return this._textPattern.GetSelection();
		}
		public virtual TextPatternRange[] GetVisibleRanges()
		{
			// SafeTextRangeHandle[] hTextRanges = UiaCoreApi.TextPattern_GetVisibleRanges(this._hPattern);
			// return TextPatternRange.Wrap(hTextRanges, this);
			return this._textPattern.GetVisibleRanges();
		}
		
		public virtual TextPatternRange RangeFromChild(IUiElement childElement)
		{
//			if (childElement == null) {
//				throw new ArgumentNullException("childElement");
//			}
//			SafeTextRangeHandle hTextRange = UiaCoreApi.TextPattern_RangeFromChild(this._hPattern, childElement.RawNode);
//			return TextPatternRange.Wrap(hTextRange, this);
		    // 20140102
		    // return this._textPattern.RangeFromChild(childElement.GetSourceElement());
		    return this._textPattern.RangeFromChild(childElement.GetSourceElement() as AutomationElement);
		}
		public virtual TextPatternRange RangeFromPoint(Point screenLocation)
		{
//			Rect rect = (Rect)this._element.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty);
//			if (screenLocation.X < rect.Left || screenLocation.X >= rect.Right || screenLocation.Y < rect.Top || screenLocation.Y >= rect.Bottom) {
//				throw new ArgumentException(SR.Get("ScreenCoordinatesOutsideBoundingRect"));
//			}
//			SafeTextRangeHandle hTextRange = UiaCoreApi.TextPattern_RangeFromPoint(this._hPattern, screenLocation);
//			return TextPatternRange.Wrap(hTextRange, this);
			return this._textPattern.RangeFromPoint(screenLocation);
		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			if (hPattern.IsInvalid) {
//				throw new InvalidOperationException(SR.Get("CantPrefetchTextPattern"));
//			}
//			return new TextPattern(el, hPattern);
//		}
//		static internal bool Compare(TextPattern t1, TextPattern t2)
//		{
//			return Misc.Compare(t1._element, t2._element);
//		}
		
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
		    this._textPattern = pattern as TextPattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._textPattern;
		}
	}
}
