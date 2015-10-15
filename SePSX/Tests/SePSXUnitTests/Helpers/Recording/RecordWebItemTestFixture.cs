/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/4/2012
 * Time: 12:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Recording
{
    using MbUnit.Framework;
    //using NUnit.Framework;
    using SePSX;
    using PSTestLib;
    using OpenQA.Selenium;
    using System.Drawing;
    
    /// <summary>
    /// Description of RecordWebItemTestFixture.
    /// </summary>
    [TestFixture]
    public class RecordWebItemTestFixture
    {
        public RecordWebItemTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            //MiddleLevelCode.PrepareRunspace();
            //Recorder.recordingCollection.Clear();
        }
        
        private IRecordedCodeSequence generateWebItem(
            IRecordedCodeSequence codeSequence,
            IWebElement webElement,
            RecordedWebElement recordingItem)
        {
            IRecordedCodeSequence result =
                Recorder.RecordWebItem(
                    (new TranscriptCmdletBase()),
                    codeSequence,
                    webElement,
                    recordingItem);
            return result;
        }
        
        [Test] //[Test(Description="The Recorder.RecordWebItem test")]
        [Category("Fast")]
        public void CodeSequence_Null_RecordWebItem_Null()
        {
            IRecordedCodeSequence result = null;
            IRecordedCodeSequence codeSequence = null;
            int expectedResult = (new RecordedCodeSequence()).Items.Count;
            IWebElement element = null;
            result = 
                generateWebItem(
                    codeSequence,
                    element,
                    (new RecordedWebElement()));
            Assert.AreEqual(expectedResult, result.Items.Count);
        }
        
        [Test] //[Test(Description="The Recorder.RecordWebItem test")]
        [Category("Fast")]
        public void RecordWebItem_Null()
        {
            IRecordedCodeSequence result = null;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            IRecordedCodeSequence expectedResult = codeSequence;
            IWebElement element = null;
            result = 
                generateWebItem(
                    codeSequence,
                    element,
                    (new RecordedWebElement()));
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.RecordWebItem test")]
        [Category("Fast")]
        public void RecordWebItem_Displayed()
        {
            IRecordedCodeSequence result = null;
            bool expectedResult = true;
            IRecordedCodeSequence codeSequence = null;
            IWebElement element = new FakeWebElement("a", "text abc", true, false, false);
            result = 
                generateWebItem(
                    codeSequence,
                    element,
                    (new RecordedWebElement()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedElementItem)result.Items[result.Items.Count - 1]).UserData["Displayed"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordWebItem test")]
        [Category("Fast")]
        public void RecordWebItem_Enabled()
        {
            IRecordedCodeSequence result = null;
            bool expectedResult = true;
            IRecordedCodeSequence codeSequence = null;
            IWebElement element = new FakeWebElement("a", "text abc", false, true, false);
            result = 
                generateWebItem(
                    codeSequence,
                    element,
                    (new RecordedWebElement()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedElementItem)result.Items[result.Items.Count - 1]).UserData["Enabled"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordWebItem test")]
        [Category("Fast")]
        public void RecordWebItem_Location()
        {
            IRecordedCodeSequence result = null;
            Point expectedResult = new Point(1, 1);
            IRecordedCodeSequence codeSequence = null;
            IWebElement element = new FakeWebElement("a", "text abc", expectedResult, new Size(expectedResult));
            result = 
                generateWebItem(
                    codeSequence,
                    element,
                    (new RecordedWebElement()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedElementItem)result.Items[result.Items.Count - 1]).UserData["Location"]);
        }
        
        
        
        [Test] //[Test(Description="The Recorder.RecordWebItem test")]
        [Category("Fast")]
        public void RecordWebItem_Selected()
        {
            IRecordedCodeSequence result = null;
            bool expectedResult = true;
            IRecordedCodeSequence codeSequence = null;
            IWebElement element = new FakeWebElement("a", "text abc", false, false, true);
            result = 
                generateWebItem(
                    codeSequence,
                    element,
                    (new RecordedWebElement()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedElementItem)result.Items[result.Items.Count - 1]).UserData["Selected"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordWebItem test")]
        [Category("Fast")]
        public void RecordWebItem_Size()
        {
            IRecordedCodeSequence result = null;
            Size expectedResult = new Size(1, 1);
            IRecordedCodeSequence codeSequence = null;
            IWebElement element = new FakeWebElement("a", "text abc", new Point(2, 2), expectedResult);
            result = 
                generateWebItem(
                    codeSequence,
                    element,
                    (new RecordedWebElement()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedElementItem)result.Items[result.Items.Count - 1]).UserData["Size"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordWebItem test")]
        [Category("Fast")]
        public void RecordWebItem_TagName()
        {
            IRecordedCodeSequence result = null;
            string expectedResult = "button";
            IRecordedCodeSequence codeSequence = null;
            IWebElement element = new FakeWebElement(expectedResult, "OK");
            result = 
                generateWebItem(
                    codeSequence,
                    element,
                    (new RecordedWebElement()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedElementItem)result.Items[result.Items.Count - 1]).UserData["TagName"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordWebItem test")]
        [Category("Fast")]
        public void RecordWebItem_Text()
        {
            IRecordedCodeSequence result = null;
            string expectedResult = "OK";
            IRecordedCodeSequence codeSequence = null;
            IWebElement element = new FakeWebElement("button", expectedResult);
            result = 
                generateWebItem(
                    codeSequence,
                    element,
                    (new RecordedWebElement()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedElementItem)result.Items[result.Items.Count - 1]).UserData["Text"]);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            Settings.CleanUpRecordingCollection();
        }
    }
}
