/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2013
 * Time: 12:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.UnderlyingCode.Adapter
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;using Xunit;
    using System.Linq;
    
    /// <summary>
    /// Description of GetSupportedPatternsTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class GetSupportedPatternsTestFixture
    {
        public GetSupportedPatternsTestFixture()
        {
            FakeFactory.Init();
        }
        
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        #region helpers
        #endregion helpers
        
        [Test][Fact]
        public void NoPatterns()
        {
            IFakeUiElement element =
                FakeFactory.GetAutomationElement(
                    ControlType.Button,
                    "name",
                    "auId",
                    "className",
                    new IBasePattern[] {},
                    true);
            
            MbUnit.Framework.Assert.AreEqual(0, element.GetSupportedPatterns().Count());
            Xunit.Assert.Equal(0, element.GetSupportedPatterns().Count());
        }
        
        [Test]// [Fact]
        public void OnePattern()
        {
            IFakeUiElement element =
                FakeFactory.GetAutomationElement(
                    ControlType.Button,
                    "name",
                    "auId",
                    "className",
                    new[] { AutomationFactory.GetPatternAdapter<IValuePattern>(AutomationFactory.GetUiElement(), null) },
                    true);
            
            MbUnit.Framework.Assert.AreEqual(1, element.GetSupportedPatterns().Count());
            MbUnit.Framework.Assert.Exists(element.GetSupportedPatterns(), p => p is IValuePattern);
            Xunit.Assert.Equal(1, element.GetSupportedPatterns().Count());
            // Xunit.Assert.Contains<IBasePattern>(AutomationFactory.GetPatternAdapter<IValuePattern>(AutomationFactory.GetUiElement(), null) as IBasePattern, element.GetSupportedPatterns());
        }
        
        [Test]// [Fact]
        public void ThreePatterns()
        {
            IFakeUiElement element =
                FakeFactory.GetAutomationElement(
                    ControlType.Button,
                    "name",
                    "auId",
                    "className",
                    new IBasePattern[] {
                        AutomationFactory.GetPatternAdapter<IExpandCollapsePattern>(AutomationFactory.GetUiElement(), null),
                        AutomationFactory.GetPatternAdapter<ITableItemPattern>(AutomationFactory.GetUiElement(), null),
                        AutomationFactory.GetPatternAdapter<IWindowPattern>(AutomationFactory.GetUiElement(), null)
                    },
                    true);
            
            MbUnit.Framework.Assert.AreEqual(3, element.GetSupportedPatterns().Count());
            MbUnit.Framework.Assert.Exists(element.GetSupportedPatterns(), p => p is IExpandCollapsePattern);
            MbUnit.Framework.Assert.Exists(element.GetSupportedPatterns(), p => p is ITableItemPattern);
            MbUnit.Framework.Assert.Exists(element.GetSupportedPatterns(), p => p is IWindowPattern);
            Xunit.Assert.Equal(3, element.GetSupportedPatterns().Count());
            // Xunit.Assert.Contains<IBasePattern>(AutomationFactory.GetPatternAdapter<IExpandCollapsePattern>(AutomationFactory.GetUiElement(), null) as IBasePattern, element.GetSupportedPatterns());
            // Xunit.Assert.Contains<IBasePattern>(AutomationFactory.GetPatternAdapter<ITableItemPattern>(AutomationFactory.GetUiElement(), null), element.GetSupportedPatterns());
            // Xunit.Assert.Contains<IBasePattern>(AutomationFactory.GetPatternAdapter<IWindowPattern>(AutomationFactory.GetUiElement(), null), element.GetSupportedPatterns());
        }
    }
}
