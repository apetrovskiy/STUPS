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
    using System;
    using MbUnit.Framework;
    //using NUnit.Framework;
    using SePSX;
    using PSTestLib;
    using OpenQA.Selenium;
//    using System.Drawing;
//    using System.Collections.ObjectModel;
    
    /// <summary>
    /// Description of RecordActionItemTestFixture.
    /// </summary>
    [TestFixture]
    public class RecordActionItemTestFixture
    {
        public RecordActionItemTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
        }
        
        private IRecordedCodeSequence generateActionItem(
            IRecordedCodeSequence codeSequence,
            IWebElement webElement,
            RecordedAction recordingItem)
        {
            IRecordedCodeSequence result =
                Recorder.RecordActionItem(
                    (new TranscriptCmdletBase()),
                    codeSequence,
                    webElement,
                    recordingItem);
            return result;
        }
        
        [Test] //[Test(Description="The Recorder.RecordActionItem test")]
        [Category("Fast")]
        public void CodeSequence_Null_RecordActionItem_Null()
        {
            IRecordedCodeSequence result = null;
            IRecordedCodeSequence codeSequence = null;
            int expectedResult = (new RecordedCodeSequence()).Items.Count;
            IWebElement element = null;
            result = 
                generateActionItem(
                    codeSequence,
                    element,
                    (new RecordedAction()));
            Assert.AreEqual(expectedResult, result.Items.Count);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActionItem test")]
        [Category("Fast")]
        public void RecordActionItem_Null()
        {
            IRecordedCodeSequence result = null;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            IRecordedCodeSequence expectedResult = codeSequence;
            IWebElement element = null;
            result = 
                generateActionItem(
                    codeSequence,
                    element,
                    (new RecordedAction()));
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActionItem test")]
        [Category("Fast")]
        public void RecordActionItem_Click()
        {
            IRecordedCodeSequence result = null;
            string expectedResult = Recorder.codeGenElementClick;
            IRecordedCodeSequence codeSequence = null;
            IWebElement element = new FakeWebElement(Recorder.constAuxElementClicked, "");
            result = 
                generateActionItem(
                    codeSequence,
                    element,
                    (new RecordedAction()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedActionItem)result.Items[result.Items.Count - 1]).UserData["code"]);
        }
        
#region temporarily commented
//        [Test] //[Test(Description="The Recorder.RecordActionItem test")]
//        [Category("Fast")]
//        public void RecordActionItem_TypedIn()
//        {
//            IRecordedCodeSequence result = null;
//            string expectedResult = Recorder.codeGen;
//            IRecordedCodeSequence codeSequence = null;
//            IWebElement element = new WebElementFromSelenium(Recorder.constAuxElementTypedIn, "");
//            result = 
//                generateWebItem(
//                    codeSequence,
//                    element,
//                    (new RecordedAction()));
//            Assert.AreEqual(
//                expectedResult, 
//                ((IRecordedActionItem)result.Items[result.Items.Count - 1]).UserData["code"]);
//        }
//
//        [Test] //[Test(Description="The Recorder.RecordActionItem test")]
//        [Category("Fast")]
//        public void RecordActionItem_Selected()
//        {
//            IRecordedCodeSequence result = null;
//            string expectedResult = Recorder.codeGen;
//            IRecordedCodeSequence codeSequence = null;
//            IWebElement element = new WebElementFromSelenium(Recorder.constAuxElementSelected, "");
//            result = 
//                generateWebItem(
//                    codeSequence,
//                    element,
//                    (new RecordedAction()));
//            Assert.AreEqual(
//                expectedResult, 
//                ((IRecordedActionItem)result.Items[result.Items.Count - 1]).UserData["code"]);
//        }
//
//        [Test] //[Test(Description="The Recorder.RecordActionItem test")]
//        [Category("Fast")]
//        public void RecordActionItem_Data()
//        {
//            IRecordedCodeSequence result = null;
//            string expectedResult = Recorder.codeGen;
//            IRecordedCodeSequence codeSequence = null;
//            IWebElement element = new WebElementFromSelenium(Recorder.constAuxElementData, "");
//            result = 
//                generateWebItem(
//                    codeSequence,
//                    element,
//                    (new RecordedAction()));
//            Assert.AreEqual(
//                expectedResult, 
//                ((IRecordedActionItem)result.Items[result.Items.Count - 1]).UserData["code"]);
//        }
#endregion temporarily commented
        
        [Test] //[Test(Description="The Recorder.RecordActionItem test")]
        [Category("Fast")]
        public void CodeSequence_Empty()
        {
            IRecordedCodeSequence result = null;
            string expectedResult = Recorder.codeGenElementClick;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            IWebElement element = new FakeWebElement(Recorder.constAuxElementClicked, "");
            result = 
                generateActionItem(
                    codeSequence,
                    element,
                    (new RecordedAction()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedActionItem)result.Items[result.Items.Count - 1]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActionItem test")]
        [Category("Fast")]
        public void CodeSequence_with_WebElement()
        {
            IRecordedCodeSequence result = null;
            string expectedResult = Recorder.codeGenElementClick;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            IWebElement alreadyHere = new FakeWebElement("input", "aaa");
            IWebElement element = new FakeWebElement(Recorder.constAuxElementClicked, "");
            result = 
                generateActionItem(
                    codeSequence,
                    element,
                    (new RecordedAction()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedActionItem)result.Items[result.Items.Count - 1]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActionItem test")]
        [Category("Fast")]
        public void CodeSequence_with_different_RecordedAction()
        {
            IRecordedCodeSequence result = null;
            string expectedResult = Recorder.codeGenElementClick;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            IWebElement alreadyHere = new FakeWebElement(Recorder.constAuxElementSelected, "aaa");
            IWebElement element = new FakeWebElement(Recorder.constAuxElementClicked, "");
            result = 
                generateActionItem(
                    codeSequence,
                    element,
                    (new RecordedAction()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedActionItem)result.Items[result.Items.Count - 1]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActionItem test")]
        [Category("Fast")]
        public void CodeSequence_with_of_the_same_type_RecordedAction()
        {
            IRecordedCodeSequence result = null;
            string expectedResult = Recorder.codeGenElementClick;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            IWebElement alreadyHere = new FakeWebElement(Recorder.constAuxElementClicked, "aaa");
            IWebElement element = new FakeWebElement(Recorder.constAuxElementClicked, "");
            result = 
                generateActionItem(
                    codeSequence,
                    element,
                    (new RecordedAction()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedActionItem)result.Items[result.Items.Count - 1]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActionItem test")]
        [Category("Fast")]
        public void CodeSequence_with_the_same_RecordedAction()
        {
            IRecordedCodeSequence result = null;
            string expectedResult = Recorder.codeGenElementClick;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            IWebElement alreadyHere = new FakeWebElement(Recorder.constAuxElementClicked, "aaa");
            IWebElement element = new FakeWebElement(Recorder.constAuxElementClicked, "aaa");
            result = 
                generateActionItem(
                    codeSequence,
                    element,
                    (new RecordedAction()));
            Assert.AreEqual(
                expectedResult, 
                ((IRecordedActionItem)result.Items[result.Items.Count - 1]).UserData["code"]);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            Settings.CleanUpRecordingCollection();
        }
    }
}
