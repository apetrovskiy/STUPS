/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/26/2013
 * Time: 5:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    using System.Windows.Automation;
    using PSTestLib;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of elementOfPossibleControlTypeTestFixture.
    /// </summary>
    [TestFixture]
    public class elementOfPossibleControlTypeTestFixture
    {
        public elementOfPossibleControlTypeTestFixture()
        {
        }
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        private GetControlCollectionCmdletBase getClass()
        {
            return new GetControlCollectionCmdletBase();
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.elementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void Nothing_to_compare()
        {
            Assert.AreEqual(
                false,
                getClass().elementOfPossibleControlType(
                    null,
                    null));
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.elementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void No_ControlTypeArray()
        {
            Assert.AreEqual(
                false,
                getClass().elementOfPossibleControlType(
                    null,
                    "Button"));
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.elementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void No_ControlType()
        {
            Assert.AreEqual(
                false,
                getClass().elementOfPossibleControlType(
                    (new string[]{ "Button" }),
                    null));
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.elementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void One_ControlType_That_Matches()
        {
            Assert.AreEqual(
                true,
                getClass().elementOfPossibleControlType(
                    (new string[]{ "Button" }),
                    "Button"));
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.elementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void One_ControlType_That_DoesNot_Match()
        {
            Assert.AreEqual(
                false,
                getClass().elementOfPossibleControlType(
                    (new string[]{ "Button" }),
                    "CheckBox"));
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.elementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void Three_ControlType_That_Match()
        {
            Assert.AreEqual(
                true,
                getClass().elementOfPossibleControlType(
                    (new string[]{ "TreeItem", "Button", "Edit" }),
                    "Button"));
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.elementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void Three_ControlType_That_DonT_Match()
        {
            Assert.AreEqual(
                false,
                getClass().elementOfPossibleControlType(
                    (new string[]{ "TreeItem", "ComboBox", "Edit" }),
                    "Button"));
        }
    }
}
