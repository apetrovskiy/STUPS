/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/21/2013
 * Time: 1:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.ObjectModel
{
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    using NSubstitute;
    
    /// <summary>
    /// Description of ISupportsExpandCollapseTestFixture.
    /// </summary>
    [TestFixture]
    public class ISupportsExpandCollapseTestFixture
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
        public void ExpandCollapse_ImplementsCommonPattern()
        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsHighlighter;
            
            Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsNavigation;
            
            Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            
            ISupportsConversion conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsConversion;
            
            Assert.IsNotNull(conversibleElement as ISupportsConversion);
            
            ISupportsRefresh refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsRefresh;
            
            Assert.IsNotNull(refreshableElement as ISupportsRefresh);
        }
        
        [Test]
        public void ExpandCollapse_ImplementsPatternInQuestion()
        {
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsExpandCollapsePattern;
            
            Assert.IsNotNull(element as ISupportsExpandCollapsePattern);
        }
        
        [Test]
        public void ExpandCollapse_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            Assert.IsNull(element as ISupportsValuePattern);
        }
        
        [Test]
        public void ExpandCollapse_Expand_ExpandCollapseState()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.Expanded;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
            // Act
            element.Expand();
            
            // Assert
            Assert.AreEqual(expectedValue, element.ExpandCollapseState);
        }
        
        [Test]
        public void ExpandCollapse_Collapse_ExpandCollapseState()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.Collapsed;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
            // Act
            element.Collapse();
            
            // Assert
            Assert.AreEqual(expectedValue, element.ExpandCollapseState);
        }
        
        [Test]
        public void ExpandCollapse_LeafNode()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.LeafNode;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.ExpandCollapseState);
        }
        
        [Test]
        public void ExpandCollapse_PartiallyExpanded()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.PartiallyExpanded;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
            // Act
            
            // Assert
            Assert.AreEqual(expectedValue, element.ExpandCollapseState);
        }
        
        [Test]
        public void ExpandCollapse_Collapse()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.Collapsed;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsExpandCollapsePattern;
            
            // Act
            element.Collapse();
            try {
                (element as IUiElement).GetCurrentPattern<IExpandCollapsePattern>(ExpandCollapsePattern.Pattern).Received().Collapse();
                element.ExpandCollapseState.Returns(expectedValue);
            }
            catch {}
            
            // Assert
            Assert.AreEqual(expectedValue, element.ExpandCollapseState);
        }
        
        [Test]
        public void ExpandCollapse_Expand()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.Expanded;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsExpandCollapsePattern;
            
            // Act
            element.Expand();
            try {
                (element as IUiElement).GetCurrentPattern<IExpandCollapsePattern>(ExpandCollapsePattern.Pattern).Received().Expand();
                element.ExpandCollapseState.Returns(expectedValue);
            }
            catch {}
            
            // Assert
            Assert.AreEqual(expectedValue, element.ExpandCollapseState);
        }
    }
}
