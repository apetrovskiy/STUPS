/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/4/2014
 * Time: 1:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    /// <summary>
    /// Description of IExtendedModel.
    /// </summary>
    public interface IExtendedModel
    {
        IUiEltCollection Buttons { get; }
        IUiEltCollection Calendars { get; }
        IUiEltCollection CheckBoxes { get; }
        IUiEltCollection ComboBoxes { get; }
        IUiEltCollection Customs { get; }
        IUiEltCollection DataGrids { get; }
        IUiEltCollection DataItems { get; }
        IUiEltCollection Documents { get; }
        IUiEltCollection Edits { get; }
        IUiEltCollection Groups { get; }
        IUiEltCollection Headers { get; }
        IUiEltCollection HeaderItems { get; }
        IUiEltCollection Hyperlinks { get; }
        IUiEltCollection Images { get; }
        IUiEltCollection ListItems { get; }
        IUiEltCollection Lists { get; }
        IUiEltCollection Menus { get; }
        IUiEltCollection MenuBars { get; }
        IUiEltCollection MenuItems { get; }
        IUiEltCollection Panes { get; }
        IUiEltCollection ProgressBars { get; }
        IUiEltCollection RadioButtons { get; }
        IUiEltCollection ScrollBars { get; }
        IUiEltCollection Separators { get; }
        IUiEltCollection Sliders { get; }
        IUiEltCollection Spinners { get; }
        IUiEltCollection SplitButtons { get; }
        IUiEltCollection StatusBars { get; }
        IUiEltCollection Tabs { get; }
        IUiEltCollection TabItems { get; }
        IUiEltCollection Tables { get; }
        IUiEltCollection Texts { get; }
        IUiEltCollection Thumbs { get; }
        IUiEltCollection TitleBars { get; }
        IUiEltCollection ToolBars { get; }
        IUiEltCollection ToolTips { get; }
        IUiEltCollection Trees { get; }
        IUiEltCollection TreeItems { get; }
        IUiEltCollection Windows { get; }
    }
}
