/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/2/2012
 * Time: 10:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Settings
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUIAHighligherSettingsCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Set-UIAHighligherSettingsCommand test")]
    //[Cmdlet(VerbsCommon.Set, "UIAHighligherSettings")]
    public class SetUIAHighligherSettingsCommandTestFixture
    {
        public SetUIAHighligherSettingsCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlight_On1()
        {
            string highlightResponse = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight -HighlightParent " + 
                "; " + 
                @"[UIAutomation.Preferences]::Highlight;",
                highlightResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlight_On2()
        {
            string highlight = "true";
            string highlightResponse = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight:$" + 
                highlight +
                " -HighlightParent:$false; " +
                @"[UIAutomation.Preferences]::Highlight;",
                highlightResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlightParent_On1()
        {
            string highlightResponse = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight -HighlightParent " + 
                "; " + 
                @"[UIAutomation.Preferences]::HighlightParent;",
                highlightResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlightParent_On2()
        {
            string highlight = "true";
            string highlightResponse = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -HighlightParent:$" + 
                highlight +
                " -Highlight:$false; " +
                @"[UIAutomation.Preferences]::HighlightParent;",
                highlightResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlight_Off()
        {
            string highlight = "false";
            string highlightResponse = "False";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight:$" + 
                highlight +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::Highlight;",
                highlightResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlightParent_Off()
        {
            string highlight = "false";
            string highlightResponse = "False";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight:$" + 
                highlight +
                " -HighlightParent:$" + 
                highlight +
                "; " +
                @"[UIAutomation.Preferences]::HighlightParent;",
                highlightResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlighterColor_Default()
        {
            string colorCode = @"([System.Drawing.Color]::";
            string highlighterColor = @"Red)";
            string highlighterColorResponse = @"Color [Red]";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight " + 
                @" -Color " +
                colorCode + 
                highlighterColor +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterColor;",
                highlighterColorResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlighterColor_Simple()
        {
            string colorCode = @"([System.Drawing.Color]::";
            string highlighterColor = @"White)";
            string highlighterColorResponse = @"Color [White]";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight " + 
                @" -Color " +
                colorCode + 
                highlighterColor +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterColor;",
                highlighterColorResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlighterColorParent_Simple()
        {
            string colorCode = @"([System.Drawing.Color]::";
            string highlighterColor = @"White)";
            string highlighterColorResponse = @"Color [White]";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight " + 
                @" -Color " +
                colorCode + 
                highlighterColor +
                " -HighlightParent " +
                @" -ColorParent " +
                colorCode + 
                highlighterColor +
                "; " +
                @"[UIAutomation.Preferences]::HighlighterColorParent;",
                highlighterColorResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlighterColor_Complex1()
        {
            string highlighterColor = @"0xff808040";
            string highlighterColorResponse = @"Color [A=255, R=128, G=128, B=64]";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight " + 
                @" -Color " +
                highlighterColor +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterColor;",
                highlighterColorResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlighterColor_Complex2()
        {
            string highlighterColor = @"0xff800040";
            string highlighterColorResponse = @"Color [A=255, R=128, G=0, B=64]";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight " + 
                @" -Color " +
                highlighterColor +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterColor;",
                highlighterColorResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlighterBorder_Default()
        {
            string highlighterBorder = "3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight " + 
                " -Border " + 
                highlighterBorder +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterBorder;",
                highlighterBorder);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlighterBorder_0()
        {
            string highlighterBorder = "0";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight " + 
                " -Border " + 
                highlighterBorder +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterBorder;",
                highlighterBorder);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIAHighligherSettings")]
        public void SetHighlighterBorder_5()
        {
            string highlighterBorder = "5";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIAHighligherSettings -Highlight " + 
                " -Border " + 
                highlighterBorder +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterBorder;",
                highlighterBorder);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
