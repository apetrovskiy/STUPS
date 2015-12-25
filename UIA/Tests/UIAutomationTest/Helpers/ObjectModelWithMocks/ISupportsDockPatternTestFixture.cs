/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/8/2014
 * Time: 2:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers.ObjectModelWithMocks
{
    using System.Windows.Automation;
    using UIAutomation;
    using UIAutomationUnitTests;
    
    /// <summary>
    /// Description of ISupportsDockPatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsDockPatternTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
//            FakeFactory.InitForPowerShell();
//            MiddleLevelCode.PrepareRunspace();
//            CmdletUnitTest.TestRunspace.RunPSCode(
//                @"[void]([UIAutomation.CurrentData]::ResetData());");
            
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
            FakeFactory.InitForPowerShell();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Dock_ImplementsCommonPattern()
//        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
//            
//            ISupportsHighlighter highlightableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsHighlighter;
//            
//            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
//            
//            ISupportsNavigation navigatableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsNavigation;
//            
//            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
//            
//            ISupportsConversion conversibleElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsConversion;
//            
//            Assert.IsNotNull(conversibleElement as ISupportsConversion);
//            
//            ISupportsRefresh refreshableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsRefresh;
//            
//            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Dock_ImplementsPatternInQuestion()
//        {
//            ISupportsDockPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsDockPattern;
//            
//            Assert.IsNotNull(element as ISupportsDockPattern);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Dock_DoesNotImplementOtherPatterns()
//        {
//            ISupportsValuePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsValuePattern;
//            
//            Assert.IsNull(element as ISupportsValuePattern);
//        }
//        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore("")]
        public void Dock_DockPosition()
        {
            // Arrange
            DockPosition expectedValue = DockPosition.Bottom;
            ISupportsDockPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData() { DockPattern_DockPosition = expectedValue }) }) as ISupportsDockPattern;
            
//            // Arrange
//            ExpandCollapseState expectedValue = ExpandCollapseState.Expanded;
//            ISupportsExpandCollapsePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
            
//            // Act
//            element.SetDockPosition(expectedValue);
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.DockPosition);
            
            // Act
            // Assert
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$input | %{ $_.DockPosition; }",
                new [] { element },
                expectedValue.ToString());
        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void Dock_SetDockPosition()
//        {
//            // Arrange
//            DockPosition expectedValue = DockPosition.Left;
//            ISupportsDockPattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetDockPattern(new PatternsData()) }) as ISupportsDockPattern;
//            
//            // Act
//            element.SetDockPosition(expectedValue);
//            try {
//                (element as IUiElement).GetCurrentPattern<IDockPattern>(DockPattern.Pattern).Received(1).SetDockPosition(expectedValue);
//                element.DockPosition.Returns(expectedValue);
//                
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.DockPosition);
//        }
    }
}
