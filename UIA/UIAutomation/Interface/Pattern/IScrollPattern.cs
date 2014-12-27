/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 3:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    public interface IScrollPattern : IBasePattern
    {
        void SetScrollPercent(double horizontalPercent, double verticalPercent);
        void Scroll(classic.ScrollAmount horizontalAmount, classic.ScrollAmount verticalAmount);
        void ScrollHorizontal(classic.ScrollAmount amount);
        void ScrollVertical(classic.ScrollAmount amount);
        IScrollPatternInformation Cached { get; }
        IScrollPatternInformation Current { get; }
    }
}
