/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 10:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    // using System.Windows.Automation.Text;
    using System.Windows;

    public interface ITextPattern : IBasePattern
    {
        classic.Text.TextPatternRange[] GetSelection();
        classic.Text.TextPatternRange[] GetVisibleRanges();
        classic.Text.TextPatternRange RangeFromChild(IUiElement childElement);
        classic.Text.TextPatternRange RangeFromPoint(Point screenLocation);
        classic.Text.TextPatternRange DocumentRange { get; }
        classic.SupportedTextSelection SupportedTextSelection { get; }
    }
}
