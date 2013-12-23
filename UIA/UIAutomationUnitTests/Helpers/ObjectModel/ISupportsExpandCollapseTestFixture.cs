/*
 * Created by SharpDevelop.
 * User: Alexander
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
            ISupportsInvokePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsInvokePattern;
            
            Assert.IsNotNull(element as ISupportsInvokePattern);
        }
        
        [Test]
        public void ExpandCollapse_ImplementsPattern()
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
        public void ExpandCollapse_Expand()
        {
            // Arrange
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsExpandCollapsePattern;
            
            // Act
            // Assert
            element.Expand();
        }
        
        [Test]
        public void ExpandCollapse_Collapse()
        {
            // Arrange
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsExpandCollapsePattern;
            
            // Act
            // Assert
            element.Collapse();
        }
    }
}
