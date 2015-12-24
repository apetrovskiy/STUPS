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
    using MbUnit.Framework;using Xunit;using NUnit.Framework;
    
    /// <summary>
    /// Description of elementOfPossibleControlTypeTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class elementOfPossibleControlTypeTestFixture
    {
        public elementOfPossibleControlTypeTestFixture()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        private GetControlCollectionCmdletBase getClass()
        {
            return new GetControlCollectionCmdletBase();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
//        [Category("Fast")]
        public void Nothing_to_compare()
        {
            MbUnit.Framework.Assert.AreEqual(
                false,
                getClass().ElementOfPossibleControlType(
                    null,
                    null));
            
            Xunit.Assert.Equal(
                false,
                getClass().ElementOfPossibleControlType(
                    null,
                    null));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
//        [Category("Fast")]
        public void No_ControlTypeArray()
        {
            MbUnit.Framework.Assert.AreEqual(
                false,
                getClass().ElementOfPossibleControlType(
                    null,
                    "Button"));
            
            Xunit.Assert.Equal(
                false,
                getClass().ElementOfPossibleControlType(
                    null,
                    "Button"));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
//        [Category("Fast")]
        public void No_ControlType()
        {
            MbUnit.Framework.Assert.AreEqual(
                false,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "Button" }),
                    null));
            
            Xunit.Assert.Equal(
                false,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "Button" }),
                    null));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
//        [Category("Fast")]
        public void One_ControlType_That_Matches()
        {
            MbUnit.Framework.Assert.AreEqual(
                true,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "Button" }),
                    "Button"));
            
            Xunit.Assert.Equal(
                true,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "Button" }),
                    "Button"));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
//        [Category("Fast")]
        public void One_ControlType_That_DoesNot_Match()
        {
            MbUnit.Framework.Assert.AreEqual(
                false,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "Button" }),
                    "CheckBox"));
            
            Xunit.Assert.Equal(
                false,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "Button" }),
                    "CheckBox"));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
//        [Category("Fast")]
        public void Three_ControlType_That_Match()
        {
            MbUnit.Framework.Assert.AreEqual(
                true,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "TreeItem", "Button", "Edit" }),
                    "Button"));
            
            Xunit.Assert.Equal(
                true,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "TreeItem", "Button", "Edit" }),
                    "Button"));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("GetControlCollectionCmdletBase.ElementOfPossibleControlType(string[], string)")]
//        [Category("Fast")]
        public void Three_ControlType_That_DonT_Match()
        {
            MbUnit.Framework.Assert.AreEqual(
                false,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "TreeItem", "ComboBox", "Edit" }),
                    "Button"));
            
            Xunit.Assert.Equal(
                false,
                getClass().ElementOfPossibleControlType(
                    (new[]{ "TreeItem", "ComboBox", "Edit" }),
                    "Button"));
        }
    }
}
