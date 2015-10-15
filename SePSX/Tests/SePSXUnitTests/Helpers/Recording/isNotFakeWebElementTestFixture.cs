/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/4/2012
 * Time: 12:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Recording
{
    using MbUnit.Framework;
    //using NUnit.Framework;
    using SePSX;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of isNotFakeWebElementTestFixture.
    /// </summary>
    [TestFixture]
    public class isNotFakeWebElementTestFixture
    {
        public isNotFakeWebElementTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
        }
        
        [Test] //[Test(Description="The Recorder.isNotFakeWebElement test")]
        [Category("Fast")]
        public void isNotFakeWebElement_Null()
        {
            bool result = false;
            bool expectedResult = false;
            IWebElement element = null;
            result = 
                Recorder.IsNotFakeWebElement(
                    element);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.isNotFakeWebElement test")]
        [Category("Fast")]
        public void isNotFakeWebElement_WebElement()
        {
            bool result = false;
            bool expectedResult = true;
            IWebElement element = new FakeWebElement("a", "text");
            result = 
                Recorder.IsNotFakeWebElement(
                    element);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.isNotFakeWebElement test")]
        [Category("Fast")]
        public void isNotFakeWebElement_ElementClicked()
        {
            bool result = false;
            bool expectedResult = false;
            IWebElement element = new FakeWebElement(Recorder.ConstAuxElementClicked, "");
            result = 
                Recorder.IsNotFakeWebElement(
                    element);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.isNotFakeWebElement test")]
        [Category("Fast")]
        public void isNotFakeWebElement_ElementData()
        {
            bool result = false;
            bool expectedResult = false;
            IWebElement element = new FakeWebElement(Recorder.ConstAuxElementData, "");
            result = 
                Recorder.IsNotFakeWebElement(
                    element);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.isNotFakeWebElement test")]
        [Category("Fast")]
        public void isNotFakeWebElement_ElementSelected()
        {
            bool result = false;
            bool expectedResult = false;
            IWebElement element = new FakeWebElement(Recorder.ConstAuxElementSelected, "");
            result = 
                Recorder.IsNotFakeWebElement(
                    element);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.isNotFakeWebElement test")]
        [Category("Fast")]
        public void isNotFakeWebElement_ElementTypedIn()
        {
            bool result = false;
            bool expectedResult = false;
            IWebElement element = new FakeWebElement(Recorder.ConstAuxElementTypedIn, "");
            result = 
                Recorder.IsNotFakeWebElement(
                    element);
            Assert.AreEqual(expectedResult, result);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            Settings.CleanUpRecordingCollection();
        }
    }
}
