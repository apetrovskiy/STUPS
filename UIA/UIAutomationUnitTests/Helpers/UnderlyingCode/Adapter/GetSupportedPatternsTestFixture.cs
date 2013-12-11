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
    using MbUnit.Framework;
    using System.Linq;
    
    /// <summary>
    /// Description of GetSupportedPatternsTestFixture.
    /// </summary>
    [TestFixture]
    public class GetSupportedPatternsTestFixture
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
        
        #region helpers
        #endregion helpers
        
        [Test]
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
            
            Assert.AreEqual(0, element.GetSupportedPatterns().Count());
        }
        
        [Test]
        public void OnePattern()
        {
            IFakeUiElement element =
                FakeFactory.GetAutomationElement(
                    ControlType.Button,
                    "name",
                    "auId",
                    "className",
                    new[] { AutomationFactory.GetMySuperPattern<IMySuperValuePattern>(AutomationFactory.GetUiElement(), null) },
                    true);
            
            Assert.AreEqual(1, element.GetSupportedPatterns().Count());
            Assert.Exists(element.GetSupportedPatterns(), p => p is IMySuperValuePattern);
        }
        
        [Test]
        public void ThreePatterns()
        {
            IFakeUiElement element =
                FakeFactory.GetAutomationElement(
                    ControlType.Button,
                    "name",
                    "auId",
                    "className",
                    new IBasePattern[] {
                        AutomationFactory.GetMySuperPattern<IMySuperExpandCollapsePattern>(AutomationFactory.GetUiElement(), null),
                        AutomationFactory.GetMySuperPattern<IMySuperTableItemPattern>(AutomationFactory.GetUiElement(), null),
                        AutomationFactory.GetMySuperPattern<IMySuperWindowPattern>(AutomationFactory.GetUiElement(), null)
                    },
                    true);
            
            Assert.AreEqual(3, element.GetSupportedPatterns().Count());
            Assert.Exists(element.GetSupportedPatterns(), p => p is IMySuperExpandCollapsePattern);
            Assert.Exists(element.GetSupportedPatterns(), p => p is IMySuperTableItemPattern);
            Assert.Exists(element.GetSupportedPatterns(), p => p is IMySuperWindowPattern);
        }
    }
}
