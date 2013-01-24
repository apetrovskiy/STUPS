/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/25/2012
 * Time: 12:54 PM
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
    /// Description of CheckCodeSequenceNoveltyTestFixture.
    /// </summary>
    [TestFixture]
    public class CheckCodeSequenceNoveltyTestFixture
    {
        public CheckCodeSequenceNoveltyTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
        }
        
        [Test] //[Test(Description="The Recorder.CheckCodeSequenceNovelty test")]
        [Category("Fast")]
        public void CheckCodeSequenceNovelty_RecordingCollection_Null_CodeSequence_Null()
        {
            bool result = false;
            bool expectedResult = false;
            TranscriptCmdletBase cmdlet = new TranscriptCmdletBase();
            Recorder.recordingCollection = null;
            IRecordedCodeSequence codeSequence = null;
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.recordingCollection,
                    codeSequence);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.CheckCodeSequenceNovelty test")]
        [Category("Fast")]
        public void CheckCodeSequenceNovelty_RecordingCollection_Null_CodeSequence_Empty()
        {
            bool result = false;
            bool expectedResult = false;
            TranscriptCmdletBase cmdlet = new TranscriptCmdletBase();
            Recorder.recordingCollection = null;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.recordingCollection,
                    codeSequence);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.CheckCodeSequenceNovelty test")]
        [Category("Fast")]
        public void CheckCodeSequenceNovelty_RecordingCollection_Null_CodeSequence_Non_Empty()
        {
            bool result = false;
            bool expectedResult = false;
            TranscriptCmdletBase cmdlet = new TranscriptCmdletBase();
            Recorder.recordingCollection = null;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            codeSequence.Items.Add((new RecordedAction()));
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.recordingCollection,
                    codeSequence);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.CheckCodeSequenceNovelty test")]
        [Category("Fast")]
        public void CheckCodeSequenceNovelty_CodeSequence_Null()
        {
            bool result = false;
            bool expectedResult = false;
            TranscriptCmdletBase cmdlet = new TranscriptCmdletBase();
            Recorder.recordingCollection =
                new System.Collections.Generic.List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence = null;
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.recordingCollection,
                    codeSequence);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.CheckCodeSequenceNovelty test")]
        [Category("Fast")]
        public void CheckCodeSequenceNovelty_RecordingCollection_Empty_CodeSequence_Empty()
        {
            bool result = false;
            bool expectedResult = false;
            TranscriptCmdletBase cmdlet = new TranscriptCmdletBase();
            Recorder.recordingCollection =
                new System.Collections.Generic.List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.recordingCollection,
                    codeSequence);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.CheckCodeSequenceNovelty test")]
        [Category("Fast")]
        public void CheckCodeSequenceNovelty_RecordingCollection_Empty_CodeSequence_Non_Empty()
        {
            bool result = false;
            bool expectedResult = true;
            TranscriptCmdletBase cmdlet = new TranscriptCmdletBase();
            Recorder.recordingCollection =
                new System.Collections.Generic.List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            codeSequence.Items.Add((new RecordedAction()));
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.recordingCollection,
                    codeSequence);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.CheckCodeSequenceNovelty test")]
        [Category("Fast")]
        public void CheckCodeSequenceNovelty_CodeSequence_Unique()
        {
            bool result = false;
            bool expectedResult = true;
            TranscriptCmdletBase cmdlet = new TranscriptCmdletBase();
            Recorder.recordingCollection =
                new System.Collections.Generic.List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            RecordedWebElement webElement = new RecordedWebElement();
            webElement.TagName = "button";
            codeSequence.Items.Add(webElement);
            RecordedAction action = new RecordedAction();
            action.UserData.Add("code", Recorder.codeGenElementClick);
            codeSequence.Items.Add(action);
            
            Recorder.recordingCollection.Add(codeSequence);
            
            // a new code sequence
            codeSequence = new RecordedCodeSequence();
            webElement = new RecordedWebElement();
            webElement.TagName = "button";
            codeSequence.Items.Add(webElement);
            action = new RecordedAction();
            action.UserData.Add("code", Recorder.codeGenIdParameter + "aaaa'");
            codeSequence.Items.Add(action);
            
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.recordingCollection,
                    codeSequence);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.CheckCodeSequenceNovelty test")]
        [Category("Fast")]
        public void CheckCodeSequenceNovelty_CodeSequence_Duplicated()
        {
            bool result = false;
            bool expectedResult = false;
            TranscriptCmdletBase cmdlet = new TranscriptCmdletBase();
            Recorder.recordingCollection =
                new System.Collections.Generic.List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            RecordedWebElement webElement = new RecordedWebElement();
            webElement.TagName = "button";
            codeSequence.Items.Add(webElement);
            RecordedAction action = new RecordedAction();
            action.UserData.Add("code", Recorder.codeGenElementClick);
            codeSequence.Items.Add(action);
            
            Recorder.recordingCollection.Add(codeSequence);
            
            // a new code sequence
            codeSequence = new RecordedCodeSequence();
            webElement = new RecordedWebElement();
            webElement.TagName = "button";
            codeSequence.Items.Add(webElement);
            action = new RecordedAction();
            action.UserData.Add("code", Recorder.codeGenElementClick);
            codeSequence.Items.Add(action);
            
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.recordingCollection,
                    codeSequence);
            Assert.AreEqual(expectedResult, result);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            Settings.CleanUpRecordingCollection();
        }
    }
}
