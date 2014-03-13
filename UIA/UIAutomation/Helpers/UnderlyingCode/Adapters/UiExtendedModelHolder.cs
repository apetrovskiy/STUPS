/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/4/2014
 * Time: 1:44 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    /// <summary>
    /// Description of UiExtendedModelHolder.
    /// </summary>
    public class UiExtendedModelHolder : IExtendedModelHolder
    {
        private IUiElement _parentElement;
        private classic.TreeScope _scope;
        
        public int Seconds { get; set; }
        
        public UiExtendedModelHolder()
        {
            Seconds = Preferences.Timeout;
        }
        
        public void SetParentElement(IUiElement parentElement)
        {
            _parentElement = parentElement;
        }
        
        public IUiElement GetParentElement()
        {
            return _parentElement;
        }
        
        public void SetScope(classic.TreeScope scope)
        {
            _scope = scope;
        }
        
        public classic.TreeScope GetScope()
        {
            return _scope;
        }
    }
}
