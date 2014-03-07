/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/24/2013
 * Time: 11:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    /// <summary>
    /// Description of IBasePattern.
    /// </summary>
    public interface IBasePattern
    {
        void SetParentElement(IUiElement element);
        IUiElement GetParentElement();
        void SetSourcePattern(object pattern);
        object GetSourcePattern();
    }
}
