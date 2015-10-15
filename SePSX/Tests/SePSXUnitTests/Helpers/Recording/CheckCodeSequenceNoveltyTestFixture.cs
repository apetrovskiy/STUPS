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
    using MbUnit.Framework;
    //using NUnit.Framework;
    using SePSX;
    using PSTestLib;

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
            Recorder.RecordingCollection = null;
            IRecordedCodeSequence codeSequence = null;
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.RecordingCollection,
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
            Recorder.RecordingCollection = null;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.RecordingCollection,
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
            Recorder.RecordingCollection = null;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            codeSequence.Items.Add((new RecordedAction()));
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.RecordingCollection,
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
            Recorder.RecordingCollection =
                new System.Collections.Generic.List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence = null;
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.RecordingCollection,
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
            Recorder.RecordingCollection =
                new System.Collections.Generic.List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.RecordingCollection,
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
            Recorder.RecordingCollection =
                new System.Collections.Generic.List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            codeSequence.Items.Add((new RecordedAction()));
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.RecordingCollection,
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
            Recorder.RecordingCollection =
                new System.Collections.Generic.List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            RecordedWebElement webElement = new RecordedWebElement();
            webElement.TagName = "button";
            codeSequence.Items.Add(webElement);
            RecordedAction action = new RecordedAction();
            action.UserData.Add("code", Recorder.CodeGenElementClick);
            codeSequence.Items.Add(action);
            
            Recorder.RecordingCollection.Add(codeSequence);
            
            // a new code sequence
            codeSequence = new RecordedCodeSequence();
            webElement = new RecordedWebElement();
            webElement.TagName = "button";
            codeSequence.Items.Add(webElement);
            action = new RecordedAction();
            action.UserData.Add("code", Recorder.CodeGenIdParameter + "aaaa'");
            codeSequence.Items.Add(action);
            
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.RecordingCollection,
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
            Recorder.RecordingCollection =
                new System.Collections.Generic.List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            RecordedWebElement webElement = new RecordedWebElement();
            webElement.TagName = "button";
            codeSequence.Items.Add(webElement);
            RecordedAction action = new RecordedAction();
            action.UserData.Add("code", Recorder.CodeGenElementClick);
            codeSequence.Items.Add(action);
            
            Recorder.RecordingCollection.Add(codeSequence);
            
            // a new code sequence
            codeSequence = new RecordedCodeSequence();
            webElement = new RecordedWebElement();
            webElement.TagName = "button";
            codeSequence.Items.Add(webElement);
            action = new RecordedAction();
            action.UserData.Add("code", Recorder.CodeGenElementClick);
            codeSequence.Items.Add(action);
            
            result = 
                Recorder.CheckCodeSequenceNovelty(
                    cmdlet,
                    Recorder.RecordingCollection,
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
