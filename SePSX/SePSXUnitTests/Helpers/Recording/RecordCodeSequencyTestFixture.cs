/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/24/2012
 * Time: 3:47 AM
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
    using System.Drawing;
    using System.Collections.ObjectModel;
    
    /// <summary>
    /// Description of RecordCodeSequencyTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Recording test")]
    public class RecordCodeSequencyTestFixture
    {
        public RecordCodeSequencyTestFixture()
        {
        }
        
        
        [SetUp]
        public void PrepareRunspace()
        {
        }
        
        private void generateSequence(
            TranscriptCmdletBase cmdlet,
            System.Collections.Generic.List<IRecordedCodeSequence> recordingsCollection,
            IRecordedCodeSequence codeSequence,
            IWebElement firstElement,
            IWebElement secondElement)
        {
            Recorder.recordingCollection = recordingsCollection;

            codeSequence = 
                Recorder.RecordCodeSequence(
                    cmdlet,
                    Recorder.recordingCollection,
                    firstElement,
                    codeSequence);

            if (null != secondElement) {
                codeSequence = 
                    Recorder.RecordCodeSequence(
                        cmdlet,
                        Recorder.recordingCollection,
                        secondElement,
                        codeSequence);
            }
            
            Recorder.StoreCodeSequenceInCollection(
                cmdlet,
                Recorder.recordingCollection,
                codeSequence);
        }
        
        [Test] //[Test(Description="code sequence")]
        [Category("Fast")]
        public void RecordCodeSequency_Null_CodeSequence()
        {
            generateSequence(
                (new TranscriptCmdletBase()),
                (new System.Collections.Generic.List<IRecordedCodeSequence>()),
                null,
                null,
                null);

            // there should no codeSequence as there's nothing to put into
            Assert.AreEqual(
            	0,
                Recorder.recordingCollection.Count);
        }
        
        
        [Test] //[Test(Description="code sequence")]
        [Category("Fast")]
        public void RecordCodeSequency_Null_CodeSequence_and_Two_Records()
        {
            generateSequence(
                (new TranscriptCmdletBase()),
                (new System.Collections.Generic.List<IRecordedCodeSequence>()),
                null,
                (new FakeWebElement("button", string.Empty)),
                (new FakeWebElement("recclicked", string.Empty)));

            Assert.AreEqual(
                Recorder.codeGenGetElement, 
                ((RecordedWebElement)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
                    Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 2]).UserData["code"]);

            Assert.AreEqual(
                Recorder.codeGenElementClick, 
                ((RecordedAction)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
                    Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData["code"]);

        }
        
        [Test] //[Test(Description="code sequence")]
        [Category("Fast")]
        public void RecordCodeSequency_Not_Null_CodeSequence_and_Two_Records()
        {
            generateSequence(
                (new TranscriptCmdletBase()),
                (new System.Collections.Generic.List<IRecordedCodeSequence>()),
                (new RecordedCodeSequence()),
                (new FakeWebElement("button", string.Empty)),
                (new FakeWebElement("recclicked", string.Empty)));

            Assert.AreEqual(
                Recorder.codeGenElementClick, 
                ((RecordedAction)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
                    Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData["code"]);
        }
        
        [Test] //[Test(Description="code sequence")]
        [Category("Fast")]
        public void RecordCodeSequency_Non_Empty_CodeSequence_WebElement()
        {
            IRecordedCodeSequence codeSequence =
                new RecordedCodeSequence();
            codeSequence.Items.Add((new RecordedAction()));
            generateSequence(
                (new TranscriptCmdletBase()),
                (new System.Collections.Generic.List<IRecordedCodeSequence>()),
                codeSequence,
                (new FakeWebElement("button", string.Empty)),
                null);
            
            Assert.AreEqual(
                Recorder.codeGenGetElement, 
                ((RecordedWebElement)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
                    Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData["code"]); // ?
        }
        
        [Test] //[Test(Description="code sequence")]
        [Category("Fast")]
        public void RecordCodeSequency_Non_Empty_CodeSequence_RecordedAction()
        {
            IRecordedCodeSequence codeSequence =
                new RecordedCodeSequence();
            codeSequence.Items.Add((new RecordedAction()));
            generateSequence(
                (new TranscriptCmdletBase()),
                (new System.Collections.Generic.List<IRecordedCodeSequence>()),
                codeSequence,
                (new FakeWebElement("recclicked", string.Empty)),
                null);

            Assert.AreEqual(
                Recorder.codeGenElementClick, 
                ((RecordedAction)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[codeSequence.Items.Count - 1]).UserData["code"]);  // ?
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            Settings.CleanUpRecordingCollection();
        }
    }
}
