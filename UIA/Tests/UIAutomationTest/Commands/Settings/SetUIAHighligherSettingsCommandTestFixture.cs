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
    /// <summary>
    /// Description of SetUiaHighligherSettingsCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Set-UiaHighligherSettingsCommand test")]
    //[Cmdlet(VerbsCommon.Set, "UiaHighligherSettings")]
    public class SetUiaHighligherSettingsCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlight_On1()
        {
            string highlightResponse = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight -HighlightParent " + 
                "; " + 
                @"[UIAutomation.Preferences]::Highlight;",
                highlightResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlight_On2()
        {
            string highlight = "true";
            string highlightResponse = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight:$" + 
                highlight +
                " -HighlightParent:$false; " +
                @"[UIAutomation.Preferences]::Highlight;",
                highlightResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlightParent_On1()
        {
            string highlightResponse = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight -HighlightParent " + 
                "; " + 
                @"[UIAutomation.Preferences]::HighlightParent;",
                highlightResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlightParent_On2()
        {
            string highlight = "true";
            string highlightResponse = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -HighlightParent:$" + 
                highlight +
                " -Highlight:$false; " +
                @"[UIAutomation.Preferences]::HighlightParent;",
                highlightResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlight_Off()
        {
            string highlight = "false";
            string highlightResponse = "False";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight:$" + 
                highlight +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::Highlight;",
                highlightResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlightParent_Off()
        {
            string highlight = "false";
            string highlightResponse = "False";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight:$" + 
                highlight +
                " -HighlightParent:$" + 
                highlight +
                "; " +
                @"[UIAutomation.Preferences]::HighlightParent;",
                highlightResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlighterColor_Default()
        {
            string colorCode = @"([System.Drawing.Color]::";
            string highlighterColor = @"Red)";
            string highlighterColorResponse = @"Color [Red]";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight " + 
                @" -Color " +
                colorCode + 
                highlighterColor +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterColor;",
                highlighterColorResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlighterColor_Simple()
        {
            string colorCode = @"([System.Drawing.Color]::";
            string highlighterColor = @"White)";
            string highlighterColorResponse = @"Color [White]";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight " + 
                @" -Color " +
                colorCode + 
                highlighterColor +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterColor;",
                highlighterColorResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlighterColorParent_Simple()
        {
            string colorCode = @"([System.Drawing.Color]::";
            string highlighterColor = @"White)";
            string highlighterColorResponse = @"Color [White]";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight " + 
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlighterColor_Complex1()
        {
            string highlighterColor = @"0xff808040";
            string highlighterColorResponse = @"Color [A=255, R=128, G=128, B=64]";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight " + 
                @" -Color " +
                highlighterColor +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterColor;",
                highlighterColorResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlighterColor_Complex2()
        {
            string highlighterColor = @"0xff800040";
            string highlighterColorResponse = @"Color [A=255, R=128, G=0, B=64]";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight " + 
                @" -Color " +
                highlighterColor +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterColor;",
                highlighterColorResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlighterBorder_Default()
        {
            string highlighterBorder = "3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight " + 
                " -Border " + 
                highlighterBorder +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterBorder;",
                highlighterBorder);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlighterBorder_0()
        {
            string highlighterBorder = "0";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight " + 
                " -Border " + 
                highlighterBorder +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterBorder;",
                highlighterBorder);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaHighligherSettings")]
        public void SetHighlighterBorder_5()
        {
            string highlighterBorder = "5";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaHighligherSettings -Highlight " + 
                " -Border " + 
                highlighterBorder +
                " -HighlightParent; " + 
                @"[UIAutomation.Preferences]::HighlighterBorder;",
                highlighterBorder);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
