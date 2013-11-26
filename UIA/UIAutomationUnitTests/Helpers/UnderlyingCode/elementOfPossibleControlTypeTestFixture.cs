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
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of elementOfPossibleControlTypeTestFixture.
    /// </summary>
    [TestFixture]
    public class elementOfPossibleControlTypeTestFixture
    {
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
        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void Nothing_to_compare()
        {
            Assert.AreEqual(
                false,
                getClass().ElementOfPossibleControlType(
                    null,
                    null));
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void No_ControlTypeArray()
        {
            Assert.AreEqual(
                false,
                getClass().ElementOfPossibleControlType(
                    null,
                    "Button"));
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void No_ControlType()
        {
            Assert.AreEqual(
                false,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "Button" }),
                    null));
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void One_ControlType_That_Matches()
        {
            Assert.AreEqual(
                true,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "Button" }),
                    "Button"));
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void One_ControlType_That_DoesNot_Match()
        {
            Assert.AreEqual(
                false,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "Button" }),
                    "CheckBox"));
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void Three_ControlType_That_Match()
        {
            Assert.AreEqual(
                true,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "TreeItem", "Button", "Edit" }),
                    "Button"));
        }
        
        [Test]
        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
        [Category("Fast")]
        public void Three_ControlType_That_DonT_Match()
        {
            Assert.AreEqual(
                false,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "TreeItem", "ComboBox", "Edit" }),
                    "Button"));
        }
    }
}
