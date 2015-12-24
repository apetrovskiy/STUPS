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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    public class UiaInvokePattern : IInvokePattern
    {
        private classic.InvokePattern _invokePattern;
        private IUiElement _element;
        
        public UiaInvokePattern(IUiElement element, classic.InvokePattern invokePattern)
        {
            _invokePattern = invokePattern;
            _element = element;
            //this._useCache = useCache;
        }
        
        public UiaInvokePattern(IUiElement element)
        {
            _element = element;
        }
        
        public UiaInvokePattern(classic.InvokePattern InvokePattern)
        {
            _invokePattern = InvokePattern;
        }
        
        public static readonly classic.AutomationPattern Pattern = classic.InvokePatternIdentifiers.Pattern;
        public static readonly classic.AutomationEvent InvokedEvent = classic.InvokePatternIdentifiers.InvokedEvent;
        
        public virtual void Invoke()
        {
            if (null == _invokePattern) return;
            _invokePattern.Invoke();
        }
        
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
            _invokePattern = pattern as classic.InvokePattern;
        }
        
        public object GetSourcePattern()
        {
            return _invokePattern;
        }
    }
}
