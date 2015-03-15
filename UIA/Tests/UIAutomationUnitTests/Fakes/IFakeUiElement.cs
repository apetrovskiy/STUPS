/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/9/2013
 * Time: 11:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System.Collections.Generic;
    using UIAutomation;
    
    /// <summary>
    /// Description of IFakeUiElement.
    /// </summary>
    public interface IFakeUiElement : IUiElement
    {
        List<IBasePattern> Patterns { get; set; }
    }
}
