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
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of UiExtendedModelHolder.
    /// </summary>
    public class UiExtendedModelHolder : IExtendedModelHolder
    {
        private IUiElement _parentElement;
        private TreeScope _scope;
        
        public UiExtendedModelHolder()
        {
            
        }
        
//        public UiExtendedModelHolder(TreeScope scope)
//        {
//            
//        }
        
        public void SetParentElement(IUiElement parentElement)
        {
            _parentElement = parentElement;
        }
        
        public IUiElement GetParentElement()
        {
            return _parentElement;
        }
        
        public void SetScope(TreeScope scope)
        {
            _scope = scope;
        }
        
        public TreeScope GetScope()
        {
            return _scope;
        }
    }
}
