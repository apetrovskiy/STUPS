/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/2/2012
 * Time: 10:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUIAHighligherSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAHighligherSettings")]
    public class SetUIAHighligherSettingsCommand : ModuleSettingsCmdletBase
    {
        public SetUIAHighligherSettingsCommand()
        {
            this.Highlight = Preferences.Highlight;
            this.Color = Preferences.HighlighterColor;
            this.Border = Preferences.HighlighterBorder;
            
            this.HighlightParent = Preferences.HighlightParent;
            this.ColorParent = Preferences.HighlighterColorParent;
            this.BorderParent = Preferences.HighlighterBorderParent;
            
//            this.HighlightFirstChild = Preferences.HighlightFirstChild;
//            this.ColorFirstChild = Preferences.HighlighterColorFirstChild;
//            this.BorderFirstChild = Preferences.HighlighterBorderFirstChild;
        }
        
        #region Parameters
        [Parameter(Mandatory=true)]
        public SwitchParameter Highlight { get; set; }
        [Parameter(Mandatory=false)]
        public System.Drawing.Color Color { get; set; }
        [Parameter(Mandatory=false)]
        public int Border { get; set; }
        
        [Parameter(Mandatory=true)]
        public SwitchParameter HighlightParent { get; set; }
        [Parameter(Mandatory=false)]
        public System.Drawing.Color ColorParent { get; set; }
        [Parameter(Mandatory=false)]
        public int BorderParent { get; set; }
        
//        [Parameter(Mandatory=true)]
//        public SwitchParameter HighlightFirstChild { get; set; }
//        [Parameter(Mandatory=false)]
//        public System.Drawing.Color ColorFirstChild { get; set; }
//        [Parameter(Mandatory=false)]
//        public int BorderFirstChild { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            Preferences.Highlight = this.Highlight;
            Preferences.HighlighterColor = this.Color;
            Preferences.HighlighterBorder = this.Border;
            
            Preferences.HighlightParent = this.HighlightParent;
            Preferences.HighlighterColorParent = this.ColorParent;
            Preferences.HighlighterBorderParent = this.BorderParent;
            
//            Preferences.HighlightFirstChild = this.HighlightFirstChild;
//            Preferences.HighlighterColorFirstChild = this.ColorFirstChild;
//            Preferences.HighlighterBorderFirstChild = this.BorderFirstChild;
        }
    }
}
