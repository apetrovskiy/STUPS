/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/9/2013
 * Time: 10:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System.Collections.Generic;
    using System.Windows.Automation;
    using UIAutomation;
    
    /// <summary>
    /// Description of FakeUiElement.
    /// </summary>
    public class FakeUiElement : UiElement, IFakeUiElement
    {
        public List<IBasePattern> Patterns { get; set; }
        
        public FakeUiElement()
        {
            Patterns = new List<IBasePattern>();
        }
    }
}
