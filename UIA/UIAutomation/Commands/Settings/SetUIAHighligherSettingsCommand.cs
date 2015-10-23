/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/2/2012
 * Time: 10:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Drawing;

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUiaHighligherSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaHighligherSettings")]
    public class SetUiaHighligherSettingsCommand : ModuleSettingsCmdletBase
    {
        public SetUiaHighligherSettingsCommand()
        {
            Highlight = Preferences.Highlight;
            Color = Preferences.HighlighterColor;
            Border = Preferences.HighlighterBorder;
            
            HighlightParent = Preferences.HighlightParent;
            ColorParent = Preferences.HighlighterColorParent;
            BorderParent = Preferences.HighlighterBorderParent;
            
//            this.HighlightFirstChild = Preferences.HighlightFirstChild;
//            this.ColorFirstChild = Preferences.HighlighterColorFirstChild;
//            this.BorderFirstChild = Preferences.HighlighterBorderFirstChild;
        }
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory=true)]
        public SwitchParameter Highlight { get; set; }
        [UiaParameter][Parameter(Mandatory=false)]
        public Color Color { get; set; }
        [UiaParameter][Parameter(Mandatory=false)]
        public int Border { get; set; }
        
        [UiaParameter][Parameter(Mandatory=true)]
        public SwitchParameter HighlightParent { get; set; }
        [UiaParameter][Parameter(Mandatory=false)]
        public Color ColorParent { get; set; }
        [UiaParameter][Parameter(Mandatory=false)]
        public int BorderParent { get; set; }
        
//        [UiaParameterNotUsed][Parameter(Mandatory=true)]
//        public SwitchParameter HighlightFirstChild { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory=false)]
//        public System.Drawing.Color ColorFirstChild { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory=false)]
//        public int BorderFirstChild { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            Preferences.Highlight = Highlight;
            Preferences.HighlighterColor = Color;
            Preferences.HighlighterBorder = Border;
            
            Preferences.HighlightParent = HighlightParent;
            Preferences.HighlighterColorParent = ColorParent;
            Preferences.HighlighterBorderParent = BorderParent;
            
//            Preferences.HighlightFirstChild = this.HighlightFirstChild;
//            Preferences.HighlighterColorFirstChild = this.ColorFirstChild;
//            Preferences.HighlighterBorderFirstChild = this.BorderFirstChild;
        }
    }
}
