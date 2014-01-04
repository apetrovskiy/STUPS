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
    /// <summary>
    /// Description of UiExtendedModelHolder.
    /// </summary>
    public class UiExtendedModelHolder : IExtendedModelHolder
    {
        private IUiElement _parentElement;
        
        public UiExtendedModelHolder()
        {
            
        }
        
        public void SetParentElement(IUiElement parentElement)
        {
            _parentElement = parentElement;
        }
        
        public IUiElement GetParentElement()
        {
            return _parentElement;
        }
    }
}
