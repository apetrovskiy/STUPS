/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/4/2012
 * Time: 12:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Recording
{
    using MbUnit.Framework;
    //using NUnit.Framework;
    using SePSX;
    using PSTestLib;
//    using OpenQA.Selenium;
//    using System.Drawing;
//    using System.Collections.ObjectModel;
    
    /// <summary>
    /// Description of StoreCodeSequenceInCollectionTestFixture.
    /// </summary>
    [TestFixture]
    public class StoreCodeSequenceInCollectionTestFixture
    {
        public StoreCodeSequenceInCollectionTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
        }
        
//        internal static void StoreCodeSequenceInCollection(
//            TranscriptCmdletBase cmdlet,
//            System.Collections.Generic.List<IRecordedCodeSequence> recordings,
//            IRecordedCodeSequence codeSequence)
//        {
//            cmdlet.WriteVerbose(cmdlet, "StoreCodeSequenceInCollection");
//            if (null != recordings) { //  && 0 < recordings.Count) { // :)
//
//                if (CheckCodeSequenceNovelty(cmdlet, recordings, codeSequence)) {
//
//                    cmdlet.WriteVerbose(cmdlet, "adding code sequence to the collection");
//                    recordings.Add(codeSequence);
//                    
//                }
//            } 
//
//        }
        
        
        [Test] //[Test(Description="The Recorder.StoreCodeSequenceInCollection test")]
        [Category("Fast")]
        [Ignore]
        public void Collection_Null()
        {
            System.Collections.Generic.List<IRecordedCodeSequence> recordings = null;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            
            Recorder.StoreCodeSequenceInCollection(
                (new TranscriptCmdletBase()),
                recordings,
                codeSequence);
            

            //Assert.AreEqual(expectedResult, result.Items.Count);
//            Assert.AreEqual(
//                expectedResult,
//                ((RecordedData)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
//                    Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData["code"]);
            Assert.Fail("not implemented");
        }
        
        [Test] //[Test(Description="The Recorder.StoreCodeSequenceInCollection test")]
        [Category("Fast")]
        [Ignore]
        public void CodeSequence_Null()
        {
            System.Collections.Generic.List<IRecordedCodeSequence> recordings =
                new System.Collections.Generic.List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence = null;
            
            Recorder.StoreCodeSequenceInCollection(
                (new TranscriptCmdletBase()),
                recordings,
                codeSequence);
            
            

            //Assert.AreEqual(expectedResult, result.Items.Count);
//            Assert.AreEqual(
//                expectedResult,
//                ((RecordedData)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
//                    Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData["code"]);
            Assert.Fail("not implemented");
        }
        
        [Test] //[Test(Description="The Recorder.StoreCodeSequenceInCollection test")]
        [Category("Fast")]
        [Ignore]
        public void CodeSequence_Not_Null()
        {
            System.Collections.Generic.List<IRecordedCodeSequence> recordings =
                new System.Collections.Generic.List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence =
                new RecordedCodeSequence();
            
            Recorder.StoreCodeSequenceInCollection(
                (new TranscriptCmdletBase()),
                recordings,
                codeSequence);
            
            

            //Assert.AreEqual(expectedResult, result.Items.Count);
//            Assert.AreEqual(
//                expectedResult,
//                ((RecordedData)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
//                    Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData["code"]);
            Assert.Fail("not implemented");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            Settings.CleanUpRecordingCollection();
        }
    }
}
