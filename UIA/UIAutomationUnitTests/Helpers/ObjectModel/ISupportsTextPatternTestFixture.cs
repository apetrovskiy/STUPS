/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/22/2013
 * Time: 2:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using System.Windows.Automation.Text;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of ISupportsTextPatternTestFixture.
    /// </summary>
    // [Ignore]
    [TestFixture]
    public class ISupportsTextPatternTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        [Test]
        public void Text_ImplementsCommonPattern()
        {
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void Text_ImplementsPattern()
        {
            ISupportsTextPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            Assert.IsNotNull(element as ISupportsTextPattern);
        }
        
        [Test]
        public void Text_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void Text_GetTextSelection()
        {
            // Arrange
            ISupportsTextPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            // Act
            // Assert
            element.GetTextSelection();
        }
        
        [Test]
        public void Text_GetVisibleRanges()
        {
            // Arrange
            ISupportsTextPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            // Act
            // Assert
            element.GetVisibleRanges();
        }
        
        [Test]
        [Ignore]
        public void Text_RangeFromChild()
        {
            // Arrange
            ISupportsTextPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            // Act
            // Assert
            element.RangeFromChild(new UiElement());
        }
        
        [Test]
        [Ignore]
        public void Text_RangeFromPoint()
        {
            // Arrange
            ISupportsTextPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData()) }) as ISupportsTextPattern;
            
            // Act
            // Assert
            element.RangeFromPoint(new System.Windows.Point());
        }
        
        
        [Test]
        [Ignore]
        public void Text_DocumentRange()
        {
            // Arrange
            TextPatternRange expectedValue = new object() as TextPatternRange;
            ISupportsTextPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData() { TextPattern_DocumentRange = expectedValue }) }) as ISupportsTextPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.DocumentRange);
        }
        
        [Test]
        public void Text_SupportedTextSelection()
        {
            // Arrange
            SupportedTextSelection expectedValue = SupportedTextSelection.Single;
            ISupportsTextPattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetTextPattern(new PatternsData() { TextPattern_SupportedTextSelection = expectedValue }) }) as ISupportsTextPattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.SupportedTextSelection);
        }
    }
}
