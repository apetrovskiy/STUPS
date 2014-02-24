/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/18/2014
 * Time: 1:00 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    // using System.Windows.Automation;
    
    /// <summary>
    /// Description of UiControlInputHolder.
    /// </summary>
    public class UiControlInputHolder : IControlInputHolder
    {
        private IUiElement _parentElement;
        
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
