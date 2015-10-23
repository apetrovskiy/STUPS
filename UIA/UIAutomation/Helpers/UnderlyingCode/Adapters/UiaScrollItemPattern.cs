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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of ScrollItemPatternAdapter.
    /// </summary>
    public class UiaScrollItemPattern : IScrollItemPattern
    {
        public static readonly classic.AutomationPattern Pattern = classic.ScrollItemPatternIdentifiers.Pattern;
        // private SafePatternHandle _hPattern;
        
        private classic.ScrollItemPattern _scrollItemPattern;
        private IUiElement _element;
        
        public UiaScrollItemPattern(IUiElement element, classic.ScrollItemPattern scrollItemPattern)
        {
            _scrollItemPattern = scrollItemPattern;
            _element = element;
            //this._useCache = useCache;
        }
        
        public UiaScrollItemPattern(IUiElement element)
        {
            _element = element;
        }
        
//        private UiaScrollItemPattern(AutomationElement el, SafePatternHandle hPattern) : base(el, hPattern)
//        {
//            this._hPattern = hPattern;
//        }
        public virtual void ScrollIntoView()
        {
            // UiaCoreApi.ScrollItemPattern_ScrollIntoView(this._hPattern);
            _scrollItemPattern.ScrollIntoView();
        }
//        static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//        {
//            return new ScrollItemPattern(el, hPattern);
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
            _scrollItemPattern = pattern as classic.ScrollItemPattern;
        }
        
        public object GetSourcePattern()
        {
            return _scrollItemPattern;
        }
    }
}
