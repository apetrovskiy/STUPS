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
    using MbUnit.Framework;using Xunit;using NUnit.Framework;
    using NSubstitute;
    
    /// <summary>
    /// Description of ISupportsExpandCollapseTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsExpandCollapseTestFixture
    {
        public ISupportsExpandCollapseTestFixture()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExpandCollapse_ImplementsCommonPattern()
        {
//            ISupportsInvokePattern invokableElement =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsInvokePattern;
//            
//            MbUnit.Framework.Assert.IsNotNull(invokableElement as ISupportsInvokePattern);
            
            ISupportsHighlighter highlightableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsHighlighter;
            
            MbUnit.Framework.Assert.IsNotNull(highlightableElement as ISupportsHighlighter);
            Xunit.Assert.NotNull(highlightableElement as ISupportsHighlighter);
            
            ISupportsNavigation navigatableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsNavigation;
            
            MbUnit.Framework.Assert.IsNotNull(navigatableElement as ISupportsNavigation);
            Xunit.Assert.NotNull(navigatableElement as ISupportsNavigation);
            
            ISupportsConversion conversibleElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsConversion;
            
            MbUnit.Framework.Assert.IsNotNull(conversibleElement as ISupportsConversion);
            Xunit.Assert.NotNull(conversibleElement as ISupportsConversion);
            
            ISupportsRefresh refreshableElement =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsRefresh;
            
            MbUnit.Framework.Assert.IsNotNull(refreshableElement as ISupportsRefresh);
            Xunit.Assert.NotNull(refreshableElement as ISupportsRefresh);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExpandCollapse_ImplementsPatternInQuestion()
        {
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsExpandCollapsePattern;
            
            MbUnit.Framework.Assert.IsNotNull(element as ISupportsExpandCollapsePattern);
            Xunit.Assert.NotNull(element as ISupportsExpandCollapsePattern);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExpandCollapse_DoesNotImplementOtherPatterns()
        {
            ISupportsValuePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsValuePattern;
            
            MbUnit.Framework.Assert.IsNull(element as ISupportsValuePattern);
            Xunit.Assert.Null(element as ISupportsValuePattern);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExpandCollapse_Expand_ExpandCollapseState()
        {
            // Arrange
            const ExpandCollapseState expectedValue = ExpandCollapseState.Expanded;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
            // Act
            element.Expand();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ExpandCollapseState);
            Xunit.Assert.Equal(expectedValue, element.ExpandCollapseState);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExpandCollapse_Collapse_ExpandCollapseState()
        {
            // Arrange
            const ExpandCollapseState expectedValue = ExpandCollapseState.Collapsed;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
            // Act
            element.Collapse();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ExpandCollapseState);
            Xunit.Assert.Equal(expectedValue, element.ExpandCollapseState);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExpandCollapse_LeafNode()
        {
            // Arrange
            const ExpandCollapseState expectedValue = ExpandCollapseState.LeafNode;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ExpandCollapseState);
            Xunit.Assert.Equal(expectedValue, element.ExpandCollapseState);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExpandCollapse_PartiallyExpanded()
        {
            // Arrange
            const ExpandCollapseState expectedValue = ExpandCollapseState.PartiallyExpanded;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
            // Act
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ExpandCollapseState);
            Xunit.Assert.Equal(expectedValue, element.ExpandCollapseState);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExpandCollapse_Collapse()
        {
            // Arrange
            const ExpandCollapseState expectedValue = ExpandCollapseState.Collapsed;
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
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ExpandCollapseState);
            Xunit.Assert.Equal(expectedValue, element.ExpandCollapseState);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ExpandCollapse_Expand()
        {
            // Arrange
            const ExpandCollapseState expectedValue = ExpandCollapseState.Expanded;
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
            MbUnit.Framework.Assert.AreEqual(expectedValue, element.ExpandCollapseState);
            Xunit.Assert.Equal(expectedValue, element.ExpandCollapseState);
        }
    }
}
