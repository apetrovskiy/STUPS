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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    // using System.Windows.Automation.Text;
    using System.Windows;

    /// <summary>
    /// Description of TextPatternAdapterNet.
    /// </summary>
    public class UiaTextPattern : ITextPattern
    {
        private classic.TextPattern _textPattern;
        private IUiElement _element;
        
        public UiaTextPattern(IUiElement element, classic.TextPattern textPattern)
        {
            _textPattern = textPattern;
            _element = element;
            //this._useCache = useCache;
        }
        
        public UiaTextPattern(IUiElement element)
        {
            _element = element;
        }
        
        public UiaTextPattern(classic.TextPattern textPattern)
        {
            _textPattern = textPattern;
        }
        
        public static readonly object MixedAttributeValue = classic.TextPatternIdentifiers.MixedAttributeValue;
        public static readonly classic.AutomationTextAttribute AnimationStyleAttribute = classic.TextPatternIdentifiers.AnimationStyleAttribute;
        public static readonly classic.AutomationTextAttribute BackgroundColorAttribute = classic.TextPatternIdentifiers.BackgroundColorAttribute;
        public static readonly classic.AutomationTextAttribute BulletStyleAttribute = classic.TextPatternIdentifiers.BulletStyleAttribute;
        public static readonly classic.AutomationTextAttribute CapStyleAttribute = classic.TextPatternIdentifiers.CapStyleAttribute;
        public static readonly classic.AutomationTextAttribute CultureAttribute = classic.TextPatternIdentifiers.CultureAttribute;
        public static readonly classic.AutomationTextAttribute FontNameAttribute = classic.TextPatternIdentifiers.FontNameAttribute;
        public static readonly classic.AutomationTextAttribute FontSizeAttribute = classic.TextPatternIdentifiers.FontSizeAttribute;
        public static readonly classic.AutomationTextAttribute FontWeightAttribute = classic.TextPatternIdentifiers.FontWeightAttribute;
        public static readonly classic.AutomationTextAttribute ForegroundColorAttribute = classic.TextPatternIdentifiers.ForegroundColorAttribute;
        public static readonly classic.AutomationTextAttribute HorizontalTextAlignmentAttribute = classic.TextPatternIdentifiers.HorizontalTextAlignmentAttribute;
        public static readonly classic.AutomationTextAttribute IndentationFirstLineAttribute = classic.TextPatternIdentifiers.IndentationFirstLineAttribute;
        public static readonly classic.AutomationTextAttribute IndentationLeadingAttribute = classic.TextPatternIdentifiers.IndentationLeadingAttribute;
        public static readonly classic.AutomationTextAttribute IndentationTrailingAttribute = classic.TextPatternIdentifiers.IndentationTrailingAttribute;
        public static readonly classic.AutomationTextAttribute IsHiddenAttribute = classic.TextPatternIdentifiers.IsHiddenAttribute;
        public static readonly classic.AutomationTextAttribute IsItalicAttribute = classic.TextPatternIdentifiers.IsItalicAttribute;
        public static readonly classic.AutomationTextAttribute IsReadOnlyAttribute = classic.TextPatternIdentifiers.IsReadOnlyAttribute;
        public static readonly classic.AutomationTextAttribute IsSubscriptAttribute = classic.TextPatternIdentifiers.IsSubscriptAttribute;
        public static readonly classic.AutomationTextAttribute IsSuperscriptAttribute = classic.TextPatternIdentifiers.IsSuperscriptAttribute;
        public static readonly classic.AutomationTextAttribute MarginBottomAttribute = classic.TextPatternIdentifiers.MarginBottomAttribute;
        public static readonly classic.AutomationTextAttribute MarginLeadingAttribute = classic.TextPatternIdentifiers.MarginLeadingAttribute;
        public static readonly classic.AutomationTextAttribute MarginTopAttribute = classic.TextPatternIdentifiers.MarginTopAttribute;
        public static readonly classic.AutomationTextAttribute MarginTrailingAttribute = classic.TextPatternIdentifiers.MarginTrailingAttribute;
        public static readonly classic.AutomationTextAttribute OutlineStylesAttribute = classic.TextPatternIdentifiers.OutlineStylesAttribute;
        public static readonly classic.AutomationTextAttribute OverlineColorAttribute = classic.TextPatternIdentifiers.OverlineColorAttribute;
        public static readonly classic.AutomationTextAttribute OverlineStyleAttribute = classic.TextPatternIdentifiers.OverlineStyleAttribute;
        public static readonly classic.AutomationTextAttribute StrikethroughColorAttribute = classic.TextPatternIdentifiers.StrikethroughColorAttribute;
        public static readonly classic.AutomationTextAttribute StrikethroughStyleAttribute = classic.TextPatternIdentifiers.StrikethroughStyleAttribute;
        public static readonly classic.AutomationTextAttribute TabsAttribute = classic.TextPatternIdentifiers.TabsAttribute;
        public static readonly classic.AutomationTextAttribute TextFlowDirectionsAttribute = classic.TextPatternIdentifiers.TextFlowDirectionsAttribute;
        public static readonly classic.AutomationTextAttribute UnderlineColorAttribute = classic.TextPatternIdentifiers.UnderlineColorAttribute;
        public static readonly classic.AutomationTextAttribute UnderlineStyleAttribute = classic.TextPatternIdentifiers.UnderlineStyleAttribute;
        public static readonly classic.AutomationPattern Pattern = classic.TextPatternIdentifiers.Pattern;
        public static readonly classic.AutomationEvent TextSelectionChangedEvent = classic.TextPatternIdentifiers.TextSelectionChangedEvent;
        public static readonly classic.AutomationEvent TextChangedEvent = classic.TextPatternIdentifiers.TextChangedEvent;
        // private SafePatternHandle _hPattern;
        // private AutomationElement _element;
        public classic.Text.TextPatternRange DocumentRange {
            get {
                // SafeTextRangeHandle hTextRange = UiaCoreApi.TextPattern_get_DocumentRange(this._hPattern);
                // return TextPatternRange.Wrap(hTextRange, this);
                return _textPattern.DocumentRange;
            }
        }
        public classic.SupportedTextSelection SupportedTextSelection {
            // get { return UiaCoreApi.TextPattern_get_SupportedTextSelection(this._hPattern); }
            get { return _textPattern.SupportedTextSelection; }
        }
//        internal UiaTextPattern(AutomationElement el, SafePatternHandle hPattern) : base(el, hPattern)
//        {
//            this._hPattern = hPattern;
//            this._element = el;
//        }
        public virtual classic.Text.TextPatternRange[] GetSelection()
        {
            // SafeTextRangeHandle[] hTextRanges = UiaCoreApi.TextPattern_GetSelection(this._hPattern);
            // return TextPatternRange.Wrap(hTextRanges, this);
            return _textPattern.GetSelection();
        }
        public virtual classic.Text.TextPatternRange[] GetVisibleRanges()
        {
            // SafeTextRangeHandle[] hTextRanges = UiaCoreApi.TextPattern_GetVisibleRanges(this._hPattern);
            // return TextPatternRange.Wrap(hTextRanges, this);
            return _textPattern.GetVisibleRanges();
        }
        
        public virtual classic.Text.TextPatternRange RangeFromChild(IUiElement childElement)
        {
//            if (childElement == null) {
//                throw new ArgumentNullException("childElement");
//            }
//            SafeTextRangeHandle hTextRange = UiaCoreApi.TextPattern_RangeFromChild(this._hPattern, childElement.RawNode);
//            return TextPatternRange.Wrap(hTextRange, this);
            // 20140102
            // return this._textPattern.RangeFromChild(childElement.GetSourceElement());
            return _textPattern.RangeFromChild(childElement.GetSourceElement() as classic.AutomationElement);
        }
        public virtual classic.Text.TextPatternRange RangeFromPoint(Point screenLocation)
        {
//            Rect rect = (Rect)this._element.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty);
//            if (screenLocation.X < rect.Left || screenLocation.X >= rect.Right || screenLocation.Y < rect.Top || screenLocation.Y >= rect.Bottom) {
//                throw new ArgumentException(SR.Get("ScreenCoordinatesOutsideBoundingRect"));
//            }
//            SafeTextRangeHandle hTextRange = UiaCoreApi.TextPattern_RangeFromPoint(this._hPattern, screenLocation);
//            return TextPatternRange.Wrap(hTextRange, this);
            return _textPattern.RangeFromPoint(screenLocation);
        }
//        static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//        {
//            if (hPattern.IsInvalid) {
//                throw new InvalidOperationException(SR.Get("CantPrefetchTextPattern"));
//            }
//            return new TextPattern(el, hPattern);
//        }
//        static internal bool Compare(TextPattern t1, TextPattern t2)
//        {
//            return Misc.Compare(t1._element, t2._element);
//        }
        
        public void SetParentElement(IUiElement element)
        {
            _element = element;
        }
        
        public IUiElement GetParentElement()
        {
            return _element;
        }
        
        public void SetSourcePattern(object pattern)
        {
            _textPattern = pattern as classic.TextPattern;
        }
        
        public object GetSourcePattern()
        {
            return _textPattern;
        }
    }
}
